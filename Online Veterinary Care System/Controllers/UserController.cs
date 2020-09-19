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
    public class UserController : ApiController
    {
        UserBAL _bal = new UserBAL();
        public IHttpActionResult GetUserByUsername(string username)
        {
            return Ok(_bal.GetUserByUsername(username));
        }

        public IHttpActionResult RegisterUser([FromBody] User user)
        {
            return Ok(_bal.RegisterUser(user));
        }
    }
}