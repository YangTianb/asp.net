using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpClient _httpClient;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:42333");
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1234");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");
            

            var tolen = _httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters))
                .Result.Content.ReadAsStringAsync().Result;


            Response.Write(tolen);
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