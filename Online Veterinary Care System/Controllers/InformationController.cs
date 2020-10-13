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

        [HttpPost]
        [Route("api/Information/AddInformationDissemination")]
        public IHttpActionResult AddInformationDissemination([FromBody] InformationDissemination id)
        {
            return Ok(_bal.AddInformationDissemination(id));
        }

        [HttpPost]
        [Route("api/Information/UploadInformationDisseminationFile")]
        public IHttpActionResult UploadIdentityCardImage()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var directory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/InformationDissemination/"));
                        if (!directory.Exists)
                            directory.Create();
                        var filePath = HttpContext.Current.Server.MapPath("~/InformationDissemination/" + postedFile.FileName);
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
    }
}