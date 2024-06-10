using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.ViewModels
{
    public class LoginInViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        //public string Email { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }


    }
}
