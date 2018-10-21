using System.Web;
using System.Web.Optimization;

namespace App.Site
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 全局通用样式，包含重置样式和动画
            bundles.Add(new StyleBundle("~/AppStyle/Common").Include(
                "~/Content/Styles/Common/normalize.css",
                "~/Content/Styles/Common/animate.css",
                "~/Content/Styles/Common/common.css"
            ));

            // 后台系统样式
            bundles.Add(new StyleBundle("~/AppStyle/Backend").Include(
                "~/Content/Styles/Backend/backend.css"
            ));

            // 字体图标
            bundles.Add(new StyleBundle("~/AppStyle/Iconfont").Include(
              "~/Content/Styles/Backend/Iconfont/iconfont.css"
             ));

            // 全局脚本，包含jQuery，jQuery.easing，json2，lodash
            bundles.Add(new ScriptBundle("~/AppScript/CommonFull").Include(
                "~/Scripts/Libs/jquery-v2.2.1/jquery-2.2.1.min.js",
                "~/Scripts/Libs/jquery.easing-v1.3/jquery.easing.1.3.js",
                "~/Scripts/Libs/json2/json2.js",
                "~/Scripts/Libs/json2/json_parse.js",
                "~/Scripts/Libs/json2/json_parse_state.js",
                "~/Scripts/Libs/json2/cycle.js",
                "~/Scripts/Libs/lodash-v4.5.0/lodash.js"
            ));
            // 全局脚本，包含jQuery，jQuery.easing
            bundles.Add(new ScriptBundle("~/AppScript/CommonSimple").Include(
                "~/Scripts/Libs/jquery-v2.2.1/jquery-2.2.1.min.js",
                "~/Scripts/Libs/jquery.easing-v1.3/jquery.easing.1.3.js"
            ));

            // 加载监控
            bundles.Add(new StyleBundle("~/AppStyle/Pace").Include(
               "~/Scripts/Libs/pace-v1.0.2/themes/blue/pace-theme-minimal.css"
           ));
            bundles.Add(new ScriptBundle("~/AppScript/Pace").Include(
               "~/Scripts/Libs/pace-v1.0.2/pace.min.js"
           ));

            // 表单验证插件
            bundles.Add(new ScriptBundle("~/AppScript/Validform").Include(
               "~/Scripts/Libs/validform-v5.3.2/Validform-v5.3.2.js"
           ));

            // javascript模板引擎
            bundles.Add(new ScriptBundle("~/AppScript/Tppl").Include(
               "~/Scripts/Libs/tppl/tppl.js"
           ));

            // 分页
            bundles.Add(new StyleBundle("~/AppStyle/Pagination").Include(
              "~/Scripts/Libs/mricode.pagination-v1.4.0/mricode.pagination.css"
          ));
            bundles.Add(new ScriptBundle("~/AppScript/Pagination").Include(
               "~/Scripts/Libs/mricode.pagination-v1.4.0/mricode.pagination.js"
           ));

            // Layer弹窗
            bundles.Add(new ScriptBundle("~/AppScript/Layer").Include(
               "~/Scripts/Libs/layer-v2.1/layer.js",
               "~/Scripts/Libs/layer-v2.1/extend/layer.ext.js"
           ));

            // 滚动条插件
            bundles.Add(new ScriptBundle("~/AppScript/Nicescroll").Include(
               "~/Scripts/Libs/jquery.nicescroll-v3.6.7/jquery.nicescroll.min.js"
           ));

            // Linq操作
            bundles.Add(new ScriptBundle("~/AppScript/Linq").Include(
               "~/Scripts/Libs/linq-v3.0.4/linq.min.js"
           ));

            // pjax
            bundles.Add(new ScriptBundle("~/AppScript/Pjax").Include(
               "~/Scripts/Libs/jquery.pjax/jquery.pjax.js"
           ));

            // 后台全局脚本
            bundles.Add(new ScriptBundle("~/AppScript/Backend").Include(
               "~/Scripts/Backend/backend.js"
           ));

            // 选项卡
            bundles.Add(new StyleBundle("~/AppStyle/wdScrollTab").Include(
              "~/Scripts/Libs/wdScrollTab-v1.0.1/css/TabPanel.css"
             ));
            bundles.Add(new ScriptBundle("~/AppScript/wdScrollTab").Include(
               "~/Scripts/Libs/wdScrollTab-v1.0.1/js/Fader.js",
               "~/Scripts/Libs/wdScrollTab-v1.0.1/js/TabPanel.js",
               "~/Scripts/Libs/wdScrollTab-v1.0.1/js/Math.uuid.js"
           ));
        }
    }
}
