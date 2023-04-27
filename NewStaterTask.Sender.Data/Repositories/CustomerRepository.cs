using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;

namespace NewStaterTask.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(NewStarterTaskContext dbContext) : base(dbContext)
        {
        }

        public new async Task DeleteAsync(Customer customer)
        {
            var customers = _dbContext.ProductCustomer.Where(s => s.CustomerId == customer.Id);
            _dbContext.ProductCustomer.RemoveRange(customers);
            _dbSet.Remove(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
