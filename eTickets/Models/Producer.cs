using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture required")]
        public string ProducerProfilePictureURL { get; set; }
        
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name required")]
        public string ProducerFullName { get; set; }
        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography required")]
        public string ProducerBio { get; set; }

        // Relationships:
        public List<Movie> ProducerMovies { get; set; }
    }
}
