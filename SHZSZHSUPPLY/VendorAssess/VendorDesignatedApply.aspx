<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorDesignatedApply.aspx.cs" Inherits="VendorAssess.VendorDesignatedApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .t {
            border: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
        }
        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 10px 0px;
        }
        table {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            margin-left: auto;
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
        .auto-style1 {
            border-style: none;
            border-color: inherit;
            border-width: 0px;
            overflow: hidden;
            text-align: center;
        }
        .auto-style2 {
            width: 1032px;
        }
        .auto-style3 {
            width: 170px;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        </style>
        <script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js" ></script>
    <script src="Script/jquery-3.2.1.min.js"></script>  
	<script src="Script/layer/layer.js"></script>  
	<script type="text/javascript">  
		$(function () {  
			layer.config({  
				extend: ['skin/default/layer.css'], //加载新皮肤  
				skin: 'layer-ext-espresso' //一旦设定，所有弹层风格都采用此主题。  
			});  
		});  
  
		//弹出框  
		function popUp(formid) {
			layer.open({
				title: '请选择审批部门',
				content: 'SelectDepartment.aspx?formid=' + formid,
				type: 2,
				area: ['750px', '400px'],
				shade: 0.3,
				shadeClose: false, //点击遮罩关闭
				btn: ['确定'],
				yes: function (index, layero) {
					__myDoPostBack('submitForm', '');
					layer.close(index);
				},
				cancel: function (index, layero) {
					if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
						layer.close(index)
					}
					return false;
				},
				success: function (layero, index) {
					console.log(layero, index);
				}
			});
		}  
	</script>  
	<script type="text/javascript">
	
		function __myDoPostBack(eventTarget, eventArgument) {
			var theForm = document.forms['form1'];
			if (!theForm) {
				theForm = document.form1;
			}
			if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
				theForm.__EVENTTARGET.value = eventTarget;
				theForm.__EVENTARGUMENT.value = eventArgument;
				theForm.submit();
		}
	}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
		<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
    <div style="text-align:right">PR-05-10-2</div><br>
    <div style="text-align: center">
        <table style="margin: auto; border-collapse:initial" cellpadding="0" cellspacing="0">
            <caption style="font-size:xx-large; " class="auto-style2">上海科勒有限公司</caption>
            <tr>
                <td colspan="6">指定供应商申请表</td>
            </tr>
            <tr>
                <td colspan="1" >供应商名称*</td>
                <td colspan="1" >SPA编号*</td>
                <td colspan="1" >产品描述*</td>
                <td colspan="1" class="auto-style3" >有效期*</td>
                <td colspan="1" >预估年采购金额(Estimated Purchase Amount)*</td>
                <td colspan="1" >原因*</td>
            </tr>
             <tr>
                <td colspan="1" >Vendor Name*</td>
                <td colspan="1" >SAP Code*</td>
                <td colspan="1" >Business Category*</td>
                <td colspan="1" class="auto-style3" >Effective Time*</td>
                <td colspan="1" >(Over 100K should have formal bidding process)*</td>
                <td colspan="1" >(With Supporting Documents)*</td>
            </tr>
            <tr>
                <td colspan="1" ><asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox2" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox runat="server" id="TextBox4" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="35px"/></td>
                <td colspan="1" ><asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" >Initiator:</td>
                <td colspan="5" ><asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style1" Width="819px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1">Date:</td>
                <td colspan="5"><asp:TextBox runat="server" id="TextBox8" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">Approval Signature</td>
            </tr>
            <tr>
                <td colspan="1">Applicant: </td>
                <td colspan="1"><asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
                <td colspan="1">Request Dept Head: </td>
                <td colspan="1" class="auto-style3">
                    <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" /> </td>
                <td colspan="1">FIN Manager: </td>
                <td colspan="1"><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" /> </td>
            </tr>
             <tr>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox runat="server" id="TextBox12" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1" class="auto-style3"><asp:TextBox runat="server" id="TextBox13" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox runat="server" id="TextBox14" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /> </td>
            </tr>
            <tr>
                <td colspan="1">Purchasing Manager: </td>
                <td colspan="2"><asp:Image ImageUrl="imageurl" ID="Image3" runat="server" /> </td>
                <td colspan="1" class="auto-style3">GM: </td>
                <td colspan="2">
                    <asp:Image ID="Image4" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox runat="server" id="TextBox17" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox runat="server" id="TextBox18" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Director: </td>
                <td colspan="2">
                    <asp:Image ID="Image5" runat="server" ImageUrl="imageurl" />
                </td>
                <td colspan="1" class="auto-style3">Supply Chain Director: </td>
                <td colspan="2">
                    <asp:Image ID="Image6" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox runat="server" id="TextBox21" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox runat="server" id="TextBox22" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1"> President:</td>
                <td colspan="5" style="text-align:left"> 
                    <asp:Image ID="Image7" runat="server" ImageUrl="imageurl" />
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
            </tr>
              <tr>
                <td colspan="1"> Date:</td>
                <td colspan="5"><asp:TextBox runat="server" id="TextBox24" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" height="100%" width="90%" /></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div style="text-align: center">
        <asp:Button ID="Button1" runat="server" Text="提交" CssClass="button" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="button" OnClick="Button2_Click" />
	        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="返回" CssClass="button" OnClick="Button3_Click" />
    </div>
    <div>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_ID" HeaderText="表格编号"
						SortExpression="Form_ID" />
					<asp:BoundField DataField="File_ID" HeaderText="文件编号"
						SortExpression="File_ID" />

					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="fail"
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
    </div>
    </form>
</body>
</html>
