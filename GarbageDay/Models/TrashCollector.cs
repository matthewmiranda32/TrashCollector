using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageDay.Models
{
    public class TrashCollector
    {
        [Key]
        
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        
        public Customer Customer { get; set; }
        [Display(Name = "Customer")]

        [ForeignKey("Customer")]
        public int Customerid { get; set; }

    }
}