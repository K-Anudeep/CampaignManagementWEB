using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class UserDetails
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Please enter your Full Name")]
        [MaxLength(25)]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Login ID should not be Empty")]
        [MaxLength(30)]
        public string LoginID { get; set; }

        [Required(ErrorMessage = "Password should not be Empty")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password should not be Empty")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Both Passwords should match!")]
        public string ConfirmPassword { get; set; }

        public DateTime DateOfJoin { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
        public byte Discontinued { get; set; }
        public byte IsAdmin { get; set; }
    }
}
