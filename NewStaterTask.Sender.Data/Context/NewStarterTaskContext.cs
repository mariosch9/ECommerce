using Microsoft.EntityFrameworkCore;
using NewStarterTask.Core.Entities;

namespace NewStaterTask.Data.Context
{
    public class NewStarterTaskContext : DbContext
    {
        public NewStarterTaskContext (DbContextOptions<NewStarterTaskContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductCustomer> ProductCustomer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductCustomer>().ToTable("ProductCustomer");
        }
    }
}
