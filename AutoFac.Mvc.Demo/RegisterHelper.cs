using AutoFac.Mvc.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFac.Mvc.Demo
{
    public class RegisterHelper
    {
        //ITeacher Teacher { get; set; }
        public void Show()
        {
            ITeacher Teacher = DependencyResolver.Current.GetService<ITeacher>();
            Teacher.SayHi();
        }
    }
}