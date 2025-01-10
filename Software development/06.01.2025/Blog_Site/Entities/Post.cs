namespace Blog_Site.Entities
{
    public class Post : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string? Type { get; set; }
        public User? Owner { get; set; }
    }
}
