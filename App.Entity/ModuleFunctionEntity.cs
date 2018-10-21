using System;
using System.Runtime.Serialization;

/*!
* 文件名称：ModuleFunctionEntity实体类
* 文件作者：杨龙刚
*/
namespace App.Entity
{
	[Serializable]
	[DataContract]
	public partial class ModuleFunctionEntity
	{
		/// <summary>
		/// 描述：功能模块ID
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public int ModuleFunctionID { get; set; }

		/// <summary>
		/// 描述：功能模块名称
		/// 可空：不为空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string ModuleFunctionName { get; set; }

		/// <summary>
		/// 描述：功能模块描述
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string ModuleFunctionDescribe { get; set; }

		/// <summary>
		/// 描述：功能模块类型：（root,top,module，function）
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string ModuleFunctionType { get; set; }

		/// <summary>
		/// 描述：是否是MVC地址格式
		/// 可空：空
		/// 默认值：((1))
		/// </summary>
		[DataMember]
		public Nullable<bool> IsMVC_URL { get; set; }

		/// <summary>
		/// 描述：区域
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Area { get; set; }

		/// <summary>
		/// 描述：控制器
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Controller { get; set; }

		/// <summary>
		/// 描述：行为
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Action { get; set; }

		/// <summary>
		/// 描述：ID参数
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// 描述：插件名称
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string PluginName { get; set; }

		/// <summary>
		/// 描述：是否是插件
		/// 可空：不为空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public bool IsPlugin { get; set; }

		/// <summary>
		/// 描述：请求方式（GET，POST，HEAD，PUT，DELETE）
		/// 可空：空
		/// 默认值：('GET')
		/// </summary>
		[DataMember]
		public string Method { get; set; }

		/// <summary>
		/// 描述：自定义地址
		/// 可空：空
		/// 默认值：('javascript(void);')
		/// </summary>
		[DataMember]
		public string CustomUrl { get; set; }

		/// <summary>
		/// 描述：是否是Ajax请求
		/// 可空：空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public Nullable<bool> IsAjax { get; set; }

		/// <summary>
		/// 描述：Ajax代码
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string AjaxCode { get; set; }

		/// <summary>
		/// 描述：模块图标class或image图片
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string ModuleFunctionIco { get; set; }

		/// <summary>
		/// 描述：图标类型（iconfont,image)
		/// 可空：空
		/// 默认值：
		/// </summary>
		[DataMember]
		public string ModuleFunctionIcoType { get; set; }

		/// <summary>
		/// 描述：唯一标识ID
		/// 可空：不为空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string GUID { get; set; }

		/// <summary>
		/// 描述：最后更新人
		/// 可空：空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public Nullable<int> UpdateUser { get; set; }

		/// <summary>
		/// 描述：最后更新人IP地址
		/// 可空：空
		/// 默认值：('127.0.0.1')
		/// </summary>
		[DataMember]
		public string UpdateIPAddress { get; set; }

		/// <summary>
		/// 描述：最后更新时间
		/// 可空：空
		/// 默认值：(getdate())
		/// </summary>
		[DataMember]
		public Nullable<DateTime> UpdateTime { get; set; }

		/// <summary>
		/// 描述：更新次数
		/// 可空：空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public Nullable<int> UpdateCount { get; set; }

		/// <summary>
		/// 描述：创建人
		/// 可空：空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public Nullable<int> CreateUser { get; set; }

		/// <summary>
		/// 描述：创建人IP地址
		/// 可空：空
		/// 默认值：('127.0.0.1')
		/// </summary>
		[DataMember]
		public string CreateIPAddress { get; set; }

		/// <summary>
		/// 描述：创建时间
		/// 可空：空
		/// 默认值：(getdate())
		/// </summary>
		[DataMember]
		public Nullable<DateTime> CreateTime { get; set; }

		/// <summary>
		/// 描述：是否启用
		/// 可空：空
		/// 默认值：((1))
		/// </summary>
		[DataMember]
		public Nullable<bool> IsEnable { get; set; }

		/// <summary>
		/// 描述：父功能模块ID
		/// 可空：空
		/// 默认值：((-1))
		/// </summary>
		[DataMember]
		public Nullable<int> ModuleFunctionParentID { get; set; }

	}
}