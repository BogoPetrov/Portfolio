using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site.Entities
{
    public class Post: BaseEntity
    {
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description {  get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public string Type { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }
    }
}