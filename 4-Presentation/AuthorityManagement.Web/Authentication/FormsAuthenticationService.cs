namespace AuthorityManagement.Web.Authentication
{
    using System;
    using System.Web;
    using System.Web.Security;

    using AuthorityManagement.Presentations;

    public class FormsAuthenticationService:IAuthenticationService
    {
        private readonly HttpContextBase httpContext;
        private readonly TimeSpan expirationTimeSpan;
        private  Guid cachedAccountId;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="customerSettings">Customer settings</param>
        public FormsAuthenticationService(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
            
            this.expirationTimeSpan = FormsAuthentication.Timeout;
            
        }


        public virtual void SignIn(Guid userId, bool createPersistentCookie)
        {
            var now = DateTime.Now;

            var ticket = new FormsAuthenticationTicket(
                1,
                userId.ToString("N"),
                now,
                now.Add(this.expirationTimeSpan),
                createPersistentCookie,
                userId.ToString("N"),
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            this.httpContext.Response.Cookies.Add(cookie);
            this.cachedAccountId = userId;
        }
        public virtual void SignOut()
        {
            this.cachedAccountId = Guid.Empty;
            FormsAuthentication.SignOut();
        }
        public virtual Guid GetAuthenticatedAccount()
        {
            if (this.cachedAccountId != Guid.Empty)
                return this.cachedAccountId;

            if (this.httpContext == null ||
                this.httpContext.Request == null ||
                !this.httpContext.Request.IsAuthenticated ||
                !(this.httpContext.User.Identity is FormsIdentity))
            {
                return Guid.Empty;
            }

            var formsIdentity = (FormsIdentity)this.httpContext.User.Identity;
            var customer = this.GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
            if (customer != null)
                this.cachedAccountId = customer;
            return this.cachedAccountId;

        }

        private Guid GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var usernameOrEmail = ticket.UserData;

            if (String.IsNullOrWhiteSpace(usernameOrEmail))
                return Guid.Empty;

            Guid accountId = Guid.Empty;
            Guid.TryParse(usernameOrEmail, out accountId);

            return accountId;
        }
    }
}
