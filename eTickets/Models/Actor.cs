using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {

        //Might need to be removed and refactor al ocurrences in the solution
        //Id to simple Id

        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ActorProfilePictureURL { get; set; }

        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Actor name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Actor name must be between 3 and 50 characters")]
        public string ActorFullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Actor biography is required")]
        public string ActorBio { get; set; }

        //Relationships:
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
