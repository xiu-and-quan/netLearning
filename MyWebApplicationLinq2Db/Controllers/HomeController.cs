using Microsoft.AspNetCore.Mvc;
using Models;
using MyWebApplicationLinq2Db.Models;
using System.Diagnostics;

namespace MyWebApplicationLinq2Db.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List() {
            string res;
            
            using (TestBaseDB db = new TestBaseDB()) 
            {
                ViewData["UserInfos"] = db.UserInfos.ToList();
                return View();
            }           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}