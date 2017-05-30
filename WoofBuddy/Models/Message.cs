using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        public ApplicationUser ToUser { get; set; }
        public string ToUserID { get; set; }

        public ApplicationUser FromUser { get; set; }
        public string FromUserID { get; set; }

        public string Body { get; set; }
        public DateTime SentTime { get; set; }
    }
}