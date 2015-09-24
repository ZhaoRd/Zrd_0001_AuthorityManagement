﻿using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AuthorityManagement.Web
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;

    using AuthorityManagement.Presentation;
    using AuthorityManagement.Presentation.Attributes;
    using AuthorityManagement.Presentation.Dtos;
    using AuthorityManagement.Security;
    using AuthorityManagement.Web.Controllers;
    using Castle.Facilities.Logging;
    using Castle.Windsor;

    using Skymate;
    using Skymate.Engines;
    using Skymate.Logging;
    using System.Reflection;

    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_AuthenticateRequest()
        {
            LogHelper.Logger.Info("验证");

            // 解密 string[] roles = authTicket.UserData.Split(new char[]{';'});//根据存入时的格式分解 
            // Context.User = new GenericPrincipal(Context.User.Identity);
            // 存到HttpContext.User中 

        }

        protected void Application_Start()
        {
            EngineContext.Initialize(false);

            var container = EngineContext.Current.Resolve<IWindsorContainer>();
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            LogHelper.Logger.Info("程序启动");

            StartupContext.Initialize();

            var assembly = typeof(HomeController).Assembly;
            var types = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

            var functions = new List<FunctionDto>();
            foreach (var type in types)
            {
                functions.AddRange(Invoke(type));
            }

            IFunctionService functionService = EngineContext.Current.Resolve<IFunctionService>();
            functionService.InitModel(functions);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public IEnumerable<FunctionDto> Invoke(Type target)
        {
            var result = new List<FunctionDto>();

            var targetType = target;

            if (!targetType.IsDefined(typeof(SystemModelAttribute), false))
            {
                return result;
            }

            var methods = targetType.GetMethods();
            var functionPermissionValue = 
                (from methodInfo in methods 
                 where methodInfo.IsDefined(typeof(PermissionSettingAttribute), false)
                 select methodInfo.GetCustomAttribute<PermissionSettingAttribute>()).Aggregate(
                     PermissionValue.None,
                     (current, permissionSetting) => current | permissionSetting.PermissionValue);

            var description = targetType.GetCustomAttribute<SystemModelAttribute>();
            var areaName = this.GetArea(target);
            var function = new FunctionDto()
                               {
                                   FunctionName = description.Name,
                                   ModelName = areaName,
                                   PermissionValue = functionPermissionValue
                               };
            result.Add(function);

            return result;

        }


        protected virtual string GetArea(Type controllerType)
        {

            string @namespace = controllerType.Namespace;
            LogHelper.Logger.Info(@namespace);
            LogHelper.Logger.Info(controllerType.Name);
            if (@namespace == null)
            {
                return null;
            }
            int index = @namespace.IndexOf("Areas", StringComparison.Ordinal) + 6;
            string area = index > 6 ? @namespace.Substring(index, @namespace.IndexOf(".Controllers", StringComparison.Ordinal) - index) : null;
            LogHelper.Logger.Info("area---->" + controllerType.Name);
            return area;
        }
    }
}