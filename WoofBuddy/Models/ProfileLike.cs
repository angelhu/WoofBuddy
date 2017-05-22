using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class ProfileLike
    {
        public int ProfileLikeID { get; set; }

        public ApplicationUser LookerUser { get; set; }
        public string LookerUserID { get; set; }

        public ApplicationUser ViewedUser { get; set; }
        public string ViewedUserID { get; set; }

        public bool Liked { get; set; }
    }
}