
using Microsoft.AspNetCore.Identity;
using travelingExperience.Entity;
namespace travelingExperience.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string SName { get; internal set; }
        public string Number { get; internal set; }
        public int Age { get; internal set; }
        public ICollection<Travel> Travels { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
