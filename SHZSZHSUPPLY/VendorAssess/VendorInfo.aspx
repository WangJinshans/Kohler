<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorInfo.aspx.cs" Inherits="AendorAssess.VendorInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table {
            width: 800px;
            height: 400px;
            margin: 0 auto;
        }

        .auto-style1 {
            height: 58px;
        }
    </style>

    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=2"></script>
    <%--<script src="Script/layer/layer.js"></script>--%>
    <script>
        layui.use(['form', 'layedit', 'laydate'], function () {
            var form = layui.form()
            , layer = layui.layer
            , layedit = layui.layedit
            , laydate = layui.laydate;
        });

        function messageBox(msg) {
            layui.use('layer', function () {
                var layer = layui.layer;
                layer.msg(msg);
            })
        }

        function openConfirmDialog() {
            layui.use(['layer'], function () {
                layer.confirm('此供应商已经存在，是否为此供应商添加当前选择的供应商类型?', { icon: 3, title: '提示' }, function (index) {
                    //do something
                    __myDoPostBack('addVendorMultiType', '');
                    layer.close(index);
                });
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="layui-form">
        <div>
            <table>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td colspan="2" class="auto-style1">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <label class="layui-form-label">供应商名称</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="Temp_Vendor_Name" Style="width: 300px;" placeholder="请输入供应商名称" runat="server" class="layui-input"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <label class="layui-form-label">供应商类型</label>
                        <div class="layui-input-block">
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>直接物料常规</asp:ListItem>
                                <asp:ListItem>直接物料危化品</asp:ListItem>
                                <asp:ListItem>非生产性特种劳防品</asp:ListItem>
                                <asp:ListItem>非生产性危化品</asp:ListItem>
                                <asp:ListItem>非生产性常规</asp:ListItem>
                                <asp:ListItem>非生产性质量部有标准的物料</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <label class="layui-form-label">采购金额(万)</label>
                        <div class="layui-input-block">
                            <asp:TextBox ID="Purchase_Money" Style="width: 300px;" placeholder="金额" runat="server" class="layui-input"></asp:TextBox>
                        </div>
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="Promise" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="承诺"/>
                        <%--<asp:Label ID="Label2" runat="server" Text="是否承诺性"></asp:Label>
                        <asp:CheckBox ID="Promise" Text="[Promise]" runat="server" />--%>
                    </td>
                    <td>
                        <input id="Advance_Charge" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="预付款"/>
                        <%--<asp:Label ID="Label3" runat="server" Text="是否预付款"></asp:Label>
                        <asp:CheckBox ID="Advance_Charge" Text="[Advance_Charge]" runat="server" />--%>
                    </td>
                    <td>
                        <input id="Vendor_Assign" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="指定"/>
                        <%--<asp:Label ID="Label4" runat="server" Text="是否指定供应商"></asp:Label>
                        <asp:CheckBox ID="Vendor_Assign" Text="[Vendor_Assign]" runat="server" /><br />--%>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CssClass="layui-btn" ID="Button1" runat="server" Text="提交" OnClick="button1_click" />
                    </td>
                    <td>
                        <%--<asp:Button CssClass="layui-btn layui-btn-primary" ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
