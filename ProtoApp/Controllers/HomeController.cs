using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ProtoApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //To enable caching on an action
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]

        /* 
         To disable caching on an action
         [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
         */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}