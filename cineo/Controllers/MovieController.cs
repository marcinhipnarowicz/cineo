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

namespace cineo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private DataContext _db;

        public MoviesController(DataContext context)
        {
            _db = context;
        }

        // GET api/values
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Movie>> GetAll()
        {
            var m = _db.Movies.AsEnumerable();
            return Ok(m);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public ActionResult<Movie> GetOne(int id)
        {
            var m = _db.Movies.Where(p => p.Id == id);
            return Ok(m);
        }

        [HttpGet]
        [Route("GetRand")]
        public ActionResult<Movie> GetRand()
        {
            IQueryable<int> movies = from n in _db.Movies
                                     select n.Id;
            List<int> cos = new List<int>();
            foreach (var item in movies)
            {
                cos.Add(item);
            }

            Random rnd = new Random();
            int index = rnd.Next(0, cos.Count());

            var m = _db.Movies.Where(p => p.Id == cos[index]);
            return Ok(m);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Movie>> Add(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<Movie>> Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _db.Entry(movie).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            var m = await _db.Movies.FindAsync(id);
            if (m == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(m);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id) =>
         _db.Movies.Any(e => e.Id == id);
    }
}