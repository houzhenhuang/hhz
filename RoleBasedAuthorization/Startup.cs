using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using RoleBasedAuthorization.PermissionMiddleware;
using Microsoft.AspNetCore.Http;

namespace RoleBasedAuthorization
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Denied");
                });

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

            app.UsePermission(new PermissionMiddlewareOptions()
            {
                LoginAction = new PathString("/Account/Login"),
                NoPermissionAction = new PathString("/Account/Denied"),
                //这个集合从数据库中查出所有用户的全部权限
                UserPerssions = new List<UserPermission>()
                 {
                    new UserPermission {  Url="/", UserName="test"},
                    new UserPermission {  Url="/Home/Index", UserName="test"},
                    new UserPermission {  Url="/", UserName="hhz"},
                    new UserPermission {  Url="/Home/Index", UserName="hhz"},
                    new UserPermission {  Url="/Home/About", UserName="hhz"},
                    new UserPermission {  Url="/Home/Contact", UserName="hhz"}

                 }
            });

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
