using System;
using DAL.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Seeder
{
    public static class DbSeeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            #region Identity
            string adminId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "andrei.marinich@gmail.com",
                NormalizedEmail = "andrei.marinich@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

            #endregion

            modelBuilder.Entity<UserProfile>().HasData(new UserProfile
            {
                Id = 1,
                ProfileImagePath = "profile_images/default_profile_image.png",
                Rating = 0,
                IsActive = true,
                RegistrationDate = DateTime.Now,
                ApplicationUserId = adminId
            });

            modelBuilder.Entity<Topic>().HasData(new Topic
            {
                Id = 1,
                Title = "C#",
                Description = "General-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.",
                ImagePath = "topic_images/csharp.png"
            });

            modelBuilder.Entity<Thread>().HasData(
                new Thread
                {
                    Id = 1,
                    Title = "Test thread one",
                    Content = "Some content one",
                    IsOpen = true,
                    ThreadOpenedDate = DateTime.Now,
                    TopicId = 1,
                    UserProfileId = 1
                },
                new Thread
                {
                    Id = 2,
                    Title = "Test thread two",
                    Content = "Some content two",
                    IsOpen = true,
                    ThreadOpenedDate = DateTime.Now,
                    TopicId = 1,
                    UserProfileId = 1
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    PostDate = DateTime.Now,
                    Content = "First reply to thread",
                    UserProfileId = 1,
                    ThreadId = 1
                },

                new Post
                {
                    Id = 2,
                    PostDate = DateTime.Now,
                    Content = "Reply to first reply to thread",
                    UserProfileId = 1,
                    ThreadId = 1,
                    RepliedPostId = 1
                },

                new Post
                {
                    Id = 3,
                    PostDate = DateTime.Now,
                    Content = "Reply to second thread",
                    UserProfileId = 1,
                    ThreadId = 2,
                }
                
            );
        }
    }
}
