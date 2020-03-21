using cineo.Data;
using cineo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cineo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class SeanceController : Controller
    {
        

        private DataContext _db;

        public SeanceController(DataContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Seance>> GetAll()
        {
            var m = _db.Seances.AsEnumerable();
            return Ok(m);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public ActionResult<Seance> GetOne(int id)
        {
            var m = _db.Seances.Where(p => p.Id == id);
            return Ok(m);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Seance>> Add(Seance seance)
        {
            _db.Seances.Add(seance);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<Seance>> Edit(int id, Seance seance)
        {
            if (id != seance.Id)
            {
                return BadRequest();
            }

            _db.Entry(seance).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeanceExists(id))
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

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Seance>> Delete(int id)
        {
            var m = await _db.Seances.FindAsync(id);
            if (m == null)
            {
                return NotFound();
            }

            _db.Seances.Remove(m);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool SeanceExists(long id) =>
         _db.Seances.Any(e => e.Id == id);


    }
}
