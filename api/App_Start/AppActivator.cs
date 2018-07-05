using api.App_Start;
using System.Web.Http;
using System.Web.Routing;

namespace api
{
    public class AppActivator
    {
        public static void PreStart() { }
        public static void PostStart()
        {
            IocConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ServiceLocator.Logger.Info("Pharmacy.WebAPIs Application_Start.");
            //ServiceLocator.Logger.Fatal(new System.Exception("exception message"));

            //var config = ServiceLocator.AppConfig.GetJsonString();
        }
    }
}