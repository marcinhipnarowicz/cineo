using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cineo.Models;
using Microsoft.EntityFrameworkCore;

namespace cineo.Data
{
    public class TicketRepository
    {
        private readonly DataContext _context;

        public TicketRepository(DataContext context)
        {
            this._context = context;
            //if (_context.Tickets.Count() == 0)
            //{
            //    _context.Tickets.AddRange(
            //        new Ticket
            //        {
            //            CinemaName = "cineo",
            //            MovieTitle = "Titanic",
            //            BarcodeNumber = 43534534,
            //            TheaterNumber = 1,
            //            RowNumber = 1,
            //            SeatNumber = 3,
            //            Date = "14/09/2020"
            //        },
            //        new Ticket
            //        {
            //            CinemaName = "cineo",
            //            MovieTitle = "Passengers",
            //            BarcodeNumber = 43534535,
            //            TheaterNumber = 1,
            //            RowNumber = 1,
            //            SeatNumber = 4,
            //            Date = "14/09/2020"
            //        });
            //    _context.SaveChanges();
            //}
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        public bool TryGetTicket(int id, out Ticket ticket)
        {
            ticket = _context.Tickets.Find(id);
            return (ticket != null);
        }

        public async Task<int> AddTicketAsync(Ticket ticket)
        {
            int rowsAffected = 0;
            _context.Tickets.Add(ticket);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
