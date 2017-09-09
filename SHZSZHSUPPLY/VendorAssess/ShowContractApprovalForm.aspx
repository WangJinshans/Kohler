<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowContractApprovalForm.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowContractApprovalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Script/jquery-3.2.1.min.js"></script>
	<script src="Script/layui/layui.js"></script>
	<script src="Script/Own/fileUploader.js"></script>
    <script src="Script/My97DatePicker/WdatePicker.js"></script>
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
        .ts {
			border: 0px;
			overflow: hidden;
			width: 100%;
			text-align: center;
            border-top-style:none;
            border-right-style:none;
            border-left-style:none;
		}
	    td {
			border: solid #000000;
			border-width: 1px 1px 1px 1px;
            height:10px;
			padding: 5px 0px;
            font-size:small;
		}
		table {
			border: solid #000000;
			border-width: 1px 1px 1px 1px;
			margin-left: auto;
		}
		
      
		 .auto-style1 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             text-align: center;
         }
		 .auto-style2 {
             height: 12px;
         }
		 .auto-style3 {
             height: 10px;
         }
		 </style>
     <script>
         function takeScreenshot(file, formID) {
            html2canvas(document.getElementById("table1"), {
                // 渲染完成时调用，获得 canvas
                onrendered: function (canvas) {
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
                        pdf.addImage(pageData, 'JPEG', 20, 20, imgWidth-50, imgHeight);
                    } else {
                        while (leftHeight > 0) {
                            pdf.addImage(pageData, 'JPEG', 20, position+20, imgWidth-50, imgHeight-100)
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
    </script>
    <script>
        function viewFile(filePath)
        {
            window.open(filePath);
        }
    </script>
    <script>
        function requestToPdfAshx(fileName,formID) {
            $.get(
                "ASHX/PDF.ashx",
                { "fileName": fileName,"formID":formID},
                function (res) {
                    window.location.href = document.URL;
                    alert(res);
                }
            );
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
        <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="Button1" runat="server" OnClick="Button1_Click" style="float: right; " />
        <table id="table1" style="margin: auto; border-collapse:collapse" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="14" style="text-align:center;border-right:0;font-size:small;">Contract Approval Form - Purchasing<br>合同批准格式——采购</td>
                    <td colspan="2" style="border-right:0;border-left:0;">Ref No.:<br>合同编号：</td>
                    <td colspan="4" style="border-left:0;"><asp:TextBox runat="server" ID="Textbox1" BorderStyle="None" ReadOnly="true"/></td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="border:none;font-size:small;" class="auto-style3">
                        <asp:Label Text="Type of Purchase:" runat="server" BorderStyle="None" Width="200px" /></td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center;">
                        <asp:CheckBox Text="" runat="server" onclick="choose(1)" ID="CheckBox1" disabled="disabled"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Direct</td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center"><asp:CheckBox Text="" runat="server" onclick="choose(2)" disabled="disabled" ID="CheckBox2"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Indirect</td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox3" disabled="disabled" onclick="choose(3)"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Capital</td>
                    <td colspan="3" rowspan="1" style="border-collapse:collapse;border-bottom:0;border-right:0;font-size:small;" class="auto-style3">
                        <asp:Label Text="Contract Subject:" runat="server" BorderStyle="None" Width="250px" /></td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;"><asp:TextBox runat="server" ReadOnly="true" ID="Textbox5" BorderStyle="None"/></td>
                    <td colspan="2" rowspan="1" style="border-bottom:0;border-right:0;" class="auto-style3">
                        <asp:Label Text="Vendor Name:" runat="server" Width="150px" /></td>
                    <td colspan="4" rowspan="2" style="border-left:0;border-bottom:0;"><asp:TextBox runat="server" ID="Textbox8" BorderStyle="None" ReadOnly="true"/></td>
                </tr>
                 <tr>
                    <td colspan="2" rowspan="1" style="border:none">采购类别：*</td>
                    <td colspan="1" rowspan="1" style="border:none">直接</td>
                    <td colspan="1" rowspan="1" style="border:none">间接</td>                   
                    <td colspan="1" rowspan="1" style="border:none">资产</td>
                    <td colspan="2" rowspan="1" style="border-bottom:0;border-right:0;border-top:0;">合同名称：*</td>
                    <td colspan="4" rowspan="1" style="border-left:0;border-top:0;"></td>
                    
                    <td colspan="2" rowspan="1" style="border-bottom:0;border-right:0;border-top:0;">供应商名称：*</td>
                   
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="border:none">
                        <asp:Label Text="Sourcing Specialist:" runat="server" BorderStyle="None" /></td>
                    <td colspan="6" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;color:#00ffff">
                        <asp:TextBox runat="server" CssClass="auto-style1" ID="Textbox2" ReadOnly="true" Height="28px" Width="558px"/>
                    </td>
                    <td colspan="3" style="border-collapse:collapse;border-top:0;border-bottom:0;border-right:0;">Contract Annual Amount:</td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;">
                        <asp:TextBox runat="server" CssClass="auto-style1" ID="Textbox6" Height="48px" Width="350px" ReadOnly="true"/>
                    </td>
                    <td colspan="2" rowspan="3" style="border-bottom:0;border-right:0;border-top:0;">Existing vendor: <br>现有供应商 * </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox4" disabled="disabled" onclick="choose(4)" /></td>
                    <td colspan="1" rowspan="1" style="border-bottom:0;border-left:0;border-right:0;text-align:center">yes</td>
                    <td colspan="1" rowspan="2" style="border-left:0;border-right:0;"><asp:TextBox runat="server" ReadOnly="true" ID="Textbox10" BorderStyle="None"/></td>
                    <td colspan="1" rowspan="1" style="border-left:0;text-align:center;">
                        <asp:Label Text="years' relationship" runat="server" BorderStyle="None" /></td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="border:none">采购人:</td>

                    <td colspan="3" style="border-collapse:collapse;border-top:0;border-bottom:0;border-right:0;">合同年度金额:*</td>
                    <td colspan="1" rowspan="1" style="border:none;text-align:center">是</td>
                    <td colspan="1" rowspan="1" style="border-left:0;text-align:center;">年的合作</td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="border:none">User Dept / CC#:</td>
                    <td colspan="6" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;color:#00ffff">
                        <asp:TextBox runat="server" CssClass="ts" ID="Textbox3" ReadOnly="true"/>
                    </td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-bottom:0;border-top:0;border-right:0;">Contract Period:<br>合同周期：</td>
                    <td colspan="1" rowspan="2" style="border-style:none;">
                        <asp:TextBox runat="server" ReadOnly="true" id="Textbox7" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="10px"/>
                    </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center;">
                        TO
                    </td>
                    <td colspan="1" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;">
                        <asp:TextBox runat="server" ReadOnly="true" id="Textbox86" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="10px"/>
                    </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center;">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox5" disabled="disabled" onclick="choose(5)"/></td>
                    <td colspan="1" rowspan="1" style="text-align:center;border-style:none;">no</td>
                </tr>
                <tr>
                    <td colspan="2"  style="border:none">使用部门/成本中心:</td>
                    <td colspan="2" rowspan="1" style="text-align:center;border-style:none;"></td>
                    <td colspan="1" rowspan="1" style="text-align:center;border-style:none;">否</td>
                </tr>
                <tr>
                    <td colspan="16">Description of Purchase 采购描述</td>
                    <td colspan="4" style="text-align:center">Approve by 批准人</td>
                </tr>
                <tr>
                    <td colspan="16"><asp:TextBox runat="server" ReadOnly="true" ID="Textbox4" BorderStyle="None" Width="890px"/></td>
                    <td colspan="2">
                        <asp:Image ID="Image8" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="2" style="text-align:center">User Dept Head<br>使用部门领导</td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align:left;">Key Commercial Terms<br>关键贸易条款</td>
                    <td colspan="1" style="text-align:center;">Page<br>页码</td>
                    <td colspan="1" style="text-align:center;">Clause<br>条款</td>
                    <td colspan="1" style="text-align:center;">If Commitment<br>是否承诺性"√"</td>
                    <td colspan="8" style="text-align:center;">For Commitment,Please state clearly the "Penalty details in breach of contract"*对于承诺性合同,请清楚写明"违反合同的惩罚条款"</td>
                    <td colspan="4" style="text-align:center">Approve by 批准人</td>
                </tr>
                <tr>
                    <td colspan="5" class="auto-style2">Payment Terms<br>付款条件*</td>
                    <td class="auto-style2"><asp:TextBox runat="server" ID="Textbox11" BorderStyle="None"/></td>
                    <td class="auto-style2"><asp:TextBox runat="server" ID="Textbox9" BorderStyle="None"/></td>
                    <td style="text-align:center" class="auto-style2"><asp:CheckBox Text="" runat="server" ID="CheckBox6" disabled="disabled" onclick="choose(6)"/></td>
                    <td colspan="8" class="auto-style2"><asp:TextBox runat="server" ID="Textbox13" BorderStyle="None" ReadOnly="true" ></asp:TextBox></td>
                    <td colspan="2" class="auto-style2">
                        <asp:Image ID="Image7" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="2" style="text-align:center" class="auto-style2">FIN Leader<br>财务领导</td>
                </tr>
                <tr>
                    <td colspan="5">Price & price adjustment<br>价格&调价*</td>
                    <td><asp:TextBox runat="server" ID="Textbox16" BorderStyle="None"/></td>
                    <td><asp:TextBox runat="server" ID="Textbox17" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox7" disabled="disabled"  onclick="choose(7)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox19" BorderStyle="None" ReadOnly="true" /></td>
                    <td colspan="2" rowspan="11">
                        <asp:Image ID="Image6" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="2" rowspan="11">User Dept Head使用部门领导</td>
                </tr>
                <tr>
                    <td colspan="5">Volume or total amount<br>数量或总额*</td>
                    <td><asp:TextBox runat="server" ID="Textbox20" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox21" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox8" disabled="disabled" onclick="choose(8)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox23" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Period &amp; renewal<br>周期&amp;续约*</td>
                    <td><asp:TextBox runat="server" ID="Textbox24" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox25" BorderStyle="None" ReadOnly="true" /></td>
                   <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox9" disabled="disabled" onclick="choose(9)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox27" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Rebate &amp; commission<br>折扣&amp;佣金*</td>
                    <td><asp:TextBox runat="server" ID="Textbox28" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox29" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox10" disabled="disabled" onclick="choose(10)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox31" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Scope of Work / Service Level Agreement<br>工作范围/服务水平协议</td>
                    <td><asp:TextBox runat="server" ID="Textbox32" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox33" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox11" disabled="disabled" onclick="choose(11)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox35" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Acceptence Criteria<br>接受条件*</td>
                    <td><asp:TextBox runat="server" ID="Textbox36" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox37" BorderStyle="None" ReadOnly="true" /></td>
                   <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox12" disabled="disabled" onclick="choose(12)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox39" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Warranty<br>担保</td>
                    <td><asp:TextBox runat="server" ID="Textbox40" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox41" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox13" disabled="disabled" onclick="choose(13)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox43" BorderStyle="None" ReadOnly="true" /></td>
                </tr>

                <tr>
                    <td colspan="5">Termination<br>终止</td>
                    <td><asp:TextBox runat="server" ID="Textbox44" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox45" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox14" disabled="disabled" onclick="choose(14)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox47" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Exclusivity<br>独占权</td>
                    <td><asp:TextBox runat="server" ID="Textbox48" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox49" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox15" disabled="disabled" onclick="choose(15)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox51" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Other key terms, please specify<br>其他关键条款，请说明</td>
                    <td><asp:TextBox runat="server" ID="Textbox52" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox53" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox16" disabled="disabled" onclick="choose(16)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox55" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Penalty detail in breach of contract<br>违反合同的罚款细节</td>
                    <td><asp:TextBox runat="server" ID="Textbox56" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox57" BorderStyle="None" ReadOnly="true" /></td>
                    <td colspan="9"><asp:TextBox runat="server" ID="Textbox59" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:center;border-bottom:0;border-right:0;">Does this contract use a pre-approved contract template with no changes?</td>
                    <td colspan="2" rowspan="2" style="border-style:none;text-align:center;"><asp:CheckBox Text="" ID="CheckBox18" runat="server" disabled="disabled"  onclick="choose(18)"/></td>
                    <td colspan="2" style="border-style:none;text-align:left;">yes</td>
                    <td colspan="2" rowspan="2" style="border-style:none;text-align:center;"><asp:CheckBox Text="" ID="CheckBox19" runat="server" disabled="disabled"  onclick="choose(19)"/></td>
                    <td colspan="2" style="border-style:none;text-align:left;">no</td>
                    <td colspan="4" style="text-align:center;border-style:none">(If no, please fill in the below section)</td>
                </tr>
                 <tr>
                    <td colspan="8" style="text-align:center;border-top:0;border-right:0;">此合同是否使用预先批准的合同格式且没有变动？</td>
                    <td colspan="2" style="border-style:none;text-align:left;">是</td>
                    <td colspan="2" style="border-style:none;text-align:left;">否</td>
                    <td colspan="4" style="text-align:center;border-style:none">若为否，请填写以下部分</td>
                </tr>
                 <tr>
                    <td colspan="5">General Legal Provisions<br>常规法律条款</td>
                    <td colspan="1" style="text-align:center;">Page<br>页码</td>
                    <td colspan="1" style="text-align:center;">Clause<br>条款</td>
                    <td colspan="1" style="text-align:center;">If Commitment<br>是否承诺性"√"</td>
                    <td colspan="8" style="text-align:center;">For non-standard clause, put input detail of variation对于非标准条款，输入变更的细节</td>
                    <td colspan="4" style="text-align:center;">Approve by 批准(per Contract Legal Review Policy)批准人（参考合同法律审核政策）</td>
                </tr>
                <tr>
                    <td colspan="5">Notic注意</td>
                    <td><asp:TextBox runat="server" ID="Textbox12" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox18" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox20" disabled="disabled" onclick="choose(20)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox22" BorderStyle="None" ReadOnly="true" /></td>
                    <td colspan="2" rowspan="9">
                        <asp:Image ID="Image5" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="2" rowspan="9" style="text-align:center">Legal Head Head<br>法律领导</td>
                </tr>
                <tr>
                    <td colspan="5">Confidentiality<br>保密性</td>
                    <td><asp:TextBox runat="server" ID="Textbox30" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox34" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox21" disabled="disabled" onclick="choose(21)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox38" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Announcement<br>声明</td>
                    <td><asp:TextBox runat="server" ID="Textbox46" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox50" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox22" disabled="disabled" onclick="choose(22)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox54" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Waivers<br>弃权</td>
                    <td><asp:TextBox runat="server" ID="Textbox60" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox61" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox23" disabled="disabled" onclick="choose(23)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox62" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Severalbility<br>服务性</td>
                    <td><asp:TextBox runat="server" ID="Textbox64" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox65" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox24" disabled="disabled" onclick="choose(24)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox66" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Force Majeure<br>不可抗力</td>
                    <td><asp:TextBox runat="server" ID="Textbox68" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox69" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox25" disabled="disabled" onclick="choose(25)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox70" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Assignment & Delegation<br>分配&授权</td>
                    <td><asp:TextBox runat="server" ID="Textbox72" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox73" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox26" disabled="disabled" onclick="choose(26)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox74" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Dispute Resolution<br>纠纷解决</td>
                    <td><asp:TextBox runat="server" ID="Textbox76" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox77" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox27" disabled="disabled" onclick="choose(27)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox78" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="5">Other legal provisions, please specify<br>其他法律条款，请说明</td>
                    <td><asp:TextBox runat="server" ID="Textbox80" BorderStyle="None" ReadOnly="true" /></td>
                    <td><asp:TextBox runat="server" ID="Textbox81" BorderStyle="None" ReadOnly="true" /></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox28" disabled="disabled" onclick="choose(28)"/></td>
                    <td colspan="8"><asp:TextBox runat="server" ID="Textbox82" BorderStyle="None" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align:center;background-color:#808080;">以下用于工程项目合同，需要时提供</td>
                    <td colspan="3" style="text-align:center;background-color:#808080">Sourcing Specialist<br>采购人</td>
                    <td colspan="3" style="text-align:center;background-color:#808080">User Dept Head (per cost center)<br>工厂使用部门经理（按成本中心）</td>
                    <td colspan="3" style="text-align:center;background-color:#808080">SC Leader Approval(According to Contract Approval Policy)<br>工厂采购经理批准（参照合同批准政策）</td>
                    <td colspan="3" style="text-align:center;background-color:#808080">Finance Leader Approval(According to Contract Approval Policy)<br>工厂财务经理批准（参照合同批准政策）</td>
                    <td colspan="3" style="text-align:center;background-color:#808080">General Manager Approval(According to Contract Approval Policy)<br>总经理批准（参照合同批准政策）</td>
                    <td colspan="2" rowspan="8" style="text-align:center">Sinature<br>签字</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">承包商环境、健康安全手册</td>
                    <td colspan="1" style="text-align:center;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox29" disabled="disabled" onclick="choose(29)"/></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                </tr>
               <tr>
                    <td colspan="2" style="text-align:center;border-style:none">安全施工协议</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox30" disabled="disabled" onclick="choose(30)"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" ID="Textbox42" BorderStyle="None" ReadOnly="true" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="imageurl" />
                    </td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ID="Image4" runat="server" ImageUrl="imageurl" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">危险源辨别、评价控制</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox31" disabled="disabled" onclick="choose(31)"/></td>
                    <td colspan="3" style="text-align:left;border-left:0;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">环境因素清单</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox32" disabled="disabled" onclick="choose(32)"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" ReadOnly="true" id="Textbox75" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" ReadOnly="true" id="Textbox79" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>                                     
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server"  ReadOnly="true" id="Textbox83" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>                                     
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server"  ReadOnly="true" id="Textbox84" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>                                     
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server"  ReadOnly="true" id="Textbox85" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">已签署ACT</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox33" disabled="disabled" onclick="choose(33)"/></td>
                    <td colspan="3" style="text-align:left;border-style:none">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">人机工程确认</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox34" disabled="disabled" onclick="choose(34)"/></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">EHS认可(需要时)</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox35" disabled="disabled" onclick="choose(35)"/></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                </tr>
            </table>
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
           
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" />
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
    </form>
    <script type="text/javascript">
        function choose(i)
        {
            if (document.getElementById("CheckBox" + i).checked == true) {
                document.getElementById("CheckBox" + i).checked = false;
            }
            else
            {
                document.getElementById("CheckBox" + i).checked = true;
            }
        }
    </script>
</body>
</html>
