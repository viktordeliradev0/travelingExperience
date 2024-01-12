using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using travelingExperience.Data.Enums;
using travelingExperience.Models;

namespace travelingExperience.Entity
{
    public class Travel
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "UserID")]
        [Required]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please select a start destination")]
        [Display(Name = "Start Destination")]
        public TravelDestinations StartDestination { get; set; }

        [Required(ErrorMessage = "Please select an end destination")]
        [Display(Name = "End Destination")]
        public TravelDestinations EndDestination { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        [Display(Name = "Description")]
        public string Descrition { get; set; }

        [Required(ErrorMessage = "Please provide a start date")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please provide an end date")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please provide a price")]
        [Display(Name = "Price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please provide the number of seats")]
        [Display(Name = "Seats")]
        public int Seats { get; set; }

        //Relationship
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }



        //ForeingKey



    }
}
