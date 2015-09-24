using System.Web;
using System.Web.Optimization;

namespace AuthorityManagement.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));





            bundles.Add(new StyleBundle("~/Global/Css")
               .Include("~/assets/global/css/googlefont/google_font.css")
               .Include("~/assets/global/plugins/font-awesome/css/font-awesome.css")
               .Include("~/assets/global/plugins/simple-line-icons/simple-line-icons.css")
               .Include("~/assets/global/plugins/bootstrap/css/bootstrap.css")
                /*.Include("~/Content/bootstrap.css")#1#
               .Include("~/assets/global/plugins/uniform/css/uniform.default.css")
               .Include("~/Content/jqueryval.css")
               .Include("~/assets/global/plugins/bootstrap-toastr/toastr.css"));

            bundles.Add(new StyleBundle("~/Global/Them/Css")
                .Include("~/assets/global/css/components.css")
                .Include("~/assets/global/css/plugins.css")
                .Include("~/assets/admin/layout/css/layout.css")
                .Include("~/assets/admin/layout/css/themes/default.css")
                .Include("~/assets/admin/layout/css/custom.css"));

            bundles.Add(new ScriptBundle("~/CoreScript/IE9/Js")
                .Include("~/assets/global/plugins/respond.min.js")
                .Include("~/assets/global/plugins/excanvas.min.js"));

            bundles.Add(new ScriptBundle("~/CoreScript/Js")
                .Include("~/assets/global/plugins/jquery-1.11.0.js")
                .Include("~/assets/global/plugins/jquery-migrate-1.2.1.js")
                .Include("~/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.js")
                .Include("~/assets/global/plugins/bootstrap/js/bootstrap.js")
                /*.Include("~/Scripts/bootstrap.js")#1#
                .Include("~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js")
                .Include("~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.js")
                .Include("~/assets/global/plugins/jquery.blockui.js")
                .Include("~/assets/global/plugins/jquery.cokie.js")
                .Include("~/assets/global/plugins/uniform/jquery.uniform.js")
                .Include("~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.js")
                .Include("~/assets/global/plugins/bootstrap-toastr/toastr.js")
                .Include("~/assets/global/plugins/bootbox/bootbox.js")
                .Include("~/Scripts/app.js")
                .Include("~/Scripts/Sgs/Namespace.js")
                .Include("~/Scripts/Sgs/JavascriptClass/Interface.js"));

            bundles.Add(new ScriptBundle("~/Metronic/Js")
                .Include("~/assets/global/scripts/metronic.js")
                .Include("~/assets/admin/layout/scripts/layout.js"));*/

            // Application Scripts
            bundles.Add(new ScriptBundle("~/bundles/appScripts")
                // Main module definition
                .Include("~/Scripts/app/app.module.js")
                // All modules definition
                .Include("~/Scripts/app/modules/core/core.module.js")
                .IncludeDirectory("~/Scripts/app/modules/core", "*.js", true)
                .Include("~/Scripts/app/modules/colors/colors.module.js")
                .IncludeDirectory("~/Scripts/app/modules/colors", "*.js", true)
                .Include("~/Scripts/app/modules/lazyload/lazyload.module.js")
                .IncludeDirectory("~/Scripts/app/modules/lazyload", "*.js", true)
                .Include("~/Scripts/app/modules/loadingbar/loadingbar.module.js")
                .IncludeDirectory("~/Scripts/app/modules/loadingbar", "*.js", true)
                .Include("~/Scripts/app/modules/navsearch/navsearch.module.js")
                .IncludeDirectory("~/Scripts/app/modules/navsearch", "*.js", true)
                .Include("~/Scripts/app/modules/preloader/preloader.module.js")
                .IncludeDirectory("~/Scripts/app/modules/preloader", "*.js", true)
                .Include("~/Scripts/app/modules/routes/routes.module.js")
                .IncludeDirectory("~/Scripts/app/modules/routes", "*.js", true)
                .Include("~/Scripts/app/modules/settings/settings.module.js")
                .IncludeDirectory("~/Scripts/app/modules/settings", "*.js", true)
                .Include("~/Scripts/app/modules/sidebar/sidebar.module.js")
                .IncludeDirectory("~/Scripts/app/modules/sidebar", "*.js", true)
                .Include("~/Scripts/app/modules/translate/translate.module.js")
                .IncludeDirectory("~/Scripts/app/modules/translate", "*.js", true)
                .Include("~/Scripts/app/modules/utils/utils.module.js")
                .IncludeDirectory("~/Scripts/app/modules/utils", "*.js", true)
                // Custom scripts
                .Include("~/Scripts/app/custom/custom.module.js")
                .IncludeDirectory("~/Scripts/app/custom", "*.js", true));

            // Base Scripts (not lazyloaded)
            bundles.Add(new ScriptBundle("~/bundles/baseScripts").Include(
              "~/Vendor/modernizr/modernizr.js",
              "~/Vendor/jquery/dist/jquery.js",
              "~/Vendor/angular/angular.js",
              "~/Vendor/angular-route/angular-route.js",
              "~/Vendor/angular-cookies/angular-cookies.js",
              "~/Vendor/angular-animate/angular-animate.js",
              "~/Vendor/angular-touch/angular-touch.js",
              "~/Vendor/angular-ui-router/release/angular-ui-router.js",
              "~/Vendor/ngstorage/ngStorage.js",
              "~/Vendor/angular-ui-utils/ui-utils.js",
              "~/Vendor/angular-sanitize/angular-sanitize.js",
              "~/Vendor/angular-resource/angular-resource.js",
              "~/Vendor/angular-translate/angular-translate.js",
              "~/Vendor/angular-translate-loader-url/angular-translate-loader-url.js",
              "~/Vendor/angular-translate-loader-static-files/angular-translate-loader-static-files.js",
              "~/Vendor/angular-translate-storage-local/angular-translate-storage-local.js",
              "~/Vendor/angular-translate-storage-cookie/angular-translate-storage-cookie.js",
              "~/Vendor/oclazyload/dist/ocLazyLoad.js",
              "~/Vendor/angular-bootstrap/ui-bootstrap-tpls.js",
              "~/Vendor/angular-loading-bar/build/loading-bar.js",
              "~/Vendor/green-auth/green.auth.js",
              "~/Vendor/angular-dynamic-locale/dist/tmhDynamicLocale.js",
                "~/Vendor/jquery.browser/dist/jquery.browser.js"));

            bundles.Add(new StyleBundle("~/bundles/appStyles")
                    .Include("~/Content/app/app.css")
                    .Include("~/Content/mvcoverride.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrapStyles")
                    .Include("~/Content/app/bootstrap.css"));
        }
    }
}