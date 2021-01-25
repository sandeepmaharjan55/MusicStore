using System.Web;
using System.Web.Optimization;

namespace WebApplication_musicstore_codefirst
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


        //    old bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
          //          "~/Scripts/bootstrap.js",
            //        "~/Scripts/respond.js", "~/Scripts/moment.js", "~/Scripts/bootstrap-datetimepicker.js",

          bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/musicstoretheme/bootstrap.min.js", "~/Scripts/musicstoretheme/plugins/swiper/js/swiper.min.js",
                       "~/Scripts/musicstoretheme/plugins/player/jplayer.playlist.min.js", "~/Scripts/musicstoretheme/plugins/player/jquery.jplayer.min.js", "~/Scripts/musicstoretheme/plugins/player/audio-player.js",
                       "~/Scripts/musicstoretheme/plugins/player/volume.js", "~/Scripts/musicstoretheme/plugins/nice_select/jquery.nice-select.min.js", "~/Scripts/musicstoretheme/plugins/scroll/jquery.mCustomScrollbar.js",
                       "~/Scripts/musicstoretheme/custom.js"));
            //  old only this in   bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/bootstrap.css",
            //        "~/Content/site.css", "~/Content/bootstrap-datetimepicker.css",

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/musicstoretheme/fonts.css",
                      "~/Content/musicstoretheme/bootstrap.css", "~/Content/musicstoretheme/font-awesome.min.css", "~/Scripts/musicstoretheme/plugins/swiper/css/swiper.min.css",
                      "~/Scripts/musicstoretheme/plugins/nice_select/nice-select.css",
                      "~/Scripts/musicstoretheme/plugins/player/volume.css", "~/Scripts/musicstoretheme/plugins/scroll/jquery.mCustomScrollbar.css", "~/Content/musicstoretheme/style.css"));
        }
    }
}
