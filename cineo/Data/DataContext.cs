using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cineo.Models;
using Microsoft.EntityFrameworkCore;

namespace cineo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
