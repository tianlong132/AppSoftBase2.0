using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

/*!
 * 文件名称：Json序列化
 * 文件作者：杨龙刚
 */

namespace App.Library.Helper
{
    public class JsonHelper
    {
        public static JavaScriptSerializer jss = new JavaScriptSerializer();

        #region 静态：对象转换成json + public static string DataContractJsonSerialize<T>(T jsonObject)
        /// <summary>
        /// 对象转换成json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject">需要格式化的对象</param>
        /// <returns>Json字符串</returns>
        public static string DataContractJsonSerialize<T>(T jsonObject)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            string json = null;
            using (var ms = new MemoryStream()) //定义一个stream用来存发序列化之后的内容
            {
                serializer.WriteObject(ms, jsonObject);
                var dataBytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(dataBytes, 0, (int)ms.Length);
                json = Encoding.UTF8.GetString(dataBytes);
                ms.Close();
            }
            return json;
        }
        #endregion

        #region 方法：json字符串转换成对象 + public static T DataContractJsonDeserialize<T>(string json)
        /// <summary>
        /// json字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">要转换成对象的json字符串</param>
        /// <returns></returns>
        public static T DataContractJsonDeserialize<T>(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var obj = default(T);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
            }
            return obj;
        }
        #endregion

        #region 静态：将json字符串转化为指定的对象 + public static T Deserialize<T>(string jsonStr)
        /// <summary>
        /// 将json字符串转化为指定的对象
        /// </summary>
        /// <typeparam name="T">指定反序列化的类型</typeparam>
        /// <param name="jsonStr">需要反序列化的json字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonStr)
        {
            return jss.Deserialize<T>(jsonStr);
        }
        #endregion

        #region 静态：将对象序列号成Json字符串 + public static string Serialize(object obj)
        /// <summary>
        /// 将对象序列号成Json字符串
        /// </summary>
        /// <param name="obj">需要序列号的对象</param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            return jss.Serialize(obj);
        }
        #endregion
    }
}
