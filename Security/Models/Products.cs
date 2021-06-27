using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Security.Models
{
    public partial class Products
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int UnitPrice { get; set; }
        public int? CatId { get; set; }

        public virtual Category Cat { get; set; }
    }
}
