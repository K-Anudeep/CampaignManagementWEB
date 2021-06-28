using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class LeadsDetails
    {
        [Required] public int LeadId { get; set; }

        [Required(ErrorMessage = "Campaign ID should not be empty.")]
        public int CampaignId { get; set; }

        [Required(ErrorMessage = "Consumer Name should not be empty.")]
        [MaxLength(30)]
        public string ConsumerName { get; set; }

        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,63}$",
            ErrorMessage = "Please enter a valid Email address.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Email should not be empty.")]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$",
            ErrorMessage = "Please enter a valid Phone Number.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [Required(ErrorMessage = "Phone Number should not be empty!")]
        public string PhoneNo { get; set; }

        public string PreferredMoC { get; set; }

        [DataType(DataType.Date)] public DateTime DateApproached { get; set; }

        [Required(ErrorMessage = "Product ID should not be emtpy.")]
        public int ProductId { get; set; }

        public string Status { get; set; }
    }
}