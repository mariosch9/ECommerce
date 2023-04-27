using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewStarterTask.Core.Repositories;
using NewStaterTask.Data.Context;
using CustomerRepository = NewStaterTask.Data.Repositories.CustomerRepository;
using ProcedureRepository = NewStaterTask.Data.Repositories.ProcedureRepository;
using ProductRepository = NewStaterTask.Data.Repositories.ProductRepository;
using ProductCustomerRepository = NewStaterTask.Data.Repositories.ProductCustomerRepository;

namespace NewStaterTask.Data.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContextPool<NewStarterTaskContext>(options => {
                options.UseInMemoryDatabase(databaseName: "Db");
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    options.EnableSensitiveDataLogging(true);
                }
            });
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCustomerRepository, ProductCustomerRepository>();
            services.AddTransient<IProcedureRepository, ProcedureRepository>();

            return services;
        }
    }
}
