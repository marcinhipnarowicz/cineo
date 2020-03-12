using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1000, 3000)]
        public int YearOfProduction { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0, 300)]
        public int Duration { get; set; }    //czas w minutach

        [Required]
        public string Production { get; set; }

        public double ImdbScore { get; set; }
        public double MetacriticScore { get; set; }
        public double RottenTomatoesScore { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }
    }
}