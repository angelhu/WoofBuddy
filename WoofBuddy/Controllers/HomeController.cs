using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WoofBuddy.Models;

namespace WoofBuddy.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(SearchViewModel search)
        {
            return View("NearByDogs", db.Profiles.Where(p => p.ZipCode == search.SearchedZipCode || string.IsNullOrEmpty(search.SearchedZipCode)).ToList());
        }

        
    }
}