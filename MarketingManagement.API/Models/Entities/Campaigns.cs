using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingManagement.API.Models.Entities
{
    [Table("Campaign")]
    public class Campaigns
    {
        [Key]
        public int CampaignID { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string Venue { get; set; }

        [ForeignKey("UsersReference")]
        public int AssignedTo { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime? CompletedOn { get; set; }

        public bool IsOpen { get; set; }

        //To Reference Users table using FK
        public Users UsersReference { get; set; }
    }
}
