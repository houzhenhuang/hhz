using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 类型创建
            {
                //var builder = new ContainerBuilder();//创建一个容器
                //builder.RegisterType<DataSourceManager>();
                ////builder.RegisterType(typeof(DataSourceManager));
                //builder.RegisterType<Sqlserver>().As<IDataSource>();
                ////builder.RegisterType(typeof(Sqlserver)).As(typeof(IDataSource));
                //using (var container = builder.Build())
                //{
                //    var manager = container.Resolve<DataSourceManager>();
                //    //var manager = (DataSourceManager)container.Resolve(typeof(DataSourceManager));
                //    manager.GetData();
                //}
            }
            #endregion

            #region 实例创建
            {
                //var builder = new ContainerBuilder();
                //builder.RegisterInstance<DataSourceManager>(new DataSourceManager(new Sqlserver()));
                //using (var container = builder.Build())
                //{
                //    var manager = container.Resolve<DataSourceManager>();
                //    manager.GetData();
                //}
            }
            #endregion

            #region Lambda表达式创建
            {
                //var builder = new ContainerBuilder();
                //builder.RegisterType<Oracle>().As<IDataSource>();
                //builder.Register(c => new DataSourceManager(c.Resolve<IDataSource>()));
                //using (var container = builder.Build())
                //{
                //    var manager = container.Resolve<DataSourceManager>();
                //    manager.GetData();
                //}
            }
            #endregion

            #region 程序集创建
            {
                //var builder = new ContainerBuilder();
                //builder.RegisterType<Oracle>().As<IDataSource>();
                //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
                //using (var container = builder.Build())
                //{
                //    var manager = container.Resolve<DataSourceManager>();
                //    manager.GetData();
                //}
            }
            //属性注入
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<Oracle>().As<IDataSource>();
                builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                using (var container = builder.Build())
                {
                    var manager = container.Resolve<DataSourceManager>();
                    manager.GetData();
                }
            }
            #endregion

            Console.ReadLine();

        }
    }
    public interface IDataSourceManager
    {
        void GetData();
    }
    public class DataSourceManager : IDataSourceManager
    {
        //public IDataSource _ds { get; set; }
        IDataSource _ds;
        /// <summary>
        /// 根据传入的类型动态创建对象
        /// </summary>
        /// <param name="ds"></param>
        public DataSourceManager(IDataSource ds)
        {
            _ds = ds;
        }

        public void GetData()
        {
            _ds.GetData();
        }
    }

    public class DataSourceManager1 : IDataSourceManager
    {
        public IDataSource _ds { get; set; }
        //IDataSource _ds;
        /// <summary>
        /// 根据传入的类型动态创建对象
        /// </summary>
        /// <param name="ds"></param>
        //public DataSourceManager1(IDataSource ds)
        //{
        //    _ds = ds;
        //}

        public void GetData()
        {
            _ds.GetData();
        }
    }
}
