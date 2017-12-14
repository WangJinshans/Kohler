<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="BiddingApprovalForm.aspx.cs" Inherits="AendorAssess.BiddingApprovalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>BiddingApprovalForm</title>

    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=5"></script>
    <script>
        //弹出框  
        function popUp(formid) {
            layui.use(['layer'], function () {
                layer.open({
                    title: '请选择审批部门',
                    content: 'SelectDepartment.aspx?formid=' + formid,
                    type: 2,
                    area: ['750px', '400px'],
                    shade: 0.3,
                    shadeClose: false, //点击遮罩关闭
                    btn: ['确定'],
                    yes: function (index, layero) {
                        __myDoPostBack('submitForm', '');
                        layer.close(index);
                    },
                    cancel: function (index, layero) {
                        if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                            layer.close(index)
                        }
                        return false;
                    },
                    success: function (layero, index) {
                        console.log(layero, index);
                    }
                });
            });
        }
    </script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
    <style type="text/css">
        h1 {
            text-align: center;
        }

        h3 {
            text-align: right;
        }

        p {
            text-align: right;
        }

        .t {
            border: 0px;
            overflow: hidden;
            width: 100%;
            text-align: center;
        }

        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 10px 0px;
        }

        .head {
            border: solid #000000;
            border-width: 0px 0px 0px 0px;
            padding: 10px 0px;
        }

        table {
            border: solid #000000;
            border-width: 0px 1px 1px 1px;
            margin-left: auto;
        }

        .button {
            font-family: Arial;
            color: #000000;
            font-size: 27px;
            padding: 9px;
            text-decoration: none;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            -webkit-box-shadow: 0px 1px 0px #666666;
            -moz-box-shadow: 0px 1px 0px #666666;
            box-shadow: 0px 1px 0px #666666;
            text-shadow: 1px 1px 3px #666666;
            border: solid #e0e0e0 0px;
            background: -webkit-gradient(linear, 0 0, 0 100%, from(#dbd8da), to(#c9c9c9));
            background: -moz-linear-gradient(top, #dbd8da, #c9c9c9);
        }

            .button:hover {
                background: #dedbde;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin: auto; border-collapse: collapse; width: 1000px">
                <caption style="font-size: xx-large">Bidding Approval Form</caption>
                <tr>
                    <td colspan="1">CN_PRC003F</td>
                    <td colspan="1">&nbsp;</td>
                    <td>Serial  No.:</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox1" CssClass="t"></asp:TextBox>
                    </td>
                    <td>Date:</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox2" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Product产品
                    </td>
                    <td colspan="5">

                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox3" CssClass="t"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>预计年采购额
                    </td>
                    <td colspan="5">

                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox4" CssClass="t"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Item项目</td>
                    <td>Description描述</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td style="width: 30%">Remark</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox19" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox20" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox21" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox22" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox23" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox24" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox25" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox26" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox27" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox28" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox29" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox30" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox31" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox32" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox33" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox34" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox35" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox36" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox37" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox38" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox39" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox40" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox41" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox42" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox43" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox44" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox45" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox46" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox47" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox48" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">MOQ最小起订量</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox5" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox6" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox7" CssClass="t"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">Lead time交期</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox8" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox9" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox10" CssClass="t"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">Payment term账期</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox11" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox12" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox13" CssClass="t"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2">Remark备注</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox14" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox15" CssClass="t"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox16" CssClass="t"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="6">以上所有的价格均为人民币不含税价。
                    </td>
                </tr>
                <tr>
                    <td colspan="1">推荐</td>
                    <td colspan="4"><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox49" CssClass="t"></asp:TextBox></td>
                    <td colspan="1">作为供应商,理由如下：</td>
                </tr>
                <tr>
                    <td colspan="1">1
                    </td>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox17" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">2
                    </td>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox18" CssClass="t"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">examine and approve</td>
                </tr>
                <tr>
                    <td>Initiator</td>
                    <td colspan="5">
                        <asp:Image ID="Image1" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>User Department</td>
                    <td colspan="5">
                        <asp:Image onclick="openSignatureSelection(this,null)" AlternateText="请选择图片" ID="Image5" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Supplier Chain Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Finance Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image3" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>Business Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image4" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="ImgExSrc" />
                <asp:Button runat="server" ID="btnNewImage" style="display:none" OnClick="btnNewImage_Click" />
                <div style="text-align: center; margin-bottom: 50px">
                    <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
		        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="float: left; display: none">
            <table>
                <tr>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                                SortExpression="Form_ID" />
                            <asp:BoundField DataField="File_ID" HeaderText="文件编号"
                                SortExpression="File_ID" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="view"
                                        CommandArgument='<%# Eval("File_ID") %>'>查看文件</asp:LinkButton>
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
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
