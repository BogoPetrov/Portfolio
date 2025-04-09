using System.ComponentModel.DataAnnotations;

namespace Blog_Site.ViewModels.User
{
    public class EditVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is Required!")]
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
