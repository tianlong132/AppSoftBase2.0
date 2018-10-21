using System;
using App.Entity;
using App.IRepository;

/*!
* 文件名称：UserRepository仓储类
* 文件作者：杨龙刚
* 编写日期：2018-10-21 14:15:00
* 版权所有：上海艾艺信息技术有限公司
* 企业官网：http://www.adinnet.cn/
* 文件描述：一切从简，只为了更懒！
*/
namespace App.Repository
{
	public partial class UserRepository : BaseRepository<User> , IUserRepository
	{
	}
}