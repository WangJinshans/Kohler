<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepertoryInspection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.RepertoryInspection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=2"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--仓库检验--%>

            <asp:GridView ID="GridView1" class="layui-table" Style="width: 550px; margin: 0 auto; margin-bottom: 50px;" lay-even="" lay-skin="nob" runat="server" CssClass="layui-form" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>

                    <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                        SortExpression="Batch_No"></asp:BoundField>
                    <asp:BoundField DataField="SKU" HeaderText="物料编号"
                        SortExpression="SKU"></asp:BoundField>
                    <asp:BoundField DataField="Type" HeaderText="检验类型"
                        SortExpression="Type"></asp:BoundField>
                    <asp:BoundField DataField="Take_Out" HeaderText="取出"
                        SortExpression="Take_Out"></asp:BoundField>
                    <asp:BoundField DataField="Bad" HeaderText="退回"
                        SortExpression="Bad"></asp:BoundField>
                    <asp:BoundField DataField="Vendor_Code" HeaderText="供应商"
                        SortExpression="Vendor_Code"></asp:BoundField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="tuihuo" runat="server" CommandName="sure">
                                确认退货检验</asp:LinkButton>
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
