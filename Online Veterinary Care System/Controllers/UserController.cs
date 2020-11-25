using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Http;
using ActiveUp.Net.Mail;
using System.Configuration;
using DAL;

namespace Online_Veterinary_Care_System.Controllers
{
    public class UserController : ApiController
    {
        UserBAL _bal = new UserBAL();
        private Imap4Client client = new Imap4Client();

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

        [HttpPost]
        [Route("api/User/SendMail")]
        public IHttpActionResult SendMail(string id, string toEmail, string doctorName, string mobile)
        {
            try
            {
                string fromAddress = ConfigurationManager.AppSettings["fromEmail"];
                string toAddress = toEmail;
                string fromPassword = ConfigurationManager.AppSettings["fromPassword"];
                string subject = "Doctor Confirmation Email";
                string body = "Sir,<br/> Please confirm if " + doctorName + " having Mobile No " + mobile +
                              " is working in your hospital.<br/><br/><b>Regards<br/>Online Veterinary Care System</b>";

                var smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }

                VCDbContext _context = new VCDbContext();
                Guid actualId = Guid.Parse(id);
                var user = _context.Users.FirstOrDefault(u => u.ID == actualId);
                if(user != null)
                {
                    user.ConfirmationMailSent = true;
                    _context.SaveChanges();
                }

                return Ok("Confirmation Email Sent.");
            }
            catch(Exception ex)
            {
                return Ok("Error occured. " + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/User/GetDoctors")]
        public IHttpActionResult GetDoctors()
        {
            return Ok(_bal.GetDoctors());
        }

        [HttpGet]
        [Route("api/User/GetUsers")]
        public IHttpActionResult GetUsers()
        {
            return Ok(_bal.GetUsers());
        }

        [HttpGet]
        [Route("api/User/GetActiveDoctors")]
        public IHttpActionResult GetActiveDoctors()
        {
            return Ok(_bal.GetActiveDoctors());
        }
        [HttpGet]
        [Route("api/User/GetAppointmentsForUser")]
        public IHttpActionResult GetAppointmentsForUser(string mobile)
        {
            return Ok(_bal.GetAppointmentsForUser(mobile));
        }
        [HttpGet]
        [Route("api/User/GetAppointmentsForDoctor")]
        public IHttpActionResult GetAppointmentsForDoctor(string mobile)
        {
            return Ok(_bal.GetAppointmentsForDoctor(mobile));
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
        [Route("api/User/ActivateUser")]
        public IHttpActionResult ActivateUser(string mobile)
        {
            return Ok(_bal.ActivateUser(mobile));
        }

        [HttpPost]
        [Route("api/User/DeactivateUser")]
        public IHttpActionResult DeactivateUser(string mobile)
        {
            return Ok(_bal.DeactivateUser(mobile));
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

        [HttpDelete]
        public IHttpActionResult Delete(string mobile)
        {
            return Ok(_bal.DeleteDoctor(mobile));
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
        [HttpPost]
        [Route("api/User/ChangePassword")]
        [Authorize(Roles = "Admin,Doctor,User")]
        public IHttpActionResult ChangePassword(string mobile, string oldPassword, string newPassword)
        {
            newPassword = HashPassword(newPassword);
            oldPassword = HashPassword(oldPassword);
            return Ok(_bal.ChangePassword(mobile, oldPassword, newPassword));
        }
        [HttpPost]
        [Route("api/User/VerifyCaptcha")]
        public IHttpActionResult VerifyCaptcha(string token, string secretKey)
        {
            return Ok(_bal.VerifyRecaptcha(token, secretKey));
        }
    }
}