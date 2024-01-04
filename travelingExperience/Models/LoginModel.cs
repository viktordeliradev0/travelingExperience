using System.ComponentModel.DataAnnotations;

namespace travelingExperience.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
