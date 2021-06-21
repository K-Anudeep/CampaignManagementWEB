using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingManagement.API.Models.Entities
{
    [Table("Leads")]
    public class Leads
    {
        [Key]
        public int LeadID { get; set; }
        
        [ForeignKey("CampaignsReference")]
        public int CampaignID { get; set; }

        [MaxLength(30)]
        public string ConsumerName { get; set; }

        [MaxLength(30)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string PhoneNo { get; set; }

        public string PreferredMoC { get; set; }
        public DateTime DateApproached { get; set; }

        [ForeignKey("ProductsReference")]
        public int ProductID { get; set; }
        public string Status { get; set; }

        //To access Campaign and Product table through FK
        public Campaigns CampaignsReference { get; set; }
        public Products ProductsReference { get; set; }
    }
}
