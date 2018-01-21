<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="KCI.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.KCI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=9"></script>
    <script>
        function fireRefresh() {
            window.location.href = document.URL;
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div>
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="margin-left:10%;visibility:hidden">返回</a>
        </div>

        <div>
            <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
            <legend id="vendorName" runat="server">KCI审批列表</legend>
        </fieldset>

        <asp:GridView Style="width: 1000px; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                    SortExpression="Form_ID" />
                <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                    SortExpression="Temp_Vendor_ID" />
                <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                    SortExpression="Temp_Vendor_Name" />
                <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                    SortExpression="Form_Type_Name" />
                <asp:TemplateField ControlStyle-ForeColor="Green" ControlStyle-Font-Bold="true">
                    <ItemTemplate>
                        <asp:LinkButton ID="approvalsuccess" runat="server" CommandName="success"
                            CommandArgument='<%# Eval("Form_ID") %>'>通过</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-ForeColor="#F37070" ControlStyle-Font-Bold="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="approvalfail" runat="server" CommandName="fail"
                            CommandArgument='<%# Eval("Form_ID") %>'>拒绝</asp:LinkButton>
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
        </div>
    </form>

</body>
</html>
