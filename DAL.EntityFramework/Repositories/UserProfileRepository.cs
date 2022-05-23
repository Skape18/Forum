using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class UserProfileRepository: GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<UserProfile> DbSetWithAllProperties()
        {
            return DbSet
                .Include(up => up.Threads)
                .Include(up => up.Posts)
                .Include(up => up.Notifications)
                .Include(up => up.ApplicationUser)
                .Include(up => up.Tags)
                .Include(up => up.LikedTo)
                .Include(up => up.LikedBy)
                .Include(up => up.DislikedTo)
                .Include(up => up.DislikedBy);
        }
    }
}
