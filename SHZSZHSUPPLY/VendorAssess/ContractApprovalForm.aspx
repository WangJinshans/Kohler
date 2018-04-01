<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ContractApprovalForm.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ContractApprovalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>  
	<script src="Script/layui/layui.js"></script>  
    <script src="Script/Own/fileUploader.js?v=9"></script>
    <script src="Script/My97DatePicker/WdatePicker.js"></script>

    <script type="text/javascript" >
       function initMoney(){
           var money = document.getElementById("Textbox6").value;
           var str = "￥" + money.split('').reverse().join('').replace(/(\d{3}(?=\d)(?!\d+\.|$))/g, '$1,').split('').reverse().join('');
           document.getElementById("Textbox6").value = str;
       }
       function choose(i) {
           if (i == 1) {
               document.getElementById("CheckBox2").checked = false;
               document.getElementById("CheckBox3").checked = false;
               document.getElementById("CheckBox1").checked = true;
           }
           else if (i == 2) {
               document.getElementById("CheckBox1").checked = false;
               document.getElementById("CheckBox3").checked = false;
               document.getElementById("CheckBox2").checked = true;
           }
           else if (i == 3) {
               document.getElementById("CheckBox1").checked = false;
               document.getElementById("CheckBox2").checked = false;
               document.getElementById("CheckBox3").checked = true;
           }
       }
       function changes(i) {
           if (i == 1) {
               document.getElementById("CheckBox18").checked = true;
               document.getElementById("CheckBox19").checked = false;
           }
           else if (i == 2) {
               document.getElementById("CheckBox19").checked = true;
               document.getElementById("CheckBox18").checked = false;
           } 
       }
    </script>
    <script>
        function viewFile(filePath)
        {
            window.open(filePath);
        }
    </script>
    <script>
        function popUp(formid, result, kci) {
            layui.use(['layer'], function () {
                layer.open({
                    title: '请选择审批部门',
                    content: 'SelectDepartment.aspx?formid=' + formid + "&kci=" + kci,
                    type: 2,
                    area: ['750px', '400px'],
                    shade: 0.3,
                    shadeClose: false, //点击遮罩关闭
                    btn: ['确定'],
                    yes: function (index, layero) {
                        if (result == "yes") {
                            __myDoPostBack('submitForm', '');//回掉标准合同函数
                            layer.closeAll();
                        }
                        else {
                            __myDoPostBack('nonSubmitForm', '');//回掉非标准合同函数
                            layer.closeAll();
                        }
                    },
                    cancel: function (index, layero) {
                        if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                            layer.closeAll();
                        }
                        return false;
                    },
                    success: function (layero, index) {
                        console.log(layero, index);
                    }
                });
            });
        }
    </script>
    <script>
        function existvendor(i)
        {
            if (i == 1) {
                document.getElementById("CheckBox4").checked = true;
                document.getElementById("CheckBox5").checked = false;
            }
            else if (i == 2) {
                document.getElementById("CheckBox5").checked = true;
                document.getElementById("CheckBox4").checked = false;
            }
        }
        //非承诺性 是否标准合同询问框
        function messageBox(content, formid,iskci) {
            layui.use(['layer'], function () {
                layer.open({
                    title: '提示信息',
                    content: '' + content,
                    btn: ['是', '否'],
                    btn1: function (index, layero) {
                        layer.close('index');
                        iskci(formid, "yes", iskci);//标准合同
                    },
                    btn2: function (index, layero) {
                        layer.close('index');
                        iskci(formid, "no", iskci);//非标准合同
                    }
                })
            });
        }

        //自动判断是否KCI的提示框
        function iskci(formid, iskci,content) {
            layui.use(['layer'], function () {
                layer.open({
                    title: ''
                    , content: content
                    , btn: ['确认']
                    , btn1: function (index, layero) {
                        layer.close('index');
                        if (iskci) {
                            popUp(formid, "yes", "1");
                        } else {
                            popUp(formid, "yes", "0");
                        }
                       
                    },
                    
                })
            });
        }
    </script>


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
		}
		
      
		 .auto-style1 {
             border-style: none;
             border-color: inherit;
             border-width: 0px;
             overflow: hidden;
             text-align: center;
             width:100%;
         }
		 .auto-style2 {
             height: 100%;
         }
		 .auto-style3 {
             height: 10px;
         }
		 </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
		<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />--%>
        <div style="text-align:right;font-size:small;">PR-05-17-3</div>
            <table style="margin:0 auto;width:100%; border-collapse:collapse" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="14" style="text-align:center;border-right:0;font-size:small;">Contract Approval Form - Purchasing<br>合同批准格式——采购</td>
                    <td colspan="2" style="border-right:0;border-left:0;">Ref No.:<br>合同编号：</td>
                    <td colspan="4" style="border-left:0;"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox1" CssClass="auto-style1" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="2" rowspan="1" style="border:none;font-size:small;" class="auto-style3">
                        <asp:Label Text="Type of Purchase:" runat="server" BorderStyle="None" /></td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center;">
                        <asp:CheckBox Text="" runat="server" disabled="disabled" ID="CheckBox1" onclick="choose(1)"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Direct</td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center"><asp:CheckBox Text="" runat="server" onclick="choose(2)" ID="CheckBox2"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Indirect</td>
                    <td colspan="1" rowspan="2" style="border:none;text-align:center">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox3" onclick="choose(3)"/></td>
                    <td colspan="1" rowspan="1" style="border:none;font-size:small;" class="auto-style3">Capital</td>
                    <td colspan="3" rowspan="1" style="border-collapse:collapse;border-bottom:0;border-right:0;font-size:small;" class="auto-style3">
                        <asp:Label Text="Contract Subject:" runat="server" BorderStyle="None"  /></td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;"><asp:TextBox TextMode="MultiLine"  CssClass="auto-style1" runat="server" ID="Textbox5" BorderStyle="None"/></td>
                    <td colspan="2" rowspan="1" style="border-bottom:0;border-right:0;" class="auto-style3">
                        <asp:Label Text="Vendor Name:" runat="server"  /></td>
                    <td colspan="4" rowspan="2" style="border-left:0;border-bottom:0;"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox8" CssClass="auto-style1" BorderStyle="None"/></td>
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
                        <asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox2"/>
                    </td>
                    <td colspan="3" style="border-collapse:collapse;border-top:0;border-bottom:0;border-right:0;">Contract Annual Amount:</td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;">
                        <asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox6" Height="48px" />
                    </td>
                    <td colspan="2" rowspan="3" style="border-bottom:0;border-right:0;border-top:0;">Existing vendor: <br>现有供应商 * </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox4" onclick="existvendor(1)"/></td>
                    <td colspan="1" rowspan="1" style="border-bottom:0;border-left:0;border-right:0;text-align:center">yes</td>
                    <td colspan="1" rowspan="2" style="border-left:0;border-right:0;"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox10" BorderStyle="None"/></td>
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
                        <asp:TextBox TextMode="MultiLine"  runat="server" CssClass="ts" ID="Textbox3"/>
                    </td>
                    <td colspan="3" rowspan="2" style="border-collapse:collapse;border-bottom:0;border-top:0;border-right:0;">Contract Period:<br>合同周期：</td>
                    <td colspan="1" rowspan="2" style="border-style:none;">
                        <asp:TextBox runat="server" id="Textbox7" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="10px"/>
                    </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center;">
                        TO
                    </td>
                    <td colspan="1" rowspan="2" style="border-collapse:collapse;border-top:0;border-left:0;">
                        <asp:TextBox runat="server" id="Textbox86" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="10px"/>
                    </td>
                    <td colspan="1" rowspan="2" style="border-style:none;text-align:center;">
                        <asp:CheckBox Text="" runat="server" ID="CheckBox5" onclick="existvendor(2)"/></td>
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
                    <td colspan="16"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style2" ID="Textbox4" BorderStyle="None" style="width:100%"/></td>
                    <td colspan="2">
                        <asp:Image ImageUrl="imageurl" ID="Image8" runat="server" /></td>
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
                    <td class="auto-style2"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox11" BorderStyle="None"/></td>
                    <td class="auto-style2"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox9" BorderStyle="None"/></td>
                    <td style="text-align:center" class="auto-style2"><asp:CheckBox Text="" runat="server" ID="CheckBox6"/></td>
                    <td colspan="8" class="auto-style2"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox13" BorderStyle="None"></asp:TextBox></td>
                    <td colspan="2" class="auto-style2">
                        <asp:Image ImageUrl="imageurl" ID="Image7" runat="server" /></td>
                    <td colspan="2" style="text-align:center" class="auto-style2">FIN Leader<br>财务领导</td>
                </tr>
                <tr>
                    <td colspan="5">Price & price adjustment<br>价格&调价*</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox16" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox17" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox7"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox19" CssClass="auto-style1" BorderStyle="None"/></td>
                    <td colspan="2" rowspan="11">
                        <asp:Image ImageUrl="imageurl" ID="Image6" runat="server" /></td>
                    <td colspan="2" rowspan="11">User Dept Head使用部门领导</td>
                </tr>
                <tr>
                    <td colspan="5">Volume or total amount<br>数量或总额*</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox20" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox21" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox8"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox23" CssClass="auto-style1" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Period &amp; renewal<br>周期&amp;续约*</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox24" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox25" BorderStyle="None"/></td>
                   <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox9"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox27" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Rebate &amp; commission<br>折扣&amp;佣金*</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox28" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox29" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox10"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox31" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Scope of Work / Service Level Agreement<br>工作范围/服务水平协议</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox32" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox33" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox11"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox35" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Acceptence Criteria<br>接受条件*</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox36" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox37" BorderStyle="None"/></td>
                   <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox12"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox39" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Warranty<br>担保</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox40" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox41" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox13"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox43" BorderStyle="None"/></td>
                </tr>

                <tr>
                    <td colspan="5">Termination<br>终止</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox44" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox45" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox14"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox47" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Exclusivity<br>独占权</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox48" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox49" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox15"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox51" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Other key terms, please specify<br>其他关键条款，请说明</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox52" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox53" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox16"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox55" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Penalty detail in breach of contract<br>违反合同的罚款细节</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox56" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox57" BorderStyle="None"/></td>
                    <td colspan="9"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox59" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:center;border-bottom:0;border-right:0;">Does this contract use a pre-approved contract template with no changes?</td>
                    <td colspan="2" rowspan="2" style="border-style:none;text-align:center;"><asp:CheckBox Text="" ID="CheckBox18" runat="server" onclick="changes(1)" /></td>
                    <td colspan="2" style="border-style:none;text-align:left;">yes</td>
                    <td colspan="2" rowspan="2" style="border-style:none;text-align:center;"><asp:CheckBox Text="" ID="CheckBox19" runat="server" onclick="changes(2)" /></td>
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
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox12" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox18" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox20"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox22" BorderStyle="None"/></td>
                    <td colspan="2" rowspan="9">
                        <asp:Image ImageUrl="imageurl" ID="Image5" runat="server" /></td>
                    <td colspan="2" rowspan="9" style="text-align:center">Legal Head Head<br>法律领导</td>
                </tr>
                <tr>
                    <td colspan="5">Confidentiality<br>保密性</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox30" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox34" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox21"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox38" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Announcement<br>声明</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox46" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox50" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox22"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox54" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Waivers<br>弃权</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox60" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox61" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox23"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox62" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Severalbility<br>服务性</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox64" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox65" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox24"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox66" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Force Majeure<br>不可抗力</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox68" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox69" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox25"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox70" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Assignment & Delegation<br>分配&授权</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox72" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox73" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox26"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox74" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Dispute Resolution<br>纠纷解决</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox76" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox77" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox27"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox78" BorderStyle="None"/></td>
                </tr>
                <tr>
                    <td colspan="5">Other legal provisions, please specify<br>其他法律条款，请说明</td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox80" BorderStyle="None"/></td>
                    <td><asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox81" BorderStyle="None"/></td>
                    <td style="text-align:center"><asp:CheckBox Text="" runat="server" ID="CheckBox28"/></td>
                    <td colspan="8"><asp:TextBox TextMode="MultiLine"  runat="server" CssClass="auto-style1" ID="Textbox82" BorderStyle="None"/></td>
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
                    <td colspan="1" style="text-align:center;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox29"/></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                    <td colspan="3" style="border-bottom:0;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">安全施工协议</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox30"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:TextBox TextMode="MultiLine"  runat="server" ID="Textbox14" BorderStyle="None"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Signature:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;">
                        <asp:Image ImageUrl="imageurl" ID="Image4" runat="server" /></td>

                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">危险源辨别、评价控制</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox31"/></td>
                    <td colspan="3" style="text-align:left;border-left:0;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">签名：</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">环境因素清单</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox32"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" id="Textbox75" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" id="Textbox79" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>               
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" id="Textbox83" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>               
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" id="Textbox84" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                    <td colspan="1" style="text-align:left;border-style:none;">Date:</td>               
                    <td colspan="2" style="text-align:center;border-left:0;border-top:0;"><asp:TextBox runat="server" id="Textbox85" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">已签署ACT</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox33"/></td>
                    <td colspan="3" style="text-align:left;border-style:none">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                    <td colspan="3" style="text-align:left;border-top:0;border-bottom:0;">日期：</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">人机工程确认</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox34"/></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;border-style:none">EHS认可(需要时)</td>
                    <td colspan="1" style="text-align:center;border-top:0;border-left:0;border-bottom:0;"><asp:CheckBox Text="" runat="server" ID="CheckBox35"/></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                    <td colspan="3" style="border-bottom:0;border-top:0;"></td>
                </tr>
            </table>
        <%-- <div style="text-align:center;margin-bottom:50px">
            <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
        </div>--%>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div style="text-align: center; margin-bottom: 50px">
                    <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
		        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="Button4" runat="server" Text="合同上传" CssClass="layui-btn layui-btn-danger" OnClick="Button4_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="Button5" runat="server" Text="查看合同" CssClass="layui-btn" OnClick="Button5_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:GridView style="display:none" ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView1_RowCommand" GridLines="None" ForeColor="#333333">
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
    </form>
    
</body>
</html>