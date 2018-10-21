using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Site.Areas.Backend.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Backend/Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
    }
}