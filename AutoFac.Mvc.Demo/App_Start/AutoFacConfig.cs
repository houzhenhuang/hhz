using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace AutoFac.Mvc.Demo
{
    public class AutoFacConfig
    {
        public static void RegisterType()
        {
            var builder = new ContainerBuilder();
            //将MvcApplication类型所在的程序集中的Controllers进行注入
            //PropertiesAutowired:Controller中用到的实例可以进行属性注入
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            //将指定程序集中的类型进行接口实现
            builder.RegisterAssemblyTypes(Assembly.Load("AutoFac.Mvc.Service")).
                Where(p => !p.IsAbstract).
                PropertiesAutowired().
                AsImplementedInterfaces();//以接口方式进行注入,注入这些类的所有的公共接口作为服务

            //builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}