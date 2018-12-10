using System.Web.Optimization;

namespace RegressionFailureTracking
{
    public class BundleConfig
    {
        private static string CSS_VERSION = "0";
        
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                      "~/Scripts/respond.min.js"));

            //"~/Scripts/bootstrap.min.js",
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css"));
            // "~/Content/bootstrap.min.css"
            bundles.Add(new StyleBundle("~/Content/RegressionTracking").Include(
                      "~/Content/RegressionTracking/entry-0.css",
                      "~/Content/RegressionTracking/entry-buildsummary-0.css"));

            bundles.Add(new ScriptBundle("~/Script/RegressionTracking").Include(
                        "~/Scripts/RegressionTracking/*.js"));
        }
    }
}
