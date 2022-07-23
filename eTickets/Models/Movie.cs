using eTickets.Data.Base;
using eTickets.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string MovieTitle { get; set; }

        [Display(Name = "Description")]
        public string MovieDescription { get; set; }
        public double MoviePrice { get; set; }

        [Display(Name = "Movie Poster")]
        public string MovieImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships:
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Platform:
        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }

        //Producer:
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
