using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorityManagement.Web
{
    using AuthorityManagement.Web.Authentication;

    using Skymate;

    public class WebWorkContext:IWorkContext
    {
        #region Const

        private const string AccountCookieName = "skymate.account.cookiename";

        #endregion Const

        #region Fields

        private readonly HttpContextBase httpContext;
        private readonly IAuthenticationService authenticationService;

        private Guid cachedAccount;
/*
        private UserModel cachedAccount;
        private UserModel originalAccountIfImpersonated;
*/

        #endregion Fields


        public WebWorkContext(HttpContextBase httpcontext,
            IAuthenticationService authenticationService)
        {
            this.httpContext = httpcontext;
            this.authenticationService = authenticationService;
        }

        public bool IsPublishedLanguage(string seoCode, int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public string GetDefaultLanguageSeoCode(int storeId = 0)
        {
            throw new NotImplementedException();
        }

        public string CurrentCustomerId 
        {
            get
            {
                if (cachedAccount != Guid.Empty)
                    return cachedAccount.ToString();

                if (this.httpContext == null)
                {
                    return null;
                }

                var customer = this.authenticationService
                    .GetAuthenticatedAccount();

                if (customer == Guid.Empty)
                {
                    var customerCookie = GetCustomerCookie();
                    if (customerCookie != null &&
                    !String.IsNullOrEmpty(customerCookie.Value))
                    {
                        Guid customerGuid;
                        if (Guid.TryParse(customerCookie.Value, out customerGuid))
                        {
                            customer = customerGuid;
                        }
                    }
                }

                if (customer != Guid.Empty)
                {
                    this.SetCustomerCookie(customer.ToString());
                }

                cachedAccount = customer;
                return cachedAccount.ToString();
            }
            set
            {
                SetCustomerCookie(value);
                cachedAccount = Guid.Parse(value);
            }
        }

        public string WorkingLanguageId { get; set; }

        public bool IsAdmin { get; set; }

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (httpContext == null || httpContext.Request == null)
                return null;

            return httpContext.Request.Cookies[AccountCookieName];
        }

        protected virtual void SetCustomerCookie(string customerGuid)
        {
            if (httpContext != null && httpContext.Response != null)
            {
                var cookie = new HttpCookie(AccountCookieName);
                cookie.HttpOnly = true;
                cookie.Value = customerGuid;

                if (string.IsNullOrEmpty(customerGuid))
                {
                    cookie.Expires = DateTime.Now.AddMonths(-1);
                }
                else
                {
                    int cookieExpires = 24 * 365; //TODO make configurable
                    cookie.Expires = DateTime.Now.AddHours(1);
                }

                httpContext.Response.Cookies.Remove(AccountCookieName);
                httpContext.Response.Cookies.Add(cookie);
            }
        }

    }
}