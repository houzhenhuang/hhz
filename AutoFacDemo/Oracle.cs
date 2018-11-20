using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacDemo
{
    public class Oracle : IDataSource
    {
        public void GetData()
        {
            Console.WriteLine("通过ORACLE获取数据");
        }
    }
}
