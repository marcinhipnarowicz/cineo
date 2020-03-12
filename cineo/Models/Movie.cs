using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleasedYear { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }    //czas w minutach
        public string Production { get; set; }
        public double ImdbScore { get; set; }
        public double MetacriticScore { get; set; }
        public double RottenTomatoesScore { get; set; }

        public virtual Genre Genre { get; set; }
    }
}