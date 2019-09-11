using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiTOKEN
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            //Rutas del api web

            config.MapHttpAttributeRoutes();

            //Token
            config.MessageHandlers.Add(new Token.TokenValidationHandler());


           

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}
