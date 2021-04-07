using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Products>();
        }

        public int Cid { get; set; }
        public string Catname { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
