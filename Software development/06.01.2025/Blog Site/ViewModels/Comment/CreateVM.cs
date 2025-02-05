using Blog_Site.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site.ViewModels.Comment
{
    public class CreateVM
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string? Text { get; set; }
        public int Likes { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public User? Owner { get; set; }

        [ForeignKey(nameof(PostId))]
        public Entities.Post? MainPost { get; set; }
    }
}
