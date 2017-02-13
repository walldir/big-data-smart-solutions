using System.Web;
using System.Web.Optimization;

namespace BigDataSmartSolutions.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/morris").Include(
                "~/Scripts/plugins/morris/morris.min.js",
                      "~/Scripts/plugins/morris/morris-data.js",
                      "~/Scripts/plugins/morris/raphael.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/sb-admin.css",
                      "~/Content/css/plugins/morris.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
