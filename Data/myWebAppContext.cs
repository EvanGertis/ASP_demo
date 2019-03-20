using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace myWebApp.Models
{
    public class myWebAppContext : DbContext
    {
        public myWebAppContext (DbContextOptions<myWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<myWebApp.Models.Movie> Movie { get; set; }
    }
}
