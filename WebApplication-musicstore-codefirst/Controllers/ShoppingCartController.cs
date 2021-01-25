using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication_musicstore_codefirst.Models;
using WebApplication_musicstore_codefirst.ViewModels;

namespace WebApplication_musicstore_codefirst.Controllers
{
    public class ShoppingCartController : Controller
    {
        private MusicStoreModel entity = new MusicStoreModel();

        public ActionResult Index()
        {
            // Set up our ViewModel
            //var viewModel = new ShoppingCartViewModel
            //{
            //    CartItems = cart.GetCartItems(),
            //    CartTotal = cart.GetTotal()
            //};
            return View();
        }

        // GET: ShoppingCart
        public ActionResult AddToCart(int id)
        {
            //add to cart logic
            if (HttpContext.Session["CartId"] == null)
            {
                HttpContext.Session["CartId"] = Request.IsAuthenticated
                    ? User.Identity.GetUserId()
                    : Guid.NewGuid().ToString();
            }

            var cartSessionId = HttpContext.Session["CartId"].ToString();
            var albumItem = entity.CardItems.FirstOrDefault(xx => xx.AlbumId == id);
            if (albumItem == null)
            {
                CartItem cartItem = new CartItem();
                cartItem.AlbumId = id;
                cartItem.CartId = cartSessionId;
                cartItem.Count = 1;
                entity.Entry(cartItem).State = EntityState.Added;
            }
            else
            {
                albumItem.Count++;

            }
            entity.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        
        [ChildActionOnly]
        public ActionResult GetCartItem()
        {
            if (HttpContext.Session["CartId"] != null)
            {
                var cartSessionKeyId = HttpContext.Session["CartId"].ToString();
                var cartItemList = entity.CardItems.Where(xx => xx.CartId == cartSessionKeyId).Include(c => c.Album)
.ToList();
                ShoppingCartViewModel viewModel=new ShoppingCartViewModel();
                viewModel.CartTotal = GetCount(cartSessionKeyId);
                viewModel.CartItems = cartItemList;
                return PartialView("Cart", viewModel);

            }
            return PartialView("Cart",new ShoppingCartViewModel());

        }
        [ NonAction]
        public decimal GetTotal(string shoppingCartId)
        {
            return entity
                .CardItems
                .Include(c => c.Album)
                .Where(c => c.CartId == shoppingCartId)
                .Select(c => c.Album.Price * c.Count)
                .Sum();
        }
        [NonAction]
        public int GetCount(string shoppingCartId)
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in entity.CardItems
                          where cartItems.CartId == shoppingCartId
                          select (int?)cartItems.Count).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
    }
}