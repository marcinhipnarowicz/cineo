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

        [ForeignKey("Show")]
        public int? ShowId { get; set; }
        public virtual Show Show { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        [ForeignKey("Seat")]
        public int? SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        [ForeignKey("Users")]
        public int? UsersId { get; set; }
        public virtual User Users { get; set; }

        [Required]
        public int CreationDate { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Status { get; set; }

        public Ticket()
        {
            this.Status = 1;
        }
    }
}