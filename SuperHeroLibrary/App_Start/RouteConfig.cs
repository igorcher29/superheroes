using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuperHeroLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute
            (
                name: "SuperHeroEdit",
                url: "SuperHeroes/Edit",
                defaults: new { controller = "SuperHeroes", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute
            (
                name: "SuperPowerGetImage",
                url: "SuperPowers/Create{superpowerId}",
                defaults: new { controller = "SuperPowers", action = "GetImage" }
            );

            routes.MapRoute
            (
                name: "SuperPowersCreate",
                url: "SuperPowers/Create",
                defaults: new { controller = "SuperPowers", action = "Create" }
            );

            routes.MapRoute
            (
                name: "SuperPowersEdit",
                url: "SuperPowers/Edit",
                defaults: new { controller = "SuperPowers", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute
            (
                name: "SuperPowersbySuperherobyPage",
                url: "SuperPowers/{superhero}/Page{page}",
                defaults: new { controller = "SuperPowers", action = "Index" }
            );

            routes.MapRoute
            (
                name: "SuperPowersbyPage",
                url: "SuperPowers/Page{page}",
                defaults: new { controller = "SuperPowers", action = "Index" }
            );

            routes.MapRoute
            (
                name: "SuperpowersBySuperhero",
                url: "SuperPowers/{superhero}",
                defaults: new { controller = "SuperPowers", action = "Index" }
            );

            routes.MapRoute
                (
                    name: "SuperPowersIndex",
                    url: "SuperPowers",
                    defaults: new { controller = "SuperPowers", action = "Index" }
                );

            
            routes.MapRoute
            (
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "SuperHeroes", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
