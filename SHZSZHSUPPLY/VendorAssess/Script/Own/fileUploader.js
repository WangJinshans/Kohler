/*
 *created by Wei Tingjiang
 *Notes:使用此文件中的函数之前必须在页面内部引入layui.css、layui.js、JQuery文件
 */


var uploadFileResult = { 'success': false };

function getRootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    return (prePath + postPath);
}

//上传文件
function uploadFile(requestType, tempVendorID, tempVendorName, fileTypeID, needDate, callback) {
    layui.use(['form', 'layer'], function () {
        var layer = layui.layer;
        layer.open({
            type: 2,
            title: '文件上传',
            maxmin: true,
            content: './Html_Template/File_Upload_Page.html?v=5',
            area: ['800px', '300px'],
            shadeClose: false,
            success: function (layero, index) {
                var iframeWin = window[layero.find('iframe')[0]['name']];
                iframeWin.setOwnParams(requestType, tempVendorID, tempVendorName, fileTypeID, needDate);
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

//获取文件上传结果
function getUploadResult() {
    return uploadFileResult;
}

//基本提示
function message(msg) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.msg(msg);
    })
}

//提示后可自行回调的提示
function messageFunc(msg, func) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.msg(msg, { time: 1500 }, func);
    })
}

//确认后可跳转到指定url的确认框
function messageConfirm(msg, aimURL) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            title: '提示'
        , content: msg
        , yes: function (index, layero) {
            window.location.href = aimURL;
        }
        });
    })
}

//带确认按钮的提示框
function messageConfirmNone(msg) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            title: '提示'
            , content: msg
        });
    })
}

//可自定义title的带确认按钮的提示框
function messageConfirmTitle(title, msg) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            title: title
            , content: msg
        });
    })
}

//打开等待遮罩
function waiting(msg) {
    layui.use(['layer'], function () {
        layer.msg(msg, {
            icon: 16
            , shade: 0.65
            , time: 0
            , shadeClose: true
        });
    });
}

//关闭等待遮罩
function closeWaiting() {
    layui.use(['layer'], function () {
        layer.closeAll();
    });
}

//拒绝审批，打开原因填写
function openReasonDialog(form_id, position_name, factory_name, callback) {
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
                    async: false,
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
                        layer.msg("操作失败" + textStatus + errorThrown);
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

//确认是否需要进行kci审批，需要在调用页面实现postback回调
function openKCIConfirm() {
    layui.use(['layer'], function () {
        layer.confirm('是否需要KCI审批？', {
            btn: ['是', '否'], yes: function (index, layero) {
                __myDoPostBack('addKCI', '');
        }, btn2: function (index, layero) {
            __myDoPostBack('removeKCI', '');
        }
        });
    })
}

//禁止回退
function blockBack() {
    history.pushState(null, null, document.URL);
    window.addEventListener('popstate', function () {
        history.pushState(null, null, document.URL);
    });
}

//强制实现postback
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

//回退，无刷新
function goBack() {
    window.history.go(-1); 
}

//回退，强制刷新
function goBackRefresh() {
    window.history.back();
    location.reload(); 
}

//供应商创建专属调用
function changeCurrentVendor(factory, type, vendorID) {
    localStorage.setItem('newFactory', factory);
    localStorage.setItem('newType', type);
    localStorage.setItem('newName', vendorID);

    document.location.href = 'EmployeeVendor.aspx';
}

//URL处理
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

//隐藏show页面的多余元素
function hideShowOtherElements() {
    if (getQueryString("outPutID") != null) {
        //处理outputPDF事件
        $(".layui-btn").hide();
        $(".gridtable").hide();
    }
}

//Show页面textarea设置
function showAllText() {
    $.each($("textarea"), function (i, n) {
        $(n).css("height", n.scrollHeight + "px");
    });
}

//Open PDF with a new tab
function viewFile(filePath) {
    window.open(filePath);
}

//请求生成PDF预览，供前端使用（同一时间只有一份pdf存在，保存在设置中的临时文件夹）,需要实现button（id为btnPDF）
function requestToPdfAshx(ops) {
    waiting('正在生产PDF预览...');
    $.post("ASHX/PDF.ashx", { requestType: 'showPDF', pdfURL: $('input#btnPDF').attr('title'),options:arguments[0]?arguments[0]:'' }, function (data, status) {
        var json = JSON.parse(data);
        if (json['success']) {
            closeWaiting();
            window.open(json['message']);
        } else {
            closeWaiting();
            message(json['message']);
        }
    })
}

//打开签名选择对话框
function openSignatureSelection(elem,callback) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            type: 2,
            title: '选择签名',
            maxmin: true,
            content: './Html_Template/SignatureSelection.aspx',
            area: ['500px', '400px'],
            shadeClose: true,
            btn: ['确定'],
            yes: function (index, layero) {
                var iframeWin = window[layero.find('iframe')[0]['name']];
                var result = iframeWin.getResult();
                if (callback != null) {
                    callback(result);
                } else {
                    elem.src = result;
                    document.getElementById('ImgExSrc').value = elem.id + ',' + result;
                    document.getElementById('btnNewImage').click();
                    //__myDoPostBack('newImageSrc', elem.id + ',' + result);
                }
                layer.close(index);
            },
            success: function (layero, index) {
                
            },
            cancel: function (index, layero) {

            }
        });
    });
}

function openSignatureSelectio_s(elem, callback) {
    layui.use(['layer'], function () {
        var layer = layui.layer;
        layer.open({
            type: 2,
            title: '选择签名',
            maxmin: true,
            content: './Html_Template/SignatureSelection.aspx',
            area: ['500px', '400px'],
            shadeClose: true,
            btn: ['确定'],
            yes: function (index, layero) {
                var iframeWin = window[layero.find('iframe')[0]['name']];
                var result = iframeWin.getResult();
                if (callback != null) {
                    callback(result);
                } else {
                    elem.src = result;
                    //document.getElementById('ImgExSrc').value = elem.id + ',' + result;
                    //document.getElementById('btnNewImage').click();
                    __myDoPostBack('newImageSrc', elem.id + ',' + result);
                }
                layer.close(index);
            },
            success: function (layero, index) {

            },
            cancel: function (index, layero) {

            }
        });
    });
}

function isPromise() {
    layui.use(['layer'], function () {
        layer.confirm('是否承诺性供应商？', {
            btn: ['是', '否'],
            yes: function (index, layero) {
                __myDoPostBack('isPromised', 'yes');
            }, btn2: function (index, layero) {
                __myDoPostBack('isPromised', 'no');
            }
        });
    })
}
