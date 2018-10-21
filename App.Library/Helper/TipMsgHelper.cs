using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Library.Helper
{
    public class TipMsgHelper
    {
        #region 方法：public static string CreateValidateFailMsg(ValidationResult results)
        /// <summary>
        /// 生成服务器端验证失败JSON提示消息
        /// </summary>
        /// <param name="results"></param>
        /// <returns></returns>
        public static ResponseMsg CreateValidateFailMsg(ValidationResult results)
        {
            List<ErrorInfo> errors = new List<ErrorInfo>();
            foreach (var failure in results.Errors)
            {
                errors.Add(new ErrorInfo()
                {
                    PropertyName = failure.PropertyName,
                    ErrorMsg = failure.ErrorMessage
                });
            }
            return new ResponseMsg()
            {
                errors = errors,
                statu = "check_fail",
                tip = "提交数据格式不正确，请重新输入！"
            };
        }
        #endregion

        #region 方法：返回Json数据 +  public static ResponseMsg CreateResponseMsg(string statu, string tip, List<ErrorInfo> errors)
        /// <summary>
        /// 返回Json数据
        /// </summary>
        /// <param name="statu">状态</param>
        /// <param name="tip">提示消息</param>
        /// <param name="errors">错误消息</param>
        /// <returns></returns>

        public static ResponseMsg CreateResponseMsg(string statu, string tip, List<ErrorInfo> errors = null)
        {
            return new ResponseMsg()
            {
                errors = errors,
                tip = tip,
                statu = statu
            };
        }
        #endregion
    }


    public class ErrorInfo
    {
        public string PropertyName { get; set; }
        public string ErrorMsg { get; set; }
    }

    public class ResponseMsg
    {
        public List<ErrorInfo> errors { get; set; }
        public string tip { get; set; }

        public string statu { get; set; }
    }
}
