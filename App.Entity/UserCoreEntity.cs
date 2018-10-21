using System;
using System.Runtime.Serialization;

/*!
* 文件名称：UserCoreEntity实体类
* 文件作者：百小僧
* 编写日期：2017-01-16 11:31:03
* 版权所有：百签软件有限公司
* 企业官网：http://www.baisoft.org
* 开源协议：GPL v2 License
* 文件描述：一切从简，只为了更懒！
*/
namespace App.Entity
{
	[Serializable]
	[DataContract]
	public partial class UserCoreEntity
	{
		/// <summary>
		/// 描述：用户ID
		/// 可空：不为空
		/// 默认值：
		/// </summary>
		[DataMember]
		public int UserID { get; set; }

		/// <summary>
		/// 描述：用户编号
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string No { get; set; }

		/// <summary>
		/// 描述：用户唯一标识ID
		/// 可空：不为空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string GUID { get; set; }

		/// <summary>
		/// 描述：用户账号
		/// 可空：不为空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Account { get; set; }

		/// <summary>
		/// 描述：登录密码，MD5小写32位加密
		/// 可空：不为空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Password { get; set; }

		/// <summary>
		/// 描述：用户头像，Json数组，存储格式为[{"large":"large.jpg"},{"medium":"medium.jpg"},{"small":"small.jpg"}]，MD5小写32位加密
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string Picture { get; set; }

		/// <summary>
		/// 描述：加入时间
		/// 可空：不为空
		/// 默认值：(getdate())
		/// </summary>
		[DataMember]
		public DateTime JoinTime { get; set; }

		/// <summary>
		/// 描述：加入IP地址
		/// 可空：不为空
		/// 默认值：('127.0.0.1')
		/// </summary>
		[DataMember]
		public string JoinIPAddress { get; set; }

		/// <summary>
		/// 描述：当前登录时间
		/// 可空：空
		/// 默认值：(getdate())
		/// </summary>
		[DataMember]
		public Nullable<DateTime> CurrentLoginTime { get; set; }

		/// <summary>
		/// 描述：当前登录人IP地址
		/// 可空：空
		/// 默认值：('127.0.0.1')
		/// </summary>
		[DataMember]
		public string CurrentLoginIPAddress { get; set; }

		/// <summary>
		/// 描述：登录次数
		/// 可空：空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public Nullable<int> LoginCount { get; set; }

		/// <summary>
		/// 描述：最后登录时间
		/// 可空：空
		/// 默认值：(getdate())
		/// </summary>
		[DataMember]
		public Nullable<DateTime> LastLoginTime { get; set; }

		/// <summary>
		/// 描述：最后登录IP地址
		/// 可空：空
		/// 默认值：('127.0.0.1')
		/// </summary>
		[DataMember]
		public string LastLoginIPAddress { get; set; }

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
		/// 描述：是否删除
		/// 可空：不为空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public bool IsDel { get; set; }

		/// <summary>
		/// 描述：是否过期
		/// 可空：不为空
		/// 默认值：((0))
		/// </summary>
		[DataMember]
		public bool IsExpire { get; set; }

		/// <summary>
		/// 描述：即时通讯融云Token
		/// 可空：空
		/// 默认值：('')
		/// </summary>
		[DataMember]
		public string RongCloudToken { get; set; }

	}
}