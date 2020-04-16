using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SeatMap { get; set; }

        public virtual List<Seat> Seats { get; set; }
    }
}
