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
                .Include(p => p.Posts)
                .Include(p => p.Topic)
                .Include(p => p.UserProfile)
                .ThenInclude(up => up.ApplicationUser);
        }
    }
}
