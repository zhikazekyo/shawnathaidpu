using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;

namespace ShawnaThai_Eiei.Controllers
{
    public class ForgotPasswordController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: ForgotPassword
        [HttpGet]


        public ActionResult SelectForgot()
        {
            return View();
        }

        public ActionResult ForgotUserID()
        {
            

            return View();

        }

        public ActionResult ForgotAdminID()
        {
            

            return View();

        }

        public ActionResult NextStep()
        {
            return View();
        }
    }
}