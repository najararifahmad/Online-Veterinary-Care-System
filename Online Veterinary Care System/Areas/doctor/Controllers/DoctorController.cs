using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Areas.doctor.Controllers
{
    public class DoctorController : Controller
    {
        // GET: doctor/Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appointments()
        {
            return View();
        }

        public ActionResult BookingSlots()
        {
            return View();
        }

        public ActionResult AddBookingSlot()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult Chat(string receiver)
        {
            return View();
        }
        public ActionResult Messages()
        {
            return View();
        }
    }
}