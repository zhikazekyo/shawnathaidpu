using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShawnaThai_Eiei.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
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
    }
}