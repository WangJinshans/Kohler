<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorSharedUse.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorSharedUse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=5"></script>
    <script>
        layui.use(['form', 'layedit', 'laydate', 'element'], function () {
            var form = layui.form()
            , layer = layui.layer
            , layedit = layui.layedit
            , laydate = layui.laydate
            , element = layui.element();

            //监听
            form.on('select', function (data) {
                currentFactory = document.getElementById('factory').selectedIndex;
                currentType = document.getElementById('type').selectedIndex;
                currentName = document.getElementById('name').selectedIndex;
                storageParams();

                switch (data.elem.id) {
                    case 'factory':
                        onFactorySelectChanged();
                        break;
                    case 'type':
                        onVendorTypeSelectChanged();
                        break;
                    case 'name':
                        __myDoPostBack('showExistVendor', document.getElementById('name').value);
                        //$("#LBtempVendorID").val(document.getElementById('name').value);
                        //document.getElementById('LBtempVendorID').textContent = document.getElementById('name').value;
                        break;
                    default:
                        break;
                }
                console.log(data.elem); //得到select原始DOM对象
                console.log(data.value); //得到被选中的值
                console.log(data.othis); //得到美化后的DOM对象
            });

        });

        function message(msg) {
            layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.msg(msg, { time: 3000 });
            })
        }

        function refreshForm() {
            layui.use(['form'], function () {
                var form = layui.form();
                form.render('select');
            })
        }
    </script>
    <script>
        var vendorInfoJson = {};
        var currentFactory, currentType, currentName;

        function getParams() {
            this.vendorInfoJson = JSON.parse(localStorage.getItem('infoJson'));
            document.getElementById('factory').selectedIndex = localStorage.getItem('factory');
            document.getElementById('type').selectedIndex = localStorage.getItem('type');
            onVendorTypeSelectChanged();
            document.getElementById('name').selectedIndex = localStorage.getItem('name');
        }

        function setParams(infoJson) {
            this.vendorInfoJson = JSON.parse(infoJson);
            localStorage.setItem('infoJson', infoJson);
        }

        function storageParams() {
            localStorage.setItem('factory', currentFactory);
            localStorage.setItem('type', currentType);
            localStorage.setItem('name', currentName);
        }

        function onFactorySelectChanged() {
            var factorySelect = document.getElementById('factory');
            var typeSelect = document.getElementById('type');
            var nameSelect = document.getElementById('name');

            typeSelect.selectedIndex = 0;

            nameSelect.options.length = 0;
            nameSelect.options.add(new Option('请选择供应商名称', ''));

            refreshForm();
        }

        function onVendorTypeSelectChanged() {
            var factorySelect = document.getElementById('factory');
            var typeSelect = document.getElementById('type');
            var nameSelect = document.getElementById('name');

            nameSelect.options.length = 0;
            nameSelect.options.add(new Option("请选择供应商名称", ""))

            if (typeSelect.selectedIndex == 0) {
                return;
            } else {
                var names = vendorInfoJson[factorySelect.value][typeSelect.value];
                if (names != null) {
                    for (var i = 0; i < names.length; i += 2) {
                        nameSelect.options.add(new Option(names[i], names[i + 1]));
                    }
                }
            }
            refreshForm();
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px;visibility:hidden">返回</a>
            <asp:Label runat="server" ID="LBtempVendorID" Visible="true"></asp:Label>
            <label class="layui-form-label">供应商选择</label>
            <div class="layui-input-inline">
                <select id="factory" name="quiz1" onchange="onFactorySelectChanged()">
                    <option value="">请选择工厂</option>
                    <option value="上海科勒" selected="">上海科勒</option>
                    <option value="中山科勒">中山科勒</option>
                    <option value="珠海科勒">珠海科勒</option>
                </select>
            </div>
            <div class="layui-input-inline">
                <select id="type" name="quiz2" onchange="onVendorTypeSelectChanged()">
                    <option value="">请选择供应商类型</option>
                    <option value="直接物料常规">直接物料常规</option>
                    <option value="直接物料危化品">直接物料危化品</option>
                    <option value="非生产性质量部有标准的物料">非生产性质量部有标准的物料</option>
                    <option value="非生产性危化品">非生产性危化品</option>
                    <option value="非生产性特种劳防品">非生产性特种劳防品</option>
                    <option value="非生产性常规">非生产性常规</option>
                </select>
            </div>
            <div class="layui-input-inline">
                <select id="name" name="quiz3">
                    <option value="">请选择供应商名称</option>
                    <option value="name">name</option>
                </select>
            </div>
        </div>

        <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
            <legend id="vendorName" runat="server">供应商名称</legend>
        </fieldset>

        <asp:GridView Style="width: 1000px; margin: 0 auto" ID="File_GridView" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="0px" CellPadding="4" OnRowCommand="File_GridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                    SortExpression="Temp_Vendor_Name" />
                <asp:BoundField DataField="File_Type_Range" HeaderText="范围"
                    SortExpression="File_Type_Range" />
                <asp:BoundField DataField="File_Type_Name" HeaderText="类别"
                    SortExpression="File_Type_Name" />
                <asp:BoundField DataField="File_Name" HeaderText="文件名称"
                    SortExpression="File_Name" />
                <asp:BoundField DataField="File_ID" HeaderText="文件编号"
                    SortExpression="File_ID" Visible="false" />
                <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                    SortExpression="DepotSummary" Visible="False" />
                <asp:TemplateField ControlStyle-ForeColor="Blue" ControlStyle-Font-Underline="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                            CommandArgument='<%# Eval("File_Name") %>'>详情</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <%--<FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />--%>
        </asp:GridView>

        <div style="width:200px;margin:50px auto 0 auto">
            <asp:Button ID="btnYes" runat="server" CssClass="layui-btn" Text="确定" OnClick="btnYes_Click" UseSubmitBehavior="False"/>
            <%--<asp:Button ID="btnNo" runat="server" CssClass="layui-btn layui-btn-primary" Text="返回" OnClick="btnNo_Click" />--%>
        </div>

    </form>
</body>
</html>
