using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PreQual.Models;

namespace PreQual.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "PreQual is an app that shows what credit cards are available to you!";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact us at 0800 D0N7 C411 or prequal@fakeemails.com or visti us at 42 Non-existant Close, Falsebury, Phonyshire, N07 R341";

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
