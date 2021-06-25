using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingManagement.WEBUI.Models
{
    public class ProductDetails
    {
        [Required(ErrorMessage = "Please enter Product ID")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter Product Name")]
        [MaxLength(20)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter Product Description")]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Product Price")]
        public decimal UnitPrice { get; set; }
    }
}
