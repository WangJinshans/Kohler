<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorCreation.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowVendorCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Script/jquery-3.2.1.min.js"></script>
	<script src="Script/layui/layui.js"></script>
	<script src="Script/Own/fileUploader.js?v=9"></script>
    <script src="Script/PDF/js/html2canvas.js"></script>
    <script src="Script/PDF/js/jspdf.debug.js"></script>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
     <style type="text/css">
         .t {
             border: 0px;
             overflow: hidden;
             width: 100%;
             text-align: center;
         }

         td {
             border: solid #000000;
             border-width: 1px 1px 1px 1px;
             padding: 0px 0px;
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

         .auto-style2 {
             width: 1032px;
         }

         .auto-style5 {
             width: 50%;
         }

         .auto-style6 {
             width: 50%;
         }

         .auto-style7 {
             width: 100%;
             margin-left: 40px;
         }

         .auto-style8 {
             width: 464px;
             height: 61px;
         }

         .auto-style9 {
             width: 507px;
             height: 61px;
         }
         .auto-style10 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             width: 464px;
             text-align: center;
             height: 44px;
         }
         .auto-style11 {
             width: 507px;
             height: 44px;
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
        
    <div id="div1">
        <div style="text-align:right">PR-05-07-04</div>
        <table style="margin: auto; border-collapse:initial;width:1000px" cellpadding="0" cellspacing="0">
            <caption style="font-size:xx-large; " class="auto-style2">VENDOR CREATION</caption>
            <tr>
                <td colspan="1" style="text-align:center" class="auto-style10">Please select Language / 请选择语言 :</td>
                <td colspan="1" style="text-align:center" class="auto-style11">
                    <asp:DropDownList runat="server" style="Height:100%; Width:100%;text-align:center; margin-left: 0px;">
                        <asp:ListItem Text="CH" />
                        <asp:ListItem Text="EN" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">GENERAL DATA</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">目的*</td>
                <td colspan="1" style="text-align:left" class="auto-style7"><asp:TextBox TextMode="MultiLine" ID="TextBox1" runat="server" CssClass="t"  ></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">申请人姓名*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">申请人电话*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox3" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">科勒公司代码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox4" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">ACCOUNT GROUP*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox5" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">供应商名字 （中文）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox6" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">供应商名字 （英文/拼音）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox7" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">地址*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox8" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">邮政编码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox9" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">城市*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox10" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">国家*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox11" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">地区*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox12" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">语言*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox13" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">电话*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox14" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">传真*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox15" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">邮箱地址（供下单）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox16" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">邮箱地址（收付款通知书）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox17" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">税务登记证号码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox18" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">PAYMENT TRANSACTIONS</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">付款账期*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox19" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">付款方法*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox20" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">BANK INFORMATION</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">银行代码</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox21" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">银行中文名称 (含支行）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox22" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">银行所在国家*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox23" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">银行帐号*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox24" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">PURCHASING</td>
            </tr>
             <tr>
                <td colspan="1" style="text-align:left" class="auto-style8">货币种类（供下单）*</td>
                <td colspan="1" style="text-align:left" class="auto-style9"><asp:TextBox TextMode="MultiLine" ID="TextBox25" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
             <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">贸易术语*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox26" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">SUPPORTING</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">营业执照 （彩色扫描件）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6">Attached in Email</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">税务登记证 （彩色扫描件）</td>
                <td colspan="1" style="text-align:left" class="auto-style6">Attached in Email</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">银行开户函 （彩色扫描件）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6">Attached in Email</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">带公章合同（如果账期是“根据合同付款”或者“小于60天”，请提供）*</td>
                <td colspan="1" style="text-align:left;height:100%;width:100%" class="auto-style6">
                    <asp:Label Text="" runat="server" ID="label1" Visible="false"/></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">APPROVAL</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">直线经理审批</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">采购经理审批</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">法务部审批 （如果供应商的收款银行在海外，请提供）</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ID="Image3" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">财务经理审批（如果账期是“根据合同付款”或者“小于60天”，请提供）</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ID="Image4" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style5">总监审批 （特殊事宜）</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ID="Image5" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">Comments</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:TextBox TextMode="MultiLine" ID="TextBox32" runat="server" CssClass="t"  ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table class="gridtable" style="margin: auto;margin-bottom:50px; width: 1000px; border-collapse: collapse;">
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
