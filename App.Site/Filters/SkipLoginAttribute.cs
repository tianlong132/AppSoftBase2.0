using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*!
* 文件名称：跳过登录特性，只要在控制器或Action贴此特性就可以跳过登录验证
*/
namespace App.Site.Filters
{
    public class SkipLoginAttribute : Attribute
    {
    }
}
