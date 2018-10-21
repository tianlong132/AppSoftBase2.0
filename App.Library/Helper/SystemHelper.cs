using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.Library.Helper
{
    public class SystemHelper
    {
        #region 方法：获取客户端IP地址 + public static string GetIP()
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>客户端IP地址</returns>
        public static string GetIP()
        {
            string user_IP = null;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                user_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                user_IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            if (user_IP == "::1")
            {
                user_IP = "localhost";
            }
            return user_IP;
        }
        #endregion
    }
}
