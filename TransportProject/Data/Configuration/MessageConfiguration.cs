using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TransportProject.Data.Entities;

namespace TransportProject.Data.Configuration
{
    public class MessageConfiguration:IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); 

            builder.Property(m => m.Description) 
                .HasMaxLength(500) 
                .IsRequired();

            builder.Property(m => m.IsRead)
                .IsRequired();

            builder.Property(m => m.CreateTime)
                .IsRequired();

            // Relationships
            builder.HasOne(m => m.UserSender)
                .WithMany() 
                .HasForeignKey(m => m.UserSenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.UserRecipient)
                .WithMany() 
                .HasForeignKey(m => m.UserRecipientId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
