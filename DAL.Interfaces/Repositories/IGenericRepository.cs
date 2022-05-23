using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        DbSet<T> GetDbSet();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllAsync();
        Task CreateAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
