using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportProject.Data.Entities;

namespace TransportProject.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(500); 

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(100);
            // Offer -> User ilişkisi
            builder.HasOne(o => o.User)
                .WithMany(u => u.Vehicles)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
