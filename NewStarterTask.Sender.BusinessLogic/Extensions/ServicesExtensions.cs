using Microsoft.Extensions.DependencyInjection;
using NewStarterTask.BusinessLogic.Services;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;

namespace NewStarterTask.BusinessLogic.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IService<Customer>, CustomerService>();
            services.AddTransient<IService<Product>, ProductService>();
            services.AddTransient<IService<ProductCustomer>, ProductCustomerService>();
            services.AddTransient<IProcedureService, ProcedureService>();

            return services;
        }
    }
}
