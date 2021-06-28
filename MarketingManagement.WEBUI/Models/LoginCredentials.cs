using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class LoginCredentials
    {
        [Required(ErrorMessage ="Please enter the User ID")]
        public string UserId { get; init; }
        
        [Required(ErrorMessage ="Password should not be empty")]
        [DataType(DataType.Password)]
        public string Password { get; init; }
    }
}