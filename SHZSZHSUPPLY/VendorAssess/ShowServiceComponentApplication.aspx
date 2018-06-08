<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowServiceComponentApplication.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowServiceComponentApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=10"></script>
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
            border-style:none;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
            <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
            <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="btnPDF" runat="server" OnClientClick="requestToPdfAshx()" Style="float: right;" />
        </div>
        <div>
            <table>
                <tr>
                    <td colspan="2" style="font-size: 50px; font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif; text-align: center">kolher</td>
                    <td colspan="6" style="font-weight: bold; font-size:large;text-align: center">服务零件采购价格申请表</td>
                    <td colspan="2" style="font-weight: bold; text-align: center;">PR-06-08-0</td>
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
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox1" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox2" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox3" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox4" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox5" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox6" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox7" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox8" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox9" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox10" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox11" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox12" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox13" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox14" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox15" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox16" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox17" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox18" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox19" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox20" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox21" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox22" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox23" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox24" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox25" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox26" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox27" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox28" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox29" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox30" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox31" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox32" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox33" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox34" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox35" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox36" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox37" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox38" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox39" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox40" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox41" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox42" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox43" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox44" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox45" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox46" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox47" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox48" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox49" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox50" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox51" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox52" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox53" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox54" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox55" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox56" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox57" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox58" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox59" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox60" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox61" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox62" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox63" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox64" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox65" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox66" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox67" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox68" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox69" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox70" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox71" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox72" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox73" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox74" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox75" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox76" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox77" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox78" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox79" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox80" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox81" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox82" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox83" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox84" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox85" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox86" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox87" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox88" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox89" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox90" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox91" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox92" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox93" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox94" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox95" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox96" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox97" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox98" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox99" TextMode="MultiLine" CssClass="textbox-width" /></td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="True" ID="textbox100" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td >备注：</td>
                    <td colspan="9"><asp:TextBox runat="server" ID="textbox101" ReadOnly="true" TextMode="MultiLine" CssClass="textbox-width" /></td>
                </tr>
                <tr>
                    <td colspan="2">Initiator:</td>
                    <td colspan="3">
                        <asp:Image ImageUrl="imageurl" ID="image1" runat="server" /></td>
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
            <table style="margin: auto; margin-bottom: 50px; width: 1000px; border-collapse: collapse;">
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
        </div>
    </form>
</body>
</html>
