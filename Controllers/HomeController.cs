using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mummy.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

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

        [Authorize]
        public IActionResult Supervised()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BurialForm(MummyData data)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri("http://localhost:5279/score");

                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();

                var prediction = JsonConvert.DeserializeObject<Prediction>(result);

                ViewBag.Prediction = prediction;

                return View();

            }
        }


        [Authorize]
        public IActionResult Unsupervised()
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