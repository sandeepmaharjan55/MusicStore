using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_musicstore_codefirst.Models;

namespace WebApplication_musicstore_codefirst.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreModel entity = new MusicStoreModel();

        public ActionResult Index()
        {
           // var albumList = entity.Albums.Where(xx=>xx.IsFeatured).ToList();

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderLeftMenu()
        {
            var genres = entity.Genres.Select(x=> x.Name).ToList();
            return PartialView("LeftMenu", genres);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           // var albumList = entity.Albums.Where(xx => xx.IsFeatured).ToList();

            return View();
        }
    }
}