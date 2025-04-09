using Blog_Site.Entities;
using Blog_Site.Extentions;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
{
    public class CommentController: Controller
    {
        [HttpGet]
        public IActionResult Create(CreateVM model)
        {
            if (model.Text == null)
            {
                return RedirectToAction("Index", "Posts");
            }

            CommentRepository repo = new CommentRepository();
            Comment toAdd = new Comment();

            toAdd.Text = model.Text;
            toAdd.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            toAdd.PostId = model.PostId;

            repo.Save(toAdd);

            return RedirectToAction("Index", "Posts");
        }
    }
}
