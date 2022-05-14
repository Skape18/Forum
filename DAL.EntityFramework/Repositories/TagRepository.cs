using System.Linq;
using DAL.Domain.Entities;
using DAL.EntityFramework.Repositories.Generic;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(DbContext context) : base(context)
        {
        }


        protected override IQueryable<Tag> DbSetWithAllProperties()
        {
            return DbSet;
        }
    }
}