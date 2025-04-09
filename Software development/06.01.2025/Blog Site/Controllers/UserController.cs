using Blog_Site.Entities;
using Blog_Site.Filters;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Blog_Site.Controllers
{
    [AuthenticationFilter]
    public class UserController : Controller
    {
        public IActionResult Index(IndexVM model)
        {
            model.Page = model.Page <= 0
                                ? 1
                                : model.Page;

            model.ItemsPerPage = model.ItemsPerPage <= 0
                                ? 10
                                : model.ItemsPerPage;

            Expression<Func<User, bool>> filter =
                u =>
                    (string.IsNullOrEmpty(model.Username) || (u.Username.Contains(model.Username))) &&
                    (string.IsNullOrEmpty(model.FirstName) || (u.FirstName.Contains(model.FirstName))) &&
                    (string.IsNullOrEmpty(model.LastName) || (u.LastName.Contains(model.LastName))) &&
                    (u.IsAdmin == model.IsAdmin);

            UserRepository repo = new UserRepository();

            model.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)model.ItemsPerPage);
            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage);

            return View(model);
        }

        //Loads Create view for Users
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Takes data from create view and creates a user to be added to database
        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UserRepository repo = new UserRepository();

            User toAdd = new User();
            toAdd.Username = model.Username;
            toAdd.Password = model.Password;
            toAdd.FirstName = model.FirstName;
            toAdd.LastName = model.LastName;
            toAdd.IsAdmin = model.IsAdmin;
            repo.Save(toAdd);

            return RedirectToAction("Index", "User");
        }

        //Loads Edit view for users
        [HttpGet]
        public IActionResult Edit(int id)
        {
            UserRepository repo = new UserRepository();
            User toEdit = repo.GetById(id);

            if (toEdit == null)
                return RedirectToAction("Index", "User");

            EditVM model = new EditVM();
            model.Id = toEdit.Id;
            model.Username = toEdit.Username;
            model.Password = toEdit.Password;
            model.FirstName = toEdit.FirstName;
            model.LastName = toEdit.LastName;
            model.IsAdmin = toEdit.IsAdmin;

            return View(model);
        }

        //Takes data from edit view and edits the existing user
        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UserRepository repo = new UserRepository();
            User toEdit = repo.GetById(model.Id);

            if (toEdit == null)
                return RedirectToAction("Index", "User");

            toEdit.Username = model.Username;
            toEdit.Password = model.Password;
            toEdit.FirstName = model.FirstName;
            toEdit.LastName = model.LastName;
            toEdit.IsAdmin = model.IsAdmin;

            repo.Save(toEdit);

            return RedirectToAction("Index", "User");
        }

        //Deletes selected user
        public IActionResult Delete(int id)
        {
            UserRepository repo = new UserRepository();

            User toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "User");
        }
    }
}