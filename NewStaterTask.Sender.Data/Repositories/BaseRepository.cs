using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NewStarterTask.Core.Models;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;

namespace NewStaterTask.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly NewStarterTaskContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(NewStarterTaskContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<TEntity>> GetAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
            {
                query = include(query);
            }

            return query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet.Where(c => c.Id == id);

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
