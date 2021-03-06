using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingManagement.WEBUI.Models
{
    public class CampaignDetails
    {
        public int CampaignId { get; init; }

        [Required(ErrorMessage = "Please enter your  Name")]
        [MaxLength(30)]
        public string Name { get; init; }

        [Required(ErrorMessage ="Please enter venue")]
        [MaxLength(200)]
        public string Venue { get; init; }

        [Required(ErrorMessage ="Please enter the assigned Executive")]
        public int AssignedTo { get; init; }

        [Required(ErrorMessage ="Please enter the start date")]
        public DateTime StartedOn { get; init; }
        public DateTime? CompletedOn { get; init; }
        
        public int Leads { get; set; }
    }
}
