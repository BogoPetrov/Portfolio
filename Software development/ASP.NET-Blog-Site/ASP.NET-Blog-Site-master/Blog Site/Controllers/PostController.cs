using Blog_Site.Entities;
using Blog_Site.Extentions;
using Blog_Site.Filters;
using Blog_Site.Repositories;
using Blog_Site.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Site.Controllers
{
    [AuthenticationFilter]
    public class PostController: Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            IndexVM vm = new IndexVM();

            PostRepository postRepository = new PostRepository();
            CommentRepository commentRepository = new CommentRepository();
            vm.Posts = postRepository.GetAll();
            vm.Comments = commentRepository.GetAll();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(IndexVM vm)
        {
            PostRepository postRepository = new PostRepository();
            Post post = postRepository.GetById(vm.Id);
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
            Post post = new Post();

            post.OwnerId = HttpContext.Session.GetObject<User>("loggedUser").Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            PostRepository postRepository = new PostRepository();
            Post post = postRepository.GetById(id);

            EditVM vm = new EditVM();
            vm.Id = id;
            vm.Title = post.Title;
            vm.Description = post.Description;
            vm.Type = post.Type;

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditVM vm)
        {
            Post post = new Post();

            post.Id = vm.Id;
            post.Title = vm.Title;
            post.Description = vm.Description;
            post.Type = vm.Type;
            post.CreatedAt = DateTime.Now;

            PostRepository postRepository = new PostRepository();
            postRepository.Save(post);

            return RedirectToAction("Index", "Post");
        }

        public IActionResult Delete(int id)
        {
            PostRepository repo = new PostRepository();

            Post toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("Index", "Posts");
        }
    }
}
