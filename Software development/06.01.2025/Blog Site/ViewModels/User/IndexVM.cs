using System.ComponentModel;

namespace Blog_Site.ViewModels.User
{
    public class IndexVM
    {
        public List<Blog_Site.Entities.User> Items { get; set; }

        [DisplayName("Username")]
        public string Username { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Is Admin")]
        public bool IsAdmin { get; set; }

        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }
    }
}
