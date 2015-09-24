using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angle.Controllers
{
    public class AppController : Controller
    {
        // GET: 主要页面布局
        public ActionResult Index()
        {
            return View();
        }

        // 登录界面采用的布局
        public ActionResult LoginLayout()
        {
            return this.View();
        }

    }
}