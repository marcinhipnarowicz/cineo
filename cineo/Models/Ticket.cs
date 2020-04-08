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

        [ForeignKey("Seance")]
        public Seance Seance_id { get; set; }

        [ForeignKey("Hall")]
        public Seance Hall_id { get; set; }

        //[ForeignKey("Seat")]
        //public XXX Seat_id { get; set; }

        [ForeignKey("Users")]
        public User Users_id { get; set; }

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
