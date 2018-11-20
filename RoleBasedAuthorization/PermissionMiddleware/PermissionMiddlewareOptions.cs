using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.PermissionMiddleware
{
    public class PermissionMiddlewareOptions
    {
        /// <summary>
        /// 登录action
        /// </summary>
        public string LoginAction { get; set; }
        /// <summary>
        /// 无权限导航action
        /// </summary>
        public string NoPermissionAction { get; set; }

        /// <summary>
        /// 用户权限集合
        /// </summary>
        public List<UserPermission> UserPerssions { get; set; } = new List<UserPermission>();
    }
}
