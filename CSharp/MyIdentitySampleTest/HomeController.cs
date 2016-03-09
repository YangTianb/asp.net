using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyIdentitySampleTest
{
   
    public class HomeController: Controller
    {
        
        
        
        public ActionResult Index()
        {
        
        

            return View();
        }
        [Authorize(Roles = "Managers")]
        public ActionResult Managers()
        {

            return View();
        }

    }
}