// 监控页面是否加载完毕
//document.onreadystatechange = loadClickEvent;
//function loadClickEvent() {
//    if (document.readyState == "complete") {
//    }
//}


// 配置layer路径问题
layer.config({
    path: '/Scripts/Libs/layer-v2.1/',
    extend: [
    ]
});
// 重写表单提示信息
$.Tipmsg.r = null;
var showError = function (msg, o, cssctl) {
    layer.msg(msg, {
        offset: 0,
        shift: 6
    });
}

// 显示成功按钮
var showSuccess = function (msg, callback, _time) {
    _time = typeof _time == "number" ? _time : 3000;
    layer.msg(msg, {
        time: 3000
    });

    if (typeof callback == "function") {
        setTimeout(function () {
            callback();
        }, _time);
    }
}

// 显示加载按钮
var showLoad = function (_time) {
    _time = typeof _time == "number" ? _time : 15;

    return layer.load(1, { time: _time * 1000, shade: [0.8, '#393D49'] });
};

// 提交表单
function SubmitForm(formSelecter, submitSelector, callback, beforeSubmit, beforeCheck) {
    var __loadid = 0;
    // 表单验证
    $(formSelecter).Validform({
        btnSubmit: submitSelector,
        tiptype: function (msg, o, cssctl) {
            showError(msg, o, cssctl);
        },
        tipSweep: false,
        showAllError: false,
        postonce: true,
        ajaxPost: true,
        datatype: {
        },
        beforeCheck: function (curform) {
            if (typeof beforeCheck == "function") {
                beforeCheck(curform);
            }
        },
        beforeSubmit: function (curform) {
            __loadid = showLoad();
            if (typeof beforeSubmit == "function") {
                beforeSubmit(curform);
            }
        },
        callback: function (data) {
            layer.close(__loadid);
            if (data.statu == "no_login") {
                showError(data.tip);
                return false;
            }
            if (ShowErrorTip(formSelecter, data) == true) {
                if (typeof callback == "function") {
                    callback(data);
                }
            }
        }
    });
}

// 显示错误提示信息
function ShowErrorTip(formSelector, data) {
    if (data && data.statu && data.statu == "check_fail") {
        if (data.errors.length > 0) {
            var errorObj = (data.errors)[0];
            $(formSelector).find("input[name='" + errorObj.PropertyName + "'],select[name='" + errorObj.PropertyName + "'],textarea[name='" + errorObj.PropertyName + "']").focus();
            showError(errorObj.ErrorMsg);
            return false;
        }
        else {
            return true;
        }
    }
    else {
        return true;
    }
}