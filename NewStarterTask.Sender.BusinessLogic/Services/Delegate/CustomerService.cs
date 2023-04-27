using System.Net;
using NewStarterTask.BusinessLogic.Helpers;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services.Delegate
{
    public class CustomerService : IService<Customer>
    {
        private readonly IApiService _apiService;
        private const string _capabilityBaseUrl = "api/customer";

        public CustomerService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<Customer>> GetAsync()
        {
            var response = await _apiService.SendAsync(_capabilityBaseUrl, HttpMethod.Get);
            return response is not null ? await HttpResponseHelpers.DeserializeResponse<List<Customer>>(response) : new List<Customer>();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var response = await _apiService.SendAsync(_capabilityBaseUrl, HttpMethod.Get, id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            return await HttpResponseHelpers.DeserializeResponse<Customer>(response);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _apiService.SendAsync(_capabilityBaseUrl, HttpMethod.Put, customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _apiService.SendAsync(_capabilityBaseUrl, HttpMethod.Delete, customer.Id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _apiService.SendAsync(_capabilityBaseUrl, HttpMethod.Post, customer);
        }
    }
}
