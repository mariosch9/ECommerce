using System.Net;
using NewStarterTask.BusinessLogic.Helpers;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services.Delegate
{
    public class ProductService : IService<Product>
    {
        private readonly IApiService _apiService;
        private const string _productBaseUrl = "api/product";

        public ProductService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Product>> GetAsync()
        {
            var response = await _apiService.SendAsync(_productBaseUrl, HttpMethod.Get);
            return response is not null ? await HttpResponseHelpers.DeserializeResponse<List<Product>>(response) : new List<Product>();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var response = await _apiService.SendAsync(_productBaseUrl, HttpMethod.Get, id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await HttpResponseHelpers.DeserializeResponse<Product>(response);
        }

        public async Task UpdateAsync(Product product)
        {
            await _apiService.SendAsync(_productBaseUrl, HttpMethod.Put, product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _apiService.SendAsync(_productBaseUrl, HttpMethod.Delete, product.Id);
        }

        public async Task AddAsync(Product product)
        {
            await _apiService.SendAsync(_productBaseUrl, HttpMethod.Post, product);
        }
    }
}
