using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppComercial.Models
{
    public class AppComercialContext : DbContext
    {
        public AppComercialContext (DbContextOptions<AppComercialContext> options)
            : base(options)
        {
        }

        public DbSet<AppComercial.Models.Department> Department { get; set; }
    }
}
