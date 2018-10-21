using System;
using App.Entity;
using App.IRepository;

/*!
* 文件名称：ModuleFunctionRepository仓储类
* 文件作者：杨龙刚
*/
namespace App.Repository
{
	public partial class ModuleFunctionRepository : BaseRepository<ModuleFunctionEntity> , IModuleFunctionRepository
	{
	}
}