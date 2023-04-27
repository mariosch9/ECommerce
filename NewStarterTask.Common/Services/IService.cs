using NewStarterTask.Core.Models;

namespace NewStarterTask.Core.Services
{
    public interface IService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
