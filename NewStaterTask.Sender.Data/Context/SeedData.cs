using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewStarterTask.Core.Entities;

namespace NewStaterTask.Data.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewStarterTaskContext(
               serviceProvider.GetRequiredService
                   <DbContextOptions<NewStarterTaskContext>>()))
            {
                context.Database.EnsureCreated();
                if (context is null)
                {
                    return;
                }

                var customers = new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Smith"
                    },
                    new Customer
                    {
                        Id = 2,
                        FirstName = "Jane",
                        LastName = "Jackson"
                    },
                    new Customer
                    {
                        Id = 3,
                        FirstName = "Jill",
                        LastName = "Davies"
                    }
                };

                context.Customer.AddRange(customers);

                var products = new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Apple",
                        Price = 15
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Banana",
                        Price = 5                   },
                    new Product
                    {
                        Id = 3,
                        Name = "Orange",
                        Price = 7.50M,
                    }
                };

                context.Product.AddRange(products);
                context.SaveChanges();

                var productCustomers = new List<ProductCustomer>
                {
                    new ProductCustomer
                    {
                        Id = 1,
                        CustomerId = customers[0].Id,
                        ProductId = products[0].Id
                    },
                    new ProductCustomer
                    {
                        Id = 2,
                        CustomerId = customers[1].Id,
                        ProductId = products[1].Id
                    },
                    new ProductCustomer
                    {
                        Id = 3,
                        CustomerId = customers[2].Id, 
                        ProductId = products[2].Id
                    },
                    new ProductCustomer
                    {
                        Id = 4,
                        CustomerId = customers[0].Id, 
                        ProductId = products[2].Id
                    }
                };
                foreach (var order in productCustomers)
                {
                    context.ProductCustomer.Add(order);
                }

                context.SaveChanges();
            }
        }
    }
}
