using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Areas.doctor
{
    public class doctorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "doctor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "doctor_default",
                "doctor/{action}/{id}",
                new { controller = "Doctor", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}