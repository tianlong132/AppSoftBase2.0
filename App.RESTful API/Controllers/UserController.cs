using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.RESTful_API.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
       public string Get()
        {
            return "方法测试";
        }
    }
}
