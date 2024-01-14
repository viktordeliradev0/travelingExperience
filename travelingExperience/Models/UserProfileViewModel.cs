using Microsoft.AspNetCore.Identity;
namespace travelingExperience.Models

{
    public class UserProfileViewModel 
    {
        public string Name { get; set; }
        public string SName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public int Age { get; set; }

        // User comments property
        public ApplicationUser User { get; set; }

        public List<Comment> Comments { get; set; }
        public string NewCommentText { get; set; }
    }
}
