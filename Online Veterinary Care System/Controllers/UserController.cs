using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Online_Veterinary_Care_System.Controllers
{
    public class UserController : ApiController
    {
        UserBAL _bal = new UserBAL();

        [NonAction]
        public string HashPassword(string password)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        [HttpGet]
        [Route("api/User/GetUserByUsername")]
        public IHttpActionResult GetUserByUsername(string username)
        {
            return Ok(_bal.GetUserByUsername(username));
        }

        [HttpGet]
        [Route("api/User/GetDoctors")]
        public IHttpActionResult GetDoctors()
        {
            return Ok(_bal.GetDoctors());
        }

        [HttpPost]
        [Route("api/User/GenerateAdmin")]
        public IHttpActionResult GenerateAdmin(string password)
        {
            password = HashPassword(password);
            return Ok(_bal.GenerateAdmin(password));
        }

        [HttpPost]
        [Route("api/User/ApproveDoctor")]
        public IHttpActionResult ApproveDoctor(string mobile)
        {
            return Ok(_bal.ApproveDoctor(mobile));
        }

        [HttpPost]
        [Route("api/User/RejectDoctor")]
        public IHttpActionResult RejectDoctor(string mobile)
        {
            return Ok(_bal.RejectDoctor(mobile));
        }

        [HttpPost]
        [Route("api/User/SaveDoctorVerificationImages")]
        public IHttpActionResult SaveDoctorVerificationImages(User user)
        {
            return Ok(_bal.SaveDoctorVerificationImages(user));
        }

        [HttpPost]
        public IHttpActionResult Post(User user)
        {
            user.ID = Guid.NewGuid();
            user.Password = HashPassword(user.Password);
            user.AddedOn = DateTime.Now;
            return Ok(_bal.RegisterUser(user));
        }

        [HttpPost]
        [Route("api/User/UploadIdentityCardImage")]
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
                        var username = httpRequest.Form["username"];
                        var directory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/DoctorDocuments/" + username + "/IdentityCard/"));
                        if (!directory.Exists)
                            directory.Create();
                        var filePath = HttpContext.Current.Server.MapPath("~/DoctorDocuments/" + username + "/IdentityCard/" + postedFile.FileName);
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

        [HttpPost]
        [Route("api/User/UploadAadharCardImage")]
        public IHttpActionResult UploadAadharCardImage()
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
                        var directory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/DoctorDocuments/" + username + "/AadharCard/"));
                        if (!directory.Exists)
                            directory.Create();
                        var filePath = HttpContext.Current.Server.MapPath("~/DoctorDocuments/" + username + "/AadharCard/" + postedFile.FileName);
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