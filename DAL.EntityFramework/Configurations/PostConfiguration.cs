using DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityFramework.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(3000);

            builder
                .HasOne(p => p.UserProfile)
                .WithMany(up => up.Posts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
