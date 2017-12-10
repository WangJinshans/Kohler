<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorModifyInfo.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.Vendor_ModifyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--GridView显示需要更新的信息-->
            <asp:GridView Style="width: 550px; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                <Columns>
                    <asp:BoundField DataField="Item_Name" HeaderText="需要修改条目" SortExpression="Item_Name" />
                    <asp:BoundField DataField="Type" HeaderText="类型" SortExpression="Type" />
                </Columns>
                <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
