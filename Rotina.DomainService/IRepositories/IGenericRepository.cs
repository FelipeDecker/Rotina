using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rotina.DomainService.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate = null);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null);

        Task<List<T>> FindAllPagedAsync(int amount, int page, Expression<Func<T, bool>> predicate = null);

        // ter um count

        // ter um max

        // ter um select de campos que quero
    }
}
