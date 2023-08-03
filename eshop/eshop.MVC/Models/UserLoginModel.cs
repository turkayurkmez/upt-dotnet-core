using System.ComponentModel.DataAnnotations;

namespace eshop.MVC.Models
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
