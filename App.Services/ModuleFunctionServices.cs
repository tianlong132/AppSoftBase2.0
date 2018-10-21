using System;
using App.Entity;
using App.IServices;
using App.IRepository;

/*!
* 文件名称：ModuleFunctionServices服务类
* 文件作者：杨龙刚
*/
namespace App.Services
{
	public partial class ModuleFunctionServices : BaseServices<ModuleFunctionEntity> , IModuleFunctionServices
	{
		IModuleFunctionRepository _IModuleFunctionRepository;
		public ModuleFunctionServices(IModuleFunctionRepository __IModuleFunctionRepository)
		{
			this._IModuleFunctionRepository = __IModuleFunctionRepository;
			base._IBaseRepository = __IModuleFunctionRepository;
		}
	}
}