<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SurveyReport.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.SurveyReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <style type="text/css">
        * {
            padding: 0px;
            margin: 0px;
        }

        textarea {
            resize: none;
        }

        table {
            width: 80%;
            margin:100px auto;
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">检验批</td>
                    <td colspan="5" rowspan="2" style="font-size:25px;font-weight:900;">进货材料检验报告单</td>
                    <td colspan="2">PPAP</td>
                    <td colspan="1">日期/未完成/NA</td>
                </tr>
                <tr>
                    <td colspan="2">10000200001</td>
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
                    <td colspan="2"></td>
                    <td colspan="1">物料编号</td>
                    <td colspan="2"></td>
                    <td colspan="1">供应商名</td>
                    <td colspan="2"></td>
                    <td colspan="1">Region market</td>
                </tr>
                <tr>
                    <td colspan="1">订单货号</td>
                    <td colspan="2"></td>
                    <td colspan="1">数量/重量</td>
                    <td colspan="2"></td>
                    <td colspan="1">到货日期</td>
                    <td colspan="2"></td>
                    <td colspan="1">泰国</td>
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
                    <td colspan="1">xxxxxxx</td>
                    <td colspan="1">检出不良数:</td>
                    <td colspan="1">xxxxxxx</td>
                    <td colspan="1" rowspan="2">适配性检验记录</td>
                    <td colspan="1">检验数量:</td>
                    <td colspan="1">xxxxxxx</td>
                    <td colspan="1">检出不良数:</td>
                    <td colspan="1">xxxxxxx</td>
                </tr>
                <tr>
                    <td colspan="1">不良明细</td>
                    <td colspan="3"></td>
                    <td colspan="1">不良明细</td>
                    <td colspan="3"></td>
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
                            <td colspan="4">NNG</td>
                            <td colspan="1">NG</td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3" rowspan="2">检验结论:</td>
                    <td colspan="3" rowspan="2">合格</td>
                    <td colspan="3" rowspan="2">不合格</td>
                    <td colspan="1" rowspan="1">不合格类型</td>
                </tr>
                <tr>
                    <td colspan="1" rowspan="1">1001</td>
                </tr>
                <tr>
                    <td>备注:</td>
                    <td colspan="9"></td>
                </tr>
                <tr>
                    <td rowspan="2">按MRB结论处置结果</td>
                    <td colspan="2" rowspan="2">退货</td>
                    <td colspan="2" rowspan="2">让步接收</td>
                    <td colspan="2" rowspan="2">反工</td>
                    <td colspan="1" rowspan="2">挑选全检</td>
                    <td colspan="1">接收数量</td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">拒收数量</td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="10" style="font-size:20px;font-weight:800;">MBR意见</td>
                </tr>
                <tr>
                    <td colspan="1">采购</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                    <td colspan="1">物流</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">生产</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                    <td colspan="1">市场</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="1">工程</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                    <td colspan="1">质量</td>
                    <td colspan="3"></td>
                    <td colspan="1"></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size:18px;font-weight:700;">总经理/总监</td>
                    <td colspan="6"></td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size:20px;font-weight:700;">MBR结论</td>
                    <td colspan="8"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
