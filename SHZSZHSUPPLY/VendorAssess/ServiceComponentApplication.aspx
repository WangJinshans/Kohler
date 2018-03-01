<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceComponentApplication.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ServiceComponentApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <style>
        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            height: 10px;
            padding: 5px 0px;
            font-size: small;
        }

        table {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            margin-left: auto;
            border-collapse: collapse;
            width: 100%;
            table-layout: fixed;
        }

        .celltd {
            width: auto;
            height: 10px;
        }

        .textbox-width {
            height: 100%;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td rowspan="2" colspan="2" style="font-size: 50px; font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif; text-align: center">kolher
                    </td>
                    <td colspan="6" style="font-weight: bold; text-align: center">上海科勒有限公司
                    </td>
                    <td rowspan="2" colspan="2" style="font-weight: bold; text-align: center;">PR-06-08-0</td>
                </tr>
                <tr>
                    <td colspan="6" style="font-weight: bold; text-align: center">服务零件采购价格申请表
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="text-align: left">Service parts </td>
                </tr>
                <tr>
                    <td class="celltd">Item No *</td>
                    <td class="celltd">Description* </td>
                    <td class="celltd">Sku Number*</td>
                    <td class="celltd">UOM*</td>
                    <td class="celltd">Supplier *</td>
                    <td class="celltd">Service parts cost w/o VAT  *</td>
                    <td class="celltd">Original cost w/o VAT  *</td>
                    <td class="celltd">MOQ*</td>
                    <td class="celltd">MOQ ( shipping with product PO ) </td>
                    <td class="celltd">Lead time *</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox1" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox2" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox3" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox4" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox5" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox6" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox7" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox8" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox9" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox10" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox11" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox12" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox13" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox14" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox15" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox16" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox17" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox18" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox19" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox20" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox21" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox22" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox23" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox24" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox25" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox26" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox27" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox28" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox29" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox30" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox31" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox32" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox33" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox34" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox35" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox36" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox37" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox38" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox39" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox40" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox41" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox42" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox43" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox44" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox45" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox46" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox47" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox48" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox49" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox50" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox51" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox52" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox53" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox54" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox55" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox56" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox57" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox58" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox59" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox60" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox61" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox62" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox63" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox64" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox65" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox66" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox67" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox68" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox69" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox70" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox71" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox72" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox73" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox74" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox75" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox76" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox77" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox78" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox79" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox80" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox81" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox82" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox83" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox84" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox85" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox86" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox87" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox88" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox89" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox90" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="textbox91" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox92" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox93" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox94" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox95" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox96" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox97" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox98" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox99" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="textbox100" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td colspan="10"></td>
                </tr>
                <tr>
                    <td colspan="2">Initiator:</td>
                    <td colspan="3">
                        <asp:Image ImageUrl="imageurl" onclick="openSignatureSelectio_s(this,null)" ID="image1"  AlternateText="请选择图片" runat="server" /></td>
                    <td colspan="2">Purchasing Manager(Plant):</td>
                    <td colspan="3">
                        <asp:Image ImageUrl="imageurl" ID="image2" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">Finance Manager(Plant):</td>
                    <td colspan="3">
                        <asp:Image ImageUrl="imageurl" ID="image3" runat="server" /></td>
                    <td colspan="2">GM(Plant):</td>
                    <td colspan="3">
                        <asp:Image ImageUrl="imageurl" ID="image4" runat="server" /></td>
                </tr>
            </table>
            <div id="notes">
                <br>* Notes: 1）服务零件的采购价格申请表须由Purchasing Manager(Plant)批准后输入系统执行</br>
                &nbsp &nbsp &nbsp  2）采购价格批准生效后，请发至KCI采购部指定窗口备案，邮件地址：daoquan.zhang@kohler.com/电话：021-38602561</br>
            </div>
            <div style="text-align: center; margin-bottom: 50px">
                <br>
                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
	        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClientClick="waiting('正在保存')" OnClick="Button2_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
            </div>
        </div>
    </form>
</body>
</html>
