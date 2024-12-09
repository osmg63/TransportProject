using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Configuration
{
    public class DepartureAddressConfiguration : IEntityTypeConfiguration<DepartureAddress>
    {
        public void Configure(EntityTypeBuilder<DepartureAddress> builder)
        {
            // Primary Key
            builder.HasKey(d => d.Id);

            // Latitude ve Longitude için zorunlu alan
            builder.Property(d => d.Latitude).IsRequired();
            builder.Property(d => d.Longitude).IsRequired();

            builder.HasOne(d => d.City)
                        .WithMany()
                        .HasForeignKey(d => d.CityId)
                        .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.District)
                      .WithMany()
                      .HasForeignKey(d => d.DistrictId)
                      .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Neighborhood)
                        .WithMany()
                      .HasForeignKey(d => d.NeighborhoodId)
                      .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
