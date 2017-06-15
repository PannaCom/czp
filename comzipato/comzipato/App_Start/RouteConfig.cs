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
              "AdminEditProduct",
              "admin/product/edit/{id}",
              new { controller = "Products", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            "AdminDeleteProduct",
            "admin/product/delete/{id}",
            new { controller = "Products", action = "Delete", id = UrlParameter.Optional }
          );

            //AdminRestoreOffice
            routes.MapRoute(
           "AdminRestoreProduct",
           "admin/product/restore/{id}",
           new { controller = "Products", action = "Restore", id = UrlParameter.Optional }
         );

            routes.MapRoute(
            "AdminListProduct",
            "admin/product/list",
            new { controller = "Products", action = "List" }
          );
            routes.MapRoute(
           "Products Detail",
           "product/{restore}-{id}",
           new { controller = "Products", action = "Detail", title = UrlParameter.Optional,id = UrlParameter.Optional }
         );
            routes.MapRoute(
           "Products Detail English",
           "products/{restore}-{id}",
           new { controller = "Products", action = "DetailEn", title = UrlParameter.Optional, id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
