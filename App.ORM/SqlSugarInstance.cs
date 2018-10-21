using SqlSugar;
using System.Collections.Generic;

/*!
 * 文件名称：返回SqlSugarClient实体类
 * 文件作者：杨龙刚
 */

namespace App.ORM
{
    public partial class SqlSugarInstance
    {
        #region 构造：无参构造函数，禁止实例化 + public SqlSugarInstance()
        /// <summary>
        /// 禁止实例化
        /// </summary>
        public SqlSugarInstance()
        {
        }
        #endregion

        #region 静态：获取Sugar客户端实例对象 + public static SqlSugarClient GetInstance()
        /// <summary>
        /// 获取Sugar客户端实例对象
        /// </summary>
        /// <returns>SqlSugarClient</returns>
        public static SqlSugarClient GetInstance()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings[@"AppSoft.IO_ConnStr"].ToString();

            SqlSugarClient _SqlSugarClient = new SqlSugarClient(connection);

            // 映射表，解决类名和表名不一致情况，通常体现在表名加前缀，类名不加
            _SqlSugarClient.SetMappingTables(_MappingTables);

            return _SqlSugarClient;
        }
        #endregion
    }
}
