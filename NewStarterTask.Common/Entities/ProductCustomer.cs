using NewStarterTask.Core.Models;

namespace NewStarterTask.Core.Entities
{
    public class ProductCustomer : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
