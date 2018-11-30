<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyInspection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ApplyInspection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=2"></script>
    <script>
        layui.use(['form'], function () {
            var form = layui.form
                , layer = layui.layer;
            $('#batchNo').attr('placeholder', '检验批');
            $('#kg_inline').children("div").children("span").css("display", "none");
            $('#ge_inline').children("div").children("span").css("display", "none");
            $("#takeout").attr('placeholder', '取出');
            $("#amount").attr('placeholder', '不良');
        });


        function inFormRepertory() {
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;
                layer.open({
                    content: '是否上报仓库进行检验'
                    , btn: ['立即上报', '暂不上报']
                    , btnAlign: 'c'
                    , yes: function () {
                        __myDoPostBack("Apply", "");
                        layer.closeAll();
                    }
                    , btn1: function () {
                        layer.closeAll();
                    }
                    , cancle: function () {
                        layer.closeAll();
                    }
                })
            });
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <fieldset class="layui-field-title layui-elem-field" style="margin: 0 auto; width: 1000px;">
            <legend id="Legend1" style="text-align: center;" runat="server">车间报验</legend>
        </fieldset>
        <div class="layui-form-item" style="margin: 0 auto; width: 1000px;">
            <div class="layui-inline">
                <label class="layui-form-label" style="width: 100px;">SKU列表</label>
                <div class="layui-input-inline">
                    <asp:DropDownList runat="server" name="modules" lay-verify="required" lay-search="" ID="SKU">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="layui-inline">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="batchNo" />
            </div>
            <div class="layui-inline" id="ge_inline">
                <asp:RadioButton ID="ge" Text="件/个" runat="server" Checked="true" GroupName="radio" />
            </div>
            <div class="layui-inline" id="kg_inline">
                <asp:RadioButton ID="kg" Text="千克/升" runat="server" GroupName="radio" />
            </div>
        </div>
        <div class="layui-form-item" style="margin: 0 auto; width: 1000px;">
            <label class="layui-form-label" style="width: 100px;">取出</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="takeout" TextMode="MultiLine" />
            </div>
        </div>
        <div class="layui-form-item" style="margin: 0 auto; width: 1000px;">
            <label class="layui-form-label" style="width: 100px;">有瑕疵</label>
            <div class="layui-input-inline">
                <asp:TextBox runat="server" ID="amount" TextMode="MultiLine" />
            </div>
        </div>
        <div class="layui-form-item">
            <div class="layui-input" style="text-align: center;">
                <asp:Button CssClass="layui-btn" Text="确认" ID="apply" OnClick="apply_Click" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
