using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingManagement.WEBUI.Models
{
    public class LeadsDetails
    {
        public int LeadID { get; set; }

        
        public int CampaignID { get; set; }

        [MaxLength(30)]
        public string ConsumerName { get; set; }

        [MaxLength(30)]
        public string EmailAddress { get; set; }

        [MaxLength(10)]
        public string PhoneNo { get; set; }

        public string PreferredMoC { get; set; }
        public DateTime DateApproached { get; set; }

        public int ProductID { get; set; }
        public string Status { get; set; }
    }
}
