using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAPILab;

namespace MovieAPILab.Data
{

    public class MovieAPILabContext : DbContext
    {
        public MovieAPILabContext (DbContextOptions<MovieAPILabContext> options)
            : base(options)
        {
        }

        public DbSet<MovieAPILab.Movie> Movie { get; set; }
    }
}
