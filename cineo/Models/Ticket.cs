using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cineo.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public Movie Movie_Id { get; set; }

        [ForeignKey("Seance")]
        public Seance Seance_Id { get; set; }

        [Required]
        public string CinemaName { get; set; }

        [Required]
        public string MovieTitle { get; set; }

        [Required]
        [Range(0,999999999999)]
        public long BarcodeNumber { get; set; }

        [Required]
        public int TheaterNumber { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public string Date { get; set; } //data seansu
    }
}
