using PontoFidelidade.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoFidelidade.Tests.Services
{
    public class RepositorioHelper<T> : IRepositorio<T>
        where T : class
    {
        private List<T> banco = new List<T>();

        public void Add(T entity)
        {
            banco.Add(entity);
        }

        public void Delete(T entity)
        {
            banco.Remove(entity);
        }

        public Task<IEnumerable<T>> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, bool changeTracker = true, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            return Task.Run(() => banco.AsEnumerable());
        }

        public Task<bool> SaveChangesAsync()
        {
            return Task.Run(() => true);
        }

        public void Update(T entity)
        {
            var objeto = banco.Where(t => t.Equals(entity)).First();
            objeto = entity;
        }
    }
}
