using cineo.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Controllers
{
    public class Movie
    {
        [Microsoft.AspNetCore.Components.Route("api/[controller]")]
        [ApiController]
        public class MoviesController : ControllerBase
        {
            private DataContext _db;

            public MoviesController(DataContext context)
            {
                _db = context;
            }

            // GET api/values
            //[HttpGet]
            //public ActionResult<IEnumerable<Movie>> Get()
            //{

            //    var m = _db.Movies.ToList();
            //    //return m;
            //}

        }
    }
}
