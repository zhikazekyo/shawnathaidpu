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
    public class RegisterAdminController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Register
        public ActionResult RegisterAdmin()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAdmin(string AD_ID, string AD_Password, string AD_Name, string AD_Lastname, string AD_Tel)
        {

            Admin_Cooperative admin_Cooperative = new Admin_Cooperative();
            admin_Cooperative.AD_ID = AD_ID;
            admin_Cooperative.AD_Password = AD_Password;
            admin_Cooperative.AD_Name = AD_Name;
            admin_Cooperative.AD_Lastname = AD_Lastname;
            admin_Cooperative.AD_Tel = AD_Tel;


            if (ModelState.IsValid)
            {
                if (AD_ID != null)
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
                        db.Admin_Cooperative.Add(admin_Cooperative);
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