using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Models
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 99)]
        public int Col { get; set; }

        [Required]
        [Range(1, 99)]
        public int Row { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}