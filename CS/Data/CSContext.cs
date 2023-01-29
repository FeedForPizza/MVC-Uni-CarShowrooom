using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS.Models;

namespace CS.Models
{
    public class CSContext : DbContext
    {
        

        public CSContext (DbContextOptions<CSContext> options)
            : base(options)
        {
        }

        public DbSet<CS.Models.Cars> Cars { get; set; } = default!;

        public DbSet<CS.Models.TestDrive> TestDrive { get; set; }

        public DbSet<CS.Models.Orders> Orders { get; set; }

        public DbSet<CS.Models.Storage> Storage { get; set; }

        public DbSet<CS.Models.CarExtra> CarExtra { get; set; }
    }
}
