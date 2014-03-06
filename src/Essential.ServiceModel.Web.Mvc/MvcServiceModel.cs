using System;
using System.Web.Mvc;

namespace Essential.ServiceModel.Web.Mvc
{
    public static class MvcServiceModel
    {
        private static Action<MvcResponseHandler, Controller> _configuration;

        public static void OverrideDefaults(Action<MvcResponseHandler, Controller> configuration)
        {
            Configuration = configuration;
        }

        internal static Action<MvcResponseHandler, Controller> Configuration
        {
            get { return _configuration ?? ApplyDefaults; }
            private set { _configuration = value; }
        }

        private static void ApplyDefaults(MvcResponseHandler mvcResponseHandler, Controller controller)
        {
            DefaultConfiguration.Apply(mvcResponseHandler, controller);
        }
    }
}
