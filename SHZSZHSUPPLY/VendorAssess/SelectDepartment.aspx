<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectDepartment.aspx.cs" Inherits="AendorAssess.SelectDepartment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>
    <script type="text/javascript" src="Script/layui/layui.js" ></script>
    <%--<base target="_self" />--%> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList runat="server" ID="lstDepartment" AutoPostBack="True" OnSelectedIndexChanged="lstDepartment_SelectedIndexChanged" ></asp:DropDownList>
    </div>
    <div>
    <%--<a href="index.aspx" style="visibility:hidden">返回主界面</a>--%>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="Department_ID" HeaderText="Department_ID" SortExpression="Department_ID" />
                <asp:BoundField DataField="Employee_Name" HeaderText="Employee_Name" SortExpression="Employee_Name" />
                <asp:BoundField DataField="Positon_Name" HeaderText="Positon_Name" SortExpression="Positon_Name" />
                <asp:BoundField DataField="Employee_Email" HeaderText="Employee_Email" SortExpression="Employee_Email" />
                <asp:BoundField DataField="Positon_Name" HeaderText="Employee_Email" SortExpression="Employee_Email" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="选择" ShowHeader="True" Text="选择" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#0061C2" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#2097DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
