﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.Domain.Base;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityFramework.Repositories.Generic
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        protected DbSet<T> DbSet { get; }

        protected GenericRepository(DbContext context)
        {
            DbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await DbSetWithAllProperties().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await DbSetWithAllProperties()
                .AsNoTracking()
                .ToListAsync();
            
            return entities;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity != null)
                await DbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            if (entity != null)
                DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            if (entity != null)
                DbSet.Update(entity);
        }

        public async Task<IEnumerable<T>> GetWithIncludesAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            return await IncludeProperties(includeProperties).ToListAsync();
        }

        protected abstract IQueryable<T> DbSetWithAllProperties();

        protected IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbSet;

            foreach (var includeProperty in includeProperties)
            {
                if (includeProperty != null)
                    query = query.Include(includeProperty);
            }

            return query;
        }

    }
}
