using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;


namespace ShawnaThai_Eiei.Controllers
{
    public class LoginController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {

            if (ModelState.IsValid)
            {
                var checkADMIN = db.Admin_Cooperative.Where(a => a.AD_ID.Equals(username) && a.AD_Password.Equals(password)).FirstOrDefault();
                var checkUser = db.Users.Where(a => a.U_IDCard.Equals(username) && a.U_Password.Equals(password)).FirstOrDefault();

                if (checkADMIN != null)
                {
                    Session["AD_ID"] = checkADMIN.AD_ID;
                    Session["AD_Password"] = checkADMIN.AD_Password;
                    Session["AD_Name"] = checkADMIN.AD_Name;
                    Session["AD_Lastname"] = checkADMIN.AD_Lastname;
                    Session["AD_Tel"] = checkADMIN.AD_Tel;
                    return RedirectToAction("Selling", "User");

                }
                else if (checkUser != null)
                {
                    Session["U_IDCard"] = checkUser.U_IDCard;
                    Session["U_Password"] = checkUser.U_Password;
                    Session["U_Name"] = checkUser.U_Name;
                    Session["U_Lastname"] = checkUser.U_Lastname;
                    Session["U_Tel"] = checkUser.U_Tel;
                    return RedirectToAction("Selling", "User");
                }

                else
                {
                    ViewBag.Message = "ชื่อผู้ใช้ หรือรหัสผ่านผิด";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {

            if (HttpContext.Session == null)
            {
                return RedirectToAction("Index", "Index");
            }
            else if (HttpContext.Session != null)
            {
                FormsAuthentication.SignOut();
                HttpContext.Session.Abandon();
            }
            return RedirectToAction("Index", "Index");

        }

    }

    
}