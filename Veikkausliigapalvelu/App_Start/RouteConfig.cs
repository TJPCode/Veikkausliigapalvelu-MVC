using System.Web.Mvc;
using System.Web.Routing;

namespace Veikkausliigapalvelu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Leaguetable",
                url: "sarjataulukko/{action}",
                defaults: new { controller = "LeagueTable", action = "LeagueTable", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "UpdateDatebase",
                url: "sarjataulukko/{action}",
                defaults: new { controller = "LeagueTable", action = "UpdateDatabase", data = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "MatchDetails",
                url: "tapahtumat/{action}",
                defaults: new { controller = "Matches", action = "MatchDetails", id = UrlParameter.Optional }
            );               
            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index"}
            );
        }
    }
}