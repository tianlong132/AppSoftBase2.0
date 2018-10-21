using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entity;
using App.IServices;

namespace App.CMSPlugin.Controllers
{
    public class DefaultController : BaseController
    {
        public DefaultController(IUserCoreServices _IUserCoreServices)
        {
            base._IUserCoreServices = _IUserCoreServices;
        }

        // GET: Default
        public ActionResult Index()
        {
            List<UserCoreEntity> list = _IUserCoreServices.QueryAll();
            ViewBag.List = list;

            return View();
        }
    }
}