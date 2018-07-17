<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="ShowVendorDiscovery.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowVendorDiscovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>供应商调查表</title>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=10"></script>
    <script src="Script/PDF/js/html2canvas.js"></script>
    <script src="Script/PDF/js/jspdf.debug.js"></script>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <style type="text/css">
        textarea {
            resize: none;
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

        /*.div {
			width: 600px;
			height: 200px;
			border: 2px;
		}*/

        h1 {
            text-align: center;
        }

        h3 {
            text-align: right;
        }

        p {
            text-align: right;
        }

        .t {
            border: 0px;
            overflow: hidden;
            width: 100%;
            height: 20px;
            text-align: center;
        }

        table tr td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 6px 0px;
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
            margin-right: auto;
        }

        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            text-align: center;
            width: 100%;
            height: 20px;
        }

        .auto-style3 {
            height: 37px;
        }

        .auto-style4 {
            height: 36px;
        }
    </style>
    <script>
        window.onload = function () {
            showAllText();
            hideShowOtherElements();
        }
    </script>
</head>

<body style="margin: auto">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
                    <a onclick="goBack()" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px">返回</a>
                    <asp:Button CssClass="layui-btn layui-btn-normal" Text="PDF" ID="btnPDF" runat="server" OnClientClick="requestToPdfAshx()" Style="float: right;" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div>
            <table id="table1" style="margin: 0 auto; width: 1000px; border-collapse: collapse" cellpadding="0" cellspacing="0">
                <caption style="font-size: xx-large">供应商调查表</caption>
                <tr>
                    <td colspan="9" style="text-align: right">编号:PR-05-01-5</td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align: right">填表时间：</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>企业名称*</td>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>法人*</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox3" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>地址*</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox4" runat="server" Width="161px" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>电话*</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox5" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>传真*</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox6" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">产品名称*</td>
                    <td colspan="2">规格*</td>
                    <td colspan="2">质量</td>
                    <td colspan="2">职业环境</td>
                    <td>环保体系</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox7" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox8" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox9" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox10" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="TextBox11" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox49" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox50" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox51" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2" class="auto-style4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox52" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox53" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox54" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox55" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox56" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox57" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="TextBox58" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">生产能力</td>
                    <td colspan="3">去年销售额*</td>
                    <td colspan="3">主要客户及市场（最少三家*）</td>
                </tr>
                <tr>
                    <td colspan="3" rowspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox12" runat="server" Wrap="true" CssClass="auto-style1" Height="78px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3" rowspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox13" runat="server" CssClass="auto-style1" Height="63px" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox14" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>

                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox41" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>

                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox42" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">注册资金*</td>
                    <td colspan="2">固定资产</td>
                    <td colspan="2">流动资金</td>
                    <td colspan="2">付款条件*</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox15" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox16" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox17" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox18" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">员工总数*</td>
                    <td colspan="3">管理人员*</td>
                    <td colspan="2">质量人员</td>
                    <td>技术人员</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox19" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox20" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox21" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="TextBox22" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">公司占地面积*</td>
                    <td colspan="3">厂房占地面积</td>
                    <td colspan="3">仓库面积</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox23" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox24" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox25" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">每周工作时间</td>
                    <td colspan="3">每周轮班次数</td>
                    <td colspan="3">目前生产负荷</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox26" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox27" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox28" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">产品主要原料</td>
                    <td colspan="2">产地</td>
                    <td colspan="4">原材料库存状态</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox31" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox32" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox33" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox64" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox65" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox66" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox67" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox68" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox69" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="5">质量体系认证*</td>
                    <td colspan="4">运输方式*</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox29" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="4">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox30" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">生产设备名称</td>
                    <td colspan="2">规格</td>
                    <td colspan="2">使用年限</td>
                    <td colspan="2">生产厂家</td>
                    <td>目前工作状况</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox43" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox44" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox45" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox46" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="TextBox47" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">检测设备</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox34" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">频繁配送能力/采购周期/最小定单</td>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox35" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox59" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                    <td colspan="3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox60" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">供应商早期参与</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox36" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">生产工艺生产系统</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox37" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">客户订货主要流程</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox38" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">经营方向</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox39" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style3">主要雇员的士气和经验</td>
                    <td colspan="7" class="auto-style3">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox40" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">结论</td>
                    <td colspan="7">
                        <asp:TextBox TextMode="MultiLine" ID="TextBox48" runat="server" CssClass="t" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
					<td colspan="2">签名</td>
					<td colspan="2"><asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
					<td colspan="2"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
					<td colspan="2" style="border-right:0;"><asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>
                    <td colspan="1" style="border-left:0;"></td>
				</tr>--%>
            </table>
            <table style="margin: auto; width: 1000px; border-collapse: collapse">
                <tr>
                    <td colspan="2">签名</td>
                    <td colspan="2">
                        <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
                    <td colspan="2">
                        <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
                    <td colspan="2">
                        <asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>

                </tr>
            </table>
            <div style="text-align: center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		
            </div>
        </div>
        <div style="margin-bottom: 50px">
            <table class="gridtable" style="margin: auto; width: 1000px; border-collapse: collapse;">
                <tr>
                    <td>
                        <div>
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

                        </div>
                    </td>
                    <td>
                        <div>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView2_RowCommand" GridLines="None" ForeColor="#333333">
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
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
