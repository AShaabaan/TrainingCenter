using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class UseRegisterrViewModel
    {
        public string Address { get; set; } = string.Empty;

        [Required, MaxLength(20) , DataType(DataType.Text) ]
        public string FirstName { get; set; }
        [Required, MaxLength(20), DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required ]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


    }

}
