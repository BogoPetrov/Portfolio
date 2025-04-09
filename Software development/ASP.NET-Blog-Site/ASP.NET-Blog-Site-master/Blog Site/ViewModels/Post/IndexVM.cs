using Blog_Site.Entities;

namespace Blog_Site.ViewModels.Post
{
    public class IndexVM
    {
        public List<Blog_Site.Entities.Post> Posts { get; set; }
        public List<Blog_Site.Entities.Comment> Comments { get; set; }

        public int Id { get; set; }
    }
}
