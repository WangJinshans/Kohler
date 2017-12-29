<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorCreation.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=6"></script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
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
	<div style="text-align:right">PR-05-07-04</div>
	<div>
		<table style="margin: auto; border-collapse:initial;width:1000px" cellpadding="0" cellspacing="0">
			<caption style="font-size:xx-large; " class="auto-style2">VENDOR CREATION</caption>
			<tr>
				<td colspan="1" style="text-align:center" class="auto-style5">Please select Language / 请选择语言 :</td>
				<td colspan="1" style="text-align:center" class="auto-style6">
					<asp:DropDownList runat="server" style="text-align:center;height:100%;width:100%">
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
				<td colspan="1" style="text-align:left" class="auto-style7"><asp:TextBox TextMode="MultiLine" ID="TextBox1" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>

			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">申请人姓名*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">申请人电话*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox3" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">科勒公司代码*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox4" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">ACCOUNT GROUP*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox5" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">供应商名字 （中文）*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox6" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">供应商名字 （英文/拼音）*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox7" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">地址*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox8" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">邮政编码*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox9" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">城市*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox10" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">国家*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox11" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">地区*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox12" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">语言*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox13" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">电话*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox14" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">传真*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox15" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">邮箱地址（供下单）*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox16" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">邮箱地址（收付款通知书）*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox17" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">税务登记证号码*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox18" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center;background-color:black;color:#ffffff">PAYMENT TRANSACTIONS</td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">付款账期*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox19" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">付款方法*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox20" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			 <tr>
				<td colspan="2" style="text-align:center;background-color:black;color:#ffffff">BANK INFORMATION</td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">银行代码</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox21" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">银行中文名称 (含支行）*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox22" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">银行所在国家*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox23" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">银行帐号*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox24" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			 <tr>
				<td colspan="2" style="text-align:center;background-color:black;color:#ffffff">PURCHASING</td>
			</tr>
			 <tr>
				<td colspan="1" style="text-align:left" class="auto-style8">货币种类（供下单）*</td>
				<td colspan="1" style="text-align:left" class="auto-style9"><asp:TextBox TextMode="MultiLine" ID="TextBox25" runat="server" CssClass="t"></asp:TextBox></td>
			</tr>
			 <tr>
				<td colspan="1" style="text-align:left" class="auto-style5">贸易术语*</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox TextMode="MultiLine" ID="TextBox26" runat="server" CssClass="t"></asp:TextBox></td>
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
				<td colspan="1" style="text-align:left" class="auto-style6">
					<asp:Label Text="" runat="server" ID="label1" Visible="false"/></td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center;background-color:black;color:#ffffff">APPROVAL</td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">直线经理审批</td>
				<td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image onclick="openSignatureSelection(this,null)" AlternateText="请选择图片" ImageUrl="imageurl" ID="Image1" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">采购经理审批</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">法务部审批 （如果供应商的收款银行在海外，请提供）</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">财务经理审批（如果账期是“根据合同付款”或者“小于60天”，请提供）</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:Image ImageUrl="imageurl" ID="Image4" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="1" style="text-align:left" class="auto-style5">总监审批 （特殊事宜）</td>
				<td colspan="1" style="text-align:left" class="auto-style6"><asp:Image ImageUrl="imageurl" ID="Image5" runat="server" /></td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center;background-color:black;color:#ffffff">Comments</td>
			</tr>
			<tr>
				<td colspan="2" style="text-align:center">
					<asp:TextBox TextMode="MultiLine" ID="TextBox32" runat="server" CssClass="t"></asp:TextBox>
				</td>
			</tr>
		</table>
		<%--<div style="text-align:center;margin-bottom:50px">
			<asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" /></div>--%>
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
		<table style="display:none">
			<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView2_RowCommand" GridLines="None" ForeColor="#333333">
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
		</table>
	</div>
	</form>
</body>
</html>
