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
    public class InformationController : ApiController
    {
        InformationBAL _bal = new InformationBAL();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(_bal.GetInformation());
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Information information)
        {
            return Ok(_bal.AddUpdateInformation(information));
        }
    }
}