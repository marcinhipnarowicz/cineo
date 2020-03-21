using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Models
{
    public class Seance
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public Movie Movie_Id { get; set; }

        [Required]
        public string Subtitles { get; set; }

        [Required]
        [Range(0, 50)]
        public double Price { get; set; }

        [Required]
        public string Hall { get; set; }

        [Required]
        public string Language { get; set; }
    }
}
