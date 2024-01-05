
using Microsoft.AspNetCore.Identity;
namespace travelingExperience.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name {  get; set; }
        
    }
}
