using Microsoft.Extensions.DependencyInjection;
using NewStarterTask.BusinessLogic.Services;
using NewStarterTask.Core.Entities;
using NewStarterTask.Core.Services;
using CustomerService = NewStarterTask.BusinessLogic.Services.Delegate.CustomerService;
using ProcedureService = NewStarterTask.BusinessLogic.Services.Delegate.ProcedureService;
using ProductService = NewStarterTask.BusinessLogic.Services.Delegate.ProductService;
using ProductCustomerService = NewStarterTask.BusinessLogic.Services.Delegate.ProductCustomerService;

namespace NewStarterTask.BusinessLogic.Extensions
{
    public static class ApiServicesExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IApiService, ApiService>();
            services.AddTransient<IService<Customer>, CustomerService>();
            services.AddTransient<IService<Product>, ProductService>();
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IService<ProductCustomer>, ProductCustomerService>();
        
            return services;
        }
    }
}
