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
        public ActionResult UploadPost()
        {
            var file = Request.Files[0];

            return this.Content("");
        }

    }
}