using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NewStarterTask.Core.Models;

namespace NewStarterTask.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<ProductCustomer> Customers { get; set; }
    }
}
