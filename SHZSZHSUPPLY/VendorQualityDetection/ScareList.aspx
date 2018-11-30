<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScareList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ScareList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        select {
            margin-left: 40px;
            margin-right: 40px;
        }
    </style>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=1"></script>

    <script>
        layui.use('form', function () {
            var form = layui.form(),
                layer = layui.layer;

            form.on('select(vendorTypes)', function (data) {
                $('#vendorName').empty();
                var result = localStorage.getItem('result');
                var data = JSON.parse(result);
                var key = $('#vendorType').find("option:selected").val();
                var s = "'" + key + "'";
                //console.log(data[key])
                for (var i = 0; i < data[key].length;) {

                    $('#vendorName').append("<option value='" + i + "'>" + data[key][i] + "</option>");
                    i += 2;
                }
                form.render('select');
            });

            form.on('select(vendorNames)', function (data) {
                //var name = document.getElementById('vendorName').options[data.value].text;
                __myDoPostBack('loadInfo', data.value);
                form.render('select');
            });
        });


        function setParam(result) {
            localStorage.setItem('result', result);
            var data = JSON.parse(result);
            var types = $('#vendorType').val();
            for (var i = 0; i < data[types].length;) {
                $('#vendorName').append("<option value='" + data[types][i + 1] + "'>" + data[types][i] + "</option>");
                i += 2;
            }
        }

        function reSetParam(result) {
            var result = localStorage.getItem('result');
            var data = JSON.parse(result);
            var types = $('#vendorType').val();
            for (var i = 0; i < data[types].length;) {
                $('#vendorName').append("<option value='" + data[types][i + 1] + "'>" + data[types][i] + "</option>");
                i += 2;
            }
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div style="width: 550px; margin: 0 auto; margin-bottom: 50px;">
            <fieldset class="layui-elem-field layui-field-title" style="width: 550px; margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">手动触发Scar</legend>
            </fieldset>
            <div class="layui-form-item" style="text-align: center">
                <a href="ScarList.aspx" style="text-decoration-line:underline">查看Scar列表</a>
            </div>
            <div class="layui-form-item" style="text-align: center">
                <div class="layui-input-inline">
                    <select name="modules" lay-verify="required" lay-filter="vendorTypes" lay-search="" id="vendorType">
                        <option value="直接物料常规">直接物料常规</option>
                        <option value="直接物料危化品">直接物料危化品</option>
                        <option value="非生产性危化品">非生产性危化品</option>
                        <option value="非生产性常规">非生产性常规</option>
                        <option value="非生产性特种劳防品">非生产性特种劳防品</option>
                        <option value="非生产性质量部有标准的物料">非生产性质量部有标准的物料</option>
                    </select>
                </div>
                <div class="layui-input-inline" style="width:300px;">
                    <select name="smodules" lay-verify="required" lay-filter="vendorNames" lay-search="" id="vendorName">
                    </select>
                </div>
            </div>
        </div>

        <%--列出所有检验批？--%>

        <div>
            <asp:GridView ID="GridView1" class="layui-table" Style="width: 850px; margin: 0 auto; margin-bottom: 50px;" lay-even="" lay-skin="nob" runat="server" CssClass="layui-form" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Vendor_Code" HeaderText="供应商编号"
                        SortExpression="Vendor_Code"></asp:BoundField>
                    <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名"
                        SortExpression="Temp_Vendor_Name"></asp:BoundField>
                    <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                        SortExpression="Batch_No"></asp:BoundField>
                    <asp:BoundField DataField="Result" HeaderText="检验结论"
                        SortExpression="Result">
                    </asp:BoundField>

                    <%--选择原因--%>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            选择原因
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" runat="server">
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
