using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Teste_Partner
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //  Retira o tipo de formatação xml e exibe os dados no formato json
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //  Apresenta o resultado json formatado
            config.Formatters.JsonFormatter.Indent = true;
        }
    }
}
