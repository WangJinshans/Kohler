/*created by Wei Tingjiang
 *Notes:使用此文件中的函数之前必须在页面内部引入layui.css、layui.js、JQuery文件
 */


var uploadFileResult = { 'success': false };


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
            },
            end: function () {
                uploadFileResult = localStorage.getItem('uploadResult');
                if (uploadFileResult != null) {
                    uploadFileResult = JSON.parse(uploadFileResult);
                    if (uploadFileResult['success']) {
                        layer.msg('上传成功');//这里可以改为提醒1秒后刷新页面 2017年9月10日16:06:08
                    } else {
                        layer.msg('上传失败' + uploadFileResult['error']);
                    }
                }

                if (callback != null) {
                    callback(uploadFileResult);
                }
                if (fireRefresh != null) {
                    fireRefresh();
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

function messageFunc(msg, func) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.msg(msg, { time: 1500 },func);
    })
}

function openReasonDialog(form_id,position_name,factory_name,callback) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.prompt({
            formType: 2,
            value: '',
            title: '请填写原因',
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
                        messageFunc('已拒绝，正在执行回滚程序，请稍等……', function () {
                            window.location.href = './ShowApproveForm.aspx';
                        });
                        layer.close(index);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        layer.msg("操作失败"+textStatus+errorThrown);
                    }
                });
            }
        });
    });
}

//弹出框 选择审批 
function popUp(formid) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            title: '请选择审批部门',
            content: 'SelectDepartment.aspx?formid=' + formid,
            type: 2,
            area: ['750px', '450px'],
            shade: 0.3,
            shadeClose: false, //点击遮罩关闭
            btn: ['确定'],
            yes: function (index, layero) {
                __myDoPostBack('submitForm', '');
                layer.close(index);
            },
            cancel: function (index, layero) {
                if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                    layer.close(index)
                }
                return false;
            },
            success: function (layero, index) {
                console.log(layero, index);
            }
        });
    });
}

function blockBack() {
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });
}

function __myDoPostBack(eventTarget, eventArgument) {
    var theForm = document.forms['form1'];
    if (document.getElementById('__EVENTTARGET') == null) {
        var input1 = document.createElement('input');
        input1.type = "hidden";
        input1.name = "__EVENTTARGET";
        input1.id = "__EVENTTARGET";
        input1.value = "";
        theForm.appendChild(input1);
    }
    if (document.getElementById('__EVENTARGUMENT') == null) {
        var input2 = document.createElement('input');
        input2.type = "hidden";
        input2.name = "__EVENTARGUMENT";
        input2.id = "__EVENTARGUMENT";
        input2.value = "";
        theForm.appendChild(input2);
    }
    if (!theForm) {
        theForm = document.form1;
    }
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm.__EVENTTARGET.value = eventTarget;
        theForm.__EVENTARGUMENT.value = eventArgument;
        theForm.submit();
    }
}

function goBack() {
    window.history.go(-1); //回退，无刷新
}

function goBackRefresh() {
    window.history.back();
    location.reload(); //回退，强制刷新
}

//供应商创建专属调用
function changeCurrentVendor(factory, type, vendorID) {
    localStorage.setItem('newFactory', factory);
    localStorage.setItem('newType', type);
    localStorage.setItem('newName', vendorID);

    document.location.href = 'EmployeeVendor.aspx';
}