using BAL;
using System;
using System.Collections.Generic;
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
    }
}