using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MatchAJob
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "usuario",
                "usuario",
                defaults: new { controller = "Usuario", action = "Index" }
            );

           
            routes.MapRoute(
                "usuario_cadastrar",
                "usuario/cadastrar",
                new { Controller = "Usuario", action = "Cadastrar" }
                );
            routes.MapRoute(
               "usuario_registrar",
               "usuario/registrar",
               new { Controller = "Usuario", action = "Registrar" }
               );

            routes.MapRoute(
               "usuario_alterar",
               "usuario/{id}/alterar",
               new { Controller = "Usuario", action = "Alterar", id = 0  }
               );
            routes.MapRoute(
   "usuario_editar",
   "usuario/{id}/editar",
   new { Controller = "Usuario", action = "Editar", id = 0 }
   );

            routes.MapRoute(
                "usuario_excluir",
                "usuario/{id}/excluir",
                new {Controller = "Usuario", action = "Excluir", id = 0}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Perfis", id = UrlParameter.Optional }
            );
        }
    }
}
