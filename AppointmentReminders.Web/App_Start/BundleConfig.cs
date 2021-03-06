﻿using System.Web;
using System.Web.Optimization;

namespace AppointmentReminders.Web
{
    public class BundleConfig
    {
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/form").Include(
            "~/Scripts/common/form.js",
            "~/Scripts/common/CustomValidation.js"));

            bundles.Add(new ScriptBundle("~/bundles/mesa").Include(
       "~/Scripts/common/mesa.js"));

            bundles.Add(new ScriptBundle("~/bundles/ropho").Include(
       "~/Scripts/common/ropho.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetime").Include(
            "~/Scripts/moment*",
            "~/Scripts/bootstrap-datetimepicker*",
            "~/Scripts/common/datetimepicker-init.js",
            "~/Scripts/common/readonly"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/datetime").Include(
                      "~/Content/bootstrap-datetimepicker*"));
        }
    }
}
