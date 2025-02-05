using Blog_Site.Entities;
using Blog_Site.Extensions;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
{
    public class CommentController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM vm)
        {
            Comment comment = new()
            {
                OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id,
                PostId = vm.PostId,
                Text = vm.Text,
                Likes = 0,
                DateTime = DateTime.Now,
                Owner = HttpContext.Session.GetObject<User>("loggedUser"),
                MainPost = vm.MainPost

            };

            CommentRepository commentRepository = new();
            commentRepository.Save(comment);

            return RedirectToAction("Index", "Comment");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CommentRepository commentRepository = new();
            Comment comment = commentRepository.GetById(id)!;

            EditVM vm = new()
            {
                Text = comment.Text
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            Comment comment = new()
            {
                Text = vm.Text
            };

            CommentRepository commentRepository = new();
            commentRepository.Save(comment);

            return RedirectToAction("Index", "Commment");
        }

        public IActionResult Delete(int id)
        {
            CommentRepository repo = new();

            Comment toDelete = repo.GetById(id)!;

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "Comment");
        }
    }
}
