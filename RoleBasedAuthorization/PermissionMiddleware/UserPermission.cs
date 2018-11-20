﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoleBasedAuthorization.PermissionMiddleware
{
    public class UserPermission
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 请求Url
        /// </summary>
        public string Url { get; set; }
    }
}