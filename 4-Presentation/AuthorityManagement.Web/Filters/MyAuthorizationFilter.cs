// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyAuthorizationFilter.cs" company="">
//   
// </copyright>
// <summary>
//   The my authorization filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AuthorityManagement.Web.Filters
{
    using System;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Security;

    using Presentation.Attributes;
    using Presentations;
    using Presentations.Attributes;

    using Skymate;
    using Skymate.Engines;

    using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;

    /// <summary>
    /// The my authorization filter.
    /// </summary>
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        /// <summary>
        /// The on authorization.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            var controllerDescriptor = filterContext.ActionDescriptor.ControllerDescriptor;

            // 匿名一律绿灯通行
            var isAllowAnonymou = actionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false);
            if (isAllowAnonymou)
            {
                return;
            }

            // 非系统模块，一律通行
            var isSystemModel = controllerDescriptor.IsDefined(typeof(SystemModelAttribute), false);
            if (!isSystemModel)
            {
                return;
            }

            // 需要登录访问
            var isNeedLogined = actionDescriptor.IsDefined(typeof(NeedLoginedAttribute), false)
                                || controllerDescriptor.IsDefined(typeof(NeedLoginedAttribute), false);

            var userId = string.Empty;
            if (isNeedLogined)
            {
                var authCookie = filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }

                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket == null || authTicket.UserData == string.Empty)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                    return;
                }

                userId = authTicket.UserData;
            }

            var isSetPermission = actionDescriptor.IsDefined(typeof(PermissionSettingAttribute), false);

            // 如果没有设置具体权限，一律通过
            if (!isSetPermission)
            {
                return;
            }

            var systemModelAttribute = (SystemModelAttribute)controllerDescriptor.GetCustomAttributes(typeof(SystemModelAttribute), false)[0];
            var permissionSetting =
                (PermissionSettingAttribute)
                actionDescriptor.GetCustomAttributes(typeof(PermissionSettingAttribute), false)[0];

            var datatokens = filterContext.RequestContext.RouteData.DataTokens["area"];

            // 计算area
            var areaName = datatokens == null ? string.Empty : datatokens.ToString();

            var groupName = systemModelAttribute.GroupName ?? areaName;

            var permissionService = EngineContext.Current.Resolve<IPermissionService>();

            var isAllowed = permissionService.VerifyAuthority(new VerifyAuthorityInputDto()
                                                                  {
                                                                      LoginUserId = Guid.Parse(userId),
                                                                      GroupName = groupName,
                                                                      PermissionValue = permissionSetting.PermissionValue,
                                                                      SystemModelName = systemModelAttribute.Name
                                                                  });

            if (!isAllowed && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                                           {
                                               Data = OperationResult.Error("无操作权限"),
                                               ContentEncoding = Encoding.UTF8,
                                               JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                           };
                return;
            }

            if (!isAllowed)
            {
                filterContext.HttpContext.Response.Redirect("~/401.html");
            }
        }
    }
}