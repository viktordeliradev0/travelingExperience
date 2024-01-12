using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace travelingExperience.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string UserID { get; set; }
        
        [Required]
        public string CommentText { get; set; }
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }
        [ForeignKey(nameof(UserID))]
        public ApplicationUser User{ get; set; }
    }
}
