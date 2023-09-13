using MaintainSys.Models;
using Microsoft.EntityFrameworkCore;

namespace MaintainSys.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Users> Users { get; set; }

        public DbSet<Technicians> Technicians { get; set; }

        public DbSet<MaintenanceLog> MaintenanceLog { get; set; }

        public DbSet<Maintenancetickets> Maintenancetickets { get; set; }


    }
}
