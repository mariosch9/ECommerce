using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using NewStarterTask.Core.Models;

namespace NewStarterTask.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<ProductCustomer> ProductCustomer { get; set; }
    }
}
