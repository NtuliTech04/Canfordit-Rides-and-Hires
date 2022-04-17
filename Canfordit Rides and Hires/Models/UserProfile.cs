using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Canfordit_Rides_and_Hires.Models
{
    public class UserProfile
    {
        [Key]
        public string Email { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("RSA ID")]
        public string RSAID { get; set; }

        [Display(Name = "Date Of Birth")]
        public string BirthDate
        {
            get
            {
                string prefix;

                if (year() >= 00 && year() < today())
                {
                    prefix = "20";
                }
                else
                {
                    prefix = "19";
                }
                return RSAID != null ? prefix + RSAID.Substring(0, 2) + "/" + RSAID.Substring(2, 2) + "/" + RSAID.Substring(4, 2) : "";
            }
            set
            {

            }
        }
        [Display(Name = "Age")]
        public string Age
        {
            get
            {
                DateTime dt = DateTime.ParseExact(BirthDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime today = DateTime.Today;
                int age = today.Year - dt.Year;
                if (dt > today.AddYears(-age)) age--;
                return RSAID != null ? age.ToString() : "";
            }
            set
            {

            }
        }
        [Display(Name = "Gender")]
        public string Gender
        {
            get
            {
                var gendeCode = (RSAID.Substring(6, 4));
                var gender = int.Parse(gendeCode) < 5000 ? "Female" : "Male";
                return RSAID != null ? gender : "";
            }
            set
            {

            }
        }

        [DisplayName("Contact Number")]
        public string ContactNumber { get; set; }

        [DisplayName("Profile Photo")]
        public byte[] ProfilePhoto { get; set; }


        //Convert Birth-Year to INT: Function
        public int year()
        {
            return int.Parse(RSAID.Substring(0, 2));
        }

        //Get Date Today - Select Year - Convert to INT
        public int today()
        {
            var year = DateTime.Today.Year;
            string yearString = Convert.ToString(year).Substring(2, 2);
            return int.Parse(yearString);
        }

    }
}