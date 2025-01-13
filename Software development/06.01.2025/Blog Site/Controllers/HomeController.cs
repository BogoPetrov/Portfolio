using System.Diagnostics;
using Blog_Site.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyProfile()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
