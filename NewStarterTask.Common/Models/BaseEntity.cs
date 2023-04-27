using System.ComponentModel.DataAnnotations;
using NewStarterTask.Core.Interfaces;

namespace NewStarterTask.Core.Models
{
    public class BaseEntity: IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
