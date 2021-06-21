using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketingManagement.API.Models.Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
                
        [MaxLength(25)]
        public string FullName { get; set; }

        [MaxLength(30)]
        public string LoginID { get; set; }

        [MaxLength(30)]
        public string Password { get; set; }

        public DateTime DateOfJoin { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
        public byte Discontinued { get; set; }
        public byte IsAdmin { get; set; }
    }
}
