using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class ProductDetails
    {
        [Required(ErrorMessage = "Please enter Product ID")]
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Please enter Product Name")]
        [MaxLength(20)]
        public string ProductName { get; init; }
        [Required(ErrorMessage = "Please enter Product Description")]
        [MaxLength(300)]
        public string Description { get; init; }
        [Required(ErrorMessage = "Please enter Product Price")]
        public decimal UnitPrice { get; init; }
    }
}
