using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using App.Library;
using System.IO;
using App.Library.Helper;

/*!
* 文件名称：登录过滤器（AOP切面编程）
*/

namespace App.Site.Filters
{
    public class LoginFilterAttribute : AuthorizeAttribute
    {
        // 获取当前网站运行目录
        static string sitePath = AppDomain.CurrentDomain.BaseDirectory;

        // 读取配置appconfig.json
        static Dictionary<string, object> jsonObj = JsonHelper.Deserialize<Dictionary<string, object>>(File.ReadAllText((sitePath + "appconfig.json")));

        // 获取主题
        string theme = jsonObj["theme"].ToString();

        private readonly List<string> loginAreas = new List<string>() {
            "Backend"
        };

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            var id = filterContext.RouteData.Values["id"];
            var pluginName = filterContext.RouteData.Values["pluginName"];
            var area = filterContext.RouteData.DataTokens["area"];

            // 判断控制器是否贴 SkipLoginAttribute 特性
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                return;
            }

            // 判断Action是否贴 SkipLoginAttribute 特性
            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipLoginAttribute), false))
            {
                return;
            }

            // 判断是否是区域
            if (area != null && loginAreas.Where(u => u.ToLower() == area.ToString().ToLower()).Count() > 0)
            {
                // 核心方法：
                if (filterContext.HttpContext.Session[AppKey.UserSessionKey] == null)
                {
                    // 判断是否是Ajax请求
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult()
                        {
                            Data = TipMsgHelper.CreateResponseMsg("no_login", "您未登录或者登录已经失效！")
                        };
                    }

                    else
                    {
                        // 返回登录页面视图
                        filterContext.Result = new ViewResult()
                        {
                            ViewName = "~/Areas/" + area.ToString() + "/Views/Theme/" + theme + "/Entry/index.cshtml"
                        };
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}