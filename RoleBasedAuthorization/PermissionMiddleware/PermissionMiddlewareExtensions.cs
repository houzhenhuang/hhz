using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.PermissionMiddleware
{
    public static class PermissionMiddlewareExtensions
    {
        public static IApplicationBuilder UsePermission(this IApplicationBuilder app, PermissionMiddlewareOptions options)
        {
            return app.UseMiddleware<PermissionMiddleware>(options);
        }
    }
}
