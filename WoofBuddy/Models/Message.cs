using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoofBuddy.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        public string ToUser { get; set; }
        public int ToUserID { get; set; }

        public string FromUser { get; set; }
        public int FromUserID { get; set; }

        public string Body { get; set; }
        public DateTime SentTime { get; set; }
    }
}