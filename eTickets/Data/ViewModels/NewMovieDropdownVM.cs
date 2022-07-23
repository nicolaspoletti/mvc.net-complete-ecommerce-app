using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownVM
    {
        public NewMovieDropdownVM()
        {
            Producers = new List<Producer>();
            Platforms = new List<Platform>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
