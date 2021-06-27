using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Models
{
    public class Order
    {

        [Key]
        public int OrderRowId { get; set; }

        [Required]
        public string OrderId { get; set; }

        [Required]
        public int ProductRowId { get; set; }
        [Required]
        public int CustomerRowId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public Customer Customer { get; set; } // Referential Integrity 
    }
}
