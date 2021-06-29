using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingManagement.API.Models.Entities
{
    [Table("Products")]
    public class Products
    {
        [Key] public int ProductID { get; set; }

        [MaxLength(20)] public string ProductName { get; set; }

        [MaxLength(300)] public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}