using Microsoft.EntityFrameworkCore;
namespace Kurs_2
{
    public class AppContext : DbContext
    {
        public DbSet<Files> Files { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Alina;Username=postgres;Password=1");
        }
       
    }
}