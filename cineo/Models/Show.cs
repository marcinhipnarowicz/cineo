using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineo.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }

        [Required]
        public string Subtitles { get; set; }

        [Required]
        [Range(0, 50)]
        public double Price { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public DateTime DateAndTimeOfShows { get; set; }
    }
}