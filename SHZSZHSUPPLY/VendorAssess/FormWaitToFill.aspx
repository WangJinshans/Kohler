<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormWaitToFill.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.FormWaitToFill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="index.aspx">返回主界面</a>
        </div>
        <div>
            <table>
                <tr>
                    <asp:Label ID="Label1" runat="server" Text="供应商列表"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Vendor_Type_ID" HeaderText="供应商类型编号"
                                SortExpression="Vendor_Type_ID" />
                            <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                                SortExpression="Temp_Vendor_ID" />
                            <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                                SortExpression="Temp_Vendor_Name" />
                            <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                SortExpression="DepotSummary" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                        CommandArgument='<%# Eval("Temp_Vendor_ID") %>'>查看</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </tr>
                <tr>
                    <asp:Label ID="Label2" runat="server" Text="待填写表格"></asp:Label>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id"
                                SortExpression="id" Visible="False" />
                            <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                                SortExpression="Temp_Vendor_ID" Visible="False" />
                            <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                                SortExpression="Temp_Vendor_Name" />
                            <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                                SortExpression="Form_Type_ID" Visible="False" />
                            <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                                SortExpression="Form_Type_Name" />

                            <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                SortExpression="DepotSummary" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                        CommandArgument='<%# Eval("Form_Type_ID")%>'>填写表格</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
