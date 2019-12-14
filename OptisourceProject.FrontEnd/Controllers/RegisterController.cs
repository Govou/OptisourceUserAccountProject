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
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                TempData["loginName"] = register.Name;
                FormsAuthentication.RedirectFromLoginPage(register.UserName, register.RememberMe);
            }

            ViewBag.ErrorRegisterMessage = register.ErrorMessage;
            //  ViewBag.ResponseMessage = serviceResponse.ResponseDescription;

            return View(register);
        }
    }
}