using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canfordit_Rides_and_Hires.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        [EmailAddress]
        [ForeignKey("UserProfile")]
        public string Email { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        [DisplayName("Street")]
        [Required(ErrorMessage = "Please enter your Street Number.")]
        [MaxLength(10)]
        public string StreetNo { get; set; }

        [DisplayName("Suburb")]
        [MinLength(5)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please mention your suburb.")]
        public string Suburb { get; set; }

        [DisplayName("City")]
        [MinLength(5)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please mention your city.")]
        public string City { get; set; }

        [DisplayName("Province")]
        [Required(ErrorMessage = "Please select your province.")]
        public string Province { get; set; }

        [DisplayName("Postal Code")]
        [MinLength(4, ErrorMessage = "Invalid Postal Code")]
        [StringLength(4, ErrorMessage = "Invalid Postal Code")]
        [Required(ErrorMessage = "Please enter a 4-digit postal code")]
        public string PosctalCode { get; set; }
    }
}