using OptisourceProject.FrontEnd.Models;
using OptisourceProject.FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OptisourceProject.FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel login)
        {

            if (ModelState.IsValid)
            {
                TempData["loginName"] = login.Name;
                FormsAuthentication.RedirectFromLoginPage(login.Email, login.RememberMe);
                
            }
            

            ViewBag.ErrorLoginMessage = login.ErrorMessage;

            return View(login);
        }
    }
}