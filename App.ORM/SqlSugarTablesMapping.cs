using SqlSugar;
using System.Collections.Generic;

/*!
* 文件名称：SqlSugarInstance分部映射文件SqlSugarTablesMapping.cs
* 文件作者：杨龙刚
* 编写日期：2018-10-21 14:15:00
* 版权所有：上海艾艺信息技术有限公司
* 企业官网：http://www.adinnet.cn/
* 文件描述：一切从简，只为了更懒！
*/
namespace App.ORM
{
	public partial class SqlSugarInstance
	{
		private static List<KeyValue> _MappingTables = new List<KeyValue>()
		{
			new KeyValue() { Key="User",Value="User"}
		};
	}
}