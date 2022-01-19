using ApiTestEngie.Login.JWT_Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiTestEngie
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web
            config.Filters.Add(new ApiTestEngie.Filters.ErrorExceptionFilterAttribute());

            //config autho 
            config.MessageHandlers.Add(new TokenValidationHandler());

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
