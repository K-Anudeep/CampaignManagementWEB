using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.WEBUI.Models
{
    public class UserDetails
    {
        public int UserId { get; init; }

        [Required(ErrorMessage ="Please enter your Full Name")]
        [MaxLength(25)]
        public string FullName { get; init; }

        [Required(ErrorMessage ="Login ID should not be Empty")]
        [MaxLength(30)]
        public string LoginId { get; init; }

        [Required(ErrorMessage = "Password should not be Empty")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Password should not be Empty")]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Both Passwords should match!")]
        public string ConfirmPassword { get; init; }

        public DateTime DateOfJoin { get; init; }

        [MaxLength(200)]
        public string Address { get; init; }
        public byte Discontinued { get; init; }
        public byte IsAdmin { get; init; }
    }
}
