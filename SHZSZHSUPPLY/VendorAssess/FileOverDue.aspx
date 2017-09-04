<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileOverDue.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.FileOverDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>

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
                        __myDoPostBack('refreshVendor', document.getElementById('name').value);
                        break;
                    default:
                        break;
                }
            });

        });

        function message(msg) {
            layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.msg(msg, { time: 1500 });
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
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
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
        <%-- <div style="text-align:center;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label Text="请输入供应商的编号" runat="server" />
        <asp:TextBox runat="server" ID="TextBox1"/>
        &nbsp;&nbsp;&nbsp;&nbsp
        <asp:Label Text="厂区：" runat="server" CssClass="test"/>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="99px">
            <asp:ListItem Selected="True">上海科勒</asp:ListItem>
            <asp:ListItem>中山科勒</asp:ListItem>
            <asp:ListItem>珠海科勒</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp
        <asp:Button Text="搜索" runat="server" ID="search" OnClick="search_Click" />
        <br />
        <br />
             <!--
                 需要上传文件 需要保存新的文件到某个路径
                 -->
    </div>
        <br />
        <br />
        <br />--%>

        <fieldset class="layui-elem-field layui-field-title" style="width: 80%; margin: 50px auto 20px auto;">
            <legend runat="server">文件</legend>
        </fieldset>

          <asp:GridView Style="width: 80%; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:BoundField DataField="FileType_Name" HeaderText="文件编号"
								SortExpression="FileType_Name" />
							<asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商"
								SortExpression="Temp_Vendor_ID" />
							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton ID="lbtapprovesuccess" runat="server" CommandName="upload"
										CommandArgument='<%# Eval("FileType_Name") %>'>上传</asp:LinkButton>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
						<EditRowStyle BackColor="#2461BF" />
						<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
						<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
						<PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
						<RowStyle BackColor="#EFF3FB" />
						<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
						<SortedAscendingCellStyle BackColor="#F5F7FB" />
						<SortedAscendingHeaderStyle BackColor="#6D95E1" />
						<SortedDescendingCellStyle BackColor="#E9EBEF" />
						<SortedDescendingHeaderStyle BackColor="#4870BE" />
					</asp:GridView>
        <fieldset class="layui-elem-field layui-field-title" style="width: 80%; margin: 50px auto 20px auto;">
            <legend runat="server">表格</legend>
        </fieldset>
        <asp:GridView Style="width: 80%; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
								SortExpression="Form_ID" />
							<asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商"
								SortExpression="Temp_Vendor_ID" />
                            <asp:BoundField DataField="Form_Type_Is_Optional" HeaderText="标志"
								SortExpression="Form_Type_Is_Optional" />
                            <asp:BoundField DataField="Status" HeaderText="状态"
								SortExpression="Status" />
							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton ID="lbtapprovesuccess" runat="server" CommandName="refill"
										CommandArgument='<%# Eval("Form_ID") %>'>重新填写</asp:LinkButton>
								</ItemTemplate>
							</asp:TemplateField>
						</Columns>
						<EditRowStyle BackColor="#2461BF" />
						<FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
						<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
						<PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
						<RowStyle BackColor="#EFF3FB" />
						<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
						<SortedAscendingCellStyle BackColor="#F5F7FB" />
						<SortedAscendingHeaderStyle BackColor="#6D95E1" />
						<SortedDescendingCellStyle BackColor="#E9EBEF" />
						<SortedDescendingHeaderStyle BackColor="#4870BE" />
					</asp:GridView>
    </form>
</body>

</html>
