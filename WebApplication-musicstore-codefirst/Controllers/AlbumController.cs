using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication_musicstore_codefirst.Models;

namespace WebApplication_musicstore_codefirst.Controllers
{
    public class AlbumController : Controller
    {
       private  MusicStoreModel entity = new MusicStoreModel();
        //var usermanager = new ApplicationUserManager(IUserStore<ApplicationUser>);
        // GET: Album
        public ActionResult Index()
        {
            var albumList = entity.Albums.ToList();
            //foreach (var album in albumList)
            //{
            //    album.CreatedByName=
            //}
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByName(User.Identity.Name);
            return View(albumList);
        }

        [ChildActionOnly]
        public ActionResult FeatureAlbum()
        {
            var albumList = entity.Albums.Where(xx=>xx.IsFeatured).ToList();
            //  var albumList =from album in entity.Albums where album.IsFeatured select album;

            return PartialView(albumList);
        }

        // GET: Album/Details/5
        public ActionResult Details(int id)
        {
            var album = entity.Albums.FirstOrDefault(xx=>xx.AlbumId==id);

            return View(album);
        }
    }
}
