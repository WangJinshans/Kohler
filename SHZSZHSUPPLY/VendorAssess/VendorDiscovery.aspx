<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorDiscovery.aspx.cs" Inherits="AendorAssess.VendorDiscovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>供应商调查表</title>

	<link rel="stylesheet" href="Script/layui/css/layui.css" />
	<script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
	<script type="text/javascript">
	    onload = function () {
	        var obj = parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
	        //alert(obj.height); //弹出父页面中IFrame中设置的高度


	        obj.height = this.document.body.scrollHeight + "px";  //调整父页面中IFrame的高度为此页面的高度
	    }

		$(function () {
			layer.config({
				extend: ['skin/default/layer.css'], //加载新皮肤  
				skin: 'layer-ext-espresso' //一旦设定，所有弹层风格都采用此主题。  
			});
		});

		//弹出框  
		//function popUp(formid) {
		//	layer.open({
		//		title: '请选择审批部门',
		//		content: 'SelectDepartment.aspx?formid=' + formid,
		//		type: 2,
		//		area: ['750px', '400px'],
		//		shade: 0.3,
		//		shadeClose: false, //点击遮罩关闭
		//		btn: ['确定'],
		//		yes: function (index, layero) {
		//			__myDoPostBack('submitForm', '');
		//			layer.close(index);
		//		},
		//		cancel: function (index, layero) {
		//			if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
		//				layer.close(index)
		//			}
		//			return false;
		//		},
		//		success: function (layero, index) {
		//			console.log(layero, index);
		//		}
		//	});
		//}
	</script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
	<%--<script type="text/javascript">

		function __myDoPostBack(eventTarget, eventArgument) {
			var theForm = document.forms['form2'];
			if (!theForm) {
				theForm = document.form1;
			}
			if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
				theForm.__EVENTTARGET.value = eventTarget;
				theForm.__EVENTARGUMENT.value = eventArgument;
				theForm.submit();
			}
		}
	</script>--%>
	<style type="text/css">
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
				padding: 8px;
				border-style: solid;
				border-color: #666666;
				background-color: #dedede;
			}

			table.gridtable td {
				border-width: 1px;
				padding: 8px;
				border-style: solid;
				border-color: #666666;
				background-color: #ffffff;
			}

		.div {
			width: 600px;
			height: 200px;
			border: 2px;
		}

		h1 {
			text-align: center;
		}

		h3 {
			text-align: right;
		}

		p {
			text-align: right;
		}

		.button {
			font-family: Arial;
			color: #000000;
			font-size: 27px;
			padding: 9px;
			text-decoration: none;
			-webkit-border-radius: 10px;
			-moz-border-radius: 10px;
			border-radius: 10px;
			-webkit-box-shadow: 0px 1px 0px #666666;
			-moz-box-shadow: 0px 1px 0px #666666;
			box-shadow: 0px 1px 0px #666666;
			text-shadow: 1px 1px 3px #666666;
			border: solid #e0e0e0 0px;
			background: -webkit-gradient(linear, 0 0, 0 100%, from(#dbd8da), to(#c9c9c9));
			background: -moz-linear-gradient(top, #dbd8da, #c9c9c9);
		}

			.button:hover {
				background: #dedbde;
			}

		.t {
			border-style: none;
			border-color: inherit;
			border-width: 0px;
			overflow: hidden;
			text-align: center;
            width: 95%;
		}


		td {
			border: solid #000000;
			border-width: 1px 1px 1px 1px;
			padding: 10px 0px;
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
		}

		.auto-style1 {
            width: 95%;
			border-style: none;
			border-color: inherit;
			border-width: 0px;
			overflow: hidden;
			text-align: center;
		}

		.auto-style3 {
			height: 37px;
		}
	    .auto-style4 {
            height: 38px;
        }
	</style>
</head>
<body style="margin: auto">
	<form id="form1" runat="server">
		<%--<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
		<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />--%>
		<div style="text-align: center">
			<table style="margin: auto;width:1000px; border-collapse: collapse">
				<caption style="font-size: xx-large">供应商调查表</caption>
				<tr>
					<td colspan="9" style="text-align: right">编号:PR-05-01-5</td>
				</tr>
				<tr>
					<td colspan="8" style="text-align: right" class="auto-style3">填表时间：</td>
					<td class="auto-style3" style="text-align: left">
						<asp:TextBox runat="server" ID="TextBox1" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="100%" />
					</td>
				</tr>
				<tr>
					<td class="auto-style4">企业名称*</td>
					<td colspan="5" class="auto-style4">
						<asp:TextBox ID="TextBox2" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td class="auto-style4">法人*</td>
					<td colspan="2" class="auto-style4">
						<asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style1" ></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>地址*</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox4" runat="server" Width="250px" CssClass="t"></asp:TextBox>
					</td>
					<td>电话*</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox5" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td>传真*</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox6" runat="server" CssClass="auto-style1" ></asp:TextBox>
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
						<asp:TextBox ID="TextBox7" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox8" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox9" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox10" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="TextBox11" runat="server" CssClass="auto-style1"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:TextBox ID="TextBox49" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox50" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox51" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox52" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="TextBox53" runat="server" CssClass="auto-style1"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:TextBox ID="TextBox54" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox55" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox56" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox57" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="TextBox58" runat="server" CssClass="auto-style1"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="3">生产能力</td>
					<td colspan="3">去年销售额*</td>
					<td colspan="3">主要客户及市场（最少三家*）</td>
				</tr>
				<tr>
					<td colspan="3" rowspan="3">
						<asp:TextBox ID="TextBox12" runat="server" CssClass="auto-style1" TextMode="MultiLine" Wrap="true" Height="78px" MaxLength="200" Rows="3"></asp:TextBox></td>
					<td colspan="3" rowspan="3">
						<asp:TextBox ID="TextBox13" runat="server" CssClass="auto-style1" Height="63px" ></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox14" runat="server" CssClass="auto-style1"></asp:TextBox></td>
				</tr>
				<tr>

					<td colspan="3">
						<asp:TextBox ID="TextBox41" runat="server" CssClass="auto-style1"></asp:TextBox>
					</td>
				</tr>
				<tr>

					<td colspan="3">
						<asp:TextBox ID="TextBox42" runat="server" CssClass="auto-style1" ></asp:TextBox>
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
						<asp:TextBox ID="TextBox15" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox16" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox17" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox18" runat="server" CssClass="auto-style1" Height="16px" ></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">员工总数*</td>
					<td colspan="3">管理人员*</td>
					<td colspan="2">质量人员</td>
					<td>技术人员</td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox19" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox20" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox21" runat="server" CssClass="t"></asp:TextBox></td>
					<td>
						<asp:TextBox ID="TextBox22" runat="server" CssClass="auto-style1"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">公司占地面积*</td>
					<td colspan="3">厂房占地面积</td>
					<td colspan="3">仓库面积</td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox23" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox24" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox25" runat="server" CssClass="auto-style1" ></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">每周工作时间</td>
					<td colspan="3">每周轮班次数</td>
					<td colspan="3">目前生产负荷</td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox26" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox27" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox28" runat="server" CssClass="auto-style1"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">产品主要原料</td>
					<td colspan="2">产地</td>
					<td colspan="4">原材料库存状态</td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox31" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox32" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="4">
						<asp:TextBox ID="TextBox33" runat="server" CssClass="auto-style1" ></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox64" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox65" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="4">
						<asp:TextBox ID="TextBox66" runat="server" CssClass="auto-style1"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:TextBox ID="TextBox67" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="2">
						<asp:TextBox ID="TextBox68" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="4">
						<asp:TextBox ID="TextBox69" runat="server" CssClass="auto-style1" ></asp:TextBox></td>
				</tr>

				<tr>
					<td colspan="5">质量体系认证*</td>
					<td colspan="4">运输方式*</td>
				</tr>
				<tr>
					<td colspan="5">
						<asp:TextBox ID="TextBox29" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="4">
						<asp:TextBox ID="TextBox30" runat="server" CssClass="t"></asp:TextBox></td>
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
						<asp:TextBox ID="TextBox43" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox44" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox45" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox46" runat="server" CssClass="t"></asp:TextBox>
					</td>
					<td>
						<asp:TextBox ID="TextBox47" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">检测设备</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox34" runat="server" CssClass="t"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2">频繁配送能力/采购周期/最小定单</td>
					<td colspan="2">
						<asp:TextBox ID="TextBox35" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3">
						<asp:TextBox ID="TextBox59" runat="server" CssClass="t"></asp:TextBox></td>
					<td colspan="3" style="border-right:0;">
						<asp:TextBox ID="TextBox60" runat="server" CssClass="t"></asp:TextBox></td>
				</tr>
				<tr>
					<td colspan="2">供应商早期参与</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox36" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2" class="auto-style3">生产工艺生产系统</td>
					<td colspan="7" class="auto-style3">
						<asp:TextBox ID="TextBox37" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">客户订货主要流程</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox38" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">经营方向</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox39" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">主要雇员的士气和经验</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox40" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">结论</td>
					<td colspan="7">
						<asp:TextBox ID="TextBox48" runat="server" CssClass="t"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td colspan="2">签名</td>
					<td colspan="2"><asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /></td>
					<td colspan="2"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /></td>
					<td colspan="2" style="border-right:0;"><asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /></td>

				</tr>
			</table>
		</div>

		<div style="text-align: center;margin-bottom:50px">
			<asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
			<asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
		</div>
		<div style="float: left;display:none">
			<table>
				<tr>
					<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
						<Columns>
							<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
								SortExpression="Form_ID" />
							<asp:BoundField DataField="File_ID" HeaderText="文件编号"
								SortExpression="File_ID" />

							<asp:TemplateField>
								<ItemTemplate>
									<asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="view"
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
				</tr>
			</table>

		</div>
	</form>
</body>
</html>
