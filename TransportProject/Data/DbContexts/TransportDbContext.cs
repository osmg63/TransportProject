using Microsoft.EntityFrameworkCore;
using TransportProject.Data.Configuration;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.DbContexts
{
    public class TransportDbContext : DbContext
    {
        public TransportDbContext(DbContextOptions<TransportDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<DestinationAddress> DestinationAddress { get; set; }
        public DbSet<DepartureAddress> DepartureAddress { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new NeighborhoodConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationAddressConfiguration());
            modelBuilder.ApplyConfiguration(new DepartureAddressConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());




        }

    }
}
