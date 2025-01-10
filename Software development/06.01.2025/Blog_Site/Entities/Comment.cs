namespace Blog_Site.Entities
{
    public class Comment : BaseEntity
    {
        public Post? MainPost { get; set; }
        public string? Text { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        public User? Owner { get; set; }
    }
}
