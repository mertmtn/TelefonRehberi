using System.ComponentModel.DataAnnotations;
 

namespace TelefonRehberi.Models
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
    }
}