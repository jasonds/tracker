using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using tracker.domain.Models;

namespace tracker.infrastructure.Repositories
{
    public abstract class Repository<TEntity>
        where TEntity : class, IIdentifiable<Guid>
    {
        private readonly DbContext _dbContext;

        protected Repository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this._dbContext = context;
        }

        protected virtual IQueryable<TEntity> Set => this._dbContext.Set<TEntity>();

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.Set.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<TEntity>> GetByIdsAsync(ICollection<Guid> ids)
        {
            return await this.Set.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this.Set.ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            return this._dbContext.Set<TEntity>().Add(entity);
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            this._dbContext.Set<TEntity>().AddRange(entities);
        }

        public TEntity Remove(TEntity entity)
        {
            return this._dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
