<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorModify.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
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

        .auto-style2 {
            width: 1032px;
        }

        .auto-style5 {
            width: 537px;
        }

        .auto-style6 {
            width: 507px;
        }

        .auto-style7 {
            width: 507px;
            margin-left: 40px;
        }

        .auto-style8 {
            width: 537px;
            height: 61px;
        }

        .auto-style9 {
            width: 507px;
            height: 61px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: right">PR-05-07-04</div>
        <div>
            <table style="margin: auto; border-collapse: initial; width: 1000px" cellpadding="0" cellspacing="0">
                <caption style="font-size: xx-large;" class="auto-style2">VENDOR MODIFICATION</caption>
                <tr>
                    <td colspan="1" style="text-align: center" class="auto-style5">Please select Language / 请选择语言 :</td>
                    <td colspan="1" style="text-align: center" class="auto-style6">
                        <asp:DropDownList runat="server" Style="text-align: center; height: 100%; width: 100%">
                            <asp:ListItem Text="CH" />
                            <asp:ListItem Text="EN" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">GENERAL DATA</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">目的*</td>
                    <td colspan="1" style="text-align: left" class="auto-style7">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">申请人姓名*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">申请人电话*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">科勒公司代码*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">供应商代码VENDOR CODE*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">供应商名称VENDOR NAME*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">地址STREET （or PO BOX)*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">邮编POSTAL CODE (ZIP CODE)*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">城市CITY*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">国际COUNTRY*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">地区REGION*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">语言Language*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">电话TELEPHONE NO*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">传真FAX NO.*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox15" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">邮箱地址E-MAIL ADDRESS (FOR PO)*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox16" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">邮箱地址E-MAIL ADDRESS (FOR PAYMENT ADVICE用于付款信息)*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">纳税识别号TAX IDENTIFICATION NUMBER*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox18" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">PAYMENT TRANSACTIONS</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">账期PAYMENT TERM*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox19" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">付款方式PAYMENT METHOD*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox20" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">BANK INFORMATION</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">银行代码</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox21" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">银行中文名称 (含支行）*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox22" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">银行所在国家*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox23" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">银行帐号*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox24" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">PURCHASING</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style8">货币种类（供下单）*</td>
                    <td colspan="1" style="text-align: left" class="auto-style9">
                        <asp:TextBox ID="TextBox25" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">贸易术语*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:TextBox ID="TextBox26" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">SUPPORTING</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">营业执照 （彩色扫描件）*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">Attached in Email</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">税务登记证 （彩色扫描件）</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">Attached in Email</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">银行开户函 （彩色扫描件）*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">Attached in Email</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">带公章合同（如果账期是“根据合同付款”或者“小于60天”，请提供）*</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Label Text="" runat="server" ID="label1" Visible="false" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">APPROVAL</td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">直线经理审批</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">采购经理审批</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">法务部审批 （如果供应商的收款银行在海外，请提供）</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">财务经理审批（如果账期是“根据合同付款”或者“小于60天”，请提供）</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Image ImageUrl="imageurl" ID="Image4" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="1" style="text-align: left" class="auto-style5">总监审批 （特殊事宜）</td>
                    <td colspan="1" style="text-align: left" class="auto-style6">
                        <asp:Image ImageUrl="imageurl" ID="Image5" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">Comments</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:TextBox ID="TextBox32" runat="server" CssClass="t" Height="35px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-bottom: 10px">
                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
            </div>
            <div style="width: 800px;margin:0 auto">
                <div style="float:left;">
                    <label>旧的文件</label>
                    <asp:GridView ID="GridView1" Style="width: 400px; margin: 0 auto; float: left;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="File_Type_Name" HeaderText="文件名称"
                                SortExpression="File_Type_Name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="viewFile" runat="server" CommandName="view"
                                        CommandArgument='<%# Eval("File_Type_Name") %>'>查看文件</asp:LinkButton>
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
                </div>

                <div style="float:left;">
                    <label>新的文件</label>
                    <asp:GridView ID="GridView2" Style="width: 400px; margin: 0 auto; float: left;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="false" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView2_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="File_Type_Name" HeaderText="文件名称"
                                SortExpression="Form_ID" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="viewFile" runat="server" CommandName="view"
                                        CommandArgument='<%# Eval("File_Type_Name") %>'>查看文件</asp:LinkButton>
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
                </div>
            </div>
        </div>
    </form>
</body>
</html>
