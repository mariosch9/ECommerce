using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;

namespace NewStaterTask.Data.Repositories
{
    public class ProductCustomerRepository : BaseRepository<ProductCustomer>, IProductCustomerRepository
    {
        public ProductCustomerRepository(NewStarterTaskContext dbContext) : base(dbContext)
        {
        }

        public new async Task<List<ProductCustomer>> GetAsync(Func<IQueryable<ProductCustomer>, IIncludableQueryable<ProductCustomer, object>> include = null)
        {
            Func<IQueryable<ProductCustomer>, IIncludableQueryable<ProductCustomer, object>> includeQuery =
                Product => Product
                    .Include(t => t.Customer)
                    .Include(c => c.Product);

            return await base.GetAsync(includeQuery);
        }

        public new async Task<ProductCustomer> GetByIdAsync(int id, Func<IQueryable<ProductCustomer>, IIncludableQueryable<ProductCustomer, object>> include = null)
        {
            Func<IQueryable<ProductCustomer>, IIncludableQueryable<ProductCustomer, object>> includeQuery =
                Product => Product
                    .Include(t => t.Customer)
                    .Include(c => c.Product);

            return await base.GetByIdAsync(id, includeQuery);
        }
    }
}
