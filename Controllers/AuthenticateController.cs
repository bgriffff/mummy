using Microsoft.AspNetCore.Mvc;

namespace mummy.Controllers
{
    public class AuthenticateController : Controller
    {
        public IActionResult Login()
        {
            ViewData["Title"] = "Log in";
            return View("/Areas/Identity/Pages/Account/Login.cshtml");
        }
    }
}
