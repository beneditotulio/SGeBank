using System.Web;
using System.Web.Optimization;

namespace SGeBank
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //TULIO ADDED
            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    "~/Content/startbootstrap/dist/js/scripts.js",
            //    "~/Content/startbootstrap/dist/js/jquery.dataTables.min.js",
            //    "~/Content/startbootstrap/dist/js/dataTables.bootstrap4.min.js",
            //    "~/Content/startbootstrap/dist/js/all.min.js",
            //    "~/Content/Scripts/bootstrap.bundle.min.js"
            //    //"~/Scripts/jquery-3.5.1.slim.min.js"
            //    ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/startbootstrap/dist/css/styles.css",
            //"~/Content/startbootstrap/dist/css/dataTables.bootstrap4.min.css"));


        }
    }
}
