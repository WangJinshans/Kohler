<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MBRList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.MBRList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--读取MBR的记录并显示--%>
         <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">MBR裁定列表</legend>
            </fieldset>
            <asp:GridView ID="GridView1" Style="width: 1000px; margin: 0 auto; margin-bottom: 50px;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                        SortExpression="Batch_No" />
                    <asp:BoundField DataField="SKU" HeaderText="SKU"
                        SortExpression="SKU" />
                    <asp:BoundField DataField="Product_Name" HeaderText="物料"
                        SortExpression="Product_Name" />
                    <asp:BoundField DataField="Vender_Name" HeaderText="供应商"
                        SortExpression="Vender_Name" />
                    <asp:BoundField DataField="Detection_Count" HeaderText="检测数量"
                        SortExpression="Detection_Count" />
                    <asp:BoundField DataField="MBR_Distinction" HeaderText="是否KCI"
                        SortExpression="MBR_Distinction" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbgo" runat="server" CommandName="deal">
                                去处理</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#515a6d" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#5AA700" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
    </div>
    </form>
</body>
</html>
