using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json.Serialization;

namespace DI_Mvc_Autofac
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.RegisterApi);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterMvcRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public static class WebApiConfig
    {
        public static void RegisterApi(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            var jsonFormatter = configuration.Formatters.JsonFormatter;
            if (jsonFormatter != null)
            {
                jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
        }
    }
}
