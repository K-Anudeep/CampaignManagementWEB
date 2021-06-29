using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class SalesDetails
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Lead ID should not be Empty.")]
        public int LeadID { get; set; }
        
        [Required(ErrorMessage = "Shipping Address is Required")]
        [MaxLength(200)] public string ShippingAddress { get; set; }

        [MaxLength(200)] public string BillingAddress { get; set; }

        [DataType(DataType.Date)] public DateTime CreatedON { get; set; }

        public string PaymentMode { get; set; }
    }
}