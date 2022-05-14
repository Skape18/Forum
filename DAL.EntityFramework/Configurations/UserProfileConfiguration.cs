
using DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityFramework.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder
                .HasKey(up => up.Id);

            builder
                .HasOne(up => up.ApplicationUser)
                .WithOne()
                .HasForeignKey<UserProfile>(up => up.ApplicationUserId)
                .IsRequired();

            builder
                .HasMany(up => up.LikedBy)
                .WithMany(up => up.LikedTo);
        }
    }
}
