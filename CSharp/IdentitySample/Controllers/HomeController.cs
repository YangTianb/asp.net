using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            var claims = HttpContext.GetOwinContext().Authentication.User.Claims;
            var firstOrDefault = claims.FirstOrDefault(item => item.Type.Equals("Id"));
            if (firstOrDefault != null)
            {
                var id = firstOrDefault.Value;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}