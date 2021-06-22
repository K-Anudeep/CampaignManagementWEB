using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class Users
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}