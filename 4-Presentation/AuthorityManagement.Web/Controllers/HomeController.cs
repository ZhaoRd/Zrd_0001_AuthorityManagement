// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Web.Controllers
{
    using System.Web.Mvc;

    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Security;

    /// <summary>
    /// The home controller.
    /// </summary>
    [NeedLogined]
    [SystemModel("首页")]
    public class HomeController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Lookup)]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// The welcome.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [PermissionSetting(PermissionValue.Lookup)]
        public ActionResult Welcome()
        {
            return this.View();
        }

    }
}
