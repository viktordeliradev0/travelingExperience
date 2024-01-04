using System.ComponentModel.DataAnnotations;

namespace travelingExperience.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
