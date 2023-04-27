using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;

namespace NewStaterTask.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(NewStarterTaskContext dbContext) : base(dbContext)
        {
        }

        public new async Task<List<Product>> GetAsync(Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null)
        {
            return await base.GetAsync();
        }

        public new async Task DeleteAsync(Product products)
        {
            var productCustomers = _dbContext.ProductCustomer.Where(s => s.ProductId == products.Id);
            _dbContext.ProductCustomer.RemoveRange(productCustomers);
            _dbSet.Remove(products);
            await _dbContext.SaveChangesAsync();
        }
    }
}
