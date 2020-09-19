using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Veterinary_Care_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}