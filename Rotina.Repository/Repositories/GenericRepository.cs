using Microsoft.EntityFrameworkCore;
using Rotina.DomainService.IRepositories;
using Rotina.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Rotina.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            //_context.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T> FindFirstAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> FindAllPagedAsync(int amount, int page, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.Where(predicate).Skip(amount * (page - 1)).Take(page).ToListAsync();
            }

            return await _dbSet.Skip(amount * (page - 1)).Take(page).ToListAsync();
        }

        public async Task<dynamic> FindAllSelectedAsync(Expression<Func<T, bool>> predicate = null)
        {
            //if (predicate != null)
            //{
            //    return await _dbSet.Where(predicate).Select(x => new { x.Id, x.Email }).ToListAsync();
            //}

            return await _dbSet.ToListAsync();
        }
    }
}
