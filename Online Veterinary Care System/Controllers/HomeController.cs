using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Vaccination()
        {
            return View();
        }
        public ActionResult Information()
        {
            InformationBAL _bal = new InformationBAL();
            IEnumerable<DAL.Models.InformationDissemination> ids = _bal.GetInformationDisseminations();
            return View(ids);
        }
        [HttpGet]
        public System.Web.Mvc.FileContentResult DownloadVaccination()
        {
            string contentType = "text/html";
            string fileName = "Vaccination.html";

            InformationBAL _bal = new InformationBAL();

            var content = _bal.DownloadVaccination().ToArray();

            return File(content, contentType, fileName);
        }
        [HttpGet]
        public System.Web.Mvc.FileContentResult DownloadFertilityManagement()
        {
            string contentType = "text/html";
            string fileName = "FertilityManagement.html";

            InformationBAL _bal = new InformationBAL();

            var content = _bal.DownloadFertilityManagement().ToArray();

            return File(content, contentType, fileName);
        }
        [HttpGet]
        public System.Web.Mvc.FileContentResult DownloadHygenicMilk()
        {
            string contentType = "text/html";
            string fileName = "HygenicMilk.html";

            InformationBAL _bal = new InformationBAL();

            var content = _bal.DownloadHygenicMilk().ToArray();

            return File(content, contentType, fileName);
        }
    }
}
