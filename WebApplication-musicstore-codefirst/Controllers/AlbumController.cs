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

        // GET: Album/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(entity.Genres.ToList(), "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(entity.Artists.ToList(),"ArtistId","Name");

            return View();
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(Album model,HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        try
                        {
                            string fileName = image.FileName;
                            string serverPath = Server.MapPath("~/Images/");
                            string FullPath = Path.Combine(serverPath + fileName);
                            image.SaveAs(FullPath);
                            model.AlbumArtUrl = "/Images/" + fileName;
                        }
                        catch (Exception ex)
                        {

                            model.AlbumArtUrl =
                                "https://lh3.googleusercontent.com/proxy/kbLsQWyWYevLLa1K4XcPAW91JQKXM3mfr2TPCiNHqmxIzUZ3T12Jwr5ynH1ZPqbIN0-5GKRifmPm1ji8mv5GV-KXsfEdDbd-2eCT6ygj3lY8";
                        }

                    }
                    // TODO: Add insert logic here
                    // entity.Albums.Add(model); 
                    // OR
                    model.CreatedBy = User.Identity.GetUserId();
                    entity.Entry(model).State = EntityState.Added;
                    entity.SaveChanges();
                    TempData["SuccessMessage"] = "Successfully created Album";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Form validation error";
                    ViewData["ErrorMessage"] = "Form validation error";

                    ViewBag.GenreId = new SelectList(entity.Genres.ToList(), "GenreId", "Name");
                    ViewBag.ArtistId = new SelectList(entity.Artists.ToList(), "ArtistId", "Name");
                    return View();

                }
            }
            catch
            {
                ViewBag.ErrorMessage = "oops something went wrong";
                ViewBag.GenreId = new SelectList(entity.Genres.ToList(), "GenreId", "Name");
                ViewBag.ArtistId = new SelectList(entity.Artists.ToList(), "ArtistId", "Name");
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            var model = entity.Albums.FirstOrDefault(xx => xx.AlbumId == id);
            ViewBag.GenreId = new SelectList(entity.Genres.ToList(), "GenreId", "Name", model.GenreId);
            ViewBag.ArtistId = new SelectList(entity.Artists.ToList(), "ArtistId", "Name",model.ArtistId);
            return View(model);
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Album collection)
        {
            try
            {
                // TODO: Add update logic here
                entity.Entry(collection).State = EntityState.Modified;
                entity.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            var model = entity.Albums.FirstOrDefault(xx => xx.AlbumId == id);
            return View(model);
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Album collection)
        {
            try
            {
                collection = entity.Albums.FirstOrDefault(xx => xx.AlbumId == id);
                entity.Entry(collection).State = EntityState.Deleted;
                entity.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
