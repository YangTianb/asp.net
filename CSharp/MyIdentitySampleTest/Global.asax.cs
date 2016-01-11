using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.WebSockets;

namespace MyIdentitySampleTest
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Jess Liu"), new Claim(ClaimTypes.Role, "Users") };
            var identity = new ClaimsIdentity(claims, "MyClaimsLogin");
            ClaimsPrincipal principla = new ClaimsPrincipal(identity);

            HttpContext.Current.User = principla;
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        
  
    }
}