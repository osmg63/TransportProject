using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportProject.Data.Entities;
using TransportProject.Data.Entities.Location;

namespace TransportProject.Data.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            // Primary Key
            builder.HasKey(j => j.Id);

            // JobName zorunlu ve maksimum uzunluk
            builder.Property(j => j.JobName)
                .IsRequired()
                .HasMaxLength(100);

            // JobDescription için uzunluk sınırlaması
            builder.Property(j => j.JobDescription)
                .HasMaxLength(500);

            // JobPrice zorunlu
            builder.Property(j => j.JobPrice)
                .IsRequired();

            // JobDate zorunlu
            builder.Property(j => j.JobDate)
                .IsRequired();

            // Photo opsiyonel
            builder.Property(j => j.Photo)
                .HasMaxLength(250);

            // Offers ile bire çok ilişki
            builder.HasMany(j => j.Offers)
                .WithOne()
                .HasForeignKey(o => o.JobId)
                .OnDelete(DeleteBehavior.Cascade); 
   
            // DepartureAddress ile bire bir ilişki
            builder.HasOne(j => j.DepartureAddress)
                .WithOne()  // Bire bir ilişki
                .HasForeignKey<Job>(j => j.DepartureAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            // DestinationAddress ile bire bir ilişki
            builder.HasOne(j => j.DestinationAddress)
                .WithOne()  // Bire bir ilişki
                .HasForeignKey<Job>(j => j.DestinationAddressId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
