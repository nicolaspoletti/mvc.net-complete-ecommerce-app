using eTickets.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Platform: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Platform Logo")]
        [Required(ErrorMessage = "Profile picture required")]
        public string PlatformLogoURL { get; set; }

        [Display(Name = "Platform Name")]
        [Required(ErrorMessage = "Platform name required")]
        public string PlatformName { get; set; }
        
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description required")]
        public string PlatformDescription { get; set; }

        // Relationships:
        public List<Movie> PlatformMovies { get; set; }
    }
}
