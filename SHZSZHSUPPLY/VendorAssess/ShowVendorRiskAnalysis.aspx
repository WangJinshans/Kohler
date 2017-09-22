<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorRiskAnalysis.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowVendorRiskAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<title>供应商风险分析表-展示</title>

    <script src="Script/jquery-3.2.1.min.js"></script>
	<script src="Script/layui/layui.js"></script>
	<script src="Script/Own/fileUploader.js"></script>
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
	</style>
    <script>
        function takeScreenshot(file, formID) {
            html2canvas(document.getElementById("div1"), {
                // 渲染完成时调用，获得 canvas
                onrendered: function (canvas) {
                    // 从 canvas 提取图片数据
                    //var imgData = canvas.toDataURL('image/jpeg');
                    //var canWidth = canvas.width;
                    //var canHeight = canvas.height;
                    //var arrDPI = js_getDPI();//获取显示器DPI
                    //var dpiX = 96;
                    //var dpiY = 96;
                    //if (arrDPI.length > 0) {
                    //    dpiX = arrDPI[0];
                    //    dpiY = arrDPI[1];
                    //}
                    //var doc = new jsPDF("p", "mm", [230,315]);
                    ////doc.text('', 10, 20);
                    ////var doc = new jsPDF('', 'in', [(canWidth) / dpiX, (canHeight + 10) / dpiY]);//设置PDF宽高为要显示的元素的宽高，将像素转化为英寸  
                    //doc.addImage(imgData, 'JPEG', 10, 10,209,297);
                    ////doc.addImage(imgData, 'JPEG', 0, 0, 0, 0);
                    //doc.save(filename);
                    var contentWidth = canvas.width;
                    var contentHeight = canvas.height;

                    //一页pdf显示html页面生成的canvas高度;
                    var pageHeight = contentWidth / 592.28 * 841.89;
                    //未生成pdf的html页面高度
                    var leftHeight = contentHeight;
                    //页面偏移
                    var position = 0;
                    //a4纸的尺寸[595.28,841.89]，html页面生成的canvas在pdf中图片的宽高
                    var imgWidth = 595.28;
                    var imgHeight = 592.28 / contentWidth * contentHeight;

                    var pageData = canvas.toDataURL('image/jpeg', 1.0);

                    var pdf = new jsPDF('', 'pt', 'a4');

                    //有两个高度需要区分，一个是html页面的实际高度，和生成pdf的页面高度(841.89)
                    //当内容未超过pdf一页显示的范围，无需分页
                    if (leftHeight < pageHeight) {
                        pdf.addImage(pageData, 'JPEG', 20, 20, imgWidth - 50, imgHeight - 50);
                    } else {
                        while (leftHeight > 0) {
                            pdf.addImage(pageData, 'JPEG', 20, position + 20, imgWidth - 50, imgHeight - 300)
                            leftHeight -= pageHeight;
                            position -= 841.89;
                            //避免添加空白页
                            if (leftHeight > 0) {
                                pdf.addPage();
                            }
                        }
                    }
                    pdf.autoPrint();
                    pdf.save(file);
                    requestToPdfAshx(file, formID);
                },
                background: "#f7f7f7"    //设置PDF背景色（默认透明，实际显示为黑色）
            });
        }
        function js_getDPI() {
            var arrDPI = new Array();
            if (window.screen.deviceXDPI != undefined) {
                arrDPI[0] = window.screen.deviceXDPI;
                arrDPI[1] = window.screen.deviceYDPI;
            }
            else {
                var tmpNode = document.createElement("DIV");
                tmpNode.style.cssText = "width:1in;height:1in;position:absolute;left:0px;top:0px;z-index:99;visibility:hidden";
                document.body.appendChild(tmpNode);
                arrDPI[0] = parseInt(tmpNode.offsetWidth);
                arrDPI[1] = parseInt(tmpNode.offsetHeight);
                tmpNode.parentNode.removeChild(tmpNode);
            }
            return arrDPI;
        }
    </script>
    <script>
        function requestToPdfAshx(fileName, formID) {
            $.get(
                "ASHX/PDF.ashx",
                { "fileName": fileName, "formID": formID },
                function (res) {
                    window.location.href = document.URL;
                    alert(res);
                }
            );
        }
    </script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
