using Microsoft.EntityFrameworkCore;
using CarRadar.Models;

namespace CarRadar.Data
{
    public class CarRadarContext : DbContext
    {
        public CarRadarContext (DbContextOptions<CarRadarContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }

    }
}