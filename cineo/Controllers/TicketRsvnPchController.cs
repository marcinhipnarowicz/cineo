using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cineo.Data;
using cineo.Models;

namespace cineo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketRsvnPchController : ControllerBase //Reservation & Purchase Controller
    {
        private readonly DataContext _context;

        public TicketRsvnPchController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TicketRsvnPch
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetAll()
        {
            var result = (from t in _context.Tickets
                          select new
                          {
                              t.Id,
                              t.SeatId,
                              t.ShowId,
                              t.Type,
                          }).ToList();

            return Ok(result);
        }

        // GET: api/TicketRsvnPch/1
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetOne(int id)
        {
            var result = (from t in _context.Tickets
                          where t.Id == id
                          select new
                          {
                              t.Id,
                              t.SeatId,
                              t.ShowId,
                              t.Type,
                          }).ToList();

            return Ok(result);
        }

        // POST: api/TicketRsvnPch
        [HttpPost]
        public async Task<ActionResult<Ticket>> Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // PUT: api/TicketRsvnPch/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/TicketRsvnPch/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}