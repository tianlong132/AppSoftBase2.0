/*!
 * 文件名称：登录页面js
 * 文件作者：百小僧
 * 编写日期：2016年02月23日
 * 版权所有：百签软件有限公司
 * 企业官网：http://www.baisoft.org
 * 开源协议：GPL v2 License
 * 文件描述：一切从简，只为了更懒！
 */

!function (factory) {
    if (typeof require === 'function' && typeof exports === 'object' && typeof module === 'object') {
        var target = module['exports'] || exports;
        factory(target);
    } else if (typeof define === 'function' && define['amd']) {
        define(['exports'], factory);
    } else {
        factory(window['loginModule'] = {});
    }
}(function (loginExports) {
    var loginModule = typeof loginExports !== 'undefined' ? loginExports : {};
});