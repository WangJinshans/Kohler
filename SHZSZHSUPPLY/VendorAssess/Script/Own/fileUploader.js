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

