using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APICore.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Products = new HashSet<Products>();
        }

        public int VendorRowId { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
