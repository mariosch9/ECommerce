using System.Net;
using NewStarterTask.BusinessLogic.Helpers;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services.Delegate
{
    public class ProductCustomerService : IService<ProductCustomer>
    {
        private readonly IApiService _apiService;
        private const string _productCustomerBaseUrl = "api/ProductCustomer";

        public ProductCustomerService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ProductCustomer>> GetAsync()
        {
            var response = await _apiService.SendAsync(_productCustomerBaseUrl, HttpMethod.Get);
            return response is not null ? await HttpResponseHelpers.DeserializeResponse<List<ProductCustomer>>(response) : new List<ProductCustomer>();
        }

        public async Task<ProductCustomer> GetByIdAsync(int id)
        {
            var response = await _apiService.SendAsync(_productCustomerBaseUrl, HttpMethod.Get, id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            return await HttpResponseHelpers.DeserializeResponse<ProductCustomer>(response);
        }

        public async Task UpdateAsync(ProductCustomer productCustomer)
        {
            await _apiService.SendAsync(_productCustomerBaseUrl, HttpMethod.Put, productCustomer);
        }

        public async Task DeleteAsync(ProductCustomer productCustomer)
        {
            await _apiService.SendAsync(_productCustomerBaseUrl, HttpMethod.Delete, productCustomer.Id);
        }

        public async Task AddAsync(ProductCustomer productCustomer)
        {
            await _apiService.SendAsync(_productCustomerBaseUrl, HttpMethod.Post, productCustomer);
        }
    }
}