using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EshopAPI.Models
{
    //public partial class Customer
    //
    public class Customer
        //public Customer()
        //{
        //    Orders = new HashSet<Orders>();
        //}
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter FirstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
