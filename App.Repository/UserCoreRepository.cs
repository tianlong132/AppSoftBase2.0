using System;
using App.Entity;
using App.IRepository;

/*!
* 文件名称：UserCoreRepository仓储类
* 文件作者：百小僧
* 编写日期：2017-01-16 11:31:03
* 版权所有：百签软件有限公司
* 企业官网：http://www.baisoft.org
* 开源协议：GPL v2 License
* 文件描述：一切从简，只为了更懒！
*/
namespace App.Repository
{
	public partial class UserCoreRepository : BaseRepository<UserCoreEntity> , IUserCoreRepository
	{
	}
}