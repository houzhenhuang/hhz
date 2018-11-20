using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacDemo
{
    public class Sqlserver : IDataSource
    {
        public void GetData()
        {
            Console.WriteLine("通过SQLSERVER获取数据");
        }
    }
}
