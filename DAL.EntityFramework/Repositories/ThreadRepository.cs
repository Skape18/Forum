using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class ThreadRepository : GenericRepository<Thread>, IThreadRepository
    {
        public ThreadRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Thread> DbSetWithAllProperties()
        {
            return DbSet
                .Include(t => t.Posts)
                .Include(t => t.Topic)
                .Include(t => t.UserProfile)
                .ThenInclude(up => up.ApplicationUser);
        }
    }
}
