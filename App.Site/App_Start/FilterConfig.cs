﻿using App.Site.Filters;
using System.Web;
using System.Web.Mvc;

namespace App.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginFilterAttribute());
        }
    }
}
