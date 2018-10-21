using System.Web.Mvc;

namespace App.Site.Areas.Frontend
{
    public class FrontendAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Frontend";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Frontend_default",
                "Frontend/{controller}/{action}/{id}",
                new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                // 解决控制器冲突问题
                new string[] { "App.Site.Areas.Frontend.Controllers" }
            );
        }
    }
}