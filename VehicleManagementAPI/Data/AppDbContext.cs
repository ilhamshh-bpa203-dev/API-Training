using Microsoft.EntityFrameworkCore;
using VehicleManagementAPI.Models;

namespace VehicleManagementAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) {}

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle> Motorcycle { get; set; }
        public DbSet<Truck> Truck { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Vehicle>()
                .HasDiscriminator<string>("VehicleType")
                .HasValue<Vehicle>("BaseVehicle")
                .HasValue<Car>("Car")
                .HasValue<Motorcycle>("Motorcycle")
                .HasValue<Truck>("Truck");

            mb.Entity<Vehicle>()
                .HasIndex(v => v.PlateNumber)
                .IsUnique();
        }

    }
}
