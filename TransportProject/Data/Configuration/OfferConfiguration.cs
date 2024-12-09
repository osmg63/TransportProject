using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TransportProject.Data.Entities;

namespace TransportProject.Data.Configuration
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.OfferTime)
                .IsRequired();
            builder.HasOne(o => o.Job)
                    .WithMany(j => j.Offers)
                    .HasForeignKey(o => o.JobId)
                    .OnDelete(DeleteBehavior.Cascade); // Tek kaskad

            // Offer -> User ilişkisi
            builder.HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
