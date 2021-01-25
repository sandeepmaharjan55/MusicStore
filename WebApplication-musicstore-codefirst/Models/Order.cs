using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace WebApplication_musicstore_codefirst.Models
{
    public class Order
    {
        [BindNever]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(40)]
        public string City { get; set; }

        [Required]
        [StringLength(24)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }
    }

}