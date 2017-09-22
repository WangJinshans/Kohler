<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorDesignatedApply.aspx.cs" Inherits="VendorAssess.ShowVendorDesignatedApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <script src="Script/PDF/js/html2canvas.js"></script>
    <script src="Script/PDF/js/jspdf.debug.js"></script>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />

    <style type="text/css">
        .t {
            border: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
        }

        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 10px 0px;
        }

        table {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            margin-left: auto;
        }

            table.gridtable {
                font-family: verdana,arial,sans-serif;
                font-size: 11px;
                color: #333333;
                border-width: 1px;
                border-color: #666666;
                border-collapse: collapse;
            }

                table.gridtable th {
                    border-width: 1px;
                    padding: 8px;
                    border-style: solid;
                    border-color: #666666;
                    background-color: #507CD1;
                }

                table.gridtable td {
                    border-width: 1px;
                    padding: 8px;
                    border-style: solid;
                    border-color: #666666;
                    background-color: #ffffff;
                }

        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            text-align: center;
        }

        .auto-style2 {
            width: 1032px;
        }

        .auto-style3 {
            width: 170px;
        }

        .auto-style4 {
            margin-left: 0px;
        }
    </style>
    <script>
        function takeScreenshot(file, formID) {
            html2canvas(document.getElementById("div1"), {
                // 渲染完成时调用，获得 canvas
                onrendered: function (canvas) {
                    var contentWidth = canvas.width;
                    var contentHeight = canvas.height;
                    //一页pdf显示html页面生成的canvas高度;
                    var pageHeight = contentWidth / 592.28 * 841.89;
                    //未生成pdf的html页面高度
                    var leftHeight = contentHeight;
                    //页面偏移
                    var position = 0;
                    //a4纸的尺寸[595.28,841.89]，html页面生成的canvas在pdf中图片的宽高
                    var imgWidth = 595.28;
                    var imgHeight = 592.28 / contentWidth * contentHeight;

                    var pageData = canvas.toDataURL('image/jpeg', 1.0);

                    var pdf = new jsPDF('', 'pt', 'a4');

                    //有两个高度需要区分，一个是html页面的实际高度，和生成pdf的页面高度(841.89)
                    //当内容未超过pdf一页显示的范围，无需分页
                    if (leftHeight < pageHeight) {
                        pdf.addImage(pageData, 'JPEG', 20, 20, imgWidth, imgHeight);
                    } else {
                        while (leftHeight > 0) {
                            pdf.addImage(pageData, 'JPEG', 20, position, imgWidth, imgHeight)
                            leftHeight -= pageHeight;
                            position -= 841.89;
                            //避免添加空白页
                            if (leftHeight > 0) {
                                pdf.addPage();
                            }
                        }
                    }
                    pdf.autoPrint();
                    pdf.save(file);
                    requestToPdfAshx(file, formID);
                },
                background: "#f7f7f7"    //设置PDF背景色（默认透明，实际显示为黑色）
            });
        }
    </script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
    <script>
        function requestToPdfAshx(fileName, formID) {
            $.get(
                "ASHX/PDF.ashx",
                { "fileName": fileName, "formID": formID },
                function (res) {
                    window.location.href = document.URL;
                    alert(res);
                }
            );
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
            <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
            <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="Button1" runat="server" OnClick="Button1_Click" Style="float: right;" />
        </div>
        <div id="div1" style="text-align: right">
            <table style="margin: auto; border-collapse: initial; width: 1000px" cellpadding="0" cellspacing="0">
                <caption style="font-size: small; text-align: right; border-style: none;">PR-05-10-2</caption>
                <caption style="font-size: xx-large;" class="auto-style2">上海科勒有限公司</caption>
                <tr>
                    <td colspan="6" style="text-align: center">指定供应商申请表</td>
                </tr>
                <tr>
                    <td colspan="1">供应商名称*</td>
                    <td colspan="1">SPA编号*</td>
                    <td colspan="1">产品描述*</td>
                    <td colspan="1" class="auto-style3">有效期*</td>
                    <td colspan="1">预估年采购金额(Estimated Purchase Amount)*</td>
                    <td colspan="1">原因*</td>
                </tr>
                <tr>
                    <td colspan="1">Vendor Name*</td>
                    <td colspan="1">SAP Code*</td>
                    <td colspan="1">Business Category*</td>
                    <td colspan="1" class="auto-style3">Effective Time*</td>
                    <td colspan="1">(Over 100K should have formal bidding process)*</td>
                    <td colspan="1">(With Supporting Documents)*</td>
                </tr>
                <tr>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">Initiator:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style1" Width="819px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">Date:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style1" Width="811px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: left">Approval Signature</td>
                </tr>
                <tr>
                    <td colspan="1">Applicant: </td>
                    <td colspan="1">
                        <asp:Image ImageUrl="imageurl" ID="Image8" runat="server" />
                    </td>
                    <td colspan="1">Request Dept Head: </td>
                    <td colspan="1" class="auto-style3">
                        <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" />
                    </td>
                    <td colspan="1">FIN Manager: </td>
                    <td colspan="1">
                        <asp:Image ID="Image2" runat="server" ImageUrl="imageurl" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Date: </td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="1">Date: </td>
                    <td colspan="1" class="auto-style3">
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="1">Date: </td>
                    <td colspan="1">
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Purchasing Manager: </td>
                    <td colspan="2">
                        <asp:Image ID="Image3" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="1" class="auto-style3">GM: </td>
                    <td colspan="2">
                        <asp:Image ID="Image4" runat="server" ImageUrl="imageurl" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Dtae: </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="auto-style1" Width="280px" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="1" class="auto-style3">Date: </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox18" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Director: </td>
                    <td colspan="2">
                        <asp:Image ID="Image5" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="1" class="auto-style3">Supply Chain Director: </td>
                    <td colspan="2">
                        <asp:Image ID="Image6" runat="server" ImageUrl="imageurl" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: right">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
                </tr>
                <tr>
                    <td colspan="1">Dtae: </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox21" runat="server" ReadOnly="True" CssClass="auto-style1" Width="280px"></asp:TextBox>
                    </td>
                    <td colspan="1" class="auto-style3">Date: </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox22" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">President:</td>
                    <td colspan="5" style="text-align: left">
                        <asp:Image ID="Image7" runat="server" ImageUrl="imageurl" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
                </tr>
                <tr>
                    <td colspan="1">Date:</td>
                    <td colspan="5">
                        <asp:TextBox ID="TextBox24" runat="server" CssClass="auto-style1" Width="313px" ReadOnly="True"></asp:TextBox></td>
                </tr>
            </table>
            <table class="gridtable" style="margin: 0 auto; width: 1000px; border-collapse: collapse;">
                <tr>
                    <td>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                                    SortExpression="Form_ID" />
                                <asp:BoundField DataField="Position_Name" HeaderText="职位名称"
                                    SortExpression="Position_Name" />
                                <asp:BoundField DataField="Assess_Flag" HeaderText="审批状态"
                                    SortExpression="Assess_Flag" />
                                <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                    SortExpression="DepotSummary" Visible="False" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtapprovesuccess" runat="server" CommandName="approvesuccess"
                                            CommandArgument='<%# Eval("Form_ID") %>'>通过审批</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="fail"
                                            CommandArgument='<%# Eval("Form_ID") %>'>拒绝审批</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>

                    </td>
                    <td>
                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="File_Type_Name" HeaderText="文件名称"
                                        SortExpression="File_Type_Name" />
                                    <asp:BoundField DataField="File_ID" HeaderText="文件编号"
                                        SortExpression="File_ID" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="view"
                                                CommandArgument='<%# Eval("File_ID") %>'>查看文件</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>

</body>
</html>
