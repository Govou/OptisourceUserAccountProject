using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptisourceProject.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            if (TempData["loginName"] != null)
            {
                ViewBag.LoginName = TempData["loginName"] as string;
            }
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
           
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
        
            return View();
        }
    }
}