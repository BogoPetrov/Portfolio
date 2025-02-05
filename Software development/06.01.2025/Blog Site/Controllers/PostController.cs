using Microsoft.AspNetCore.Mvc;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Post;

namespace Blog_Site.Controllers
{
    public class PostController
    {
        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new();

            PostRepository postRepository = new();
            CommentRepository commentRepository = new();
        }
    }
}
