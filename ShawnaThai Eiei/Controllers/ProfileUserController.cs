using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;

namespace ShawnaThai_Eiei.Controllers
{
    public class ProfileUserController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Profile
        [HttpGet]
        public ActionResult ShowUser(int? id)
        {
            var U_IDCard = this.Session["U_IDCard"];

            User user = db.Users.Find(U_IDCard);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (id == 1)
            {
                ViewBag.ok = "OK";
                return View(user);
            }
            return View(user);
        }

        public ActionResult EditUser()
        {
            var U_IDCard = this.Session["U_IDCard"];

            User user = db.Users.Find(U_IDCard);
            if (user == null)
            {
                return HttpNotFound();
            }

            string Update_IDCard = Request.Form["Update_IDCard"];
            string Update_Name = Request.Form["Update_Name"];
            string Update_Lastname = Request.Form["Update_Lastname"];
            string Update_Tel = Request.Form["Update_Tel"];

            if (ModelState.IsValid)
            {
                if (Update_IDCard != null)
                {
                    var check_edit = db.Users.Where(a => a.U_IDCard.Equals(Update_IDCard)).FirstOrDefault();

                    check_edit.U_Name = Update_Name;
                    check_edit.U_Lastname = Update_Lastname;
                    check_edit.U_Tel = Update_Tel;

                    try
                    {
                        db.SaveChanges();

                        Session["U_Name"] = check_edit.U_Name;
                        Session["U_Lastname"] = check_edit.U_Lastname;
                        Session["U_Tel"] = check_edit.U_Tel;
                        ViewBag.ok = "OK";
                        return RedirectToAction("ShowUser", "ProfileUser", new { id = 1 });
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
            return View(user);
        }
        public ActionResult ChangePassUser(User user)
        {

            string IDCard = Request.Form["U_IDCard"];
            string Password = Request.Form["U_Password"];
            string New_Password = Request.Form["U_New_Password"];
            string New_Password_Again = Request.Form["U_New_Password_Again"];

            if (Password != null)
            {
                var check = db.Users.Where(b => b.U_IDCard.Equals(IDCard)).FirstOrDefault<User>();

                if (check.U_Password == Password)
                {
                    if (New_Password == New_Password_Again)
                    {
                        check.U_Password = New_Password;
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