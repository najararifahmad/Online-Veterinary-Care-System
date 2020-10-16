using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        [HttpPost]
        [Route("api/Conversation/UploadFile")]
        public IHttpActionResult UploadFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var username = httpRequest.Form["username"];
                        var directory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Chats/" + username + "/"));
                        if (!directory.Exists)
                            directory.Create();
                        var filePath = HttpContext.Current.Server.MapPath("~/Chats/" + username + "/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                    }
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Ok(false);
            }
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