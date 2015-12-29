using MessageServer;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sync(string groupName)
        {
            //更新组消息
            GlobalHost.ConnectionManager.GetHubContext<Buyer>().Clients.Group(groupName).updateInfo();
            return Content("");
        }
    }
}