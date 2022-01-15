using System.ComponentModel.DataAnnotations;

namespace RacingSeries.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username required...")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password required...")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
