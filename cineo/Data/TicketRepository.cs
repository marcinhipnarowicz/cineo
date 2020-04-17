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
            int rowsAffected;
            _context.Tickets.Add(ticket);
            rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
