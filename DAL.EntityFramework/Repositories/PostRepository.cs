using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }


        protected override IQueryable<Post> DbSetWithAllProperties()
        {
            return DbSet
                .Include(p => p.RepliedPost)
                .Include(p => p.Notifications)
                .Include(p => p.Thread)
                .Include(p => p.UserProfile);
        }
    }
}
