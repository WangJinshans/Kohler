<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadInfo.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.LoadInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <link href="Scripts/fine-uploader/fine-uploader-gallery.css" rel="stylesheet" />
    <link href="Scripts/fine-uploader/fine-uploader-new.css" rel="stylesheet" />
    <script src="Scripts/fine-uploader/fine-uploader.js"></script>
    <script type="text/template" id="qq-template-manual-trigger">
        <div class="qq-uploader-selector qq-uploader" qq-drop-area-text="拖动文件到此处">
            <div class="qq-total-progress-bar-container-selector qq-total-progress-bar-container">
                <div role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" class="qq-total-progress-bar-selector qq-progress-bar qq-total-progress-bar"></div>
            </div>
            <div class="qq-upload-drop-area-selector qq-upload-drop-area" qq-hide-dropzone>
                <span class="qq-upload-drop-area-text-selector"></span>
            </div>
            <div class="buttons">
                <div class="qq-upload-button-selector qq-upload-button">
                    <div>选择文件</div>
                </div>
                <button type="button" id="trigger-upload" class="btn btn-primary">
                    <i class="icon-upload icon-white"></i>导入
                </button>
            </div>
            <span class="qq-drop-processing-selector qq-drop-processing">
                <span>正在处理...</span>
                <span class="qq-drop-processing-spinner-selector qq-drop-processing-spinner"></span>
            </span>
            <ul class="qq-upload-list-selector qq-upload-list" aria-live="polite" aria-relevant="additions removals">
                <li>
                    <div class="qq-progress-bar-container-selector">
                        <div role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" class="qq-progress-bar-selector qq-progress-bar"></div>
                    </div>
                    <span class="qq-upload-spinner-selector qq-upload-spinner"></span>
                    <img class="qq-thumbnail-selector" qq-max-size="100" qq-server-scale>
                    <span class="qq-upload-file-selector qq-upload-file"></span>
                    <span class="qq-edit-filename-icon-selector qq-edit-filename-icon" aria-label="Edit filename"></span>
                    <input class="qq-edit-filename-selector qq-edit-filename" tabindex="0" type="text">
                    <span class="qq-upload-size-selector qq-upload-size"></span>
                    <button type="button" class="qq-btn qq-upload-cancel-selector qq-upload-cancel">取消</button>
                    <button type="button" class="qq-btn qq-upload-retry-selector qq-upload-retry">重试</button>
                    <button type="button" class="qq-btn qq-upload-delete-selector qq-upload-delete">删除</button>
                    <span role="status" class="qq-upload-status-text-selector qq-upload-status-text"></span>
                </li>
            </ul>
            <dialog class="qq-alert-dialog-selector">
                <div class="qq-dialog-message-selector"></div>
                <div class="qq-dialog-buttons">
                    <button type="button" class="qq-cancel-button-selector">关闭</button>
                </div>
            </dialog>
            <dialog class="qq-confirm-dialog-selector">
                <div class="qq-dialog-message-selector"></div>
                <div class="qq-dialog-buttons">
                    <button type="button" class="qq-cancel-button-selector">否</button>
                    <button type="button" class="qq-ok-button-selector">是</button>
                </div>
            </dialog>
            <dialog class="qq-prompt-dialog-selector">
                <div class="qq-dialog-message-selector"></div>
                <input type="text">
                <div class="qq-dialog-buttons">
                    <button type="button" class="qq-cancel-button-selector">取消</button>
                    <button type="button" class="qq-ok-button-selector">确定</button>
                </div>
            </dialog>
        </div>
    </script>

    <style>
        #trigger-upload {
            color: white;
            background-color: #00ABC7;
            font-size: 14px;
            padding: 7px 20px;
            background-image: none;
        }

        #fine-uploader-manual-trigger .qq-upload-button {
            margin-right: 15px;
        }

        #fine-uploader-manual-trigger .buttons {
            width: 36%;
        }

        #fine-uploader-manual-trigger .qq-uploader .qq-total-progress-bar-container {
            width: 60%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="fine-uploader-manual-trigger" style="width: 935px; margin: 50px auto;"></div>

        <fieldset class="layui-elem-field layui-field-title" style="width: 950px; margin: 50px auto 20px auto;">
            <legend style="text-align: center;" runat="server">手动添加</legend>
        </fieldset>
        <script>
            function showMsg(message) {
                layui.use(['layer'], function () {
                    var layer = layui.layer;
                    layer.msg(message);
                });
            }
            var manualUploader = new qq.FineUploader({
                element: document.getElementById('fine-uploader-manual-trigger'),
                template: 'qq-template-manual-trigger',
                request: {
                    endpoint: 'ASHX/LoadFileData.ashx'
                },
                autoUpload: false,
                thumbnails: {
                    placeholders: {
                        waitingPath: 'Scripts/fine-uploader/placeholders/waiting-generic.png',
                        notAvailablePath: 'Scripts/fine-uploader/placeholders/not_available-generic.png'
                    }
                },
                messages: {
                    typeError: "文件类型错误",
                    sizeError: "文件过大",
                    emptyError: "文件不能为空",
                    noFilesError: "无文件可上传"
                },
                validation: {
                    allowedExtensions: ['xlsx', 'xls'],
                    itemLimit: 100,
                    sizeLimit: 102400 // 100 kB = 100 * 1024 bytes
                },
                callbacks: {
                    onProgress: function (id, fileName, loaded, total) {

                    },
                    onComplete: function (id, fileName, responseJSON) {
                        upLoadSuccess();
                    },
                    onError: function (id, fileName, reason, request) {
                        showMsg(reason);
                    }
                },
                debug: true
            });

            qq(document.getElementById("trigger-upload")).attach("click", function () {
                manualUploader.uploadStoredFiles();
            });

            function upLoadSuccess() {
                layui.use(['layer'], function () {
                    var layer = layui.layer;
                    layer.msg('导入成功');
                    location.href = 'InspectionList.aspx';
                });
            }
        </script>
        <%--<div style="text-align:center;height:30px">
					检验批:
                    <asp:TextBox runat="server" style="width: 15%; height: 85%" CssClass="layui-input" ID="TextBox1" />
         </div>--%>
         <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">检验批</label>
            
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="BatchNo" />
            
        </div>
        <br />
        <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">材料描述</label>
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="Material" />
        </div>
        <br />
        <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">SKU</label>
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="SKUInput" />
        </div>
        <br />
        <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">供应商编号</label>
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="VendorCode" />
        </div>
        <br />
        <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">数量</label>
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="Quantity" />
        </div>
        <br />
        <div class="layui-form-item" style="margin: 0 auto; width: 500px;">
            <label class="layui-form-label" style="width: 100px;">导入人ko</label>
                <asp:TextBox runat="server" style="width:300px;" CssClass="layui-input" ID="InputKO" />
        </div>

        <script>
            function whetherInsert() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '提示',
					content: '确定添加检验项?',
					btn: ['确定', '返回'],
					yes: function (index, layero) {
						__myDoPostBack('insertItem', '');
					},
					btn2: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}
        </script>
        
        <div style="text-align: center;margin-top:20px;">
            <asp:Button CssClass="layui-btn" Text="确认" ID="apply" OnClick="apply_Click1" runat="server" />
        </div>
        
    </form>
</body>
</html>
