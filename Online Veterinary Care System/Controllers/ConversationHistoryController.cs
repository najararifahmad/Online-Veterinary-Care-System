using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Online_Veterinary_Care_System.Controllers
{
    public class ConversationHistoryController : ApiController
    {
        ConversationHistoryBAL _bal = new ConversationHistoryBAL();
        // GET api/<controller>
        [HttpGet]
        [Route("api/ConversationHistory/GetConversationHistories")]
        public IHttpActionResult GetConversationHistories(string name)
        {
            return Ok(_bal.GetConversationHistories(name));
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post(string sender, string receiver, string message)
        {
            return Ok(_bal.AddConversationHistory(sender, receiver, message));
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