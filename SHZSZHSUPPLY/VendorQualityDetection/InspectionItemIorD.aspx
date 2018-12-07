<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionItemIorD.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.InspectionItemIorD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="Content-Language" content="zh-CN"/>
	<title></title>
	<script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
	<script src="../VendorAssess/Script/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
	<script src="../VendorAssess/Script/Own/fileUploader.js"></script>
	<script>
		function whetherDel() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '提示',
					content: '是否需要删除?',
					btn: ['确定', '返回'],
					yes: function (index, layero) {
						__myDoPostBack('Button2', '');
					},
					btn2: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

		function deleteError() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '删除错误',
					content: '请输入要删除的项',
					btn: ['返回'],

					yes: function (index, layero) {
						layer.close(index);
					},
					cancel: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

		function insertItemError() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '添加错误',
					content: '请输入要添加的检验项',
					btn: ['返回'],

					yes: function (index, layero) {
						layer.close(index);
					},
					cancel: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

		function insertStandardError() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '添加错误',
					content: '请输入要添加的检验项的标准',
					btn: ['返回'],

					yes: function (index, layero) {
						layer.close(index);
					},
					cancel: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}



		function delError() {
			var item = document.getElementById("TextBox1").value;
			var standard = document.getElementById("TextBox2").value;

			if (item == "请输入检验项" || item == "") {

					deleteError();
				
			}
			else {
				if (standard != "请输入标准" || standard != "") {
					whetherDel();
				}
				else {
					window.alert("不需要输入标准");
				}
			}
		}

		function insertError() {
			var item = document.getElementById("TextBox1").value;
			var standard = document.getElementById("TextBox2").value;

			if (item == "请输入检验项" || item == "") {
				insertItemError();
			}
			else {
				if(standard == "请输入标准" || standard == "") {
					insertStandardError();
				}
				else {
					__myDoPostBack('Button1', '');
				}
			}
		}

		function itemChange() {
			__myDoPostBack('DropDownList1', '');
		}
		window.onload = function () {
		    var thisWindow = parent.document.getElementById('iFrame1');
		    thisWindow.style.height = this.document.body.scrollHeight + 150 + "px";//调整页面
		    showAllText();
		}
	</script>
</head>
<body>
	
	<form id="form1" runat="server">
		
		<div class="layui-form-item" style="width: 60%; margin: 0 auto;">
			<fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
				<legend id="Legend1" runat="server">SKU选择：</legend>
			</fieldset>
			<div style="text-align:center">
					请选择SKU：
					<asp:DropDownList  lay-verify="required"  ID="DropDownList1" AutoPostBack="true" runat="server"  Height="40px" onchange="itemChange();" Width="137px" >
					</asp:DropDownList>
			</div>
		</div>
		<div class="layui-form-item" style="width: 60%; margin: 0 auto;">


			<fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
				<legend id="Inspection" runat="server">检测项：</legend>
			</fieldset>
			<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
			<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" >
				<ContentTemplate>
					<asp:GridView Style="margin: 0 auto; width: 50%" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
						<Columns>
							<asp:BoundField DataField="SKU" HeaderText="SKU"
								SortExpression="SKU" Visible="TRUE" />
							<asp:BoundField DataField="ID" HeaderText="供应商编号"
								SortExpression="ID" Visible="False" />
							<asp:BoundField DataField="Item" HeaderText="测试项目"
								SortExpression="Item" />

							<asp:BoundField DataField="Standard" HeaderText="标准"
								SortExpression="Standard" />

							<asp:BoundField DataField="IS_First" HeaderText="是否第一次检测"
								SortExpression="IS_First" Visible="False" />



						</Columns>
						<FooterStyle BackColor="#FFF" ForeColor="#330099" />
						<%--<HeaderStyle BackColor="#006F83" Font-Bold="True" ForeColor="#FEFEFE" />--%>
						<HeaderStyle BackColor="#4e79a5" Font-Bold="true" ForeColor="White" />
						<PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
						<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						<SortedAscendingCellStyle BackColor="#FEFCEB" />
						<SortedAscendingHeaderStyle BackColor="#AF0101" />
						<SortedDescendingCellStyle BackColor="#F6F0C0" />
						<SortedDescendingHeaderStyle BackColor="#7E0000" />
					</asp:GridView>
					
				</ContentTemplate>
				<Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" 
                    EventName="Click" />
					<asp:AsyncPostBackTrigger ControlID="Button2" 
                    EventName="Click" />
					<asp:AsyncPostBackTrigger ControlID="Button3" 
                    EventName="Click" />
                </Triggers>
			</asp:UpdatePanel>
		</div>
		
		<div class="layui-form" style="width: 60%; margin: 0 auto;">
			<fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
				<legend id="Legend2" runat="server">修改检测项：</legend>
			</fieldset>
			<div style="text-align:center">
			请输入要修改的检测项：
			<asp:TextBox ID="TextBox1" runat="server" class="layui-input-inline" Style="width: 200px; top: 0px; left: 0px; height: 33px;" BackColor="White" BorderColor="White" ForeColor="Gray"></asp:TextBox>
			<asp:TextBox ID="TextBox2" runat="server" class="layui-input-inline" Style="width: 200px; top: 0px; left: 0px; height: 33px;" BackColor="White" BorderColor="White" ForeColor="Gray"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" Text="添加" class="layui-btn" OnClientClick="return insertError();" />
			&nbsp
			<asp:Button ID="Button2" runat="server" Text="删除" class="layui-btn layui-btn-danger" OnClientClick="return delError();" />
			&nbsp
			<asp:Button ID="Button3" runat="server" Text="修改" class="layui-btn layui-btn-warm" OnClientClick="" OnClick="Button3_Click" />
			</div>
		</div>
		<div style="text-align: center">
			<br />
			<asp:Button ID="Button4" runat="server" Text="返回" class="layui-btn layui-btn-warm layui-btn-big" OnClick="Button4_Click" />
		</div>
	</form>

</body>
</html>
