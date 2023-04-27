using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services
{
    public class ProductService : IService<Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _productRepository.GetAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
       }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }
    }
}
