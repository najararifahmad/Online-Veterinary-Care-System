using BAL;
using DAL.Models;
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
    }
}