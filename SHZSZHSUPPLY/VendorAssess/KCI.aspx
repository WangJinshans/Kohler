<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KCI.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.KCI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
 <script src="Script/Own/fileUploader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="float:left;margin-right:100px">返回</a>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333" OnRowCommand="GridView1_RowCommand">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
						SortExpression="Form_ID" />
					<asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
						SortExpression="Temp_Vendor_ID" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="approvalsuccess" runat="server" CommandName="success"
								CommandArgument='<%# Eval("Form_ID") %>'>通过KCI</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
                    <asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="approvalfail" runat="server" CommandName="fail"
								CommandArgument='<%# Eval("Form_ID") %>'>拒绝KCI</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
						<EditRowStyle BackColor="#999999" />
				<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
				<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
				<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
				<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
				<SortedAscendingCellStyle BackColor="#E9E7E2" />
				<SortedAscendingHeaderStyle BackColor="#506C8C" />
				<SortedDescendingCellStyle BackColor="#FFFDF8" />
				<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
			</asp:GridView>
    </form>

</body>
</html>
