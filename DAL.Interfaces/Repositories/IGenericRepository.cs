using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetWithPredicatesAsync(Expression<Func<T, object>> orderByPredicate = null, params Expression<Func<T, bool>>[] predicates);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetWithIncludesAsync(params Expression<Func<T, object>>[] includeProperties);
        Task CreateAsync(T entity);
        void Remove(T entity);
        Task RemoveAsync(int id);
        void Update(T entity);
    }
}
