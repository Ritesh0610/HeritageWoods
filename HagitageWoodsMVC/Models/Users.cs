using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class Users
    {
        public Users()
        {
            Cart = new HashSet<Cart>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Userid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Mobile { get; set; }
        public string UCity { get; set; }
        public string Ustate { get; set; }
        public string UCountry { get; set; }
        public string UZip { get; set; }
        public DateTime? RegDate { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
