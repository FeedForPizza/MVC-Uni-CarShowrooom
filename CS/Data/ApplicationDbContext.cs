using CS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cars> cars { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Storage> storage { get; set; }
        public DbSet<TestDrive> testDrive { get; set; }
        public DbSet<CarExtra> carExtra { get; set; }
        

    }
}