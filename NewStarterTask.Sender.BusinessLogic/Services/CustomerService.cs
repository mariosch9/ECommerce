using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Repositories;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly ICustomerRepository _capabilityRepository;

        public CustomerService(ICustomerRepository capabilitiesRepository)
        {
            _capabilityRepository = capabilitiesRepository;
        }

        public async Task<List<Customer>> GetAsync()
        {
            return await _capabilityRepository.GetAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _capabilityRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _capabilityRepository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _capabilityRepository.DeleteAsync(customer);
        }

        public async Task AddAsync(Customer customer)
        {
            await _capabilityRepository.AddAsync(customer);
        }
    }
}
