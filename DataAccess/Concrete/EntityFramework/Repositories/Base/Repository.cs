using Core.Interfaces.Repositories.Base;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            Context
           .Set<TEntity>()
           .Add(entity);
        }

        public async Task AddAsync(params TEntity[] entities)
        {
            foreach (TEntity entity in entities)
                Context.Set<TEntity>()
                   .Add(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = Context
                .Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            return dbQuery
                .AsNoTracking()
                .Where(predicate)
                .ToList<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await Context.Set<TEntity>().ToListAsync() :
                 await Context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            Context
                .Set<TEntity>()
                .Remove(entity);
        }

        public void Remove(params TEntity[] entities)
        {
            foreach (var entity in entities)
                Context
                    .Set<TEntity>()
                    .Remove(entity);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context
                .Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
        }

        public void Update(TEntity entity)
        {
            Context.Entry<TEntity>(entity).State = EntityState.Modified;                
        }

        public void Update(params TEntity[] entities)
        {
            foreach (var entity in entities)
                Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
