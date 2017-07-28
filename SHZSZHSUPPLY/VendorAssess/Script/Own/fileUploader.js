var uploadFileResult = {'success':false};


function uploadFile(requestType, tempVendorID, tempVendorName, fileTypeID,callback) {
    layui.use(['form', 'layer'], function () {
        var layer = layui.layer;
        layer.open({
            type: 2,
            title: '文件上传',
            maxmin: true,
            content: './Html_Template/File_Upload_Page.html',
            area: ['800px', '300px'],
            shadeClose: false,
            success: function (layero, index) {
                var iframeWin = window[layero.find('iframe')[0]['name']];
                iframeWin.setOwnParams(requestType,tempVendorID, tempVendorName, fileTypeID);
            },
            cancel: function (index, layero) {
                var iframeWin = window[layero.find('iframe')[0]['name']];
                uploadFileResult = iframeWin.getUploadResult();
                if (callback != null) {
                    callback(uploadFileResult);
                }
                return true;
            }
        });
    });
}

function getUploadResult() {
    return uploadFileResult;
}

function message(msg) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.msg(msg);
    })
}

function openReasonDialog(form_id,position_name,factory_name,callback) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.prompt({
            formType: 2,
            value: '',
            title: '请输入拒绝原因或理由',
            area: ['800px', '250px'] //自定义文本域宽高
        }, function (value, index, elem) {
            if (callback != null) {
                callback(value);
            } else {
                $.ajax({
                    type: "post",
                    async:false,
                    url: "./ASHX/Database_Handler.ashx",
                    data: { requestType: 'approveReason', formID: form_id, positionName: position_name, factoryName: factory_name, reason: value },
                    dataType: "json",
                    success: function (data, textStatus) {
                        message("已拒绝");
                        layer.close(index);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.msg("操作失败");
                    }
                });
            }
        });
    });
}