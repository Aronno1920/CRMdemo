using System.Web;
using System.Web.Optimization;

namespace CRM.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
          "~/Scripts/DataTables/jquery.dataTables.min.js",
          "~/Scripts/DataTables/dataTables.bootstrap4.min.js",
          "~/Scripts/DataTables/dataTables.buttons.min.js",
          "~/Scripts/DataTables/buttons.flash.min.js",
          "~/Scripts/utility/jszip.min.js",
          "~/Scripts/utility/pdfmake.min.js",
          "~/Scripts/utility/vfs_fonts.js",
          "~/Scripts/DataTables/buttons.html5.min.js",
          "~/Scripts/DataTables/buttons.print.min.js"));

            //For New Dashboard Design
            bundles.Add(new ScriptBundle("~/bundles/dashboards").Include(
          //"~/Content/vendors/jquery/dist/jquery.min.js",
          //"~/Content/vendors/bootstrap/dist/js/bootstrap.min.js",
          "~/Content/vendors/fastclick/lib/fastclick.js",
          "~/Content/vendors/nprogress/nprogress.js",
          "~/Content/vendors/Chart.js/dist/Chart.min.js",
          "~/Content/vendors/bernii/gauge.js/dist/gauge.min.js",
          "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
          "~/Content/vendors/iCheck/icheck.min.js",
           "~/Content/vendors/Flot/jquery.flot.js",
         "~/Content/vendors/Flot/jquery.flot.pie.js",
         "~/Content/vendors/Flot/jquery.flot.time.js",
         "~/Content/vendors/Flot/jquery.flot.stack.js",
         "~/Content/vendors/Flot/jquery.flot.resize.js",
        "~/Scripts/flot/jquery.flot.orderBars.js",
        //"~/Scripts/flot/date.js",
        "~/Scripts/flot/jquery.flot.spline.js",
        "~/Scripts/flot/curvedLines.js",
        "~/Scripts/maps/jquery-jvectormap-2.0.3.min.js",
        "~/Scripts/moment/moment.min.js",
        "~/Scripts/datepicker/daterangepicker.js",
         "~/Scripts/custom.js",
          "~/Content/vendors/skycons/skycons.js"));

            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                           "~/Scripts/jtable/jquery.jtable.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/datetimepicker-setup.js",
                      "~/Scripts/respond.js"));



            //Custom Javascript Files here
            bundles.Add(new ScriptBundle("~/bundles/service").Include(
                      "~/Scripts/Apps/service.js"));
            bundles.Add(new ScriptBundle("~/bundles/product").Include(
                      "~/Scripts/Apps/product.js"));
            bundles.Add(new ScriptBundle("~/bundles/customer").Include(
                      "~/Scripts/Apps/customer.js"));
            bundles.Add(new ScriptBundle("~/bundles/search").Include(
                      "~/Scripts/Apps/search.js"));
            bundles.Add(new ScriptBundle("~/bundles/register").Include(
                      "~/Scripts/Apps/register.js"));
            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                     "~/Scripts/Apps/login.js"));
            bundles.Add(new ScriptBundle("~/bundles/city").Include(
                     "~/Scripts/Apps/city.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Script/jtable/themes/metro/brown/jtable.css",
                      "~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/Content/dashboard").Include(
            //          "~/Content/admin-dashboard/bower_components/bootstrap/dist/css/bootstrap.min.css",
            //           "~/Content/admin-dashboard/bower_components/metisMenu/dist/metisMenu.min.css",
            //           "~/Content/admin-dashboard/dist/css/timeline.css",
            //           "~/Content/admin-dashboard/dist/css/sb-admin-2.css",
            //           "~/Content/admin-dashboard/bower_components/morrisjs/morris.css",
            //          "~/Content/admin-dashboard/bower_components/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/dashboards").Include(
                     "~/Content/vendors/bootstrap/dist/css/bootstrap.min.css",
    "~/Content/vendors/font-awesome/css/font-awesome.min.css",
    "~/Content/vendors/iCheck/skins/flat/green.css",
    "~/Content/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
   "~/Content/maps/jquery-jvectormap-2.0.3.css",
    "~/Content/custom.css"));


        }
    }
}
