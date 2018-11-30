<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SCAR.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.SCAR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
        <style type="text/css">
        * {
            padding: 0px;
            margin: 0px;
        }
        
        table {
            margin-bottom: 100px;
            margin-top: 50px;
            width: 70%;
            border: solid #000000;
            border-width: 2px 2px 2px 2px;
            margin-left: auto;
            margin-right: auto;
        }

            table tr {
                border-width: 1px;
                height: 36px;
            }

                table tr td {
                    border: solid #000000;
                    border-width: 1px;
                    font-size: 15px;
                    font-family: Serif;
                }

        .tr1 {
            width: 100px;
            height: 72px;
        }

        .tr2 {
            height: 36px;
        }

        .td2 {
            width: 200px;
        }

    </style>

    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="../VendorAssess/Script/SCAR_toExcel.js" type="text/javascript"></script>
	<script>
	    $(document).ready(function () {
	        $('input[type="checkbox"]').each(function () {
	            $(this).css("padding", "0px");
	            $(this).css("margin", "0px");
	        })
	    });

        function displayNo(label,n) {	
			document.getElementById(label).innerHTML = n;
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hid" runat="server" />
            <div>
                <table id="tb">
                    <tr>
                        <th colspan="12" style="font-size: 30px; font-family: Serif">8D报告</th>
                    </tr>
                    <tr>
                        <td colspan="12" style="font-size: 15px; text-align: center">（CA report in 8D format) </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center" class="tr1">主题<br />
                            (Subject)</td>
                        <td colspan="5" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox1" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">投诉类型<br />
                            (Rea For CA)</td>
                        <td colspan="5" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center" class="tr1">发生地点<br />
                            (Occurred Site)</td>
                        <td colspan="2" style="text-align: center" class="td2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox3" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">发生时间<br />
                            (Occurred Time)</td>
                        <td colspan="2" style="text-align: center" class="td2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox4" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">总批量数<br />
                            (Occurred Qty)</td>
                        <td colspan="2" style="text-align: center" class="td2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox5" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">提出日<br />
                            (Date Raised)</td>
                        <td colspan="2" style="text-align: center" class="td2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox6" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center" class="tr1">客户<br />
                            (Customer)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox7" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">产品编号<br />
                            (Part Number)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox8" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">检验数<br />
                            (Qtv Ins)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox9" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">提出人员<br />
                            (Raised by)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox86" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center" class="tr1">供应商厂商<br />
                            (Supplier)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox10" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">产品名称<br />
                            (PartName)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox11" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">不良数<br />
                            (Qtv Rei)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox12" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr1">要求完成日期<br />
                            (Due Date)</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox13" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">1、小组成员(Discipline  1.Team Members)</td>
                    </tr>
                    <tr>
                        <td colspan="1" class="tr2">部门(Dept)：</td>
                        <td colspan="2" style="text-align: center">QA</td>
                        <td colspan="1" style="text-align: center" class="tr2">IQC</td>
                        <td colspan="2" style="text-align: center">生产</td>
                        <td colspan="1" style="text-align: center" class="tr2">工程</td>
                        <td colspan="2" style="text-align: center">开发</td>
                        <td colspan="1" style="text-align: center" class="tr2">采购</td>
                        <td colspan="2" style="text-align: center">业务</td>
                    </tr>
                    <tr>
                        <td colspan="1" class="tr2">姓名(Name)：</td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox14" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox87" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox15" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox68" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox16" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox69" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox17" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">2、问题描述(Discipline  2. Problem Description)</td>
                    </tr>
                    <tr>
                        <td colspan="12" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox18" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4">起草Prepared By：<asp:TextBox ID="TextBox19" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="4">审核Approved By：<asp:TextBox ID="TextBox20" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="4">完成日期Completed Date：<asp:TextBox ID="TextBox21" runat="server" BorderWidth="0px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">3、即日纠正措施(Discipline  3. Immediate Containment Actions)</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">NO.</td>
                        <td colspan="8" style="text-align: center">暂时补救的纠正措施(Immediate Containment Actions)</td>
                        <td colspan="1" style="text-align: center">负责人</td>
                        <td colspan="2" style="text-align: center">日期</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox22" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox23" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox24" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text="2" Style="display: none"></asp:Label>
                        </td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox25" runat="server" BorderWidth="0px" Width="100%" onclick="javascript:displayNo('<%=this.Label2.ClientID%>',2);"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox26" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox27" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label3" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox28" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox29" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox30" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label4" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox31" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox32" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox33" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">审核 Approved By：<asp:TextBox ID="TextBox34" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="6">审核日期 Approved Date：<asp:TextBox ID="TextBox35" runat="server" BorderWidth="0px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">4、明确和核实根本原因(Discipline  4.Define and Verify Root Causes)</td>
                    </tr>
                    <tr>
                        <td colspan="12" style="height: 114px">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox36" runat="server" BorderWidth="0px" Height="100%" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4">起草Prepared By：<asp:TextBox ID="TextBox37" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="4">审核Approved By：<asp:TextBox ID="TextBox38" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="4">完成日期Completed Date：<asp:TextBox ID="TextBox39" runat="server" BorderWidth="0px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">5、永久性纠正措施(Discipline  5. Permanent Corrective Actions)</td>
                    </tr>

                    <tr>
                        <td colspan="1" style="text-align: center">NO.</td>
                        <td colspan="8" style="text-align: center">纠正措施(permanent Corrective Actions)</td>
                        <td colspan="1" style="text-align: center">确认人</td>
                        <td colspan="2" style="text-align: center">日期</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label5" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox40" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox41" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox42" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label6" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox43" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox44" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox45" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label7" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox46" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox47" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox48" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label8" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox49" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox50" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox51" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">审核 Approved By：<asp:TextBox ID="TextBox52" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="6">审核日期 Approved Date：<asp:TextBox ID="TextBox53" runat="server" BorderWidth="0px"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">6、纠正措施效果验证(Discipline  6.Verification of Effectiveness)</td>
                    </tr>

                    <tr>
                        <td colspan="1" style="text-align: center">NO.</td>
                        <td colspan="8" style="text-align: center">效果验证(Verification of  Effectiveness)</td>
                        <td colspan="1" style="text-align: center">确认人</td>
                        <td colspan="2" style="text-align: center">日期</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label9" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox70" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox71" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox72" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label10" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox73" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox74" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox75" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label11" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox76" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox77" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox78" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label12" runat="server"></asp:Label></td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox79" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox80" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox81" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">审核 Approved By：<asp:TextBox ID="TextBox54" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="6">审核日期 Approved Date：<asp:TextBox TextMode="MultiLine" ID="TextBox55" runat="server" BorderWidth="0px"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">7、预防再现措施(Discipline  7.Prevent Recurrence)</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">NO.</td>
                        <td colspan="8" style="text-align: center">预防再现措施(Prevent Recurrence)</td>
                        <td colspan="1" style="text-align: center">负责人</td>
                        <td colspan="2" style="text-align: center">日期</td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label13" runat="server"></asp:Label>
                        </td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox56" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox57" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox58" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center" class="tr2">
                            <asp:Label ID="Label14" runat="server"></asp:Label>
                        </td>
                        <td colspan="8" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox59" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox60" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center" class="tr2">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox61" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label15" runat="server"></asp:Label>
                        </td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox62" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox63" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox64" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="text-align: center">
                            <asp:Label ID="Label16" runat="server"></asp:Label>
                        </td>
                        <td colspan="8" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox65" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="1" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox66" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                        <td colspan="2" style="text-align: center">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox67" runat="server" BorderWidth="0px" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="6">审核 Approved By：<asp:TextBox ID="TextBox82" runat="server" BorderWidth="0px"></asp:TextBox></td>
                        <td colspan="6">审核日期 Approved Date：<asp:TextBox ID="TextBox83" runat="server" BorderWidth="0px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td colspan="12" style="background-color: rgb(153,204,255)">8、客户确认及评价(Discipline 8.Customer satisfaction degree)</td>
                    </tr>
                    <tr>
                        <td colspan="12" style="border-bottom-width: 2px; padding: 0px" class="auto-style1">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox84" runat="server" BorderWidth="0px" Height="100%" Width="100%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th colspan="12" style="border:2px black solid ; border-width: 2px">不良根本原因类型（勾选项，可多选）</th>
                    </tr>
                    <tr>
                        <th colspan="2" style="border: 1px solid">人</th>
                        <th colspan="2" style="border: 1px solid">机</th>
                        <th colspan="2" style="border: 1px solid">料</th>
                        <th colspan="2" style="border: 1px solid">法</th>
                        <th colspan="2" style="border: 1px solid">环</th>
                        <th colspan="2" style="border: 1px solid">测</th>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="新员工" ID="CheckBox6" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="设备能力不足" ID="CheckBox5" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="原材料不良" ID="CheckBox4" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="设计问题" ID="CheckBox3" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="生产环境不良" ID="CheckBox2" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="缺测量设备" ID="CheckBox1" runat="server" TextAlign="Left" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="临时工" ID="CheckBox7" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="设备故障" ID="CheckBox8" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="物料保存不良" ID="CheckBox9" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="工艺问题" ID="CheckBox10" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="仓储环境不良" ID="CheckBox12" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="量具能力不足" ID="CheckBox11" runat="server" TextAlign="Left" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="顶岗" ID="CheckBox13" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="设备PM不足" ID="CheckBox14" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="混料" ID="CheckBox15" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="仓储问题" ID="CheckBox16" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="新车间" ID="CheckBox17" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="测量方法问题" ID="CheckBox18" runat="server" TextAlign="Left" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox19" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="模具问题" ID="CheckBox20" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="缺料" ID="CheckBox21" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="运输问题" ID="CheckBox22" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox23" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox24" runat="server" TextAlign="Left" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center"></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="新设备" ID="CheckBox26" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox27" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="变更管理问题" ID="CheckBox28" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center"></td>
                        <td colspan="2" style="text-align: center"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center"></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox25" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center"></td>
                        <td colspan="2" style="text-align: center">
                            <asp:CheckBox Text="其它" ID="CheckBox30" runat="server" TextAlign="Left" /></td>
                        <td colspan="2" style="text-align: center"></td>
                        <td colspan="2" style="text-align: center"></td>
                    </tr>
                    <tr>
                        <td colspan="1">备注(Memo)</td>
                        <td colspan="11" style="height: 72px">
                            <asp:TextBox TextMode="MultiLine" ID="TextBox85" runat="server" BorderWidth="0px" Height="100%" Width="100%"></asp:TextBox></td>
                    </tr>
                </table>
            </div>

            <div style="text-align: center;">
                <asp:Button ID="Button1" runat="server" Text="导出Excel" CssClass="layui-btn layui-btn-danger" OnClientClick="tableToExcel('tb','data')"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Back" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Back_Click" />
            </div>
        </div>
    </form>
</body>

</html>
