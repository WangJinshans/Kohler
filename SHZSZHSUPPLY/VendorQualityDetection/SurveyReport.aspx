﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="SurveyReport.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.SurveyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=2"></script>
    <style type="text/css">
        * {
            padding: 0px;
            margin: 0px;
        }

        textarea {
            resize: none;
            border: none;
        }

        table {
            width: 1000px;
            margin: 100px auto 20px;
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
                    padding: 0px;
                    border-style: solid;
                    border-color: #666666;
                    background-color: #507CD1;
                }

                table.gridtable td {
                    border-width: 1px;
                    padding: 10px;
                    border-style: solid;
                    border-color: #666666;
                    background-color: #ffffff;
                }

            table tr td {
                border: solid #000000;
                border-width: 1px 1px 1px 1px;
                padding: 6px 0px;
                text-align: center;
            }

        table {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
    <script>
        //合格
        function InspectionResultQualified() {
            var mytd = document.getElementById("unqualified_list_td");
            var mytd1 = document.getElementById("unqualified_type");
            var qu = document.getElementById("qualified");
            mytd.style.display = "none";
            mytd1.style.display = "none";
            qu.colSpan = '7';
        }
        //不合格
        function InspectionResultUnQualified() {
            var mytd = document.getElementById("unqualified_list_td");
            var mytd1 = document.getElementById("unqualified_type");
            var qu = document.getElementById("qualified");
            mytd.style.display = "table-cell";
            mytd1.style.display = "table-cell";
            qu.colSpan = '6';
        }
        function judge() {
            var qualitify = document.getElementById('qualified_list');
            if (qualitify.selectedIndex == 0) {
                InspectionResultQualified();
            } else {
                InspectionResultUnQualified();
            }
        }

        function MRBtip(msg) {
            layui.use('layer', function () {
                layer = layui.layer;
                layer.msg(msg);
            });
        }
        //申请MRB 完成
        function MRBfinish(msg, position_Name) {
            layui.use('layer', function () {
                    layer = layui.layer;
                layer.msg(msg, {
                    time: 3000
                }, function () {
                    //页面回退
                    if (position_Name == '检验员') {
                        location.href = 'InspectionList.aspx';
                    } else {
                        location.href = 'QualityClerkOperateList.aspx';
                    }
                });
            });
        }
        function addStock(msg, position_Name) {
            layui.use('layer', function () {
                    layer = layui.layer;
                layer.msg(msg, {
                    time: 3000
                }, function () {
                    //页面回退
                    if (position_Name == '检验员') {
                        location.href = 'InspectionList.aspx';
                    } else {
                        location.href = 'QualityClerkOperateList.aspx';
                    }
                });
            });
        }

        //显示MBR 以及MBR的结果  让步接收不显示接收数量以及拒收数量框  后台程序已经有过处理
        function showMRB(result) {
            document.getElementById("mbr_part").style.display = "table-row";

            var mbr_td = document.getElementById("mbr_list_td");
            var rec_lb = document.getElementById("receive_lable");
            var rec_tx = document.getElementById("receive_text");
            var rej_lb = document.getElementById("reject_lable");
            var rej_tx = document.getElementById("reject_text");
            document.getElementById("mbr_result").innerText = result;
            console.log("mbr_part................" + result);
            if (result != "让步接收") {
                //rec_lb.style.display = "table-cell";
                //rec_tx.style.display = "inline-block";
                rec_lb.style.display = "table-cell";
                rec_tx.style.display = "inline-block";
                rec_tx.style.borderLeft = "none";
                rec_tx.style.borderTop = "none";
                rec_tx.style.borderRight = "none";
                rej_lb.style.display = "table-cell";
                rej_tx.style.display = "inline-block";
                document.getElementById("mbr_list_td").colSpan = '5';
                rej_tx.style.border = "none";
            } else {
                document.getElementById("mbr_list_td").colSpan = '9';
            }
        }


        function addItems() {
            var finalValue = new Array();
            var items = document.getElementsByName("surveyItem");
            items.forEach(function (item, index, array) {
                finalValue.push(item.value);
                finalValue.push(document.getElementsByName("itemJudgement")[index].value);
            });
            finalValue.join(";");
            document.getElementById("_itemValue").value = finalValue;
        }

        function addNewInspectionItem() {
            layui.use('layer', function () {
                layer = layui.layer;
                layer.open({
                    title: ['请输入', 'text-align:center;'],
                    type: 2,
                    area: ['500px', '300px'],
                    content: 'Html/itemAdd.html',
                    btn: ['添加', '取消'],
                    yes: function (index, layero) {
                        var body = layer.getChildFrame('body', index);
                        var item = body.find('#inspectionItem').val();
                        var standard = body.find('#inspectionStandard').val();
                        __myDoPostBack('addItem', item + ',' + standard);
                        layer.closeAll();
                    },
                    btn1: function () {
                        layer.closeAll();
                    }
                    , cancle: function () {
                        layer.closeAll();
                    },
                })
            });
        }

        function reSizeRepeater(height) {
            document.getElementById('size').rowSpan = height;
        }

        window.onload = function () {
            var thisWindow = parent.document.getElementById('iFrame1');
            thisWindow.style.height = this.document.body.scrollHeight + 180 + "px";//调整页面
            showAllText();
        }
        function showReInspection() {
            $('#reInspection').css("display", "none");
        }

        function initializeData() {

            var batch_no = document.getElementById("TextBox1").value;
            var vendor_code = document.getElementById("TextBox4").value;
            location.href = "SCAR.aspx?batch_no=" + batch_no + "&vendor_code=" + vendor_code;

        }

        function setUnDetecable() {
            //不需要表面检测等等
            document.getElementById('detecable_attachment').style.display = "none";
            document.getElementById('detecable').style.display = "none";
            document.getElementById('detecable_title').style.display = "none";
        }

        function startReInspection() {
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;
                layer.open({
                    title: ['请输入需要重新检验的项目', 'text-align:center;'],
                    type: 2,
                    area: ['500px', '300px'],
                    //content: 'Html/reInspectiom.html',
                    content:'Html/FillReInspection.aspx',
                    btn: ['添加', '取消'],
                    yes: function (index, layero) {
                        //var body = layer.getChildFrame('body', index);
                        //var items = body.find('#reInspectionItem').val();
                        var items = localStorage.getItem("itemArray");
                        __myDoPostBack('startReInspection', items);
                        layer.closeAll();
                    },
                    btn1: function () {
                        layer.closeAll();
                    }
                    , cancle: function () {
                        layer.closeAll();
                    },
                })
            });
        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <input type="hidden" id="_itemValue" value="" name="_itemValue" />
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <div class="layui-form-item">
            <table>
                <tr>
                    <td colspan="2">检验批</td>
                    <td colspan="5" rowspan="2" style="font-size: 25px; font-weight: 900;">进货材料检验报告单</td>
                    <td colspan="2">PPAP</td>
                    <td colspan="1">
                        <asp:Label Text="NA" ID="lb_ppap" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" BorderStyle="None" runat="server" ReadOnly="true" ID="TextBox1" /></td>
                    <td colspan="2">型式(破坏)检验</td>
                    <td colspan="1">
                        <asp:Label Text="NA" ID="lb_broken" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">链接:</td>
                    <td colspan="8">
                        <a id="map" runat="server">图纸连接</a>
                    </td>
                    <td colspan="1">SCAR入口</td>
                </tr>
                <tr>
                    <td colspan="1">物料名称</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" BorderStyle="None" runat="server" ReadOnly="true" ID="TextBox2" /></td>
                    <td colspan="1">物料编号</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" BorderStyle="None" runat="server" ReadOnly="true" ID="TextBox3" Height="32px" /></td>
                    <td colspan="1">供应商名</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" BorderStyle="None" ReadOnly="true" runat="server" ID="TextBox4" /></td>
                    <td colspan="1">Region market</td>
                </tr>
                <tr>
                    <td colspan="1">订单货号</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ReadOnly="true" BorderStyle="None" runat="server" ID="TextBox5" /></td>
                    <td colspan="1">数量/重量</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ReadOnly="true" BorderStyle="None" runat="server" ID="TextBox6" /></td>
                    <td colspan="1">到货日期</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" BorderStyle="None" runat="server" ID="TextBox7" /></td>
                    <td colspan="1">
                        <asp:Label Text="泰国" ID="lb_region" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">检验类型:</td>
                    <td colspan="2"><asp:Label style="background-color:red;font-size:x-large" runat="server" ID="lb_Inspection_Type"></asp:Label></td>
                    <td colspan="1">AQL</td>
                    <td colspan="1">
                        <asp:DropDownList Style="display: block;" ID="Aql" AutoPostBack="true" OnSelectedIndexChanged="Aql_SelectedIndexChanged" runat="server">
                            <asp:ListItem>AQL2.5</asp:ListItem>
                            <asp:ListItem>AQL1.5</asp:ListItem>
                            <asp:ListItem>AQL1.0</asp:ListItem>
                            <asp:ListItem>AQL0.65</asp:ListItem>
                            <asp:ListItem>AQL0.40</asp:ListItem>
                            <asp:ListItem>AQL0.25</asp:ListItem>
                            <asp:ListItem>AQL0.10</asp:ListItem>
                            <asp:ListItem>AQL0.15</asp:ListItem>
                            <asp:ListItem>AQL0.065</asp:ListItem>
                            <asp:ListItem>AQL0.040</asp:ListItem>
                            <asp:ListItem>AQL0.025</asp:ListItem>
                            <asp:ListItem>AQL0.015</asp:ListItem>
                            <asp:ListItem>AQL0.010</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td colspan="1">检验等级</td>
                    <td colspan="2"><asp:Label style="background-color:red;font-size:x-large" runat="server" ID="lb_Inspetion_Level"></asp:Label></td>
                    <td colspan="1">检验水平</td>
                    <td colspan="1"><asp:Label style="background-color:red;font-size:x-large" runat="server" ID="lb_Class_Level"></asp:Label></td>
                </tr>
                <tr id="detecable_title">
                    <td colspan="10" style="text-align: left; padding-left: 20px;">表面质量检验 / 适配性检验记录 </td>
                </tr>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <tr id="detecable">
                            <td colspan="1" rowspan="2">表面质量检验</td>
                            <td colspan="1">检验数量:</td>
                            <td colspan="1">
                                <asp:Label Text="text" ID="appearance_amount" runat="server" />
                            </td>
                            <td colspan="1">检出不良数:</td>
                            <td colspan="1">
                                <asp:TextBox runat="server" TextMode="MultiLine" Text="" BorderStyle="None" ID="appearance_bad" />
                            </td>
                            <td colspan="1" rowspan="2">适配性检验记录</td>
                            <td colspan="1">检验数量:</td>
                            <td colspan="1">
                                <asp:Label Text="text" ID="suitability_amount" runat="server" />
                            </td>
                            <td colspan="1">检出不良数:</td>
                            <td colspan="1">
                                <asp:TextBox runat="server" TextMode="MultiLine" ID="suitability_bad" BorderStyle="None" Text="" />
                            </td>
                        </tr>
                        <tr id="detecable_attachment">
                            <td colspan="1">不良明细</td>
                            <td colspan="3">
                                <asp:TextBox runat="server" TextMode="MultiLine" BorderStyle="None" ID="appearance_detail" />
                            </td>
                            <td colspan="1">不良明细</td>
                            <td colspan="3">
                                <asp:TextBox runat="server" TextMode="MultiLine" BorderStyle="None" ID="suitability_detail" />
                            </td>
                        </tr>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td colspan="1" id="size" rowspan="10">尺寸和理化测试</td>
                            <td colspan="2">测试项目</td>
                            <td colspan="2">标准</td>
                            <td colspan="4">测试结果</td>
                            <td colspan="1">判定</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="2"><%# Eval("Item") %></td>
                            <td colspan="2"><%# Eval("Standard") %></td>
                            <td colspan="4">
                                <asp:TextBox runat="server" style="border: none" TextMode="MultiLine" ID="surveyItem" name="surveyItem"></asp:TextBox>
                            </td>
                            <td colspan="1">
                                <asp:TextBox runat="server" style="border: none;text-align:center" TextMode="MultiLine" ID="itemJudgement" name="itemJudgement"></asp:TextBox>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" rowspan="2">检验结论:</td>
                    <td colspan="6" id="qualified" rowspan="2">
                        <select id="qualified_list" style="display:block" runat="server" lay-filter="qualified_list" onchange="judge()">
                            <option value="合格">合格</option>
                            <option value="不合格">不合格</option>
                        </select>
                    </td>
                    <td colspan="1" id="unqualified_type" style="display: none;" rowspan="1">不合格类型</td>
                </tr>
                <tr>
                    <td colspan="1" id="unqualified_list_td" style="display: none;" rowspan="1">
                        <select id="unqualified_type_list" style="display:block;" runat="server">
                            <option value="1001">1001</option>
                            <option value="1002">1002</option>
                            <option value="2001">2001</option>
                            <option value="2002">2002</option>
                            <option value="3001">3001</option>
                            <option value="4001">4001</option>
                            <option value="4002">4002</option>
                            <option value="5001">5001</option>
                            <option value="5002">5002</option>
                            <option value="6001">6001</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>备注:</td>
                    <td colspan="9">
                        <asp:TextBox runat="server" TextMode="MultiLine" BorderStyle="None" ID="remark"/>
                    </td>
                </tr>
                <tr id="mbr_part" style="display: none;">
                    <td rowspan="2">按MRB结论处置结果</td>
                    <td colspan="5" id="mbr_list_td" rowspan="2">
                        <asp:Label Text="" ID="mbr_result" runat="server" />
                    </td>
                    <td colspan="3" id="receive_lable" style="display: none;">接收数量</td>
                    <td id="receive_text" style="display: none;">
                        <asp:TextBox runat="server" TextMode="MultiLine" BorderStyle="None" ID="rcm" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" id="reject_lable" style="display: none;">拒收数量</td>
                    <td colspan="3" id="reject_text" style="display: none;">
                        <asp:TextBox runat="server" TextMode="MultiLine" BorderStyle="None" ID="rjm" />
                    </td>
                </tr>
            </table>
            <div style="text-align: center;">
                <asp:Button Text="添加检验项" CssClass="layui-btn" ID="addItem" OnClick="addItem_Click" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <%--<asp:Button ID="reInspection" runat="server" Text="开始复检" CssClass="layui-btn" OnClientClick="startReInspection()" />--%>
                <a id="reInspection" class="layui-btn" onclick="startReInspection()">开始复检</a>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="Back" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Back_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
		        <asp:Button ID="saveReport" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClientClick="addItems()" OnClick="saveReport_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		        <asp:Button ID="submitReport" runat="server" Text="完成检验" CssClass="layui-btn" OnClick="submitReport_Click" />

            </div>
        </div>
    </form>
</body>
</html>
