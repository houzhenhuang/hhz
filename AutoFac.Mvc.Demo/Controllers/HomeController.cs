using AutoFac.Mvc.Demo.Core;
using AutoFac.Mvc.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFac.Mvc.Demo.Controllers
{
    public class HomeController : Controller
    {

        public ITeacher TeacherService { get; set; }
        //private  ITeacher TeacherService;
        //public HomeController(ITeacher teacher)
        //{
        //    this.TeacherService = teacher;
        //}
        // GET: Home
        public ActionResult Index()
        {
            string msg = TeacherService.SayHi();
            new RegisterHelper().Show();
            return Content(msg);
        }
        [HttpGet]
        public ActionResult TestJsonDate()
        {
            return View();
        }
        [HttpPost]
        public JsonResult TestJsonDate(FormCollection fc)
        {
            var data = new { birthday = DateTime.Now };
            return new CustomJsonResult()
            {
                Data = data,
                FormateStr = "yyyy-MM-dd"
            };
        }
    }
}