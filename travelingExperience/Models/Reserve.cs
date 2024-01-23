using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using travelingExperience.Entity;

namespace travelingExperience.Models
{
    public class Reserve
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public int TravelID { get; set; }

        [Required]
        public int ReservedSeats { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        // Define a foreign key relationship with the Travel model
        [ForeignKey("TravelID")]
        public  Travel Travel { get; set; }
    }
}
