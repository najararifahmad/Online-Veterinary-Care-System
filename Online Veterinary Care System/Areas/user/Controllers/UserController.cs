using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Areas.user.Controllers
{
    public class UserController : Controller
    {
        // GET: user/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appointments()
        {
            return View();
        }

        public ActionResult BookAppointment()
        {
            return View();
        }
    }
}