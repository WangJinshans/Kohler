<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdPartySubmit.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ThirdPartySubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script>
        layui.use('form', function () {
            var form = layui.form(),
                layer = layui.layer;
        });

        $('#down').click(function () {
            var that = this;
            var page_url = '../ASHX/Progress.ashx';

            var req = new XMLHttpRequest();
            req.open("POST", page_url, true);

            req.addEventListener('progress', function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;
                    console.log(percentComplete);
                    $('#progressing').html((percentComplete * 100) + '%');
                }
            }, false);

            req.responseType = "blob";
            req.onreadystatechange = function () {
                if (req.readyState === 4 && req.status === 200) {
                    var filename = $(that).data('filename');
                    if (typeof window.chrome !== 'undefined') {
                        var link = document.createElement('a');
                        link.href = URL.createObjectURL(req.response);
                        link.download = filename;
                        link.click();
                    } else {
                        var file = new File([req.response], filename, { type: 'application/force-download' });
                    }
                };
                req.send();
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="progressing"></div>
            <asp:TextBox runat="server" ID="one"></asp:TextBox>
            <asp:TextBox runat="server" ID="two"></asp:TextBox>
            <asp:TextBox runat="server" ID="three"></asp:TextBox>

            <asp:Button runat="server" ID="imgaeRead" Text="读取图片" OnClick="imgaeRead_Click" />
        </div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
                    <legend style="text-align: center;" runat="server">待检清单</legend>
                </fieldset>
                <asp:DropDownList ID="dropList" OnSelectedIndexChanged="dropList_SelectedIndexChanged" AutoPostBack="True" runat="server">
                    <asp:ListItem>AAAA</asp:ListItem>
                    <asp:ListItem>BBBB</asp:ListItem>
                    <asp:ListItem>CCCC</asp:ListItem>
                </asp:DropDownList>
                <asp:GridView ID="GridView1" AllowPaging="true" PageSize="15" Style="width: 1000px; margin: 50px auto 20px auto;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Batch_No" HeaderText="检验批"
                            SortExpression="Batch_No" />
                        <asp:BoundField DataField="SKU" HeaderText="SKU"
                            SortExpression="SKU" />
                        <asp:BoundField DataField="Product_Name" HeaderText="物料"
                            SortExpression="Product_Name" />
                        <asp:BoundField DataField="Vendor_Code" HeaderText="供应商"
                            SortExpression="Vendor_Code" />
                        <asp:BoundField DataField="Detection_Count" HeaderText="进料数量"
                            SortExpression="Detection_Count" />
                        <asp:BoundField DataField="Remark" HeaderText="备注"
                            SortExpression="Remark" />
                        <asp:BoundField DataField="Inspection_Type" HeaderText="检验类型"
                            SortExpression="Inspection_Type" />
                        <asp:BoundField DataField="Status" HeaderText="状态"
                            SortExpression="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbgo" runat="server" CommandName="go">
                                去检验</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbto" runat="server" CommandName="to">
                                委托检验</asp:LinkButton>
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
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropList"  EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
