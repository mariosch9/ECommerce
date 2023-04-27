using Microsoft.EntityFrameworkCore.Query;
using NewStarterTask.Core.Models;

namespace NewStarterTask.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<List<TEntity>> GetAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
