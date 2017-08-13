<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileOverDue.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.FileOverDue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
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
             <!--
                 需要上传文件 需要保存新的文件到某个路径
                 -->
    </div>
        <br />
        <br />
        <br />
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
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

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
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
