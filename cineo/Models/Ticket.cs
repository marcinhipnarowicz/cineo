using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cineo.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string CinemaName { get; set; }

        [Required]
        public string MovieTitle { get; set; }

        [Required]
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
