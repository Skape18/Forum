using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(DbContext context) : base(context)
        {
        }


        protected override IQueryable<Topic> DbSetWithAllProperties()
        {
            return DbSet
                .Include(p => p.Threads)
                .ThenInclude(t => t.UserProfile)
                .ThenInclude(up => up.ApplicationUser);
        }
    }
}
