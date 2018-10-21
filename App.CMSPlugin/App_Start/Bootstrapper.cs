using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;

/*!
 * 文件名称：Autofac 依赖注入，控制反转
 * 文件作者：杨龙刚
 */

namespace App.CMSPlugin
{
    public class Bootstrapper
    {
        public static void StartRegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("Services")).AsImplementedInterfaces();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            var configuration = GlobalConfiguration.Configuration;

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}