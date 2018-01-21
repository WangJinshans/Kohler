<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPurchasePriceChanges.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowPurchasePriceChanges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>采购价格变更申请表</title>
	<link rel="stylesheet" href="Script/layui/css/layui.css" />
	<script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
	<script src="Script/jquery-3.2.1.min.js"></script>
	<script src="Script/layui/layui.js"></script>
	<script src="Script/Own/fileUploader.js?v=9"></script>
	<style>
		.float-right {
			float: right;
		}
		.thead-style {

		}
		table { width: 100%; table-layout: fixed; }
		td { border: 1px solid black; }
		.none-border-td {
			border: 0px solid black;
		}
		textarea {
			width: 100%;
			height: 100%;
			border-style: none;
			border-color: inherit;
			border-width: 0px;
			overflow: hidden;
			text-align: center;
		}
		h3 {
			font-size: medium;
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
	</style>
	<script type="text/javascript">
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
	<table style="margin:0 auto;width:100%; border-collapse: collapse;word-break:break-all">
			<caption style="font-size: xx-large">上海科勒有限公司<br/>采购价格变更申请表</caption>
			<tr>
				<td class="none-border-td" colspan="4">Vendor Code <asp:TextBox ReadOnly="true" runat="server" ID="TextBox1"></asp:TextBox></td>
				<td class="none-border-td" colspan="4">Vendor <asp:TextBox ReadOnly="true" style="width: 70%" runat="server" ID="TextBox2"></asp:TextBox></td>
				<td class="none-border-td" colspan="4">币种 <asp:TextBox ReadOnly="true" runat="server" ID="TextBox3"></asp:TextBox></td>
				<td class="none-border-td" colspan="4">Date <asp:TextBox ReadOnly="true" runat="server" ID="TextBox4" ></asp:TextBox></td>
				<td class="none-border-td" colspan="2"><label class="float-right">PR-06-07-1</label></td>
			</tr>
			<tbody>
				<tr>
					<td>SKU*</td>
					<td>Description*</td>
					<td>unit*</td>
					<td>Last PO Price*</td>
					<td>Last 6 months Average Price*</td>
					<td>Required Price*</td>
					<td>STD cost*</td>
					<td>Request Price VS Last PO Price %*</td>
					<td>STD cost VS Request Price %*</td>
					<td>Yearly Forecast*</td>
					<td>Yearly Amount*</td>
					<td>PPV*</td>
					<td>Current Stock</td>
					<td>Main material cost change %*</td>
					<td>Main material cost VS Total cost %*</td>
					<td>Required Cost Change %</td>
					<td>Effective Date*</td>
					<td>Remark</td>
				</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox5"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox6"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox7"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox8"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox9"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox10"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox11"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox12"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox13"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox14"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox15"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox16"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox17"></asp:TextBox></td>
				<td rowspan="17"><asp:TextBox ReadOnly="true" style="height: 100%" TextMode="MultiLine" runat="server" ID="TextBox18"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox19"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox20"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox21" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox22"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox23"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox24"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox25"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox26"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox27"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox28"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox29"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox30"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox31"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox32"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox33"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox34"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox35"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox36"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox37"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox38" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox39"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox40"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox41"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox42"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox43"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox44"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox45"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox46"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox47"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox48"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox49"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox50"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox51"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox52"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox53"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox54"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox55" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox56"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox57"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox58"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox59"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox60"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox61"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox62"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox63"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox64"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox65"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox66"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox67"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox68"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox69"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox70"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox71"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox72" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox73"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox74"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox75"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox76"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox77"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox78"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox79"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox80"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox81"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox82"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox83"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox84"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox85"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox86"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox87"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox88"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox89" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox90"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox91"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox92"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox93"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox94"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox95"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox96"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox97"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox98"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox99"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox100"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox101"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox102"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox103"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox104"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox105"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox106" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox107"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox108"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox109"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox110"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox111"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox112"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox113"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox114"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox115"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox116"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox117"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox118"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox119"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox120"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox121"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox122"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox123" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox124"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox125"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox126"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox127"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox128"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox129"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox130"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox131"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox132"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox133"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox134"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox135"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox136"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox137"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox138"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox139"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox140" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox141"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox142"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox143"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox144"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox145"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox146"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox147"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox148"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox149"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox150"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox151"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox152"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox153"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox154"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox155"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox156"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox157" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox158"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox159"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox160"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox161"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox162"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox163"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox164"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox165"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox166"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox167"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox168"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox169"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox170"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox171"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox172"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox173"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox174" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox175"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox176"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox177"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox178"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox179"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox180"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox181"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox182"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox183"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox184"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox185"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox186"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox187"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox188"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox189"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox190"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox191" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox192"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox193"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox194"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox195"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox196"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox197"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox198"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox199"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox200"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox201"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox202"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox203"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox204"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox205"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox206"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox207"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox208" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox209"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox210"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox211"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox212"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox213"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox214"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox215"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox216"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox217"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox218"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox219"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox220"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox221"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox222"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox223"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox224"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox225" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox226"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox227"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox228"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox229"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox230"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox231"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox232"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox233"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox234"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox235"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox236"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox237"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox238"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox239"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox240"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox241"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox242" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox243"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox244"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox245"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox246"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox247"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox248"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox249"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox250"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox251"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox252"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox253"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox254"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox255"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox256"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox257"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox258"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox259" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox260"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox261"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox262"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox263"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox264"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox265"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox266"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox267"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox268"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox269"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox270"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox271"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox272"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox273"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox274"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox275"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox276" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox277"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox278"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox279"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox280"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox281"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox282"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox283"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox284"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox285"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox286"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox287"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox288"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox289"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox290"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox291"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox292"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox293" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox294"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox295"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox296"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox297"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox298"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox299"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox300"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox301"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox302"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox303"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox304"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox305"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox306"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox307"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox308"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox309"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox310"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox311" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox312"></asp:TextBox></td>
			</tr>
			<tr>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox313"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox314"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox315"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox316"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox317"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox318"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox319"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox320"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox321"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox322"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox323"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox324"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox325"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox326"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox327"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox328"></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox329" ></asp:TextBox></td>
				<td><asp:TextBox ReadOnly="true" TextMode="MultiLine" runat="server" ID="TextBox330"></asp:TextBox></td>
			</tr>
			</tbody>
			<tfoot><tr><td class="none-border-td" colspan="10">All price are RMB w/o Vat</td></tr></tfoot>
		</table>
	

	<table style="margin-top: 30px; border-collapse: separate; border-spacing: 0px 10px">
		<tr>
			<td class="none-border-td"><h3>Initiator:</h3>
			</td>
			<td class="none-border-td">
				<asp:Image runat="server" AlternateText=" " ID="Image1"/></td>
			<td class="none-border-td"><h3>Purchasing Manager(Plant):</h3></td>
			<td class="none-border-td"><asp:Image runat="server" AlternateText=" " ID="Image2"/></td>
		</tr>
		<tr>
			<td class="none-border-td"><h3>Finance Manager(Plant):</h3></td>
			<td class="none-border-td"><asp:Image runat="server" AlternateText=" " ID="Image3"/></td>
			<td class="none-border-td"><h3>GM(Plant):</h3></td>
			<td class="none-border-td"><asp:Image runat="server" AlternateText=" " ID="Image4"/></td>
		</tr>
		<tr>
			<td class="none-border-td"><h3>Associated Director Sourcin</h3></td>
			<td class="none-border-td"><asp:Image runat="server" AlternateText=" " ID="Image5"/></td>
			<td class="none-border-td"><h3>Finance Director(KCI):</h3></td>
			<td class="none-border-td"><asp:Image runat="server" AlternateText=" " ID="Image6"/></td>
		</tr>
	</table>
	<div style="margin-top: 30px">
		* Notes: 	<br/>																	
		1）凡是采购价格变更的情况下需要填写“采购价格变更申请表”，将价格变动分析资料作为支持文件一起递交待批准	<br/>				
		2）凡是采购价格下降的须由Purchasing Manager(Plant)批准后输入系统执行			<br/>		
		3）涨价幅度在5%以内（含5%）须由Purchasing Manager(Plant) /Finance Manager(Plant)批准					<br/>							
		4）涨价幅度超过5%（适用于年采购金额在10万人民币以上的供应商） ，必须由KCI Senior Associated Director Sourcing和Finance Director以及GM(Plant)的共同批准	<br/>		
		5）价格变更批准生效后，请发至KCI采购部指定窗口备案，邮件地址：daoquan.zhang@kohler.com/电话：021-38602561			
	</div>
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
