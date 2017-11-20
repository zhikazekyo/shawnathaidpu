using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShawnaThai_Eiei.Models;

namespace ShawnaThai_Eiei.Controllers
{
    public class IndexController : Controller
    {
        ShawnaThaiEntities db = new ShawnaThaiEntities();
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register ()
        {
            return View();
        }
        public ActionResult Selling()
        {
            return View();
        }
        public ActionResult GoogleMap()
        {
            return View();
        }
        public ActionResult PostSell()
        {
            return View();
        }
        public ActionResult HistorySell()
        {
            return View();
        }

        public ActionResult popuptest()
        {
            return View();
        }

        public ActionResult RegisterAdmin()
        {
            return View();
        }
        public ActionResult RegisterFarmer()
        {
            return View();
        }
        public ActionResult RegisterCooperative()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult rice2()
        {
            return View();
        }

        public ActionResult rice3()
        {
            return View();
        }
        public ActionResult Sellingz()
        {
            return View();
        }
        public ActionResult PostSellz()
        {
            return View();
        }
    }
}