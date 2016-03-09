using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

namespace BaseLibrary
{
    public class ManageUserExtend:Controller
    {
        public string GetUserId()
        {
            var id = string.Empty;
            var claims = HttpContext.GetOwinContext().Authentication.User.Claims;
            var firstOrDefault = claims.FirstOrDefault(item => item.Type.Equals("Id"));
            if (firstOrDefault != null)
            {
                id = firstOrDefault.Value;
            }
            return id;
        }
    }
}
