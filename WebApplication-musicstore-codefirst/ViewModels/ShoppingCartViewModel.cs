using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication_musicstore_codefirst.Models;

namespace WebApplication_musicstore_codefirst.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }

    }
}