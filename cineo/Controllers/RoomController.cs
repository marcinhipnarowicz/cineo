using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cineo.Data;
using cineo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cineo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private DataContext _db;

        public RoomController(DataContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Room>> GetAll()
        {
            var result = (from r in _db.Rooms
                          select new
                          {
                              r.Id,
                              r.SeatMap,
                          }).ToList();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetSeats/{id}")]
        public ActionResult<Room> GetSeats(int id)
        {
            var seats =
                        (from s in _db.Seats
                         where s.RoomId == id
                         select new
                         {
                             s.Id,
                             s.Col,
                             s.Row,
                         }).ToArray();

            var result =
                        (from r in _db.Rooms
                         where r.Id == id
                         select new
                         {
                             r.Id,
                             r.SeatMap,
                             seats,
                         });

            return Ok(result);
        }


        [Authorize]
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Room>> Add(Room room)
        {
            _db.Rooms.Add(room);

            await _db.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Room>> Delete(int id)
        {
            var result = await _db.Rooms.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            _db.Rooms.Remove(result);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}