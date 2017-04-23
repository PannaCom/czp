using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace comzipato
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //AdminAddProduct
            routes.MapRoute(
             "AdminAddProduct",
             "admin/product/add",
             new { controller = "Products", action = "Add" }
           );
            routes.MapRoute(
           "AdminListProduct",
           "admin/product/list",
           new { controller = "Products", action = "List" }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
