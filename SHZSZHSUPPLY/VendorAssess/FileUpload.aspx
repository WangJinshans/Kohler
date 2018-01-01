<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="WebLearning.KeLe.ModifySelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" autopostback="false"> 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title></title>
    <script src="../Scripts/WebForms/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <link href="Script/layui/css/layui.css" rel="stylesheet" />

    <script>
        //防止页面后退  
        history.pushState(null, null, document.URL);
        window.addEventListener('popstate', function () {
            history.pushState(null, null, document.URL);
        });
        // 浏览器回退禁止  
        function noBack() {
            // 历史记录栈中记录页数  
            var numberOfEntries = window.history.length;
            if (window.history && window.history.pushState) {
                $(window).on('popstate', function () {
                    // 当点击浏览器的 后退和前进按钮 时才会被触发，  
                    window.history.pushState('forward', null, '');
                    window.history.forward(1);
                });
            }
            // 新弹出页对应  
            if (numberOfEntries != 1) {
                // 页面间跳转用  
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            }
        };
    </script>

    <script>
        <!--上传完成之后的界面刷新-->
        function fireRefresh() {
            __myDoPostBack("refreshVendor", "");
        };
        //真正修改按钮显示
        function showButton() {
            document.getElementById("showbutton").style.display = "block";
        }
        function showModifyDetail() {
            document.getElementById("showdetails").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <!-标题框 供应商修改文件上传-->
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
            <legend style="text-align:center;">供应商修改文件上传</legend>
        </fieldset>
        <%--As_Vendor_Modify_File表中的文件显示--%>
        <asp:GridView ID="GridView1" Style="width: 1000px; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称" SortExpression="Temp_Vendor_Name" Visible="TRUE" />
                <asp:BoundField DataField="Factory_Name" HeaderText="厂" SortExpression="Factory_Name" Visible="TRUE" />
                <asp:BoundField DataField="File_Type_Name" HeaderText="文件名称" SortExpression="File_Type_Name" Visible="TRUE" />
                <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <img src="<%# Eval("Flag").ToString() == "1" ? "./Script/layui/images/check.png" : "" %>" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <asp:LinkButton Text="上传文件" runat="server" CommandName="upload" />
                    </ItemTemplate>
                </asp:TemplateField>
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
        <div id="showbutton" style="text-align:center;margin-top:50px;display:none;">
            <asp:Button Text="开始修改" runat="server" CssClass="layui-btn layui-btn-normal" ID="startModify" OnClick="startModify_Click"/>
        </div>

        <div id="showdetails" style="text-align:center;margin-top:50px;display:none;">
            <asp:Button Text="前往查看" runat="server" CssClass="layui-btn layui-btn-normal" ID="showDetail" OnClick="showDetail_Click"/>
        </div>
    </form>
</body>
</html>
