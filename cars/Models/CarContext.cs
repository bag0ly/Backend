using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace cars.Models
{
    public class CarContext : DbContext
    {
        public CarContext() 
        {

        }
        public CarContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=192.168.50.110; database=CarRent; user=root; password=geci1234!",
                    ServerVersion.AutoDetect("server=192.168.50.110; database=CarRent; user=root; password=geci1234!"));
            }
        }

        public DbSet<Car> Cars { get; set; } = null;
    }
}
