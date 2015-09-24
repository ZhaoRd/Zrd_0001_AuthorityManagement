using System.Web;
using System.Web.Mvc;

namespace AuthorityManagement.Web
{
    using AuthorityManagement.Web.Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyAuthorizationFilter());
        }
    }
}