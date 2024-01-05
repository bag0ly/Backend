using Microsoft.EntityFrameworkCore;

namespace Projects_dolgozat.Models
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Tasks> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=192.168.1.253; database=Projects; user=root; password=geci1234!";

                optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            }
        }
    }
}
