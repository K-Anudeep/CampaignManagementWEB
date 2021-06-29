using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingManagement.API.Models.Entities
{
    [Table("Sales")]
    public class Sales
    {
        [Key] public int OrderID { get; set; }

        [ForeignKey("LeadsReference")] public int LeadID { get; set; }

        [MaxLength(200)] public string ShippingAddress { get; set; }

        [MaxLength(200)] public string BillingAddress { get; set; }

        public DateTime CreatedON { get; set; }
        public string PaymentMode { get; set; }

        //To access Leads table through FK
        public Leads LeadsReference { get; set; }
    }
}