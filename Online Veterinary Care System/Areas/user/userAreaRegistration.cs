using System.Web.Mvc;

namespace Online_Veterinary_Care_System.Areas.user
{
    public class userAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "user";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "user_default",
                "user/{action}/{id}",
                new { action = "Index", controller = "User", id = UrlParameter.Optional }
            );
        }
    }
}