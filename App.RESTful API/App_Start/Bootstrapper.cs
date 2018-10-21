using Autofac;
using Autofac.Integration.WebApi;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;

/*!
 * 文件名称：Autofac 依赖注入，控制反转
 * 文件作者：杨龙刚
 * 编写日期：2018年10月21日
 */

namespace App.RESTful_API
{
    /// <summary>
    /// 
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        ///  
        /// </summary>
        public static void StartRegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Repository") && !t.Name.StartsWith("I")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Services") && !t.Name.StartsWith("I")).AsImplementedInterfaces();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var configuration = GlobalConfiguration.Configuration;

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}