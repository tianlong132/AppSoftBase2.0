using System;
using System.Runtime.Serialization;

/*!
* 文件名称：User实体类
* 文件作者：杨龙刚
* 编写日期：2018-10-21 14:14:59
* 版权所有：上海艾艺信息技术有限公司
* 企业官网：http://www.adinnet.cn/
* 文件描述：一切从简，只为了更懒！
*/
namespace App.Entity
{
	[Serializable]
	[DataContract]
	public partial class User
	{
		/// <summary>
		/// 描述：
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public int Id { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public string UserName { get; set; }

		/// <summary>
		/// 描述：
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public DateTime AddTime { get; set; }

	}
}