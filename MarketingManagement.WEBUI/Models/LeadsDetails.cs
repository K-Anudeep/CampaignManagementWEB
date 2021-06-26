using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class LeadsDetails
    {
        public int LeadId { get; set; }

        
        public int CampaignId { get; set; }

        [MaxLength(30)]
        public string ConsumerName { get; set; }

        [MaxLength(30)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string PhoneNo { get; set; }

        public string PreferredMoC { get; set; }
        public DateTime DateApproached { get; set; }

        public int ProductId { get; set; }
        public string Status { get; set; }
    }
}
