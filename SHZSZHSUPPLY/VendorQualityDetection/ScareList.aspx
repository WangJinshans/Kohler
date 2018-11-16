<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScareList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ScareList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        select {
            margin-left:40px;
            margin-right:40px;
        }
    </style>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=2"></script>
    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 550px; margin: 0 auto;margin-bottom: 50px;">
            <fieldset class="layui-elem-field layui-field-title" style="width: 550px; margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">手动触发Scar</legend>
            </fieldset>
            <div style="text-align:center">
                <asp:DropDownList runat="server" ID="vendorType">

                </asp:DropDownList>
                <asp:DropDownList runat="server" ID="vendorName">

                </asp:DropDownList> 
            </div>
        </div>

        <%--列出所有检验批？--%>

        <div>
            <asp:GridView ID="GridView1" class="layui-table" Style="width: 550px; margin: 0 auto; margin-bottom: 50px;" lay-even="" lay-skin="nob" runat="server" CssClass="layui-form" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Vendor_Code" HeaderText="供应商编号"
                        SortExpression="Vendor_Code">
                    </asp:BoundField>
                    <asp:BoundField DataField="Vendor_Name" HeaderText="供应商名"
                        SortExpression="Vendor_Name">
                    </asp:BoundField>
                    <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                        SortExpression="Batch_No">
                    </asp:BoundField>
                    <asp:BoundField DataField="Result" HeaderText="检验结论"
                        SortExpression="Result">
                    </asp:BoundField>

                    <%--选择原因--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            选择原因
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList runat="server">
                                <asp:ListItem Text="发生影响产品质量的重大问题" />   
                                <asp:ListItem Text="发生重大客户投诉" />
                                <asp:ListItem Text="管理者认为需要书面纠正预防的其它问题" />
                                <asp:ListItem Text="连续两次发生相同问题" />    
                            </asp:DropDownList>
                         </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="triggerScar" runat="server" CommandName="triggerScar">
                                触发Scar</asp:LinkButton>
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
