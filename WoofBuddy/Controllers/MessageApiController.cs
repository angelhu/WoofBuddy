using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WoofBuddy.Models;

namespace WoofBuddy.Controllers
{
    public class MessageApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET api/<controller>/5
        public IEnumerable<Message> Get(string id)
        {
            string friendUserID = id;
            string currentUserID = User.Identity.GetUserId();
            //Searching for messages between toUserID and fromUserID
            var messages = from message in db.Messages
                           where (message.FromUserID == friendUserID && message.ToUserID == currentUserID)
                                  || (message.FromUserID == currentUserID && message.ToUserID == friendUserID)
                           orderby message.SentTime
                           select message;

            return messages;
        }

        // POST api/<controller>
        public Message Post([FromBody]Message message)
        {
            message.SentTime = DateTime.Now;
            message.FromUserID = User.Identity.GetUserId();

            db.Messages.Add(message);
            db.SaveChanges();

            return message;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}