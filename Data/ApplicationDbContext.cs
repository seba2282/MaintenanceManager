using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaintenanceManager.Models;

namespace MaintenanceManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
    }
}
