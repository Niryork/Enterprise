using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Enterprise.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //公司产品
            routes.MapRoute(
                name: "product",
                url: "product",
                defaults: new { controller = "Product", action = "List" }
            );


            //关于公司
            routes.MapRoute(
                name: "About_Company",
                url: "About",
                defaults: new { controller = "About", action = "Index" }
            );

            #region 新闻列表
            routes.MapRoute(
                    name: "News_List",
                    url: "News",
                    defaults: new { controller = "News", action = "List" }
                );
            routes.MapRoute(
                 name: "Company_News",
                 url: "news/CompanyNews/",
                 defaults: new { controller = "News", action = "List" }
             );
            routes.MapRoute(
                name: "Industry_News",
                url: "News/IndustryNews/",
                defaults: new { controller = "News", action = "List" }
            ); 
            #endregion

            #region 首页
             //首页
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "index",
                defaults: new { controller = "Home", action = "Index"}
            );
            #endregion


        }
    }
}