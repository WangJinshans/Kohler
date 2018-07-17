<%@ Page Language="C#" Async="true" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="VendorRiskAnalysis.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorRiskAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>供应商风险分析表</title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=10"></script>
	<script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js" ></script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>

     <script>
        //防止页面后退  
        history.pushState(null, null, document.URL);
        window.addEventListener('popstate', function () {
            history.pushState(null, null, document.URL);
        });
        // 浏览器回退禁止  
        function noBack() {
            // 历史记录栈中记录页数  
            var numberOfEntries = window.history.length;
            if (window.history && window.history.pushState) {
                $(window).on('popstate', function () {
                    // 当点击浏览器的 后退和前进按钮 时才会被触发，  
                    window.history.pushState('forward', null, '');
                    window.history.forward(1);
                });
            }
            // 新弹出页对应  
            if (numberOfEntries != 1) {
                // 页面间跳转用  
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            }
        };
    </script>
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
	        border-style: none;
			border-color: inherit;
			border-width: 0px;
			overflow: hidden;
            overflow-y:hidden;
			text-align: center;
			width: 100%;
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
	                background-color: #dedede;
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
            $.each(
                $(":radio"), function (i, n) {
                    $(n).parent().click(
                        function () {
                            $(n).prop('checked', 'true');
                        }
                        )
                }
            )
        }

    </script>
</head>

