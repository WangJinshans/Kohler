<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ScarList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ScarList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=1"></script>
    <script>
        $(document).ready(function () {
            layui.use('form', function () {
                var form = layui.form(),
                    layer = layui.layer;

                form.on('select(vendorType)', function (data) {
                    var json = localStorage.getItem("scarItems");
                    var mydata = JSON.parse(json);
                    var nameAndCode = mydata[data.value];
                    $('#vendorName').empty();
                    for (var i = 0; i < nameAndCode.length / 2; i++) {
                        $('#vendorName').append("<option value='" + i + "'>" + nameAndCode[i + 1] + "</option>");
                    }
                    console.log(nameAndCode);
                    form.render('select');
                });

                form.on('select(vendorName)', function (data) {
                    var json = localStorage.getItem("scarItems");
                    var mydata = JSON.parse(json);
                    var type = $("#vendorType option:selected").text();
                    var vendor_Name = $("#vendorName option:selected").text();
                    var index = $("#vendorName option:selected").val();
                    var vendor_Code = mydata[type][index];
                    $('#vendorCode').empty();
                    $('#vendorCode').append("<option value='" + vendor_Name + "'>" + vendor_Code + "</option>");
                    form.render('select');
                    __myDoPostBack('initGridView', vendor_Code);
                });
            });

        })

        function setParm(json) {
            localStorage.setItem("scarItems", json);
        }

        function uploadScar(batch_No, vendor_Code) {
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;
                localStorage.setItem("QT_Vendor_Code", vendor_Code);
                localStorage.setItem("QT_Batch_No", batch_No);
                layer.open({
                    title: ['请选择Scar的反馈文件', 'text-align:center;']
                    , type: 2
                    , area: ['800px', '300px']
                    , content: 'Html/ScarUpload.html'
                    , cancle: function () {
                        layer.closeAll();
                    },
                })
            });

        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div class="layui-form-item">
            <fieldset class="layui-elem-field layui-field-title" style="width: 800px; margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">Scar列表</legend>
            </fieldset>
        </div>
        <div class="layui-form-item" style="width: 800px; margin: 0 auto;">
            <label class="layui-form-label">供应商类型</label>
            <div class="layui-input-inline">
                <select name="modules" lay-filter="vendorType" lay-search="" id="vendorType">
                    <option>非生产性常规</option>
                    <option>非生产性特种劳防品</option>
                    <option>非生产性危化品</option>
                    <option>非生产性质量部有标准的物料</option>
                    <option>直接物料常规</option>
                    <option>直接物料危化品</option>
                </select>
            </div>
            <div class="layui-input-inline">
                <asp:DropDownList runat="server" name="amoduless" lay-filter="vendorName" lay-search="" ID="vendorName">
                    <asp:ListItem>无</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="layui-input-inline">
                <select name="amodules" lay-filter="vendorCode" disabled="" id="vendorCode">
                    <option>无</option>
                </select>
            </div>
        </div>
        <div style="width: 850px; margin: 50px auto;">
            <asp:GridView ID="GridView1" Style="width: 850px; margin: 50px auto;" lay-even="" lay-skin="nob" runat="server" CssClass="layui-table" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Vendor_Code" HeaderText="供应商编号"
                        SortExpression="Vendor_Code"></asp:BoundField>
                    <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名"
                        SortExpression="Temp_Vendor_Name"></asp:BoundField>
                    <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                        SortExpression="Batch_No"></asp:BoundField>
                    <asp:HyperLinkField HeaderText="检验报告" DataTextField="Form_ID" DataNavigateUrlFields="Form_ID"
                        DataNavigateUrlFormatString="ShowSurveyReport.aspx?form_ID={0}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="finishScar" runat="server" CommandName="finishScar">
                                反馈上传</asp:LinkButton>
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
