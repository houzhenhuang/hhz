using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.PermissionMiddleware
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly PermissionMiddlewareOptions _options;

        internal readonly List<UserPermission> _userPermissions;

        public PermissionMiddleware(RequestDelegate next, PermissionMiddlewareOptions options)
        {
            this._next = next;
            this._options = options;
            this._userPermissions = options.UserPerssions;
        }

        public Task Invoke(HttpContext context)
        {
            var isAuthenticated = context.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                var questUrl = context.Request.Path.Value.ToLower();
                if (_userPermissions.GroupBy(u => u.Url).Where(u => u.Key.ToLower() == questUrl).Count() > 0)//为了防止那些没有分配给用户的url无限重定向
                {
                    var userName = context.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Sid).Value;

                    if (_userPermissions.Where(u => u.UserName.ToLower() == userName.ToLower() && u.Url.ToLower() == questUrl).Count() > 0)
                    {
                        return this._next(context);
                    }
                    else
                    {
                        //无权限跳转到拒绝页面
                        context.Response.Redirect(_options.NoPermissionAction);
                    }
                }
            }
            return this._next(context);
        }
    }
}
