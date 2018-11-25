<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowSurveyReport.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ShowSurveyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            margin: 100px auto;
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

        //MBR 结论 非挑选全检
        function notCheckAll() {
            var mbr_td = document.getElementById("mbr_list_td");
            var rec_lb = document.getElementById("receive_lable");
            var rec_tx = document.getElementById("receive_text");
            var rej_lb = document.getElementById("reject_lable");
            var rej_tx = document.getElementById("reject_text");
            rec_lb.style.display = "none";
            rec_tx.style.display = "none";
            rej_lb.style.display = "none";
            rej_tx.style.display = "none";
            mbr_td.colSpan = "9";
        }
        //MBR 结论 挑选全检
        function checkAll() {
            var mbr_td = document.getElementById("mbr_list_td");
            var rec_lb = document.getElementById("receive_lable");
            var rec_tx = document.getElementById("receive_text");
            var rej_lb = document.getElementById("reject_lable");
            var rej_tx = document.getElementById("reject_text");
            rec_lb.style.display = "table-cell";
            rec_tx.style.display = "table-cell";
            rej_lb.style.display = "table-cell";
            rej_tx.style.display = "table-cell";
            mbr_td.colSpan = "7";
        }

        function mrb_change() {
            __myDoPostBack("MBR_Change","")
        }


        window.onload = function () {
            var thisWindow = parent.document.getElementById('iFrame1');
            thisWindow.style.height = this.document.body.scrollHeight + 150 + "px";//调整页面
            showAllText();
            console.log("iframe reformed");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">检验批</td>
                    <td colspan="5" rowspan="2" style="font-size: 25px; font-weight: 900;">进货材料检验报告单</td>
                    <td colspan="2">PPAP</td>
                    <td colspan="1">日期/未完成/NA</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_batch" runat="server" />
                    </td>
                    <td colspan="2">型式(破坏)检验</td>
                    <td colspan="1">NA</td>
                </tr>
                <tr>
                    <td colspan="1">链接:</td>
                    <td colspan="8">I:\ShanghaiKohlerManagementSystem-All-needed\products\PCI\drawing\ALL DRAWING\扶手\8598\1021418.PDF</td>
                    <td colspan="1">SCAR入口</td>
                </tr>
                <tr>
                    <td colspan="1">物料名称</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_product_name" runat="server" />
                    </td>
                    <td colspan="1">物料编号</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_sku" runat="server" />
                    </td>
                    <td colspan="1">供应商名</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_vendor_code" runat="server" /> 
                    </td>
                    <td colspan="1">Region market</td>
                </tr>
                <tr>
                    <td colspan="1">订单货号</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_purachseNo" runat="server" />
                    </td>
                    <td colspan="1">数量/重量</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_amount" runat="server" />
                    </td>
                    <td colspan="1">到货日期</td>
                    <td colspan="2">
                        <asp:Label Text="text" ID="lb_arrivetime" runat="server" />
                    </td>
                    <td colspan="1">
                        <asp:Label Text="text" ID="lb_region" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">检验类型:</td>
                    <td colspan="2"></td>
                    <td colspan="1">AQL2.5</td>
                    <td colspan="2">正常</td>
                    <td colspan="1">加严</td>
                    <td colspan="1">放宽</td>
                    <td colspan="1">全检</td>
                    <td colspan="1">退货检验</td>
                </tr>
                <tr>
                    <td colspan="10" style="text-align: left; padding-left: 20px;">表面质量检验 / 适配性检验记录 </td>
                </tr>
                <tr>
                    <td colspan="1" rowspan="2">表面质量检验</td>
                    <td colspan="1">检验数量:</td>
                    <td colspan="1">
                        <asp:Label Text="text" ID="lb_surface_amount" runat="server" />
                    </td>
                    <td colspan="1">检出不良数:</td>
                    <td colspan="1">
                        <asp:Label Text="text" ID="lb_surface_bad" runat="server" />
                    </td>
                    <td colspan="1" rowspan="2">适配性检验记录</td>
                    <td colspan="1">检验数量:</td>
                    <td colspan="1">
                        <asp:Label Text="text" ID="lb_suitability_amount" runat="server" />
                    </td>
                    <td colspan="1">检出不良数:</td>
                    <td colspan="1">
                        <asp:Label Text="text" ID="lb_suitability_bad" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">不良明细</td>
                    <td colspan="3">
                        <asp:Label Text="text" ID="lb_surface_detail" runat="server" />
                    </td>
                    <td colspan="1">不良明细</td>
                    <td colspan="3">
                        <asp:Label Text="text" ID="lb_suitability_detail" runat="server" />
                    </td>
                </tr>
                <asp:Repeater ID="Repeater1" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
                    <HeaderTemplate>
                        <tr>
                            <td colspan="1" rowspan="10">尺寸和理化测试</td>
                            <td colspan="2">测试项目</td>
                            <td colspan="2">标准</td>
                            <td colspan="4"></td>
                            <td colspan="1">NG</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="2"><%# Eval("Item") %></td>
                            <td colspan="2"><%# Eval("Standard") %></td>
                            <td colspan="4"><%# Eval("Result") %></td>
                            <td colspan="1"><%# Eval("Judgement") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" rowspan="2">检验结论:</td>
                    <td colspan="7" id="qualified" rowspan="2">
                        <asp:Label Text="text" ID="lb_result" runat="server" />
                    </td>
                    <td colspan="1" id="unqualified_type" style="display: none;" rowspan="1">不合格类型</td>
                </tr>
                <tr>
                    <td colspan="1" id="unqualified_list_td" style="display: none;" rowspan="1">
                        <asp:Label Text="text" ID="lb_unqualifiedType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注:</td>
                    <td colspan="9">
                        <asp:Label Text="text" ID="lb_remark" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td rowspan="2">按MRB结论处置结果</td>
                    <td colspan="9" id="mbr_list_td" rowspan="2">
                        <asp:Label Text="text" ID="mbr_list" runat="server" />
                    </td>
                    <td colspan="1" id="receive_lable" style="display: none;">接收数量</td>
                    <td colspan="1" id="receive_text" style="display: none;">
                        <asp:Label Text="text" ID="lb_rc" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1" id="reject_lable" style="display: none;">拒收数量</td>
                    <td colspan="1" id="reject_text" style="display: none;">
                        <asp:Label Text="text" ID="lb_rj" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="font-size: 20px; font-weight: 800;">MBR意见</td>
                </tr>
                <tr>
                    <td colspan="1">采购</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="purchase_reason"></asp:TextBox>
                    </td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="purchase_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                    <td colspan="1">物流</td>
                    <td colspan="3"><asp:TextBox runat="server" TextMode="MultiLine" ID="logistics_reason"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="logistics_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">生产</td>
                    <td colspan="3"><asp:TextBox runat="server" TextMode="MultiLine" ID="product_reason"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="product_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                    <td colspan="1">市场</td>
                    <td colspan="3"><asp:TextBox runat="server" TextMode="MultiLine" ID="market_reason"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="market_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1">工程</td>
                    <td colspan="3"><asp:TextBox runat="server" TextMode="MultiLine" ID="project_reason"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="project_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                    <td colspan="1">质量</td>
                    <td colspan="3"><asp:TextBox runat="server" TextMode="MultiLine" ID="quilty_reason"></asp:TextBox></td>
                    <td colspan="1">
                        <asp:DropDownList runat="server" ID="quilty_manager">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 18px; font-weight: 700;">
                        <asp:Label Text="总经理/总监" runat="server" ID="final_decision" /></td>
                    <td colspan="6"><asp:TextBox runat="server" TextMode="MultiLine" ID="final_reason"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:DropDownList ID="final_select" OnSelectedIndexChanged="final_select_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="退货" />
                            <asp:ListItem Text="让步接收" />
                            <asp:ListItem Text="返工" />
                            <asp:ListItem Text="挑选全检" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: 20px; font-weight: 700;">MBR结论</td>
                    <td colspan="8">
                        <asp:Label Text="" ID="lb_mbr_result" runat="server" /></td>
                </tr>
            </table>
            <div style="text-align: center;">
                <asp:Button ID="selected" runat="server" Text="提交结果" CssClass="layui-btn" OnClick="selected_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
		        <asp:Button ID="Back" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Back_Click" />
            </div>
        </div>
    </form>
</body>
</html>
