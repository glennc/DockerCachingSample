using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Logging;

namespace DockerCachingSample.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Cache in any proxiesm including proxies.
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            _logger.LogCritical("Reached View Controller");
            return View();
        }

        //My about page never changes so it will cache for a day
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //My contact page never changes so it will cache for a day
        [ResponseCache(Duration = 86400, Location = ResponseCacheLocation.Any)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //Explicitly don't cache Error page. This shouldn't strictly be required since
        //we shouldn't cache at all by default for non 200 and none is the default location.
        [ResponseCache(Location = ResponseCacheLocation.None)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
