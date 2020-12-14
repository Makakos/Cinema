using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cinema.Models;

namespace Cinema.Controllers
{
   
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public IActionResult Index()
        {
            log.Info("Home page was viewed");
            return View();
        }
       
        public IActionResult Privacy()
        {
            log.Info("Privacy page was viewed");
            return View();
        }

    }
}
