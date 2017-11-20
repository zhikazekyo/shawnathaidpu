using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;

namespace ShawnaThai_Eiei.Controllers
{
    public class ProfileAdminController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Profile
        [HttpGet]
        public ActionResult ShowAdmin(int? id)
        {
            var AD_ID = this.Session["AD_ID"];

            Admin_Cooperative admin_Cooperative = db.Admin_Cooperative.Find(AD_ID);
            if (admin_Cooperative == null)
            {
                return HttpNotFound();
            }
            if (id == 1)
            {
                ViewBag.ok = "OK";
                return View(admin_Cooperative);
            }
            return View(admin_Cooperative);
        }

        public ActionResult EditAdmin()
        {
            var AD_ID = this.Session["AD_ID"];

            Admin_Cooperative admin_Cooperative = db.Admin_Cooperative.Find(AD_ID);
            if (admin_Cooperative == null)
            {
                return HttpNotFound();
            }

            string Update_ID = Request.Form["Update_ID"];
            string Update_Name = Request.Form["Update_Name"];
            string Update_Lastname = Request.Form["Update_Lastname"];
            string Update_Tel = Request.Form["Update_Tel"];

            if (ModelState.IsValid)
            {
                if (Update_ID != null)
                {
                    var check_edit = db.Admin_Cooperative.Where(a => a.AD_ID.Equals(Update_ID)).FirstOrDefault();

                    check_edit.AD_Name = Update_Name;
                    check_edit.AD_Lastname = Update_Lastname;
                    check_edit.AD_Tel = Update_Tel;

                    try
                    {
                        db.SaveChanges();

                        Session["AD_Name"] = check_edit.AD_Name;
                        Session["AD_Lastname"] = check_edit.AD_Lastname;
                        Session["AD_Tel"] = check_edit.AD_Tel;
                        ViewBag.ok = "OK";
                        return RedirectToAction("ShowAdmin", "ProfileAdmin", new { id = 1 });
                        //return View();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        var errorMessages = ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

                    }
                }
            }
            return View(admin_Cooperative);
        }
        public ActionResult ChangePassAdmin(Admin_Cooperative admin_Cooperative)
        {

            string ID = Request.Form["AD_ID"];
            string Password = Request.Form["AD_Password"];
            string New_Password = Request.Form["AD_New_Password"];
            string New_Password_Again = Request.Form["AD_New_Password_Again"];

            if (Password != null)
            {
                var check = db.Admin_Cooperative.Where(b => b.AD_ID.Equals(ID)).FirstOrDefault<Admin_Cooperative>();

                if (check.AD_Password == Password)
                {
                    if (New_Password == New_Password_Again)
                    {
                        check.AD_Password = New_Password;
                        db.SaveChanges();
                        ViewBag.ok = "OK";
                        //return JavaScript(alert("Hello this is an alert"));
                        // return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");

                    }
                    else
                    {
                        ViewBag.Error2 = "รหัสผ่านไม่ตรงกัน";
                    }
                }
                else
                {
                    ViewBag.Error1 = "รหัสผ่านไม่ถูกต้อง";
                }

            }


            return View();
        }
    }
}