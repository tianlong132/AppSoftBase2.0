﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Reflection;
using System.Web.Routing;
using System.IO;
using System.Text.RegularExpressions;

/*!
 * 文件名称：实现插件开发自定义控制器工厂
 */
namespace App.PluginFactory
{
    public class PluginControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            string pluginName = string.Empty;
            // 控制器类型
            Type controllerType = null;

            // 获取插件名称
            var _pluginName = requestContext.RouteData.Values["pluginName"];
            if (_pluginName != null)
            {
                pluginName = _pluginName.ToString();
            }

            // 判断是否是插件，插件格式是：插件名称+Plugin字符串
            Regex pluginNameReg = new Regex("^[0-9a-zA-Z]+Plugin$");
            bool isPlugin = pluginNameReg.Match(pluginName).Success;

            // 如果是插件
            if (isPlugin)
            {
                // 获取当前网站运行目录
                string sitePath = AppDomain.CurrentDomain.BaseDirectory;

                // 获取插件目录，默认放在Plugins文件夹下面
                string pluginsPath = sitePath + "Plugins\\" + pluginName;

                // 设置控制器类名
                string absControllerName = controllerName + "Controller";

                // 设置插件控制器命名空间
                string pluginControllerNamespace = "App." + pluginName + ".Controllers";

                // 搜索插件下所有的dll程序集
                string[] pluginDLLs = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.AllDirectories);

                // 将搜索到的dll载入当前运行程序集中
                if (pluginDLLs.Any())
                {
                    foreach (string currentPluginDLL in pluginDLLs)
                    {
                        // 载入程序集
                        Assembly currentDLLAssembly = Assembly.LoadFile(currentPluginDLL);
                        controllerType = currentDLLAssembly.GetType(pluginControllerNamespace + "." + absControllerName, false, true);
                        if (controllerType != null)
                        {
                            break;
                        }
                    }
                }

                if (controllerType != null)
                {
                    return controllerType;
                }

                return base.GetControllerType(requestContext, controllerName);
            }

            return base.GetControllerType(requestContext, controllerName);
        }
    }
}
