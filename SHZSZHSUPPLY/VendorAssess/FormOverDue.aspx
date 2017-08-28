<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormOverDue.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.FormOverDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Script/layui/css/layui.css" rel="stylesheet" />
    <script src="Script/jquery-3.2.1.min.js"></script>  
	<script src="Script/layer/layer.js"></script>  
    <script src="Script/layui/layui.js"></script>
    <script>
        function messageBox(msg) {
            layer.open({
                title: '提示信息',
                content: '' + msg,
                btn: ['是'],
                btn1: function (index, layero) {
                    layer.close('index');
                }
            })
        }
    </script>
    <style>
        .test {
            text-align:center;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <div style="text-align:center;">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <!--
            供应商审批只有采购能新建还是每个人都能新建？
            如果只有采购能新建则需要加入权限
            将所有过期的表放到一张表中  可能不需要做 需要更改某一类状态(也可能不需要做)
            新建一张表 ID做主键 tempvendorID(需要有一个表将tempvendorID和真正的vendorID联系起来)
            formID employeeID(先加上 可能会有用) 
            -->
        <asp:Label Text="请输入供应商的编号" runat="server" />
        <asp:TextBox runat="server" ID="TextBox1"/>
        &nbsp;&nbsp;&nbsp;&nbsp
        <asp:Label Text="厂区：" runat="server" CssClass="test"/>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="99px">
            <asp:ListItem>上海科勒</asp:ListItem>
            <asp:ListItem Selected="True">中山科勒</asp:ListItem>
            <asp:ListItem>珠海科勒</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp
        <asp:Button Text="搜索" runat="server" ID="search" OnClick="search_Click" />
        <br />
        <br />
    </div>
        <br />
        <br />
        <br />
<%--            <input type="button" value="增加行" onclick="tableAddRow(tableId);" />
            <input type="button" value="增加1行" onclick="insertOne();" />
            <table class="layui-table" lay-skin="line" id="tableId">
                <tr>
                    <td>Form_ID</td>
                    <td>Temp_Vendor_ID</td>
                    <td>Employee_ID</td>
                    <td>OverDue_Time</td>
                </tr>
            </table>--%>
          <div style="text-align:center;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
						<AlternatingRowStyle BackColor="White" />
						<Columns>
							<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
								SortExpression="Form_ID" />
							<asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商"
								SortExpression="Temp_Vendor_ID" />
                            <asp:BoundField DataField="Form_Type_Is_Optional" HeaderText="标志"
								SortExpression="Form_Type_Is_Optional" />
                            <asp:BoundField DataField="Factory_Name" HeaderText="厂方"
								SortExpression="Factory_Name" />
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
          </div>
    </form>
</body>
</html>
