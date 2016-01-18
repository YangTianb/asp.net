using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string id, string name, string type, string lastModifiedDate, int size, HttpPostedFileBase file)
        {
            return this.Content("");
        }

    }
}