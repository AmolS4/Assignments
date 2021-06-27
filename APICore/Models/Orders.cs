using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APICore.Models
{
    public partial class Orders
    {
        public int OrderRowId { get; set; }
        public string OrderId { get; set; }
        public int ProductRowId { get; set; }
        public int CustomerRowId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public virtual Customers CustomerRow { get; set; }
    }
}
