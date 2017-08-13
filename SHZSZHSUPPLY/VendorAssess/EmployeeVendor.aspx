<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeVendor.aspx.cs" Inherits="AendorAssess.EmployeeVendor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        table.gridtable {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
        }

            table.gridtable th {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #dedede;
            }

            table.gridtable td {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #ffffff;
            }
    </style>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <script>
        function lay_message(msg) {
            layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.msg(msg, { time: 2000 });
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="index.aspx">返回主界面</a>
        </div>
        <div>
            <table class="gridtable">
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
                    <asp:Label ID="Label2" runat="server" Text="未提交表格"></asp:Label>
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
                            <asp:BoundField DataField="Form_Type_Is_Optional" HeaderText="性质" NullDisplayText=""
                                SortExpression="Form_Type_Is_Optional" />

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
                <tr>
                    <asp:Label ID="Label3" runat="server" Text="已提交表格"></asp:Label>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView3_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                                SortExpression="Temp_Vendor_Name" />
                            <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                                SortExpression="Form_Type_Name" />
                            <asp:BoundField DataField="Form_ID" HeaderText="表格编号" SortExpression="Form_ID" />
                            <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                                SortExpression="Form_Type_ID" Visible="False" />
                            <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                SortExpression="DepotSummary" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                        CommandArgument='<%# Eval("Form_Type_ID") %>'>查看</asp:LinkButton>
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
                <tr>
                    <asp:Label ID="Label4" runat="server" Text="待上传文件"></asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView4_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id"
                                SortExpression="id" Visible="False" />
                            <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                                SortExpression="Temp_Vendor_ID" />
                            <asp:BoundField DataField="FileType_ID" HeaderText="文件类型编号"
                                SortExpression="FileType_ID" />
                            <asp:BoundField DataField="FileType_Name" HeaderText="文件类型名称"
                                SortExpression="FileType_Name" />
                            <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                SortExpression="DepotSummary" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtUpLoad" runat="server" CommandName="UpLoad"
                                        CommandArgument='<%# Eval("FileType_ID") %>'>上传</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </tr>
                <tr>
                    <asp:Label ID="Label5" runat="server" Text="已上传文件"></asp:Label>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView5_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id"
                                SortExpression="id" Visible="False" />
                            <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                                SortExpression="Temp_Vendor_Name" />
                            <asp:BoundField DataField="File_Name" HeaderText="文件名称"
                                SortExpression="File_Name" />
                            <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                SortExpression="DepotSummary" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                        CommandArgument='<%# Eval("File_ID") %>'>查看
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
