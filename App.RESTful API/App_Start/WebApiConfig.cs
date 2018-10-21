using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace App.RESTful_API
{
    /// <summary>
    /// API配置
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// API路由注册
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
