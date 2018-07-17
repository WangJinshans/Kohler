<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectLab.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.SelectLab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        td {
            width:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" class="layui-table" Style="width: 550px; margin: 0 auto; margin-bottom: 50px;" lay-even="" lay-skin="nob" runat="server" CssClass="layui-form" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Employee_ID" HeaderText="KO编号"
                        SortExpression="Employee_ID">
                    </asp:BoundField>
                    <asp:BoundField DataField="Employee_Name" HeaderText="姓名"
                        SortExpression="Employee_Name">
                    </asp:BoundField>
                    <asp:BoundField DataField="Department_ID" HeaderText="部门"
                        SortExpression="Department_ID">
                    </asp:BoundField>
                    <asp:BoundField DataField="Positon_Name" HeaderText="职位"
                        SortExpression="Positon_Name">
                    </asp:BoundField>
                    <asp:BoundField DataField="Employee_Email" HeaderText="邮箱"
                        SortExpression="Employee_Email">
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbselected" runat="server" CommandArgument='<%#Eval("Employee_ID") %>' CommandName="select">
                                选择</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#515a6d" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
