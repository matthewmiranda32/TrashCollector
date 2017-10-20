using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageDay.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
               
        public AddressBook AddressBook { get; set; }

        [Display(Name = "Address")]
        [ForeignKey("AddressBook")]
        public int Addressid { get; set; }

        [Display(Name = "Pickup Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string Pickup_Day { get; set; }
        
        [Display (Name = "Payment")]
        public double Payment { get; set; }
    }
}