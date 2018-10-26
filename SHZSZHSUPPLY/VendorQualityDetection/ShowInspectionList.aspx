﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowInspectionList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ShowInspectionList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
	<script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
	<script src="../VendorAssess/Script/layui-v2.4.3/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui-v2.4.3/layui/css/layui.css" rel="stylesheet" />
	<script src="../VendorAssess/Script/Own/fileUploader.js"></script>
	<style>
        body {
            padding: 0px;
            margin: 0px;
        }
        td {
            width:100px;
        }
		
		
        

    </style>
	<script>

		
		// $("#test1").trigger("input"); 
		//$("#test1").bind("input propertychange",function () {
  //                alert("aaa");  
  //              });

		//$("input").change(function(){
		//	var time = $("#test1").find("option:selected").val();
		//	__myDoPostBack('timeSelect', 'time');
		//})
		
		//function timeSelect(date) {
		//	var time = $("#test1").find("option:selected").val();
		//	alert("aa"); 
		//}

		//function changeStatus() {
		//	var time = $('#test1').val(); 
			
		//	var index = $('#status option:selected') .val();
			

		//	$.get("ShowInspectionList.aspx?time=" + time + "&status=" + status);

			
		//}

	</script>
	
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-form-item" style="width: 80%; margin: 0 auto;">
			<fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">待检清单</legend>
            </fieldset>
			<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" ></asp:ScriptManager>


			<div class="layui-inline">
				<label class="layui-form-label" >请选择日期</label>
				<div class="layui-input-inline"> 
					<input type="text" class="layui-input" id="test1" placeholder="选择日期" />
				</div>
			</div>


			<script src="../VendorAssess/Script/layui-v2.4.3/layui"></script>
			<script>

			layui.use('laydate', function(){
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
			</script>
			<script>
				function timeSelect(date) {
				//var time = $("#test1").find("option:selected").val();
					var time = date;
					//$.post("ShowInspectionList.aspx", { time1: time }, function () { alert(time); });
					__myDoPostBack('timeSelect', time);
				}
			</script>
			
			 <div class="layui-inline">
				<label class="layui-form-label">状态</label>
				<div class="layui-input-inline">
					<asp:DropDownList ID="dropStatus" runat="server" style="width:100%;height:38px;" OnSelectedIndexChanged="dropStatus_SelectedIndexChanged" AutoPostBack="True" >
						<asp:ListItem Selected="True" Value ="all">全部</asp:ListItem>
						<asp:ListItem Value ="待检">待检</asp:ListItem>
						<asp:ListItem Value ="完成">完成</asp:ListItem>
					</asp:DropDownList>
				<%--<select id="" style="width:100%;height:38px;" class="layui-select" onchange="return changeStatus();">
				  <option value="all" selected="selected">全部</option>
				  <option value="待检">待检</option>
				  <option value="完成">完成</option>
				</select>--%>
			  </div>
			</div>

			
			
			
			<asp:UpdatePanel ID="UpdatePanel1"  runat="server" >
			<ContentTemplate>
				<asp:GridView ID="GridView1" Style="width: 1000px; margin: 0 auto; margin-bottom: 50px;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" GridLines="None">
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