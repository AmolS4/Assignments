using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Models
{
     public class Vendor
    {

        [Key]
        public int VendorRowId { get; set; }

        [Required]
        public string VendorId { get; set; }

        [Required]
        [ConcurrencyCheck]
        [StringLength(20)]
        public string VendorName { get; set; }

        public ICollection<Product> Products { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
    }
}
