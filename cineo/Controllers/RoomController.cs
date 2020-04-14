using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cineo.Data;
using cineo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var m = _db.Rooms.AsEnumerable();
            return Ok(m);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public ActionResult<Room> GetOne(int id)
        {
            var m = _db.Rooms.Where(p => p.Id == id);
            return Ok(m);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Room>> Add(Room room)
        {
            _db.Rooms.Add(room);
            
            await _db.SaveChangesAsync();

            return Ok();
        }

        //Takie do testowania czy krzesełka się dobrze wpisały
        [HttpGet]
        [Route("GetAllSeats")]
        public ActionResult<IEnumerable<Seat>> GetAllSeats()
        {
            var m = _db.Seats.AsEnumerable();
            return Ok(m);
        }
    }
}