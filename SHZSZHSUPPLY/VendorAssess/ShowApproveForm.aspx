<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowApproveForm.aspx.cs" Inherits="AendorAssess.ShowApproveForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
        </div>
        <fieldset class="layui-elem-field layui-field-title" style="width: 80%; margin: 50px auto 20px auto;">
            <legend id="vendorName" runat="server">待审批项目</legend>
        </fieldset>
        <asp:GridView Style="width: 80%; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                    SortExpression="Form_ID" />
                <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                    SortExpression="Form_Type_Name" />
                <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                    SortExpression="Temp_Vendor_Name" />
                <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                    SortExpression="Form_Type_ID" Visible="false" />
                <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                    SortExpression="DepotSummary" Visible="False" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                            CommandArgument='<%# Eval("Form_Type_ID") %>'>开始审批</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </form>
</body>
</html>
