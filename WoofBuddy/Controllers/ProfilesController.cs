using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WoofBuddy.Models;

namespace WoofBuddy.Controllers
{
    [Authorize]

    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Search(SearchViewModel search)
        {
            string userID = User.Identity.GetUserId();

            var dislikes = from pl in db.ProfileLikes
                           where pl.ViewedUserID == userID && pl.Liked == false
                           select pl.LookerUserID;

            var profiles = from p in db.Profiles
                           join pl in db.ProfileLikes on new { ViewedUserID = p.UserID, LookerUserID = userID } equals new { ViewedUserID = pl.ViewedUserID, LookerUserID = pl.LookerUserID } into profilelikes
                           from pl in profilelikes.DefaultIfEmpty()
                           where pl.Liked == null && p.ZipCode == search.SearchedZipCode && p.UserID != userID && !dislikes.Contains(p.UserID)
                           select p;

            return View("NearByDogs", profiles.FirstOrDefault());
        }   

        [HttpPost]
        public ActionResult ProfileResponse(ProfileLike like)
        {
            like.LookerUserID = User.Identity.GetUserId();
            db.ProfileLikes.Add(like);
            db.SaveChanges();

            return RedirectToAction("Search", new { SearchedZipCode = Request.Form["SearchedZipCode"] });
        }

        public ActionResult Friends()
        {
            string userID = User.Identity.GetUserId();

            List<Profile> friends = (from looker in db.ProfileLikes
                                     join viewer in db.ProfileLikes on new { LookerUserID = looker.ViewedUserID, ViewedUserID = looker.LookerUserID } equals new { LookerUserID = viewer.LookerUserID, ViewedUserID = viewer.ViewedUserID }
                                     join profiles in db.Profiles on viewer.LookerUserID equals profiles.UserID
                                     where ((looker.LookerUserID == userID) && looker.Liked == true) && viewer.Liked == true
                                     orderby profiles.FirstName
                                     select profiles).ToList();

            return View(friends.ToList());

        }

        // GET: Profiles
        public ActionResult Index()
        {
            var profiles = db.Profiles.Include(p => p.User);
            return View(profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileID,UserID,FirstName,DogGender,Birthday,Bio")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", profile.UserID);
            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", profile.UserID);
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,UserID,FirstName,DogGender,Birthday,Bio")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Email", profile.UserID);
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
