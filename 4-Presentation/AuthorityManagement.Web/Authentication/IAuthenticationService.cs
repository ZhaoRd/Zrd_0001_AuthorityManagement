namespace AuthorityManagement.Web.Authentication
{
    using System;

    public interface IAuthenticationService
    {
        void SignIn(Guid userId, bool createPersistentCookie);
        void SignOut();
        Guid GetAuthenticatedAccount();
    }
}
