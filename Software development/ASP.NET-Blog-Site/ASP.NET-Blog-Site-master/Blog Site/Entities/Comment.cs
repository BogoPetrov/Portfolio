using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site.Entities
{
    public class Comment: BaseEntity
    {
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner {  get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post MainPost { get; set; }
    }
}
