﻿using cineo.Data;
using cineo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cineo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : Controller
    {
        private DataContext _db;

        public ShowsController(DataContext context)
        {
            _db = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Shows>> GetAll()
        {
            var m = _db.Shows.AsEnumerable();
            return Ok(m);
        }

        [HttpGet]
        [Route("GetOne/{id}")]
        public ActionResult<Shows> GetOne(int id)
        {
            var m = _db.Shows.Where(p => p.Id == id);
            return Ok(m);
        }

        [HttpGet]
        [Route("GetDate/{date}")]
        public ActionResult<Shows> GetDate(DateTime date)
        {
            var result = (from s in _db.Shows
                          join m in _db.Movies on s.Movie_Id equals m
                          where date.Date == s.DateAndTimeOfShows.Date
                          select new
                          {
                              m.Id,
                              m.Title,
                              m.YearOfProduction,
                              m.Image,
                              m.SmallImage,
                              m.Description,
                              m.Duration,
                              m.Production,
                              m.Genre,
                              m.ImdbScore,
                              m.MetacriticScore,
                              m.RottenTomatoesScore,
                              s.DateAndTimeOfShows
                          }).ToList();

            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Shows>> Add(Shows shows)
        {
            _db.Shows.Add(shows);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<Shows>> Edit(int id, Shows shows)
        {
            if (id != shows.Id)
            {
                return BadRequest();
            }

            _db.Entry(shows).State = EntityState.Modified;

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
        public async Task<ActionResult<Shows>> Delete(int id)
        {
            var m = await _db.Shows.FindAsync(id);
            if (m == null)
            {
                return NotFound();
            }

            _db.Shows.Remove(m);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool SeanceExists(long id) =>
         _db.Shows.Any(e => e.Id == id);
    }
}