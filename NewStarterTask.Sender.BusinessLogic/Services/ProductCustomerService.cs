using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services
{
    public class ProductCustomerService : IService<ProductCustomer>
    {
        private readonly IProductCustomerRepository _productCustomerRepository;

        public ProductCustomerService(IProductCustomerRepository productCustomerRepository)
        {
            _productCustomerRepository = productCustomerRepository;
        }

        public async Task<List<ProductCustomer>> GetAsync()
        {
            return await _productCustomerRepository.GetAsync();
        }

        public async Task<ProductCustomer> GetByIdAsync(int id)
        {
            var productCustomer = await _productCustomerRepository.GetByIdAsync(id);

            if (productCustomer == null)
            {
                return null;
            }
            
            return productCustomer;
        }

        public async Task UpdateAsync(ProductCustomer productCustomer)
        {
            await _productCustomerRepository.UpdateAsync(productCustomer);
        }

        public async Task DeleteAsync(ProductCustomer productCustomer)
        {
            await _productCustomerRepository.DeleteAsync(productCustomer);
        }

        public async Task AddAsync(ProductCustomer productCustomer)
        {
            await _productCustomerRepository.AddAsync(productCustomer);
        }
    }
}