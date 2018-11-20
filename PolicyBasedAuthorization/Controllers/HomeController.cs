using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyBasedAuthorization.Models;

namespace PolicyBasedAuthorization.Controllers
{
    
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "RequireRole")]
        public IActionResult RequireRole()
        {
            ViewData["Message"] = "Your require role page.";

            return View();
        }
        [Authorize(Policy = "RequireClaim")]
        public IActionResult RequireClaim()
        {
            ViewData["Message"] = "Your require claim page.";

            return View();
        }
        [Authorize(Policy = "RequireUserName")]
        public IActionResult RequireUserName()
        {
            ViewData["Message"] = "Your require username page.";

            return View();
        }
        [Authorize(Policy = "MinimumAgeRequirement")]
        public IActionResult MinimumAgeRequirement()
        {
            ViewData["Message"] = "Your minumum age requirement page.";

            return View();
        }
        [Authorize(Policy = "PermissionRequirement")]
        public IActionResult PermissionRequirement()
        {
            ViewData["Message"] = "Your permission requirement page.";

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
