
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ShawnaThai_Eiei.Models;
using System.Data.Entity.Validation;
using System.IO;

namespace ShawnaThai_Eiei.Controllers
{

    public class PostSellController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();

        // GET: RegistorDriver
        public ActionResult PostSell()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult PostSell(string ProD_IDSell, string ProD_Pic, string ProD_Moisture, string ProD_Weight, string ProD_Price, string ProD_CertiWeightRice,
         string RType_NID, string Farmer_IDCard)
        {
            Product_Rice post = new Product_Rice();
            post.ProD_IDSell = ProD_IDSell;
            post.ProD_Pic = ProD_Pic;
            post.ProD_Moisture = ProD_Moisture;
            post.ProD_Weight = ProD_Weight;
            post.ProD_Price = ProD_Price;
            post.ProD_CertiWeightRice = ProD_CertiWeightRice;
            post.RType_NID = RType_NID;
            post.Farmer_IDCard = Farmer_IDCard;




            //RiceType ricetype = new RiceType();
            //ricetype.RType_NID = RType_NID;
            ////ricetype.RType_Name = RType_Name;
            ////ricetype.RType_Nape = false;
            ////ricetype.RType_Napung = false;

            //Farmer farmers = new Farmer();
            //farmers.Farmer_IDCard = Farmer_IDCard;
            //farmers.Farmer_Name = Farmer_Name;
            //farmers.Farmer_LastName = Farmer_LastName;
            //farmers.Farmer_Tel = Farmer_Tel;
            //farmers.Farmer_A_No = Farmer_A_No;
            //farmers.Farmer_A_Sup = Farmer_A_Sup;
            //farmers.Farmer_A_District = Farmer_A_District;
            //farmers.Coop_Name = Coop_Name;

            if (ModelState.IsValid)
            {
                if (ProD_IDSell != null)
                {
                    var check_Post = db.Product_Rice.Where(a => a.ProD_IDSell.Equals(ProD_IDSell)).FirstOrDefault<Product_Rice>();
                    if (check_Post != null)
                    {
                        ViewBag.Message = " Please try again.";
                        return View();
                    }
                    else
                    {
                        try
                        {
                            db.Product_Rice.Add(post);
                            //db.RiceTypes.Add(ricetype);
                            //db.Farmers.Add(farmers);
                            db.SaveChanges();
                            return RedirectToAction("PostSell", "PostSell");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            var errorMessages = ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).Select(e => e.ErrorMessage);
                            var fullErrorMessage = string.Join("; ", errorMessages);
                            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                        }
                    }

                }

            }

            return RedirectToAction("PostSell", "PostSell");
        }
    }
}