using DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityFramework.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {

            builder
                .HasOne(n => n.Post)
                .WithMany(p => p.Notifications)
                .HasForeignKey(n => n.PostId);

            builder
                .HasOne(n => n.UserProfile)
                .WithMany(n => n.Notifications)
                .HasForeignKey(n => n.UserProfileId);

            builder
                .HasOne(p => p.UserProfile)
                .WithMany(up => up.Notifications)
                .OnDelete(DeleteBehavior.Restrict);

        }
       
    }
}
