using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class FileDetail
    {
        public Guid FileDetailID { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int ProfileID { get; set; }
        public virtual Profile Profile { get; set; }
    }
}