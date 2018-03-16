<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransferComparison.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.Html_Template.TransferComparison" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../Script/jquery-3.2.1.min.js"></script>
    <script src="../Script/layui/layui.js"></script>
    <script src="../Script/Own/fileUploader.js?v=9"></script>
    <title>系统文件对比</title>
    <style type="text/css">
        .left {
            width: 48%;
            height: 100%;
            float: left;
            overflow-x: auto;
            overflow-y: auto;
        }

        .right {
            width: 48%;
            height: 100%;
            float: right;
            overflow-x: auto;
            overflow-y: auto;
        }

        .comparison-body {
            width: 95%;
            height: 650px;
            margin-left: auto;
            margin-right: auto;
            /*margin: 0 auto;*/
        }

        .option-body {
            width: 1000px;
            margin-top: 5%;
            margin-left: auto;
            margin-right: auto;
        }

        .checkall {
        }
    </style>
    <script>
        layui.use(['form', 'layer'], function () {
            var form = layui.form()
            , layer = layui.layer;

            form.on('checkbox', function (data) {
                if (data.elem.checked && (data.elem.id == 'ckALL' || data.elem.id == 'ckAPPEND')) {
                    layer.tips(data.elem.value, data.othis, {
                        tips: [1, '#3595CC'],
                        time: 4000
                    });

                    $(data.elem).siblings("input").prop('checked', false);
                    form.render('checkbox');
                } else if (data.elem.id.indexOf('assessHeaderCheck') != -1) {
                    CheckAll(data.elem);
                }
            });
        });

        function initCheckbox() {
            $('.checkall').prop("display", "block");
            $('.checkall').attr("visibility", "visible");
            layui.use(['form'], function () {
                var form = layui.form();
                form.render();
            });
        }


        function checkConfig() {
            var code = document.getElementById('inputNormalCode').value;
            var select = document.getElementById('ckALL').checked ? "all" : "append";
            if (document.getElementById('inputNormalCode').value == '') {
                layer.msg('请输入编号');
                return false;
            } else {
                document.getElementById('hiddenArgs').value = code + '&' + select;
                waiting("正在执行操作...");
                return true;
            }
        }
        function CheckAll(ck) {
            $('.checkall').prop("checked", ck.checked);
            layui.use(['form'], function () {
                var form = layui.form();
                form.render();
            });
        }
        function CheckAllThenBlock() {
            //$('.checkall').prop("checked", true);
            //$('.checkall').attr("disabled", "disabled");
            layui.use(['form'], function () {
                var form = layui.form();
                form.render();
            });
        }
    </script>
</head>
<body>
    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
        <legend>文件对比（管理系统——审批系统）</legend>
    </fieldset>
    
    <form class="layui-form" id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <script>
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {
                initCheckbox();
            });
        </script>

        <div class="comparison-body">
            <div class="left">
                <asp:UpdatePanel runat="server" ID="UpdatePanelLeft" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView runat="server" class="layui-table" lay-even="" lay-skin="nob" ID="manageSystemGrid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="File_Type_Name" HeaderText="Form_Type_Name" SortExpression="Form_Type_Name" />
                                <%--<asp:BoundField DataField="Form_Type_ID" HeaderText="Form_Type_ID" SortExpression="Form_Type_ID" />--%>
                                <%--<asp:BoundField DataField="Temp_Vendor_Name" HeaderText="Temp_Vendor_Name" SortExpression="Temp_Vendor_Name" />--%>
                                <asp:BoundField DataField="File_Enable_Time" HeaderText="File_Enable_Time" SortExpression="File_Enable_Time" />
                                <asp:BoundField DataField="File_Due_Time" HeaderText="File_Due_Time" SortExpression="File_Due_Time" />
                                <asp:BoundField DataField="File_Path" HeaderText="Form_Path" SortExpression="Form_Path" />
                                <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="Temp_Vendor_ID" Visible="false" SortExpression="Temp_Vendor_ID" />
                            </Columns>
                            <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                            <%--<HeaderStyle BackColor="#04A5C2" Font-Bold="True" ForeColor="#FEFEFE" />--%>
                            <HeaderStyle BackColor="#3e62a7" Font-Bold="true" ForeColor="White" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.;Initial Catalog=SKZSZHSUPPLY;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="select top 20 * from itemList"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="right">
                <asp:UpdatePanel ID="UpdatePanelRight" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>

                        <asp:GridView runat="server" class="layui-table" lay-even="" lay-skin="nob" ID="assessSystemGrid" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input id="assessHeaderCheck" class="checkall" type="checkbox" onclick="CheckAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input id="assessCheck" class="checkall" type="checkbox" runat="server" />
                                        <%--<asp:CheckBox class="checkall" runat="server" ID="assessCheck" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="File_Type_Name" HeaderText="Form_Type_Name" SortExpression="Form_Type_Name" />
                                <asp:BoundField DataField="File_Enable_Time" HeaderText="File_Enable_Time" SortExpression="File_Enable_Time" />
                                <asp:BoundField DataField="File_Due_Time" HeaderText="File_Due_Time" SortExpression="File_Due_Time" />
                                <asp:BoundField DataField="File_Path" HeaderText="Form_Path" SortExpression="Form_Path">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="Temp_Vendor_ID" Visible="false" SortExpression="Temp_Vendor_ID" />
                                <asp:BoundField DataField="Source_From" HeaderText="文件来源" SortExpression="Source_From">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                            <HeaderStyle BackColor="#3e62a7" HorizontalAlign="Center" Font-Bold="true" ForeColor="White" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=.;Initial Catalog=SKZSZHSUPPLY;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="select top 20 * from As_Form"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="option-body layui-form-item">
                    <div class="layui-inline">
                        <label class="layui-form-label">供应商编号</label>
                        <div class="layui-input-block">
                            <input id="inputNormalCode" runat="server" style="margin-right: 40px; width: auto;" type="text" autocomplete="off" placeholder="请输入正式供应商编号" class="layui-input" />
                        </div>
                    </div>
                    <div class="layui-inline">
                        <label class="layui-form-label">转移模式</label>
                        <div class="layui-input-block">
                            <input type="checkbox" id="ckALL" name="1" value="将用审批系统内的文件覆盖管理系统内的文件" title="覆盖旧文件" lay-skin="primary" disabled/>
                            <input type="checkbox" id="ckAPPEND" name="2" value="只向管理系统中插入其中不存在的文件" title="只添加新文件" lay-skin="primary" checked />
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="hiddenArgs" />
                    <asp:Button runat="server" Text="转移" ID="btnAddFile" CssClass="layui-btn" OnClientClick="return checkConfig()" OnClick="btnAddFile_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    
</body>
</html>
