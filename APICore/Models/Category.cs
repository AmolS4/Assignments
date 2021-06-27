using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace APICore.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
        }

        public int CatId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
