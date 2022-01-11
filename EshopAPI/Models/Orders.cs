using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EshopAPI.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderitems = new HashSet<Orderitems>();
        }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
        public string Status { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SalesPersons SalesPerson { get; set; }
        public virtual ICollection<Orderitems> Orderitems { get; set; }
    }
}
