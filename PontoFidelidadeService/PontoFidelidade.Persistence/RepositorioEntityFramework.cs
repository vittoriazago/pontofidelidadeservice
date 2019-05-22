using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoFidelidade.Persistence
{
    public class RepositorioEntityFramework<T> : IRepositorio<T>
        where T : class
    {
        public readonly DbContext _context;

        public RepositorioEntityFramework(DbContext context)
        {
            this._context = context;

        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }
        
        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            bool changeTracker = true,
            params Expression<Func<T, object>>[] includes)
        {
            var list = _context.Set<T>().AsQueryable();

            if (filter != null)
                list = list.Where(filter);
            if (!changeTracker)
                list = list.AsNoTracking();

            if (includes != null & includes.Any())
            {
                list = includes.Aggregate(list,
                        (current, include) => current.Include(include));
            }
            return await list.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}