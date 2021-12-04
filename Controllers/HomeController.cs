using CRUDOptMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOptMVC.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Index([Bind] Ad_login ad)
        {
            int res = dbop.LoginCheck(ad);
            if(res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Page";
            }
            else
            {
                TempData["msg"] = "Admin User Name or Password is Incorrect!";
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
