using AutoFac.Mvc.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac.Mvc.Service
{
    public class Student : IStudent
    {
        public string  SayHi()
        {
            return "我是一名学生";
        }
    }
}
