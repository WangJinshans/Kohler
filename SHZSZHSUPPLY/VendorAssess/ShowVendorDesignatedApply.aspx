<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorDesignatedApply.aspx.cs" Inherits="VendorAssess.ShowVendorDesignatedApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=10"></script>
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
        window.onload = function () {
            showAllText();
            hideShowOtherElements();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
                    <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
                    <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="btnPDF" runat="server" OnClientClick="requestToPdfAshx()" Style="float: right;" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="div1" style="text-align: right">
            <table style="margin: auto;text-align:center; border-collapse: initial; width: 1000px" cellpadding="0" cellspacing="0">
                <caption style="font-size: small; text-align: right; border-style: none;">PR-05-10-2</caption>
                <tr>
                    <td colspan="6" style="text-align: center"><font size="4">上海科勒有限公司</font><br/>指定供应商申请表</td>
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
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox1" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox2" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox3" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox4" runat="server" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox5" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox6" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox9" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox10" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox11" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" id="TextBox15" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox16" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox19" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox20" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox23" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox25" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" id="TextBox26" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox27" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox28" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox29" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox30" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox31" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" id="TextBox32" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox33" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox34" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox35" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox36" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox37" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" id="TextBox38" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox39" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                    <td colspan="1" ><asp:TextBox ReadOnly="true" TextMode="MultiLine" ID="TextBox40" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">Initiator:</td>
                    <td colspan="5">
                        <asp:TextBox ReadOnly="true" ID="TextBox7" runat="server" CssClass="auto-style1" Width="819px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">Date:</td>
                    <td colspan="5">
                        <asp:TextBox ReadOnly="true" ID="TextBox8" runat="server" CssClass="auto-style1" Width="811px"></asp:TextBox></td>
                </tr>
                
            </table>
            <table style="margin: auto;text-align:center;width:1000px; border-collapse: initial;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="6" style="text-align: left">Approval Signature</td>
                </tr>
                <tr>
                    <td colspan="1">Applicant: </td>
                    <td colspan="1">
                        <asp:Image AlternateText=" "  ID="Image8" runat="server" />
                    </td>
                    <td colspan="1">Request Dept Head: </td>
                    <td colspan="1" class="auto-style3">
                        <asp:Image AlternateText=" "  ID="Image1" runat="server" />
                    </td>
                    <td colspan="1">FIN Manager: </td>
                    <td colspan="1">
                        <asp:Image AlternateText=" " ID="Image2" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Date: </td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" ID="TextBox12" runat="server" CssClass="auto-style1"></asp:TextBox>
                    </td>
                    <td colspan="1">Date: </td>
                    <td colspan="1" class="auto-style3">
                        <asp:TextBox ReadOnly="true" ID="TextBox13" runat="server" CssClass="auto-style1"></asp:TextBox>
                    </td>
                    <td colspan="1">Date: </td>
                    <td colspan="1">
                        <asp:TextBox ReadOnly="true" ID="TextBox14" runat="server" CssClass="auto-style1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Purchasing Manager: </td>
                    <td colspan="2">
                        <asp:Image AlternateText=" " ID="Image3" runat="server"  />
                    </td>
                    <td colspan="1" class="auto-style3">GM: </td>
                    <td colspan="2">
                        <asp:Image AlternateText=" " ID="Image4" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Dtae: </td>
                    <td colspan="2">
                        <asp:TextBox ReadOnly="true" ID="TextBox17" runat="server" CssClass="auto-style1" Width="280px"></asp:TextBox>
                    </td>
                    <td colspan="1" class="auto-style3">Date: </td>
                    <td colspan="2">
                        <asp:TextBox ReadOnly="true" ID="TextBox18" runat="server" CssClass="auto-style1" Width="344px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">Director: </td>
                    <td colspan="2">
                        <asp:Image AlternateText=" " ID="Image5" runat="server"  />
                    </td>
                    <td colspan="1" class="auto-style3">Supply Chain Director: </td>
                    <td colspan="2">
                        <asp:Image AlternateText=" " ID="Image6" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: right">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
                </tr>
                <tr>
                    <td colspan="1">Dtae: </td>
                    <td colspan="2">
                        <asp:TextBox ReadOnly="true" ID="TextBox21" runat="server" CssClass="auto-style1" Width="280px"></asp:TextBox>
                    </td>
                    <td colspan="1" class="auto-style3">Date: </td>
                    <td colspan="2">
                        <asp:TextBox ReadOnly="true" ID="TextBox22" runat="server" CssClass="auto-style1" Width="344px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">President:</td>
                    <td colspan="5" style="text-align: left">
                        <asp:Image AlternateText=" " ID="Image7" runat="server"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
                </tr>
                <tr>
                    <td colspan="1">Date:</td>
                    <td colspan="5">
                        <asp:TextBox ReadOnly="true" ID="TextBox24" runat="server" CssClass="auto-style1" Width="313px"></asp:TextBox></td>
                </tr>
            </table>
            <table class="gridtable" style="margin: 0 auto;margin-bottom:50px; width: 1000px; border-collapse: collapse;">
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
                                        <asp:LinkButton OnClientClick="waiting('正在处理')" ID="lbtapprovesuccess" runat="server" CommandName="approvesuccess"
                                            CommandArgument='<%# Eval("Form_ID") %>'>通过审批</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton OnClientClick="waiting('正在处理')" ID="lbtapprovefail" runat="server" CommandName="fail"
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
