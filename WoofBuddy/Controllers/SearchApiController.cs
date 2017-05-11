using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WoofBuddy.Models;

namespace WoofBuddy.Controllers
{
    public class SearchApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();


        // POST: api/SearchApi
        public IEnumerable<Profile> Post(SearchViewModel search)

        {
            return db.Profiles.Where(p => p.ZipCode.Equals(search.SearchedZipCode));
        }
    }
}
