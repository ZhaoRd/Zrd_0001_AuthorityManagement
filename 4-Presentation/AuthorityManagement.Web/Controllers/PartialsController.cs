using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    /// <summary>
    /// The partials controller.
    /// </summary>
    public class PartialsController : Controller
    {
        /// <summary>
        /// The top navbar.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult TopNavbar()
        {
            return PartialView();
        }

        /// <summary>
        /// The sidebar.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Sidebar()
        {
            return PartialView();
        }
        public ActionResult Offsidebar()
        {
            return PartialView();
        }
        public ActionResult Footer()
        {
            return PartialView();
        }
        public ActionResult OffsidebarTab1()
        {
            return PartialView();
        }
        public ActionResult OffsidebarTab2()
        {
            return PartialView();
        }
    }
}