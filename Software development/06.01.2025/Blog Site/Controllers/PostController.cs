using Blog_Site.Entities;
using Blog_Site.Extensions;
using Blog_Site.Filters;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
{
    [AuthenticationFilter]
    public class PostController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new();

            PostRepository postRepository = new();
            CommentRepository commentRepository = new();
            vm.Posts = postRepository.GetAll();
            vm.Comments = commentRepository.GetAll();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm)
        {
            PostRepository postRepository = new();
            Post post = postRepository.GetById(vm.Id)!;
            post.Likes++;

            postRepository.Save(post);

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM vm)
        {
            Post post = new()
            {
                OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id,
                Title = vm.Title,
                Description = vm.Description,
                Type = vm.Type,
                CreatedAt = DateTime.Now
            };

            PostRepository postRepository = new();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PostRepository postRepository = new();
            Post post = postRepository.GetById(id)!;

            EditVM vm = new()
            {
                Id = id,
                Title = post.Title,
                Description = post.Description,
                Type = post.Type
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            Post post = new()
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                Type = vm.Type,
                CreatedAt = DateTime.Now
            };

            PostRepository postRepository = new();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            PostRepository repo = new();

            Post toDelete = repo.GetById(id)!;

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "Posts");
        }
    }
}
