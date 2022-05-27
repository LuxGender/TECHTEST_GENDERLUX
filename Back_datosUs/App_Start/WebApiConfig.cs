using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Back_datosUs
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //formatea xml a json
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                            "text/html",
                            StringComparison.InvariantCultureIgnoreCase,
                            true,
                            "application/json")
                );
        }
    }
}
