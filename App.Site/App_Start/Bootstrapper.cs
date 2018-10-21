using App.Library;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;

/*!
 * 文件名称：Autofac 依赖注入，控制反转
 */

namespace App.Site
{
    public class Bootstrapper
    {
        public static void StartRegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Repository") && !t.Name.StartsWith("I")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Services") && !t.Name.StartsWith("I")).AsImplementedInterfaces();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // 异步加载插件程序集并自动注入到内存中
            LoadPluginDllAsync(builder).Wait();

            // 这里自定义注入你的程序集
            RegisterTypeOrControllers(builder);

            var container = builder.Build();
            var configuration = GlobalConfiguration.Configuration;

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #region 异步：异步加载并注入程序集 + public static async void LoadPluginDllAsync(ContainerBuilder builder)
        /// <summary>
        /// 异步加载并注入程序集
        /// </summary>
        /// <param name="builder"></param>
        public static async Task LoadPluginDllAsync(ContainerBuilder builder)
        {
            var pluginDlls = await SearchPluginDllAsync();
            if (pluginDlls.Any())
            {
                foreach (string dllPath in pluginDlls)
                {
                    builder.RegisterControllers(Assembly.LoadFile(dllPath));
                }
            }
        }
        #endregion

        #region 异步：异步搜索插件目录下所有程序集 + public static async Task<string[]> SearchPluginDllAsync()
        /// <summary>
        /// 异步搜索插件目录下所有程序集
        /// </summary>
        /// <returns></returns>
        public static async Task<string[]> SearchPluginDllAsync()
        {
            // 获取当前网站运行目录
            string sitePath = AppDomain.CurrentDomain.BaseDirectory;
            //// 读取配置appconfig.json
            //Dictionary<string, object> jsonObj = JsonHelper.Deserialize<Dictionary<string, object>>(File.ReadAllText((sitePath + "appconfig.json")));

            return await Task.Run(() =>
            {
                return Directory.GetFiles(sitePath + "Plugins", "App.*Plugin.dll", SearchOption.AllDirectories);
            });
        }
        #endregion

        #region 静态：在这里，你可以注入你所需的程序集，在网站一启动的时候 + public static void RegisterTypeOfControllers(ContainerBuilder builder)
        /// <summary>
        /// 在这里，你可以注入你所需的程序集，在网站一启动的时候
        /// </summary>
        public static void RegisterTypeOrControllers(ContainerBuilder builder)
        {
        }
        #endregion
    }
}