<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillReInspection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.Html.FillReInspection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../../VendorAssess/Script/layui/layui.js"></script>
    <link href="../../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../../VendorAssess/Script/Own/fileUploader.js"></script>
    <script>
        layui.use('form', function () {
            var form = layui.form(),
                layer = layui.layer;



        });

        function setReInspectionItems(itemArray) {
            localStorage.setItem("itemArray", itemArray);
        }
    </script>
</head>
<body>
    <form class="layui-form" runat="server" id="form1">
        <fieldset class="layui-field-title layui-elem-field" style="width:800px;margin: 0 auto;">
            <legend style="text-align:center;">请选择需要重新检验的项目</legend>
        </fieldset>
        <div class="layui-form-item" style="width:800px;margin: 50px auto 20px auto;">
            <div class="layui-input-block">
                <table>
                    <asp:Repeater runat="server" ID="repeater">
                        <ItemTemplate>
                            <asp:CheckBox runat="server" Text='<%# Eval("Item") %>' ID="check" />
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="layui-form-item" style="margin:0 auto;width:800px;">
            <asp:Button ID="submit" runat="server" CssClass="layui-btn" Text="确认选择" OnClick="submit_Click" />
        </div>

    </form>
</body>
</html>
