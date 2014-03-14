using System.Web.Optimization;

namespace Essential.ServiceModel.Examples.Mvc.App_Start
{
    public static class BundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.EnableOptimizations = true;
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js"));
        }
    }
}