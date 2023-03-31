using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIForKeeper.Controllers
{
    public class ChoiceTypeVisitController : Controller
    {
        // GET: ChoiceTypeVisit
        public ActionResult TypeVisit()
        {
            return View();
        }

        public ActionResult ChoiseSelf()
        {
            return View("LocalVisit");
        }
    }
}