using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorityManagement.Web.Controllers
{
    using System.ComponentModel;
    using System.Web.Security;

    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Presentations;
    using AuthorityManagement.Web.Authentication;

    using Skymate;

    /// <summary>
    /// The account controller.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// The account service.
        /// </summary>
        private readonly IAccountService accountService;

        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="accountService">
        /// The account service.
        /// </param>
        public AccountController(IAccountService accountService, IAuthenticationService authenticationService)
        {
            this.accountService = accountService;
            this.authenticationService = authenticationService;
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return this.View();
        }

        /// <summary>
        /// The login.
        /// </summary>
        /// <param name="loginModel">
        /// The login model.
        /// </param>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel loginModel, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginModel);
            }

            var loginUser = this.accountService.Login(new LoginInput()
                                                          {
                                                              UserName = loginModel.UserName, 
                                                              Password = loginModel.Password
                                                          });

            if (loginUser.IsError)
            {
                /*this.ModelState.AddModelError(string.Empty, loginUser.ErrorMessage);
                return this.View(loginModel);*/
                return this.Json(OperationResult.Error(loginUser.ErrorMessage));
            }

            this.authenticationService.SignIn(loginUser.LoginUserId, loginModel.RemeberMe);

            return this.Json(OperationResult.Success());
        }

        /// <summary>
        /// The login out.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult LoginOut()
        {
            this.authenticationService.SignOut();
            return this.RedirectToAction("Login");
        }

        /// <summary>
        /// The redirect to local.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }

    /// <summary>
    /// 登录模型.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 明码.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 是否记住.
        /// </summary>
        public bool RemeberMe { get; set; }
    }
}
