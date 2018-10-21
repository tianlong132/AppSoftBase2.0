using App.Library;
using App.Library.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages.Razor;

/*!
 * 文件名称：实现插件开发自定义视图引擎
 * 文件作者：杨龙刚
 */
namespace App.PluginFactory
{
    public class PluginRazorViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            string pluginName = string.Empty;

            // 获取当前网站运行目录
            string sitePath = AppDomain.CurrentDomain.BaseDirectory;

            // 读取配置appconfig.json
            Dictionary<string, object> jsonObj = JsonHelper.Deserialize<Dictionary<string, object>>(File.ReadAllText((sitePath + "appconfig.json")));

            // 获取主题
            string theme = jsonObj["theme"].ToString();

            // 获取插件名称
            var _pluginName = controllerContext.RouteData.Values["pluginName"];
            if (_pluginName != null)
            {
                pluginName = _pluginName.ToString();
            }

            // 判断是否是插件，插件格式是：插件名称+Plugin字符串
            Regex pluginNameReg = new Regex("^[0-9a-zA-Z]+Plugin$");
            bool isPlugin = pluginNameReg.Match(pluginName).Success;

            string[] AreaViewLocationFormats = {
                   "~/Areas/{2}/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
                };

            string[] ViewLocationFormats = {
                   "~/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
             };

            // 如果是插件
            if (isPlugin)
            {
                AreaViewLocationFormats = new string[]{
                    "~/Plugins/" + pluginName + "/Areas/{2}/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Plugins/" + pluginName + "/Areas/{2}/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
                };
                ViewLocationFormats = new string[]{
                    "~/Plugins/" + pluginName + "/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Plugins/" + pluginName + "/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
                };

                SetViewLocationFormats(AreaViewLocationFormats, ViewLocationFormats);

                // 重写视图引擎将 视图编译成前台页面类的方法
                RazorBuildProvider.CodeGenerationStarted += (object sender, EventArgs e) =>
                {
                    RazorBuildProvider provider = sender as RazorBuildProvider;


                    // 获取插件目录，默认放在Plugins文件夹下面
                    string pluginsPath = sitePath + "Plugins\\" + pluginName;

                    // 搜索插件下所有的dll程序集
                    string[] pluginDLLs = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories);

                    // 将搜索到的dll载入当前运行程序集中
                    if (pluginDLLs.Any())
                    {
                        foreach (string currentPluginDLL in pluginDLLs)
                        {
                            Assembly ass = Assembly.LoadFile(currentPluginDLL);

                            //将ass 添加为视图前台页面类的引用程序集
                            provider.AssemblyBuilder.AddAssemblyReference(ass);
                        }
                    }
                };
            }
            else
            {
                AreaViewLocationFormats = new string[]{
                    "~/Areas/{2}/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
                };

                ViewLocationFormats = new string[]{
                    "~/Views/Theme/"+theme+"/{1}/{0}.cshtml",
                    "~/Views/Theme/"+theme+"/Shared/{1}/{0}.cshtml"
               };
                SetViewLocationFormats(AreaViewLocationFormats, ViewLocationFormats);
            }

            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        #region 方法：设置模板引擎默认路径 - private void SetViewLocationFormats(string[] AreaViewLocationFormats, string[] ViewLocationFormats)
        /// <summary>
        /// 设置模板引擎默认路径
        /// </summary>
        /// <param name="AreaViewLocationFormats"></param>
        /// <param name="ViewLocationFormats"></param>
        private void SetViewLocationFormats(string[] AreaViewLocationFormats, string[] ViewLocationFormats)
        {
            // 将父类RazorViewEngine中的LocationFormats设置自定义的路径

            base.AreaPartialViewLocationFormats = AreaViewLocationFormats;
            base.AreaViewLocationFormats = AreaViewLocationFormats;
            base.AreaMasterLocationFormats = AreaViewLocationFormats;

            base.ViewLocationFormats = ViewLocationFormats;
            base.PartialViewLocationFormats = ViewLocationFormats;
            base.MasterLocationFormats = ViewLocationFormats;
        }
        #endregion
    }
}
