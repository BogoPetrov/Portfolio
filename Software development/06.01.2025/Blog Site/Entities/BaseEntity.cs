using System.ComponentModel.DataAnnotations;

namespace Blog_Site.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
