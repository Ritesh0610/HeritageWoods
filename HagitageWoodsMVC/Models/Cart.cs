using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class Cart
    {
        public int Cartid { get; set; }
        public int? Userid { get; set; }
        public int? Pid { get; set; }
        public int? Qty { get; set; }

        public virtual Products P { get; set; }
        public virtual Users User { get; set; }
    }
}
