using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Veterinary_Care_System.Controllers
{
    public class ConversationController : ApiController
    {
        ConversationBAL _bal = new ConversationBAL();
        // GET api/<controller>
        [HttpGet]
        [Route("api/Conversation/GetConversations")]
        public IHttpActionResult GetConversations(string sender, string receiver)
        {
            return Ok(_bal.GetConversations(sender, receiver));
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Conversation conversation)
        {
            return Ok(_bal.AddMessage(conversation));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}