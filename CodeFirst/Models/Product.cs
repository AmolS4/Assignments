using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Models
{
    public class Product
    {

        [Key]
        public int ProductRowId { get; set; }

        
        public string ProductId { get; set; }

        //[Required]
        //public string VendorId { get; set; }


        [Required]
        [ConcurrencyCheck]
        [StringLength(20)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }
        public int UnitPrice { get; set; }

        public int VendorRowId { get; set; }
        public Vendor Vendor { get; set; } // Referential Integrity 
    }
}
