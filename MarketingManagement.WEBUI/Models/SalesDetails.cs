using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class SalesDetails
    {
        public int OrderID { get; set; }
        public int LeadID { get; set; }
        
        [MaxLength(200)]
        public string ShippingAddress { get; set; }

        [MaxLength(200)]
        public string BillingAddress { get; set; }
        public DateTime CreatedON { get; set; }
        public string PaymentMode { get; set; }
        
    }
}
