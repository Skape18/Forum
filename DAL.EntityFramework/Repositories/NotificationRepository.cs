using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbContext context) : base(context)
        {
        }


        protected override IQueryable<Notification> DbSetWithAllProperties()
        {
            return DbSet
                .Include(p => p.Post)
                .Include(p => p.UserProfile)
                .ThenInclude(up => up.ApplicationUser);
        }
    }
}