<body>
	<form id="form1" runat="server">
	<div style="text-align:center">
	<table style="width:1000px; margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
		<caption style="font-size:xx-large">供应商风险分析表</caption>
		<tr>
			<td colspan="9" style="text-align:right">编号：PR-05-13-0</td>
		</tr>
		<tr>
			<td colspan="4" style="text-align:left" >Supply Risk Analysis Master template 风险分析模板</td>
		</tr>
		<tr>
			<td colspan="1" style="text-align:left">Product: 产品</td>
			<td colspan="3"><asp:TextBox TextMode="MultiLine" runat="server" ID="txbProduct" BorderStyle="None" style="text-align:center" Width="100%" Height="100%"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Part No.零件号</td>
			<td>Supplier:供应商*</td>
			<td colspan="2"><asp:TextBox TextMode="MultiLine" ID="txbVendor" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%"></asp:TextBox></td>
		</tr>
		<tr >
			<td><asp:TextBox TextMode="MultiLine" ID="txbPartNo" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%"></asp:TextBox></td>
			<td>Manufacturer (if Different):<br />
				生产者(如果不同)*</td>
			<td colspan="2"><asp:TextBox TextMode="MultiLine" ID="TextBox1" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Where Used: 用在何处*</td>
			<td ><asp:TextBox TextMode="MultiLine" ID="txbWhereUsed" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%"></asp:TextBox></td>
			<td class="td-label-style">Annual Spend:年开支*(￥人民币-万元)</td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox2" Width="100%" Height="100%" BorderStyle="None" style="text-align:center">0</asp:TextBox></td>
		</tr>
		<tr>
			<td ></td>
		</tr>
		<tr>
			<td >Overall Risk Category<br/>总体风险等级*</td>
			<td ><asp:RadioButton ID="RadioButton1" Text="LOW" runat="server" GroupName="RiskCategory" /></td>
			<td ><asp:RadioButton ID="RadioButton2" Text="MEDIUM" runat="server" GroupName="RiskCategory" /></td>
			<td ><asp:RadioButton ID="RadioButton3" Text="HIGH" runat="server" GroupName="RiskCategory" /></td>
		</tr>
		<tr>
			<td >General assessment of supplier:<br />
				总体供应商评价*</td>
			<td colspan="3"><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox3" BorderStyle="None" Width="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Contingency plan:<br/>应急计划*</td>
			<td colspan="3"><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox4" BorderStyle="None" Width="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Urgency:<br />紧急</td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox5" BorderStyle="None" CssClass="t"></asp:TextBox></td>
			<td >Complete by:<br />完成人*</td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox6" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Compiled by:<br />编写人*</td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox7" BorderStyle="None" CssClass="t"></asp:TextBox></td>
			<td >Date:</td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" id="TextBox8" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></td>
		</tr>
	</table>
	</div>
	<div style="text-align:center">
		<table style="width:1000px;margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
			<caption style="font-size:x-large ">SUPPLY RISK ANALYSIS</caption>
		<tr>
			<td class="risk-label-left">Political</td>
			<td class="td-label-text-center-bold" colspan="3">RISK</td>
			<td class="td-label-style">Comments/Notes</td>
		</tr>
		<tr>
			<td >Consider:</td>
			<td class="td-label-style">Low</td>
			<td class="td-label-style">Med</td>
			<td class="td-label-style">High</td>
			<td >&nbsp;</td>
		</tr>
		<tr>
			<td >Corporate Strategy 公司战略*</td>
			<td ><asp:RadioButton ID="RadioButton4" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:RadioButton ID="RadioButton5" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:RadioButton ID="RadioButton6" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox10" BorderStyle="None" CssClass="t"> </asp:TextBox></td>
		</tr>

		<tr>
			<td >Stability (of company) 公司稳定性</td>
			<td ><asp:RadioButton ID="RadioButton7" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:RadioButton ID="RadioButton8" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:RadioButton ID="RadioButton9" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox11" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Contractual 契约*</td>
			<td ><asp:RadioButton ID="RadioButton10" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:RadioButton ID="RadioButton11" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:RadioButton ID="RadioButton12" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox12" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Third party involvement 第三方参与*</td>
			<td ><asp:RadioButton ID="RadioButton13" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:RadioButton ID="RadioButton14" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:RadioButton ID="RadioButton15" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox13" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

	</table>
	<table style="width:1000px;margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
			<caption style="font-size:x-large ">&nbsp</caption>
		<tr>
			<td class="risk-label-left">Environmental</td>
			<td class="td-label-text-center-bold" colspan="3">RISK</td>
			<td class="td-label-style">Comments/Notes</td>
		</tr>
		<tr>
			<td >Consider:</td>
			<td class="td-label-style">Low</td>
			<td class="td-label-style">Med</td>
			<td class="td-label-style">High</td>
			<td ></td>
		</tr>
		<tr>
			<td >Location 地理位置*</td>
			<td ><asp:RadioButton ID="RadioButton16" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:RadioButton ID="RadioButton17" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:RadioButton ID="RadioButton18" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox14" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Transport 交通*</td>
			<td ><asp:RadioButton ID="RadioButton19" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:RadioButton ID="RadioButton20" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:RadioButton ID="RadioButton21" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox15" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Seasonality 季节性*</td>
			<td ><asp:RadioButton ID="RadioButton22" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:RadioButton ID="RadioButton23" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:RadioButton ID="RadioButton24" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox16" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Capacity 能力*</td>
			<td ><asp:RadioButton ID="RadioButton25" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:RadioButton ID="RadioButton26" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:RadioButton ID="RadioButton27" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox17" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Stocks 库存*</td>
			<td ><asp:RadioButton ID="RadioButton28" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:RadioButton ID="RadioButton29" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:RadioButton ID="RadioButton30" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox18" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Dedicated facilities 专用设备*</td>
			<td ><asp:RadioButton ID="RadioButton31" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:RadioButton ID="RadioButton32" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:RadioButton ID="RadioButton33" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox19" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Recycling policy 再循环政策*</td>
			<td ><asp:RadioButton ID="RadioButton34" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:RadioButton ID="RadioButton35" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:RadioButton ID="RadioButton36" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox20" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

	</table>
	<table style="width:1000px;margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
			<caption style="font-size:x-large ">&nbsp</caption>
		<tr>
			<td class="risk-label-left">Internal systems</td>
			<td class="td-label-text-center-bold" colspan="3">RISK</td>
			<td class="td-label-style">Comments/Notes</td>
		</tr>
		<tr>
			<td >Consider:</td>
			<td class="td-label-style">Low</td>
			<td class="td-label-style">Med</td>
			<td class="td-label-style">High</td>
			<td ></td>
		</tr>
		<tr>
			<td >Communication 沟通*</td>
			<td ><asp:RadioButton ID="RadioButton37" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:RadioButton ID="RadioButton38" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:RadioButton ID="RadioButton39" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox21" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Financial 财政*</td>
			<td ><asp:RadioButton ID="RadioButton40" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:RadioButton ID="RadioButton41" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:RadioButton ID="RadioButton42" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox22" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >(Lack of) Forward planning (Kohler)
				<br />
				缺乏前瞻性计划*</td>
			<td ><asp:RadioButton ID="RadioButton43" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:RadioButton ID="RadioButton44" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:RadioButton ID="RadioButton45" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox23" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >(Lack of) Forward planning (supplier)
				<br />
				缺乏前瞻性计划*</td>
			<td ><asp:RadioButton ID="RadioButton46" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:RadioButton ID="RadioButton47" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:RadioButton ID="RadioButton48" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox24" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>
        <tr>
            <td>Price 价格*</td>
            <td ><asp:RadioButton ID="RadioButton94" Text=" " runat="server" GroupName="31"/></td>
            <td ><asp:RadioButton ID="RadioButton95" Text=" " runat="server" GroupName="31"/></td>
            <td ><asp:RadioButton ID="RadioButton96" Text=" " runat="server" GroupName="31"/></td>
            <td ><asp:TextBox TextMode="MultiLine" ID="TextBox40" runat="server" BorderStyle="None" CssClass="t"></asp:TextBox></td>
        </tr>
		<tr>
			<td >Change of source (site) of manufacture
				<br />
				变更生产场地或迁移*</td>
			<td ><asp:RadioButton ID="RadioButton49" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:RadioButton ID="RadioButton50" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:RadioButton ID="RadioButton51" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox25" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Annual Shutdown
				<br />
				每年的歇业时间*</td>
			<td ><asp:RadioButton ID="RadioButton52" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:RadioButton ID="RadioButton53" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:RadioButton ID="RadioButton54" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox26" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Computer systems 计算机系统*</td>
			<td ><asp:RadioButton ID="RadioButton55" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:RadioButton ID="RadioButton56" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:RadioButton ID="RadioButton57" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox27" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Intellectual property rights of Kohler
				<br />
				知识产权*</td>
			<td ><asp:RadioButton ID="RadioButton58" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:RadioButton ID="RadioButton59" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:RadioButton ID="RadioButton60" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox28" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Relationship between manufacturer / agent
				<br />
				制造商和代理商的关系*</td>
			<td ><asp:RadioButton ID="RadioButton61" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:RadioButton ID="RadioButton62" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:RadioButton ID="RadioButton63" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox29" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

	</table>

		<table style="width:1000px;margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
			<caption style="font-size:x-large ">&nbsp</caption>
		<tr>
			<td class="risk-label-left">Technological</td>
			<td class="td-label-text-center-bold" colspan="3">RISK</td>
			<td class="td-label-style">Comments/Notes</td>
		</tr>
		<tr>
			<td >Consider:</td>
			<td class="td-label-style">Low</td>
			<td class="td-label-style">Med</td>
			<td class="td-label-style">High</td>
			<td ></td>
		</tr>
		<tr>
			<td >Capacity 能力*</td>
			<td ><asp:RadioButton ID="RadioButton64" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:RadioButton ID="RadioButton65" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:RadioButton ID="RadioButton66" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox30" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Machine breakdown 机器故障*</td>
			<td ><asp:RadioButton ID="RadioButton67" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:RadioButton ID="RadioButton68" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:RadioButton ID="RadioButton69" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox31" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Quality accreditation 质量认证*</td>
			<td ><asp:RadioButton ID="RadioButton70" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:RadioButton ID="RadioButton71" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:RadioButton ID="RadioButton72" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox32" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Audit failure (SQM) 审查失败*</td>
			<td ><asp:RadioButton ID="RadioButton73" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:RadioButton ID="RadioButton74" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:RadioButton ID="RadioButton75" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox33" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Alternative supplier 可替换供应商*</td>
			<td ><asp:RadioButton ID="RadioButton76" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:RadioButton ID="RadioButton77" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:RadioButton ID="RadioButton78" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox34" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Alternative materials 可替换的原材料*</td>
			<td ><asp:RadioButton ID="RadioButton79" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:RadioButton ID="RadioButton80" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:RadioButton ID="RadioButton81" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox35" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Complexity 复杂性*</td>
			<td ><asp:RadioButton ID="RadioButton82" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:RadioButton ID="RadioButton83" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:RadioButton ID="RadioButton84" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox36" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Research &amp; Development 研究与开发*</td>
			<td ><asp:RadioButton ID="RadioButton85" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:RadioButton ID="RadioButton86" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:RadioButton ID="RadioButton87" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox37" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Rejections / complaints 拒绝,投诉*</td>
			<td ><asp:RadioButton ID="RadioButton88" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:RadioButton ID="RadioButton89" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:RadioButton ID="RadioButton90" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox38" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Specifications 说明*</td>
			<td ><asp:RadioButton ID="RadioButton91" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:RadioButton ID="RadioButton92" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:RadioButton ID="RadioButton93" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox39" BorderStyle="None" CssClass="t"></asp:TextBox></td>
		</tr>

	</table>
	</div>

    <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
        <ContentTemplate>
	        <div style="text-align: center;margin-bottom:50px">
		        <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
				        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
		        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClientClick="waiting('正在保存')" OnClick="Button2_Click" />
				        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
	        </div>
        </ContentTemplate>
    </asp:UpdatePanel>

	<div style="float:left;display:none">

		<table>
			<tr>
				<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView2_RowCommand" GridLines="None" ForeColor="#333333">
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
			</tr>
		</table>
	</div>
	</form>
     <script>
        $('textarea').bind('input', function () {
            this.style.height = this.scrollTop + this.scrollHeight + "px";
        })
    </script>
</body>

</html>
