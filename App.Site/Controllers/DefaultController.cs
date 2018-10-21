using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.IServices;
using App.Entity;

namespace App.Site.Controllers
{
    public class DefaultController : BaseController
    {
        public DefaultController(IUserServices _userServices)
        {
            base._IUserServices = _userServices;
        }
        // GET: Default
        public ActionResult Index()
        {
            //_IUserServices.Insert(new User {
            //    UserName = "杨龙刚测试",
            //    AddTime = DateTime.Now
            //});
            //_IUserServices.Delete(u=>u.Id==1);
            //return Content("添加成功");

            return View();
        }
    }
}