using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace BACSchedulingSystem.Models
{
    public enum Months{ 
        Jan = 1, 
        Feb, 
        Mar, 
        Apr, 
        May, 
        Jun, 
        Jul, 
        Aug, 
        Sep, 
        Oct, 
        Nov, 
        Dec };
    public enum States
    {
        [Description("Alabama")]
        AL,
        [Description("Alaska")]
        AK,
        [Description("Arkansas")]
        AR,
        [Description("Arizona")]
        AZ,
        [Description("California")]
        CA,
        [Description("Colorado")]
        CO,
        [Description("Connecticut")]
        CT,
        [Description("D.C.")]
        DC,
        [Description("Delaware")]
        DE,
        [Description("Florida")]
        FL,
        [Description("Georgia")]
        GA,
        [Description("Hawaii")]
        HI,
        [Description("Iowa")]
        IA,
        [Description("Idaho")]
        ID,
        [Description("Illinois")]
        IL,
        [Description("Indiana")]
        IN,
        [Description("Kansas")]
        KS,
        [Description("Kentucky")]
        KY,
        [Description("Louisiana")]
        LA,
        [Description("Massachusetts")]
        MA,
        [Description("Maryland")]
        MD,
        [Description("Maine")]
        ME,
        [Description("Michigan")]
        MI,
        [Description("Minnesota")]
        MN,
        [Description("Missouri")]
        MO,
        [Description("Mississippi")]
        MS,
        [Description("Montana")]
        MT,
        [Description("North Carolina")]
        NC,
        [Description("North Dakota")]
        ND,
        [Description("Nebraska")]
        NE,
        [Description("New Hampshire")]
        NH,
        [Description("New Jersey")]
        NJ,
        [Description("New Mexico")]
        NM,
        [Description("Nevada")]
        NV,
        [Description("New York")]
        NY,
        [Description("Oklahoma")]
        OK,
        [Description("Ohio")]
        OH,
        [Description("Oregon")]
        OR,
        [Description("Pennsylvania")]
        PA,
        [Description("Rhode Island")]
        RI,
        [Description("South Carolina")]
        SC,
        [Description("South Dakota")]
        SD,
        [Description("Tennessee")]
        TN,
        [Description("Texas")]
        TX,
        [Description("Utah")]
        UT,
        [Description("Virginia")]
        VA,
        [Description("Vermont")]
        VT,
        [Description("Washington")]
        WA,
        [Description("Wisconsin")]
        WI,
        [Description("West Virginia")]
        WV,
        [Description("Wyoming")]
        WY
    }
    public class CardData
    {

        // [StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z'''-'\s]{2,80}$",
            ErrorMessage = "Invalid Character Detected. Must be letters of 2 to 80 character lenght.")]
        [Required(ErrorMessage = "Please complete this field")]
        [DisplayName("First Name")]
        public string firstname { get; set; }

        [RegularExpression(@"^[A-Za-z'''-'\s]{2,80}$",
           ErrorMessage = "Invalid Character Detected. Must be letters of 2 to 80 character lenght.")]
        [Required(ErrorMessage = "Please complete this field")]
        [DisplayName("Last Name")]
        public string lastname { get; set; }

        [RegularExpression(@"^[0-9]{14,16}$",
            ErrorMessage = "Must be numeric of 14 to 16 digits.")]
        [Remote(action: "ValidateCardNumber", controller: "Payment", 
            ErrorMessage = "I dont feel it")]
            //[intLength(16, MinimumLength = 13)]
        [DisplayName("Card Number")]
        public string cardnumber { get; set; }

        // [StringLength(4, MinimumLength = 3)]
        [RegularExpression(@"^[0-9]{3,4}$", 
            ErrorMessage ="Must be numeric of 3 to 4 digits.")]
        [Range(000, 9999)]
        [DisplayName("CVV")]
        public int cvv { get; set; }

        //the DisplayFormat attribute is used to explicitly specify the date format
        //the ApplyFormatInEditMode setting specifies that the formatting should also be applied when the value is displayed in a text box for editing
        //[DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        //[DisplayName("Expiration Date"),
        //    DisplayFormat(DataFormatString ="{0:MM/yyyy}", ApplyFormatInEditMode =true)]
        //[DataType(DataType.Date)]
        //public DateTime expDate { get; set; } 
        [DisplayName("Month")]
         public int month { get; set; }
        [DisplayName("Year")]
        public int year { get; set; }

        //[RegularExpression(@"^[a-zA-Z0-9\s]{3, 80}$",
         //   ErrorMessage = "Invalid character detected. Valid characters must be Letters, Digits, Space or '-'.")]
        [RegularExpression(@"^[a-zA-Z0-9.'-',\s]{2,80}$")]
        [DisplayName("Address")]
        public string address { get; set; }

        [RegularExpression(@"^[A-Za-z''\s]{2,80}$", 
            ErrorMessage ="Invalid character detected. Must be all letters.")]
        [DisplayName("City")]        
        public string city { get; set; }

        [DisplayName("State")]
        public States state { get; set; }

        //[StringLength(6)]
        [RegularExpression(@"^[0-9]{5,6}$", 
            ErrorMessage ="Must be numeric of 5 to 6 digits.")]
        [DataType(DataType.PostalCode)]
        [Range(00000,99999)]
        [DisplayName("ZIP")]
        public int zipcode { get; set; }
    }
}
