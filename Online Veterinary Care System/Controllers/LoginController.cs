using Online_Veterinary_Care_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoctorRegister()
        {
            return View();
        }
        public ActionResult DoctorVerification()
        {
            return View();
        }
        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
        public string GetCaptchaString()
        {
            return Session["captchastring"].ToString();
        }
    }
}