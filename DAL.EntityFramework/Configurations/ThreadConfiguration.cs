using DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityFramework.Configurations
{
    public class ThreadConfiguration : IEntityTypeConfiguration<Thread>
    {
        public void Configure(EntityTypeBuilder<Thread> builder)
        {
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(3000);


        }
    }
}
