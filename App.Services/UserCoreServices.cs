using System;
using App.Entity;
using App.IServices;
using App.IRepository;

/*!
* 文件名称：UserCoreServices服务类
* 文件作者：杨龙刚
*/
namespace App.Services
{
	public partial class UserCoreServices : BaseServices<UserCoreEntity> , IUserCoreServices
	{
		IUserCoreRepository _IUserCoreRepository;
		public UserCoreServices(IUserCoreRepository __IUserCoreRepository)
		{
			this._IUserCoreRepository = __IUserCoreRepository;
			base._IBaseRepository = __IUserCoreRepository;
		}
	}
}