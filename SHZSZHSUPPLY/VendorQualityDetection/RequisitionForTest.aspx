<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequisitionForTest.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.RequisitionForTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
	<style type="text/css">
		* {
			padding: 0px;
			margin: 0px;
		}
		table {
			margin-bottom:100px;
			margin-top:50px;
			width: 70%;
			border: solid #000000;
			border-width: 2px 2px 2px 2px;
			margin-left:auto;
			margin-right:auto;
		}
		
		table tr td {
			border: solid #000000;
			border-width:1px;
			font-size:15px;
			font-family:Serif;
			height:50px;
			width:210px;
			vertical-align:top;
		}

	</style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
			<table>
				<tr><th colspan="10" style="font-size:25px">试验委托单<br />Requisition For Test</th></tr>
				<tr>
					<td colspan="2">委托单号:<asp:TextBox ID="TextBox1" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />R.F.TNO.</td>
					<td colspan="2">委托日期:<asp:TextBox ID="TextBox2" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />Date of Issue</td>
					<td colspan="2">委托人:<asp:TextBox ID="TextBox3" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />Requested by</td>
					<td colspan="2">分机号:<asp:TextBox ID="TextBox4" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />Ext. No.</td>
					<td colspan="2">部门:<asp:TextBox ID="TextBox5" runat="server" Height="26px" Width="109px" BorderWidth="0px"></asp:TextBox><br />Department</td>
				</tr>
				<tr>
					<td colspan="2">样品名称:<asp:TextBox ID="TextBox6" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />Sample Name</td>
					<td colspan="2">规格:&nbsp&nbsp<asp:TextBox ID="TextBox7" runat="server" Height="26px" Width="115px" BorderWidth="0px"></asp:TextBox><br />Desciption</td>
					<td colspan="2">样品量:<asp:TextBox ID="TextBox8" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox><br />Sample Qty/Wt.</td>
					<td colspan="4">要求日期:&nbsp<asp:TextBox ID="TextBox9" runat="server" Height="26px" Width="121px" BorderWidth="0px"></asp:TextBox><br />Date Required</td>
				</tr>
				<tr>
					<td colspan="10" style=" height:100px">测试内容Test Content:<br /><asp:TextBox ID="TextBox10" runat="server" Height="77px" Width="1021px" TextMode="MultiLine" BorderWidth="0px"></asp:TextBox></td>
				</tr>
				<tr>
					<td rowspan="2" style="height:120px">如是原材料, 请填这栏If Raw Material, Fill in This Column :<br /><asp:TextBox ID="TextBox11" runat="server" Height="59px" Width="171px" TextMode="MultiLine" BorderWidth="0px"></asp:TextBox></td>
					<td colspan="2">供应商Suplier:<asp:TextBox ID="TextBox12" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox></td>
					<td colspan="2">到货量Goods Qty/Wt.:<asp:TextBox ID="TextBox13" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox></td>
					<td colspan="2">到货日期Arrived Date:<asp:TextBox ID="TextBox14" runat="server" Height="26px" Width="113px" BorderWidth="0px"></asp:TextBox></td>
					<td colspan="2">用户User:&nbsp&nbsp<asp:TextBox ID="TextBox15" runat="server" Height="26px" Width="144px" BorderWidth="0px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="8" style="vertical-align:top">取样说明Desciption of Take Sample:<asp:TextBox ID="TextBox16" runat="server" Height="26px" Width="798px" TextMode="MultiLine" BorderWidth="0px"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">接受日期Received Date:<asp:TextBox ID="TextBox17" runat="server" Height="26px" BorderWidth="0px" ></asp:TextBox></td>
					<td colspan="3">接受人Received by:<asp:TextBox ID="TextBox18" runat="server" Height="26px" BorderWidth="0px"  ></asp:TextBox></td>
					<td colspan="4">实验室主管同意LAV Supervisor Approval:<asp:TextBox ID="TextBox19" runat="server" Height="26px" BorderWidth="0px"  ></asp:TextBox></td>
				</tr>
				<tr><td colspan="10" style="text-align:center;vertical-align:top;height:25px;border-bottom-width:0px">申请人Requester:<asp:TextBox ID="TextBox20" runat="server" Height="16px" BorderWidth="0px"  ></asp:TextBox></td></tr>
				<tr><td colspan="10" style="text-align:center;vertical-align:top;height:25px;border-top-width:0px">实验室Lab:<asp:TextBox ID="TextBox21" runat="server" Height="16px" BorderWidth="0px" Width="161px"  ></asp:TextBox></td></tr>
			</table>
			<div style="text-align: center;">
                <asp:Button ID="selected" runat="server" Text="提交" CssClass="layui-btn" OnClick="Submit"/>
			</div>
        </div>
    </form>
</body>
</html>
