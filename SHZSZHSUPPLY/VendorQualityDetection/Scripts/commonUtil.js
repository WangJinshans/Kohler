function QT_flashTip(msg, position_Name) {
    layui.use('form', function () {
        var form = layui.form,
            layer = layui.layer;
        layer.msg(msg, {
            time: 3000
        }, function () {
            //页面回退
            if (position_Name == '检验员') {
                location.href = 'InspectionList.aspx';
            } else {
                location.href = 'QualityClerkOperateList.aspx';
            }
        });
    });
}

function reInspectionTips(msg) {
    layui.use('form', function () {
        var form = layui.form,
            layer = layui.layer;
        layer.msg(msg, {
            time: 3000
        }, function () {
            //页面回退
            location.href = 'QualityClerkOperateList.aspx';
        });
    });
}


function mytips(msg) {
    layui.use('form', function () {
        var layer = layui.layer;
        layer.msg(msg);
    });
}

function mytips_then_back(msg, url) {
    layui.use('form', function () {
        var layer = layui.layer;
        layer.msg(msg, {
            time: 3000
        }, function () {
            location.href = url;
        })
    })
}