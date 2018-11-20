using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PolicyBasedAuthorization.Services.Requirements.MinimumAgePolicy;
using PolicyBasedAuthorization.Services.Requirements.PermissionPolicy;

namespace PolicyBasedAuthorization
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(options=> {
                //基于角色的策略
                options.AddPolicy("RequireRole", policy => policy.RequireRole(ClaimTypes.Role, "admin"));
                //基于Claims的策略
                options.AddPolicy("RequireClaim", policy=>policy.RequireClaim(ClaimTypes.Country,"中国"));
                //基于用户名的策略
                options.AddPolicy("RequireUserName", policy => policy.RequireUserName("黄厚镇"));
                //自定义的策略
                options.AddPolicy("MinimumAgeRequirement", policy=>policy.Requirements.Add(new MinimumAgeRequirement(22)));


                var userPermissions = new List<UserPermission> {
                    new UserPermission {  Url="/", UserName="hhz"},
                    new UserPermission {  Url="/Home/Index", UserName="hhz"},
                    new UserPermission {  Url="/Home/PermissionRequirement", UserName="hhz"},
                    new UserPermission {  Url="/", UserName="test"},
                };
                options.AddPolicy("PermissionRequirement", policy => policy.Requirements.Add(new PermissionRequirement("/Account/AccessDenied", userPermissions)));

            })
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
