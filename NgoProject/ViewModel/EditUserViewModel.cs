using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class EditUserViewModel
    {


        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
    }

}
