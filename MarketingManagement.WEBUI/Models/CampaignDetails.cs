using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class CampaignDetails
    {
        public int campaignId { get; set; }

        [Required(ErrorMessage = "Please enter your  Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter venue")]
        [MaxLength(200)]
        public string Venue { get; set; }

        [Required(ErrorMessage ="Please enter the assigned Executive")]
        public int AssignedTo { get; set; }

        [Required(ErrorMessage ="Please enter the start date")]
        public DateTime StartedOn { get; set; }

        [Required(ErrorMessage ="Please Enter Completed Date")]
        public DateTime? CompletedOn { get; set; }

        

        
    }
}
