using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EshopAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderitems = new HashSet<Orderitems>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Varienty { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; }
        public virtual ICollection<Orderitems> Orderitems { get; set; }
    }
}
