using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenExpert.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [Authorize(Roles = "系统管理员")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}