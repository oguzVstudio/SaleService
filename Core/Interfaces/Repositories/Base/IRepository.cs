using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] navigationProperties);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddAsync(params TEntity[] entities);

        void Remove(TEntity entity);

        void Remove(params TEntity[] entities);

        void Update(TEntity entity);

        void Update(params TEntity[] entities);
    }
}
