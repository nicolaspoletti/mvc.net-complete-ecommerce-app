using eTickets.Data.Base;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie Title")]
        [Required(ErrorMessage = "Movie Title required")]
        public string MovieTitle { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Movie Description required")]
        public string MovieDescription { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Movie price required")]
        public double MoviePrice { get; set; }


        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL")]
        public string MovieImageURL { get; set; }
        
        [Display(Name = "Start day")]
        [Required(ErrorMessage = "Start day required")]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "End day")]
        [Required(ErrorMessage = "End day required")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Category required")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships:
        [Display(Name = "Select a actor(s)")]
        [Required(ErrorMessage = "actor required")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a Platform")]
        [Required(ErrorMessage = "Platform required")]
        public int PlatformId { get; set; }

        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Producer required")]
        public int ProducerId { get; set; }

    }
}