</head>
<body>
	<form id="form1" runat="server">
    <div class="layui-form-item" style="width:1000px;margin:0 auto">
            <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
            <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="Button1" runat="server" OnClick="Button1_Click" style="float: right; " />
        </div>    
    <div style="text-align: center" id="div1">
        
        <table aria-readonly="true" id="table1" style="width:1000px; margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
		<caption style="font-size:xx-large">供应商风险分析表</caption>
		<tr>
			<td colspan="9" style="text-align:right">编号：PR-05-13-0</td>
		</tr>
		<tr>
			<td colspan="4" style="text-align:left" >Supply Risk Analysis Master template 风险分析模板</td>
		</tr>
		<tr>
			<td colspan="1" style="text-align:left">Product: 产品</td>
			<td colspan="3"><asp:TextBox runat="server" ID="txbProduct" BorderStyle="None" style="text-align:center" Width="100%" Height="100%" ReadOnly="true"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Part No.零件号</td>
			<td>Supplier:供应商*</td>
			<td colspan="2"><asp:TextBox ID="txbVendor" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%" ReadOnly="true"></asp:TextBox></td>
		</tr>
		<tr >
			<td><asp:TextBox ID="txbPartNo" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%" ReadOnly="true"></asp:TextBox></td>
			<td>Manufacturer (if Different):<br />
				生产者(如果不同)*</td>
			<td colspan="2"><asp:TextBox ID="TextBox1" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%" ReadOnly="true"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Where Used: 用在何处*</td>
			<td ><asp:TextBox ID="txbWhereUsed" style="text-align:center" runat="server" BorderStyle="None" Width="100%" Height="100%" ReadOnly="true"></asp:TextBox></td>
			<td class="td-label-style">Annual Spend:年开支*</td>
			<td ><asp:TextBox runat="server" ID="TextBox2" Width="100%" Height="100%" BorderStyle="None" style="text-align:center" ReadOnly="true">0</asp:TextBox></td>
		</tr>
		<tr>
			<td ></td>
		</tr>
		<tr>
			<td >Overall Risk Category<br/>总体风险等级*</td>
			<td ><asp:RadioButton ID="RadioButton1" Text="LOW" runat="server" GroupName="RiskCategory" Enabled="false" /></td>
			<td ><asp:RadioButton ID="RadioButton2" Text="MEDIUM" runat="server" GroupName="RiskCategory" Enabled="false" /></td>
			<td ><asp:RadioButton ID="RadioButton3" Text="HIGH" runat="server" GroupName="RiskCategory" Enabled="false" /></td>
		</tr>
		<tr>
			<td >General assessment of supplier:<br />
				总体供应商评价*</td>
			<td colspan="3"><asp:TextBox ReadOnly="true" runat="server" ID="TextBox3" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Contingency plan:<br/>应急计划*</td>
			<td colspan="3"><asp:TextBox ReadOnly="true" runat="server" ID="TextBox4" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Urgency:<br />紧急</td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox5" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
			<td >Complete by:<br />完成人*</td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox6" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Compiled by:<br />编写人*</td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox7" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
			<td >Date:</td>
			<td ><asp:TextBox ReadOnly="true" runat="server" id="TextBox8" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></td>
		</tr>
	</table>
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
			<td ><asp:RadioButton Enabled="false" ID="RadioButton4" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton5" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton6" Text=" " runat="server" GroupName="1" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox10" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"> </asp:TextBox></td>
		</tr>
		<tr>
			<td >Stability (of company) 公司稳定性</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton7" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton8" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton9" Text=" " runat="server" GroupName="2" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox11" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Contractual 契约*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton10" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton11" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton12" Text=" " runat="server" GroupName="3" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox12" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Third party involvement 第三方参与*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton13" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton14" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton15" Text=" " runat="server" GroupName="4" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox13" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
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
			<td ><asp:RadioButton Enabled="false" ID="RadioButton16" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton17" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton18" Text=" " runat="server" GroupName="5" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox14" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Transport 交通*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton19" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton20" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton21" Text=" " runat="server" GroupName="6" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox15" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Seasonality 季节性*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton22" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton23" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton24" Text=" " runat="server" GroupName="7" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox16" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Capacity 能力*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton25" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton26" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton27" Text=" " runat="server" GroupName="8" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox17" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Stocks 库存*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton28" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton29" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton30" Text=" " runat="server" GroupName="9" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox18" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Dedicated facilities 专用设备*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton31" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton32" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton33" Text=" " runat="server" GroupName="10" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox19" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Recycling policy 再循环政策*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton34" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton35" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton36" Text=" " runat="server" GroupName="11" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox20" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
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
			<td ><asp:RadioButton Enabled="false" ID="RadioButton37" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton38" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton39" Text=" " runat="server" GroupName="12" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox21" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>

		<tr>
			<td >Financial 财政*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton40" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton41" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton42" Text=" " runat="server" GroupName="13" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox22" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >(Lack of) Forward planning (Kohler)
				<br />
				缺乏前瞻性计划*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton43" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton44" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton45" Text=" " runat="server" GroupName="14" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox23" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >(Lack of) Forward planning (supplier)
				<br />
				缺乏前瞻性计划*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton46" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton47" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton48" Text=" " runat="server" GroupName="15" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox24" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Change of source (site) of manufacture
				<br />
				变更生产场地或迁移*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton49" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton50" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton51" Text=" " runat="server" GroupName="16" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox25" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Annual Shutdown
				<br />
				每年的歇业时间*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton52" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton53" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton54" Text=" " runat="server" GroupName="17" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox26" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Computer systems 计算机系统*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton55" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton56" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton57" Text=" " runat="server" GroupName="18" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox27" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Intellectual property rights of Kohler
				<br />
				知识产权*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton58" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton59" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton60" Text=" " runat="server" GroupName="19" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox28" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Relationship between manufacturer / agent
				<br />
				制造商和代理商的关系*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton61" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton62" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton63" Text=" " runat="server" GroupName="20" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox29" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
	</table>
		<table style="width:1000px;margin:auto; border-collapse:collapse" cellpadding:"0" cellspacing="0" border="1">
			<caption style="font-size:x-large;">&nbsp</caption>
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
			<td ><asp:RadioButton Enabled="false" ID="RadioButton64" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton65" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton66" Text=" " runat="server" GroupName="21" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox30" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Machine breakdown 机器故障*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton67" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton68" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton69" Text=" " runat="server" GroupName="22" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox31" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Quality accreditation 质量认证*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton70" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton71" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton72" Text=" " runat="server" GroupName="23" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox32" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Audit failure (SQM) 审查失败*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton73" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton74" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton75" Text=" " runat="server" GroupName="24" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox33" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Alternative supplier 可替换供应商*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton76" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton77" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton78" Text=" " runat="server" GroupName="25" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox34" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Alternative materials 可替换的原材料*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton79" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton80" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton81" Text=" " runat="server" GroupName="26" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox35" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Complexity 复杂性*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton82" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton83" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton84" Text=" " runat="server" GroupName="27" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox36" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Research &amp; Development 研究与开发*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton85" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton86" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton87" Text=" " runat="server" GroupName="28" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox37" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Rejections / complaints 拒绝,投诉*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton88" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton89" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton90" Text=" " runat="server" GroupName="29" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox38" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
		<tr>
			<td >Specifications 说明*</td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton91" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton92" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:RadioButton Enabled="false" ID="RadioButton93" Text=" " runat="server" GroupName="30" /></td>
			<td ><asp:TextBox ReadOnly="true" runat="server" ID="TextBox39" BorderStyle="None" Width="100%" Height="100%" style="text-align:center"></asp:TextBox></td>
		</tr>
	</table>
	</div>
		<div>
			<table class="gridtable" style="margin: auto;width:1000px; border-collapse: collapse;">
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
										<asp:BoundField DataField="Assess_Time" HeaderText="操作时间" 
											SortExpression="Assess_Time" />
										<asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary" 
											SortExpression="DepotSummary" Visible="False" />
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
			
					</td>
					<td>
			<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333" >
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
