using Entity = Blog_Site.Entities;

namespace Blog_Site.ViewModels.Post
{
    public class IndexVM
    {
        public List<Entity.Post>? Posts { get; set; }
        public List<Entity.Comment>? Comments { get; set; }
        public int Id { get; set; }
    }
}
