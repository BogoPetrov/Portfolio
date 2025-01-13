using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site.Entities
{
    public class Comment
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string? Text { get; set; }
        public int Likes { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User? Owner { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post? MainPost { get; set; }
    }
}
