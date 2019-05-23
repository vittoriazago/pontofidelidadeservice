
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoFidelidade.Domain
{
    public interface IRepositorio<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            bool changeTracker = true,
            params Expression<Func<T, object>>[] includes);

    }

}
