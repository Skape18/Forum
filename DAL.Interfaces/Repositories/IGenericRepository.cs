using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWithIncludesAsync(params Expression<Func<T, object>>[] includeProperties);
        Task CreateAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
