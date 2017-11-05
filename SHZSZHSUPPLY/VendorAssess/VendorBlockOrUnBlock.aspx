<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorBlockOrUnBlock.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorBlockOrUnBlock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            background-color:transparent;
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
            margin-right:auto;
             width: 1007px;
         }
         .auto-style3 {
             width: 50%;
         }
         .auto-style6 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             width: 124%;
             text-align: center;
             background: #0094ff;
         }
         .auto-style8 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             width: 50%;
             text-align: center;
             background-color: transparent;
         }
         .auto-style9 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             width: 124%;
             text-align: center;
             background-color: transparent;
         }
         .auto-style10 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             text-align: center;
             background-color: transparent;
         }
         .auto-style11 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             width: 95%;
             text-align: center;
             background-color: transparent;
             margin-left: 0px;
         }
         .auto-style12 {
             width: 1007px;
         }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:right" class="auto-style12">PR-05-07-04</div>
        <table style="margin: auto; border-collapse:initial;width:1000px" cellpadding="0" cellspacing="0">
            <caption style="font-size:xx-large; " class="auto-style2">VENDOR BLOCK or UNBLOCK</caption>
             <tr>
                <td colspan="1" style="text-align:center" class="auto-style8">Please select Language / 请选择语言 :</td>
                <td colspan="1" style="text-align:center" class="auto-style9">
                    <asp:DropDownList runat="server" ID="dropDownList1" style="text-align:center;" Height="16px" Width="486px">
                        <asp:ListItem Text="CH" />
                        <asp:ListItem Text="EN" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">GENERAL DATA</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">目的*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">申请人姓名*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style10" Height="35px" Width="452px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">申请人电话*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">科勒公司代码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">VENDOR INFORMATION</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">供应商编码*</td>
                 <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">APPROVAL</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">直线经理审批</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">采购经理审批</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">Comments</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style10" Height="35px" Width="979px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div style="text-align:center;margin-bottom:50px">
            <asp:Button ID="Button1" runat="server" Text="保存" CssClass="layui-btn" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="提交" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
        </div>
        <div>
            <asp:GridView style="display:none" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
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
        </div>
    </form>
</body>
</html>
