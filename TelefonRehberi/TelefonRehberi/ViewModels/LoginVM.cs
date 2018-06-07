using System.ComponentModel.DataAnnotations;

namespace TelefonRehberi.ViewModels
{
    public class LoginVM
    {         


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}