using ActiveUp.Net.Dns;
using ActiveUp.Net.Mail;
using BAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Doctors()
        {
            UserBAL _bal = new UserBAL();

            var doctors = _bal.GetDoctors();

            return View(doctors);
        }
        public ActionResult Vaccination()
        {
            return View();
        }
        public ActionResult Information()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult InformationDissemination()
        {
            InformationBAL _bal = new InformationBAL();
            IEnumerable<InformationDissemination> ids = _bal.GetInformationDisseminations();
            return View(ids);
        }
        public ActionResult AddInformationDissemination()
        {
            return View();
        }

        public ActionResult MailBox()
        {
            Imap4Client client = new Imap4Client();

            client.ConnectSsl("imap.gmail.com", 993);
            client.Login(ConfigurationManager.AppSettings["fromEmail"], ConfigurationManager.AppSettings["fromPassword"]);

            Mailbox mails = client.SelectMailbox("inbox");
            MessageCollection messages = mails.SearchParse("ALL");

            return View(messages);
        }
        public ActionResult Chat(string receiver)
        {
            return View();
        }
        public ActionResult Messages()
        {
            UserBAL _bal = new UserBAL();
            IEnumerable<User> doctors = _bal.GetActiveDoctors();
            return View(doctors);
        }
    }
}