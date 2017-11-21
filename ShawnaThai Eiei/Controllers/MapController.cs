using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShawnaThai_Eiei.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult GoogleMap()
        {
            return View();
        }
    }
}