using System.Diagnostics;
using Blog_Site.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace First_Try.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [HttpGet]
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
        public IActionResult Login(LoginVM login)
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
