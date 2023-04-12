using Microsoft.AspNetCore.Mvc;
using mummy.Models;
using System.Diagnostics;

namespace mummy.Controllers
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

        public IActionResult BurialList()
        {
            return View();
        }

        public IActionResult BurialForm()
        {
            return View();
        }

        public IActionResult Supervised()
        {
            return View();
        }
        public IActionResult Unsupervised() 
        {
            return View();
        }


            //// Use the View method to return the view
            //return View(virtualPath);

        ////    return RedirectToPage("//Identity/Account/Login");
     
        ////}

        //Edit get and post needed

        //delete get and post needed

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}