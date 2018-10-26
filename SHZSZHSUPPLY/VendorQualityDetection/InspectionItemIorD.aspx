<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionItemIorD.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.InspectionItemIorD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script>
        $(document).ready(function () {
            layui.use('form', function () {
                var form = layui.form;

            })
        });

        function whetherDel() {
            layui.use('layer', function () {
                var layer = layui.layer;

                layer.open({
                    title: '提示',
                    content: '是否需要删除?',
                    btn: ['确定', '返回'],
                    yes: function (index, layero) {
                        __myDoPostBack('del', '');
                    },
                    btn2: function (index, layero) {
                        layer.close(index);
                    }
                });
            });
        }
	</script>
</head>
<body>
    <form id="form1" class="layui-form body" runat="server">
        <div class="layui-form-item" style="width: 80%; margin: 0 auto;margin-top:50px;">
            <div class="layui-inline">
                <label class="layui-form-label">请选择物料</label>
                <div class="layui-input-inline">
                    <select id="SKU_List" runat="server" lay-search="" lay-verify="required">
                        <option value="">直接选择或搜索选择</option>
                        <option value="1">layer</option>
                        <option value="2">form</option>
                        <option value="3">layim</option>
                        <option value="4">element</option>
                        <option value="5">laytpl</option>
                        <option value="6">upload</option>
                        <option value="7">laydate</option>
                        <option value="8">laypage</option>
                        <option value="9">flow</option>
                        <option value="10">util</option>
                        <option value="11">code</option>
                        <option value="12">tree</option>
                        <option value="13">layedit</option>
                        <option value="14">nav</option>
                        <option value="15">tab</option>
                        <option value="16">table</option>
                        <option value="17">select</option>
                        <option value="18">checkbox</option>
                        <option value="19">switch</option>
                        <option value="20">radio</option>
                    </select>
                </div>
            </div>

        </div>
        <div class="layui-form-item" style="width: 80%; margin: 0 auto;">
            <fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
                <legend runat="server">检测项</legend>
            </fieldset>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:GridView Style="margin: 0 auto; width: 50%" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                        <Columns>
                            <asp:BoundField DataField="SKU" HeaderText="SKU"
                                SortExpression="SKU" Visible="TRUE" />
                            <asp:BoundField DataField="ID" HeaderText="供应商编号"
                                SortExpression="ID" Visible="False" />
                            <asp:BoundField DataField="Item" HeaderText="测试项目"
                                SortExpression="Item" />

                            <asp:BoundField DataField="Standard" HeaderText="标准"
                                SortExpression="Standard" />

                            <asp:BoundField DataField="IS_First" HeaderText="是否第一次检测"
                                SortExpression="IS_First" Visible="False" />



                        </Columns>
                        <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                        <HeaderStyle BackColor="#4e79a5" Font-Bold="true" ForeColor="White" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                </ContentTemplate>

            </asp:UpdatePanel>
        </div>
        <div class="layui-form-item" style="width: 80%; margin: 0 auto;">
            <label class="layui-form-label" style="width: auto">请输入要修改的检测项：</label>
            <asp:TextBox ID="TextBox1" runat="server" class="layui-input-inline" Style="width: 200px; top: 0px; left: 0px; height: 33px;" BackColor="White" BorderColor="White" ForeColor="Gray"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" class="layui-input-inline" Style="width: 200px; top: 0px; left: 0px; height: 33px;" BackColor="White" BorderColor="White" ForeColor="Gray"></asp:TextBox>
            <br />
            <br />
        </div>
        <div class="layui-form-item" style="width: 80%; margin: auto auto; text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="添加" class="layui-btn" OnClick="Button1_Click" />

            <asp:Button ID="Button2" runat="server" Text="删除" class="layui-btn layui-btn-danger" OnClick="Button2_Click" />

            <asp:Button ID="Button3" runat="server" Text="修改" class="layui-btn layui-btn-warm" OnClick="Button3_Click" />
        </div>
        <div style="text-align: center">

            <asp:Button ID="Button4" runat="server" Text="返回" class="layui-btn layui-btn-warm layui-btn-big" OnClick="Back_Click" />
        </div>
    </form>
</body>
</html>
