using System.Web.Mvc;
using App.IServices;

/*!
* 文件名称：BaseController父控制器类
* 文件作者：杨龙刚
*/
namespace App.CMSPlugin
{
    public partial class BaseController : Controller
    {
        protected IUserCoreServices _IUserCoreServices;
    }
}