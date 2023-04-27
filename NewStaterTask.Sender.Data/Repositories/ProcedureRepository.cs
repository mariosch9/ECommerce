using Microsoft.EntityFrameworkCore;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;

namespace NewStaterTask.Data.Repositories
{
    public class ProcedureRepository: IProcedureRepository
    {
        private readonly NewStarterTaskContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public ProcedureRepository(NewStarterTaskContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _serviceProvider = serviceProvider;
        }

        public async Task ResetDataAsync()
        {
            foreach (var entity in _dbContext.ProductCustomer)
            {
                _dbContext.ProductCustomer.Remove(entity);
            }
            foreach (var entity in _dbContext.Customer)
            {
                _dbContext.Customer.Remove(entity);
            }
            foreach (var entity in _dbContext.Product)
            {
                _dbContext.Product.Remove(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SeedDataAsync()
        {
            await ResetDataAsync();
            SeedData.Initialize(_serviceProvider);
        }
    }
}
