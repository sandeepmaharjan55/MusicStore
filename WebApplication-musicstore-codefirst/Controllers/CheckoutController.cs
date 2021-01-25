using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_musicstore_codefirst.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: CreateOrder
        public ActionResult CreateOrder()
        {
            return View();
        }
        public ActionResult Complete()
        {
            return View();
        }
    }
}