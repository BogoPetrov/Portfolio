using Blog_Site.Entities;
using Blog_Site.Extensions;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
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

        [HttpGet]
        public IActionResult MyProfile()
        {
            User loggedUser = HttpContext.Session.GetObject<User>("loggedUser");
            MyProfileVM User = new()
            {
                FirstName = loggedUser.FirstName,
                LastName = loggedUser.LastName,
                Username = loggedUser.Username,
                Password = loggedUser.Password
            };

            return View(User);
        }


        [HttpGet]
        public IActionResult Login(string url)
        {
            LoginVM model = new()
            {
                Url = url
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
                return View(model);

            UserRepository repo = new();
            User loggedUser = repo.FirstOrDefault(u =>
                                                u.Username == model.Username &&
                                                u.Password == model.Password)!;

            if (loggedUser == null)
            {
                ModelState.AddModelError("authFailed", "Authentication failed!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            if (!string.IsNullOrEmpty(model.Url))
                return new RedirectResult(model.Url);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}