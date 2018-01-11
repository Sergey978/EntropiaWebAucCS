using System.Web;
using System.Web.Optimization;

namespace EntropiaWebAuc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Graph").Include(
                     "~/Content/Graph.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
             "~/Scripts/jquery.unobtrusive*",
             "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/graphDraw").Include(
             "~/Scripts/GraphDraw.js"));

            bundles.Add(new ScriptBundle("~/bundles/someeAdRemove").Include(
             "~/Scripts/someeAdRemove.js"));

            // new template budles

            bundles.Add(new StyleBundle("~/Content/style2").Include(
                     "~/Content/css/bootstrap.min.css",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/css/bootstrap-theme.css",
                     "~/Content/css/main.css"));

            bundles.Add(new StyleBundle("~/Content/slider").Include(
                    "~/Content/css/layout.css",
                    "~/Content/plugins/slider.revolution.v4/css/settings.css"));


            bundles.Add(new ScriptBundle("~/Content/js").Include(
             "~/Content/js/headroom.min.js",
             "~/Content/js/jQuery.headroom.min.js",
             "~/Content/js/template.js"));

            //revolution slider
            bundles.Add(new ScriptBundle("~/Content/revolution").Include(
             "~/Content/plugins/slider.revolution.v4/js/jquery.themepunch.tools.min.js",
             "~/Content/plugins/slider.revolution.v4/js/jquery.themepunch.revolution.min.js",
             "~/Content/js/slider_revolution.js"));
            
            //checkBox required for validator extend jquery
            bundles.Add(new ScriptBundle("~/bundles/chekBoxRequire").Include(
            "~/Scripts/chekBoxRequire.js"));

        }
    }
}
