using System.ComponentModel.DataAnnotations;

namespace Identity.Quickstart.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]

        public string UserName { get; set; }


        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
        public string RoleName { get; set; }


    }
}
