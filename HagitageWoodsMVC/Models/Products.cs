using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Pid { get; set; }
        public int? Cid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Stock { get; set; }
        public string ProductImage { get; set; }
        [NotMapped]
        [DisplayName("Upload Product Pic")]
        public IFormFile ProductPic { get; set; }

        public virtual ProductCategory C { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
