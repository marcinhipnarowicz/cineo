using cineo.Data;
using cineo.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Movie> GetOne(int Id)
        {
            var m = _db.Movies.Where(p => p.Id == Id);
            return Ok(m);
        }
    }
}