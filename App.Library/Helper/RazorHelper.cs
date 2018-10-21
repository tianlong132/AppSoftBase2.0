using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace App.Library.Helper
{
    public static class RazorHelper
    {
        #region 生成Submit按钮 - public static MvcHtmlString Submit(this HtmlHelper htmlHelper, string value)
        /// <summary>
        /// 生成Submit按钮
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="value">按钮值</param>
        /// <returns></returns>
        public static MvcHtmlString Submit(this HtmlHelper htmlHelper, string value)
        {
            return new MvcHtmlString(string.Format("<input type=\"submit\" value=\"{0}\" />", value));
        }
        #endregion

        #region 生成Submit按钮 + public static MvcHtmlString Submit(this HtmlHelper htmlHelper, string value, object htmlAttributes)
        /// <summary>
        /// 生成Submit按钮
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="value">按钮值</param>
        /// <param name="htmlAttributes">属性列表</param>
        /// <returns></returns>
        public static MvcHtmlString Submit(this HtmlHelper htmlHelper, string value, object htmlAttributes)
        {
            string attrs = string.Empty;
            IDictionary<string, object> attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (attributes.Any())
            {
                foreach (var item in attributes.Keys)
                {
                    attrs += " " + item + "=\"" + attributes[item].ToString() + "\" ";
                }
            }

            return new MvcHtmlString(string.Format("<input type=\"submit\" value=\"{0}\" {1} />", value, attrs));
        }
        #endregion

        #region 生成超链接 + public static MvcHtmlString Href(this HtmlHelper htmlHelper, string url, string title, string text, string target = "_self")
        /// <summary>
        /// 生成超链接
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="url">链接地址</param>
        /// <param name="title">标题</param>
        /// <param name="text">文本</param>
        /// <param name="target">打开方式</param>
        /// <returns></returns>
        public static MvcHtmlString Href(this HtmlHelper htmlHelper, string url, string title, string text, string target = "_self")
        {
            return new MvcHtmlString(string.Format("<a href=\"{0}\" title=\"{1}\" target=\"{2}\">{3}</a> ", url, title, target, text));
        }
        #endregion

        #region 生成超链接 + public static MvcHtmlString Href(this HtmlHelper htmlHelper, string url, string title, string text, string target = "_self")
        /// <summary>
        /// 生成超链接
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="url">链接地址</param>
        /// <param name="title">标题</param>
        /// <param name="text">文本</param>
        /// <param name="text">文本</param>
        /// <param name="htmlAttributes">属性列表</param>
        /// <returns></returns>
        public static MvcHtmlString Href(this HtmlHelper htmlHelper, string url, string title, string text, object htmlAttributes, string target = "_self")
        {
            string attrs = string.Empty;
            IDictionary<string, object> attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (attributes.Any())
            {
                foreach (var item in attributes.Keys)
                {
                    attrs += " " + item + "=\"" + attributes[item].ToString() + "\" ";
                }
            }

            return new MvcHtmlString(string.Format("<a href=\"{0}\" title=\"{1}\" target=\"{2}\" {4}>{3}</a> ", url, title, target, text, attrs));
        }
        #endregion

        #region 生成格式化脚本引用 + public static IHtmlString ScriptsRenderFormat(this HtmlHelper htmlHelper, object htmlAttributes, params string[] paths)
        /// <summary>
        /// 生成格式化脚本引用
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes">属性</param>
        /// <param name="paths">脚本地址</param>
        /// <returns></returns>
        public static IHtmlString ScriptsRenderFormat(this HtmlHelper htmlHelper, object htmlAttributes, params string[] paths)
        {
            string attrs = string.Empty;
            IDictionary<string, object> attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            if (attributes.Any())
            {
                foreach (var item in attributes.Keys)
                {
                    attrs += " " + item + "=\"" + attributes[item].ToString() + "\" ";
                }
            }
            string script = string.Format("<script type=\"text/javascript\" {0} ", attrs);
            return Scripts.RenderFormat(script + " src=\"{0}\" ></script>", paths);
        }
        #endregion
    }
}
