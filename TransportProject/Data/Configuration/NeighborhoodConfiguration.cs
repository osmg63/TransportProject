using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportProject.Data.Entities.Location;

public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
{
    public void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        // Tablo adı belirtme (isteğe bağlı)
        builder.ToTable("Neighborhoods");

        // Anahtar alanı
        builder.HasKey(n => n.Id);

        // İsim ve postal kodu uzunluğu sınırlaması
        builder.Property(n => n.NeighborhoodName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(n => n.PostalCode)
            .HasMaxLength(10);
       
        // District ile ilişki
        builder.HasOne(n => n.District)
            .WithMany(d => d.Neighborhoods)
            .HasForeignKey(n => n.DistrictId)
            .OnDelete(DeleteBehavior.Cascade); // District silindiğinde, DistrictId null olur.

       
    }
}
