using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyIdentitySampleTest
{
    [Authorize]
    public class HomeController: Controller
    {
        [Authorize(Roles = "Users")]
        public ActionResult Index()
        {
            var user = User.Identity.Name;

            return View();
        }
        [Authorize(Roles = "Managers")]
        public ActionResult Managers()
        {

            return View();
        }

    }
}