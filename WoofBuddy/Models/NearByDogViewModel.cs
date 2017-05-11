using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class NearByDogViewModel
    {
        public int NearByDogID { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        public string FirstName { get; set; }

        public virtual Gender DogGender { get; set; }

        public DateTime Birthday { get; set; }

        public string ZipCode { get; set; }

        public string Breed { get; set; }

        public string Bio { get; set; }

        public virtual List<FileDetail> FileDetails { get; set; }
    }
}