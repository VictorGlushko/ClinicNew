﻿using System.Web;
using System.Web.Optimization;

namespace Clinic
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/clockpicker.js",
                       "~/Scripts/bootbox.min.js",
                      "~/Scripts/datatables/jquery.datatables.js",
                      "~/Scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/css/custom.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/css/morris.css",
                       "~/Content/css/animate.css",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                       "~/Content/css/font-awesome.min.css",
                       "~/Content/css/select2.min.css",
                      "~/Content/themes/base/datepicker.css",
                       "~/Content/site.css"));
        }


    }
}
