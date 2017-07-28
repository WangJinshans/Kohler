<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVendorExtend.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowVendorExtend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script src="Script/jquery-3.2.1.min.js"></script>
	<script src="Script/layui/layui.js"></script>
	<script src="Script/Own/fileUploader.js"></script>
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
		.td-label-text-center-bold{
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
		.risk-label-left{
			width:30%;
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
            background-color:transparent;
		}


		td {
			border: solid #000000;
			border-width: 1px 1px 1px 1px;
			padding: 10px 0px;
			height:30px;
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
	font-size:11px;
	color:#333333;
	border-width: 1px;
	border-color: #666666;
	border-collapse: collapse;
}
table.gridtable th {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #dedede;
}
table.gridtable td {
	border-width: 1px;
	padding: 8px;
	border-style: solid;
	border-color: #666666;
	background-color: #ffffff;
}
	      .auto-style6 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            width: 65%;
            text-align: center;
            background: #00ffff;
        }
	    .auto-style7 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            text-align: center;
            background-color: transparent;
        }
        .auto-style8 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            width: 65%;
            text-align: center;
            background-color: transparent;
        }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:right">PR-05-07-04</div><br>
        <table style="margin: auto; border-collapse:initial" cellpadding="0" cellspacing="0">
            <caption style="font-size:xx-large; " class="auto-style2">VENDOR EXTEND</caption>
             <tr>
                <td colspan="1" style="text-align:center" class="t">Please select Language / 请选择语言 :</td>
                <td colspan="1" style="text-align:center" class="auto-style8">
                    <asp:DropDownList runat="server" ID="dropDownList1" style="text-align:center;height:100%;width:100%">
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
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style7" Height="35px" Width="447px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">申请人姓名*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style7" Height="35px" Width="466px" ReadOnly="true"></asp:TextBox></td>
            </tr>

           <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">申请人电话*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px" ReadOnly="true" Width="453px"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">科勒公司代码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px" ReadOnly="true" Width="450px"></asp:TextBox></td>
            </tr>

            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">VENDOR INFORMATION</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">供应商编码*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ReadOnly="true" Width="453px"></asp:TextBox></td>
            </tr>
             <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">从哪个COMPANY扩展过来*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px" ReadOnly="true" Width="454px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">邮箱地址（收付款通知书）*</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox7" runat="server" CssClass="t" Height="35px" ReadOnly="true" Width="452px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">PURCHASING</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">货币种类（供下单）</td>
                <td colspan="1" style="text-align:left" class="auto-style6"><asp:TextBox ID="TextBox8" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">APPROVAL</td>
            </tr>
            <tr>
                <td colspan="1" style="text-align:left" class="auto-style3">直线经理审批(Intercompany vendor 需要 VM Leader Liu Junling审批）</td>
                <td colspan="1" style="text-align:left" class="auto-style6">
                    <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
            </tr>
             <tr>
                <td colspan="2" style="text-align:center;background-color:black;color:#ffffff">Comments</td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:TextBox ID="TextBox10" runat="server" CssClass="t" Height="35px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
				<AlternatingRowStyle BackColor="White" />
				<Columns>
					<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
						SortExpression="Form_ID" />
					<asp:BoundField DataField="Position_Name" HeaderText="职位名称"
						SortExpression="Position_Name" />
					<asp:BoundField DataField="Assess_Flag" HeaderText="审批状态"
						SortExpression="Assess_Flag" />
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
        </div>
        <div>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
						SortExpression="Form_ID" />
					<asp:BoundField DataField="File_ID" HeaderText="文件编号"
						SortExpression="File_ID" />

					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="fail"
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
