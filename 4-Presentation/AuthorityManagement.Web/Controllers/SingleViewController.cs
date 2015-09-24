using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class SingleViewController : Controller
    {
        // GET: SingleView
        public ActionResult Index()
        {
            return View();
        }
        // GET: SingleView
        public ActionResult MenuView()
        {
            return View();
        }

        public ActionResult Buttons()
        {
            return this.View();
        }

        public ActionResult Panels()
        {
            return this.View();
        }

    }
}