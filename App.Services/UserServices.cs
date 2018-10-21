using System;
using App.Entity;
using App.IServices;
using App.IRepository;

/*!
* 文件名称：UserServices服务类
* 文件作者：杨龙刚
* 编写日期：2018-10-21 14:15:00
* 版权所有：上海艾艺信息技术有限公司
* 企业官网：http://www.adinnet.cn/
* 文件描述：一切从简，只为了更懒！
*/
namespace App.Services
{
	public partial class UserServices : BaseServices<User> , IUserServices
	{
		IUserRepository _IUserRepository;
		public UserServices(IUserRepository __IUserRepository)
		{
			this._IUserRepository = __IUserRepository;
			base._IBaseRepository = __IUserRepository;
		}
	}
}