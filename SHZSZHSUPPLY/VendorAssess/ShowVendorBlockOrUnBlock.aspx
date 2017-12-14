<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorBlockOrUnBlock.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowVendorBlockOrUnBlock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=5"></script>
    <script src="Script/PDF/js/html2canvas.js"></script>
    <script src="Script/PDF/js/jspdf.debug.js"></script>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />

    <style type="text/css">
        .td-label-style {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }

        .td-label-text-center-bold {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: Arial, sans-serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
        }

        .risk-label-left {
            width: 30%;
        }

        .div {
            width: 600px;
            height: 200px;
            border: 2px;
        }

        h1 {
            text-align: center;
        }

        h3 {
            text-align: right;
        }

        p {
            text-align: right;
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

        .t {
            border: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
            background-color: transparent;
        }


        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 10px 0px;
            height: 30px;
        }

        .head {
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

        .auto-style6 {
            border-color: black;
            border-width: 1px;
            border:1px;
            overflow: hidden;
            width: 24%;
            text-align: center;
        }

        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            width: 30%;
            text-align: center;
            background-color: transparent;
        }

        .auto-style9 {
            width: 70%;
        }

        .auto-style10 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
            background-color: transparent;
            margin-left: 0px;
        }
        .auto-style11 {
            width: 62%;
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

        <div style="text-align: right" class="auto-style12">PR-05-07-04</div>
        <br/>
        <table id="table1" style="margin: auto; border-collapse: initial;width:1000px" cellpadding="0" cellspacing="0">
            <caption style="font-size: xx-large;" class="auto-style2">VENDOR BLOCK or UNBLOCK</caption>
            <tr>
                <td colspan="1" style="text-align: center" class="auto-style8">Please select Language / 请选择语言 :</td>
                <td colspan="1" style="text-align: center" class="auto-style9">
                    <asp:DropDownList runat="server" ID="dropDownList1" Style="text-align: center;" Height="16px" Width="486px">
                        <asp:ListItem Text="CH" />
                        <asp:ListItem Text="EN" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">GENERAL DATA</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">目的*</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">申请人姓名*</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style10" Height="35px" Width="452px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">申请人电话*</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">科勒公司代码*</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">VENDOR INFORMATION</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">供应商编码*</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">APPROVAL</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">直线经理审批</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align: left" class="auto-style11">采购经理审批</td>
                <td colspan="1" style="text-align: left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center; background-color: black; color: #ffffff">Comments</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style10" Height="35px"  Style="margin-left: 0px" ReadOnly="true"></asp:TextBox>
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
    </form>
</body>
</html>
