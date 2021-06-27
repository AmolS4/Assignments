using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Models
{
     public class Customer
    {
		[Key]
		public int CustomerRowId { get; set; }

		public int CustomerId { get; set; }

		[Required]
		[ConcurrencyCheck]
		[StringLength(20)]
		public string CustomerName { get; set; }

		[Required]
		[StringLength(20)]
		public string Address { get; set; }

		[Required]
		[StringLength(20)]
		public string City { get; set; }


		public int Age { get; set; }

		public ICollection<Order> Orders { get; set; }




	}
}
