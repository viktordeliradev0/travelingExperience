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
        [DataType(DataType.Password)]
        [StringLength(50,ErrorMessage ="The {0} must be at least {2} characters long!"), MinLength(6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = " Confirm Password")]
        [Compare("Password",ErrorMessage ="The password and confirming pass do not match")]

        public string ConfirmPassword { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        //Update the requarments for the data
    }
}
