using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacDemo
{
    public interface IDataSource
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        void  GetData();
    }
}
