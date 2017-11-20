using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;


namespace ShawnaThai_Eiei.Controllers
{
    public class RegisterController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Register
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string U_IDCard, string U_Password, string U_Name, string U_Lastname, string U_Tel) {

            User user = new User();
            user.U_IDCard = U_IDCard;
            user.U_Password = U_Password;
            user.U_Name = U_Name;
            user.U_Lastname = U_Lastname;
            user.U_Tel = U_Tel;


            if (ModelState.IsValid)
            {
                if (U_IDCard != null) 
                {
                    //var check_User = db.Users.Where(a => a.U_IDCard.Equals(U_IDCard)).FirstOrDefault<User>();
                    //if (check_User != null)
                    //{
                    //    ViewBag.Message = " Please try again.";
                    //    return View();
                    //}
                    //else
                    //{
                        try
                        {
                            db.Users.Add(user);
                            db.SaveChanges();
                            return RedirectToAction("Login", "Login");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            var errorMessages = ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage);
                            var fullErrorMessage = string.Join("; ", errorMessages);
                            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                        }
                    //}

                }

            }

            return RedirectToAction("Index", "Index");
        }
    }
}