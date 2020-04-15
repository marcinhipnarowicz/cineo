using cineo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace cineo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Shows> Shows { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public IEnumerable<object> Companies { get; internal set; }
    }
}