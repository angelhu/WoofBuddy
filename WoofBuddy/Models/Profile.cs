using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }

        public ApplicationUser User { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Display (Name = "Gender")]
        public virtual Gender DogGender { get; set; }

        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public string Breed { get; set; }

        public string Bio { get; set; }

        public virtual List<FileDetail> FileDetails { get; set; }

    }
}