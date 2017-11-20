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
        ShawnaThai_DB_Azure_V3Entities db = new ShawnaThai_DB_Azure_V3Entities();
        // GET: ForgotPassword
        [HttpGet]


        public ActionResult SelectForgot()
        {

        }

        public ActionResult ForgotUserID()
        {
            string email_FG = Request.Form["IDCard"];
            var check = db.Profiles.Where(b => b.Email.Equals(email_FG)).FirstOrDefault<Profile>();
            if (check != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                check.Password = finalString;
                db.SaveChanges();
                using (MailMessage mm = new MailMessage("shawnathaidpu@gmail.com", check.Email))
                {
                    mm.Subject = "Reset Password";

                    mm.Body = "รหัสผ่านใหม่ของคุณคือ : " + check.Password;


                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("shawnathaidpu@gmail.com", "Gear2404");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);

                    }
                }
                return RedirectToAction("NextStep", "Forgetpassword");
            }

            return View();

        }

        public ActionResult ForgotAdminID()
        {
            string User_Email = Request.Form["User_Email"];
            string IDCard = Request.Form["IDCard"];
            string User_Tel = Request.Form["User_Tel"]
            var check = db.Users.Where(b => b.Email.Equals(IDCard).FirstOrDefault<User>();
            if (check != null)
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                check.U_Password = finalString;
                db.SaveChanges();
                using (MailMessage MailMess = new MailMessage("shawnathaidpu@gmail.com", check.Email))
                {
                    MailMess.Subject = "Reset Password";

                    MailMess.Body = "รหัสผ่านใหม่ของคุณคือ : " + check.Password;


                    MailMess.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("shawnathaidpu@gmail.com", "Gear2404");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);

                    }
                }
                return RedirectToAction("NextStep", "Forgetpassword");
            }

            return View();

        }

        public ActionResult NextStep()
        {
            return View();
        }
    }
}