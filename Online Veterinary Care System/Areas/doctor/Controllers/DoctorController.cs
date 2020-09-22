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
    }
}