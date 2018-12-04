<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInspectionList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ShowInspectionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
	<script src="../VendorAssess/Script/layui-v2.4.3/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui-v2.4.3/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=1"></script>
    <style>
        body {
            padding: 0px;
            margin: 0px;
        }

        td {
            width: 100px;
        }
    </style>
    <script>

        layui.use('laydate', function () {
            var laydate = layui.laydate;

            //执行一个laydate实例
            laydate.render({
                elem: '#test1' //指定元素
                , format: 'yyyy/M/d'
                , trigger: 'click'
                , theme: '#515a6d'

                , done: function (value) {

                    return timeSelect(value);
                }
            });
        });

        function timeSelect(date) {
            var time = date;
			__myDoPostBack('timeSelect', time);
		}

		$(document).ready(function(){

            $('select').css();

        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-form-item" style="width: 80%; margin: 0 auto;">
            <fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">待检清单</legend>
            </fieldset>
            

			<div style="text-align:center;height:30px">
					请选择日期:
                    <input type="text" style="width: 15%; height: 85%" id="test1" placeholder="选择日期" />
					<%--<asp:TextBox ID="test1" runat="server"></asp:TextBox>--%>
					&nbsp;&nbsp;
					状态:
                    <asp:DropDownList ID="dropStatus" runat="server" Style="width: 15%; height: 100%;" OnSelectedIndexChanged="dropStatus_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Selected="True" Value="全部">全部</asp:ListItem>
                        <asp:ListItem Value="待检">待检</asp:ListItem>
                        <asp:ListItem Value="完成">完成</asp:ListItem>
                    </asp:DropDownList>
                
            </div>


			<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" Style="width: 1000px; margin: 0 auto; margin-bottom: 50px;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Product_Describes" HeaderText="ProductDescribes"
                                SortExpression="Product_Describes" />
                            <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商"
                                SortExpression="Temp_Vendor_Name" />
                            <asp:BoundField DataField="Go" HeaderText="Go"
                                SortExpression="Go" />
                            <asp:BoundField DataField="To" HeaderText="To"
                                SortExpression="To" />
                            <asp:BoundField DataField="Form_ID" HeaderText="FormID"
                                SortExpression="Form_ID" />
                            <asp:BoundField DataField="Status" HeaderText="状态"
                                SortExpression="Status" />

                            <asp:BoundField DataField="Add_Time" HeaderText="加入时间"
                                SortExpression="Add_Time" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#515a6d" Font-Bold="true" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#5AA700" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>

                </ContentTemplate>
                <%--<Triggers>
					<asp:AsyncPostBackTrigger ControlID="dropStatus" EventName="dropStatus_SelectedIndexChanged"/>
				</Triggers>--%>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
