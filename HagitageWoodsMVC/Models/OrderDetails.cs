using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int? Userid { get; set; }
        public int? Pid { get; set; }
        public double? OrderAmount { get; set; }
        public double? ShippingCharge { get; set; }
        public int? OrderQuantity { get; set; }
        public string OrderEmail { get; set; }
        public string OrderMobile { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderAdress { get; set; }

        public virtual Products P { get; set; }
        public virtual Users User { get; set; }
    }
}
