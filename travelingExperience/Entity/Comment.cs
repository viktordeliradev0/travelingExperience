using System.ComponentModel.DataAnnotations;

namespace travelingExperience.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public int UserID { get; set; }
        public int TravelID { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateOnly CommentDate { get; set; }
    }
}
