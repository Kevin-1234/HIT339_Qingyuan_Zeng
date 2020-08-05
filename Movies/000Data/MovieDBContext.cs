using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies._000Data
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options)
                    : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
