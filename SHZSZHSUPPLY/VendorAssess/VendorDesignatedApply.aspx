<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorDesignatedApply.aspx.cs" Inherits="VendorAssess.VendorDesignatedApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=10"></script>
    <script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            layer.config({
                extend: ['skin/default/layer.css'], //加载新皮肤  
                skin: 'layer-ext-espresso' //一旦设定，所有弹层风格都采用此主题。  
            });
        });
    </script>
     <script>
        //防止页面后退  
        history.pushState(null, null, document.URL);
        window.addEventListener('popstate', function () {
            history.pushState(null, null, document.URL);
        });
        // 浏览器回退禁止  
        function noBack() {
            // 历史记录栈中记录页数  
            var numberOfEntries = window.history.length;
            if (window.history && window.history.pushState) {
                $(window).on('popstate', function () {
                    // 当点击浏览器的 后退和前进按钮 时才会被触发，  
                    window.history.pushState('forward', null, '');
                    window.history.forward(1);
                });
            }
            // 新弹出页对应  
            if (numberOfEntries != 1) {
                // 页面间跳转用  
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            }
        };
    </script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
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
            width: 100px;
        }

        .auto-style4 {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <%--<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
		<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />--%>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="tableUpdatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div style="text-align: center">
                    <table style="margin: auto; border-collapse: initial; width: 1000px" cellpadding="0" cellspacing="0">
                        <caption style="font-size: small; text-align: right; border-style: none;">PR-05-10-2</caption>
                        <caption style="font-size: xx-large;" class="auto-style2">上海科勒有限公司</caption>
                        <tr>
                            <td colspan="6">指定供应商申请表</td>
                        </tr>
                        <tr>
                            <td colspan="1">供应商名称*</td>
                            <td colspan="1">SPA编号*</td>
                            <td colspan="1">产品描述*</td>
                            <td colspan="1" class="auto-style3">有效期*</td>
                            <td colspan="1">预估年采购金额(Estimated Purchase Amount)*</td>
                            <td colspan="1">原因*</td>
                        </tr>
                        <tr>
                            <td colspan="1">Vendor Name*</td>
                            <td colspan="1">SAP Code*</td>
                            <td colspan="1">Business Category*</td>
                            <td colspan="1" class="auto-style3">Effective Time*</td>
                            <td colspan="1">(Over 100K should have formal bidding process)*</td>
                            <td colspan="1">(With Supporting Documents)*</td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox1" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox2" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox3" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox4" CssClass="t" /></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox5" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox6" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox9" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox10" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox11" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox15" CssClass="t" /></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox16" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox19" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox20" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox23" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox25" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox26" CssClass="t" /></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox27" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox28" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox29" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox30" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox31" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox32" CssClass="t" /></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox33" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox34" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox35" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox36" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox37" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="TextBox38" CssClass="t" /></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox39" runat="server" CssClass="t"></asp:TextBox></td>
                            <td colspan="1">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox40" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">Initiator:</td>
                            <td colspan="5">
                                <asp:TextBox TextMode="MultiLine" ID="TextBox7" runat="server" CssClass="t"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="1">Date:</td>
                            <td colspan="5">
                                <asp:TextBox runat="server" ID="TextBox8" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="100%" /></td>
                        </tr>

                    </table>
                    <table style="margin: auto; border-collapse: initial; width: 1000px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="6" style="text-align: left">Approval Signature</td>
                        </tr>
                        <tr>
                            <td colspan="1">Applicant: </td>
                            <td colspan="1">
                                <asp:Image onclick="openSignatureSelection(this,null)" ImageUrl="imageurl" ID="Image8" runat="server" AlternateText="请选择图片" />
                            </td>
                            <td colspan="1">Request Dept Head: </td>
                            <td colspan="1">
                                <asp:Image ImageUrl="imageurl" ID="Image1" runat="server" />
                            </td>
                            <td colspan="1">FIN Manager: </td>
                            <td colspan="1">
                                <asp:Image ImageUrl="imageurl" ID="Image2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">Date: </td>
                            <td colspan="1">
                                <asp:TextBox runat="server" ID="TextBox12" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" />
                            </td>
                            <td colspan="1">Date: </td>
                            <td colspan="1">
                                <asp:TextBox runat="server" ID="TextBox13" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" />
                            </td>
                            <td colspan="1">Date: </td>
                            <td colspan="1">
                                <asp:TextBox runat="server" ID="TextBox14" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">Purchasing Manager: </td>
                            <td colspan="2">
                                <asp:Image ImageUrl="imageurl" ID="Image3" runat="server" />
                            </td>
                            <td colspan="1">GM: </td>
                            <td colspan="2">
                                <asp:Image ID="Image4" runat="server" ImageUrl="imageurl" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">Dtae: </td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TextBox17" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" /></td>
                            <td colspan="1">Date: </td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TextBox18" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" /></td>
                        </tr>
                        <tr>
                            <td colspan="1">Director: </td>
                            <td colspan="2">
                                <asp:Image ID="Image5" runat="server" ImageUrl="imageurl" />
                            </td>
                            <td colspan="1">Supply Chain Director: </td>
                            <td colspan="2">
                                <asp:Image ID="Image6" runat="server" ImageUrl="imageurl" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: center">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
                        </tr>
                        <tr>
                            <td colspan="1">Dtae: </td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TextBox21" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" />
                            </td>
                            <td colspan="1">Date: </td>
                            <td colspan="2">
                                <asp:TextBox runat="server" ID="TextBox22" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" /></td>
                        </tr>
                        <tr>
                            <td colspan="1">President:</td>
                            <td colspan="5" style="text-align: left">
                                <asp:Image ID="Image7" runat="server" ImageUrl="imageurl" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
                        </tr>
                        <tr>
                            <td colspan="1">Date:</td>
                            <td colspan="5">
                                <asp:TextBox runat="server" ID="TextBox24" BorderStyle="None" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%" /></td>
                        </tr>
                    </table>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<div style="text-align: center;margin-bottom:50px">
		<asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
		<asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
	</div>--%>
        <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="ImgExSrc" />
                <asp:Button runat="server" ID="btnNewImage" Style="display: none" OnClick="btnNewImage_Click" />
                <div style="text-align: center; margin-bottom: 50px">
                    <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
				<asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<asp:Button ID="Button4" runat="server" Text="填写授权文件上传" CssClass="layui-btn layui-btn-danger" OnClick="Button4_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display: none">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" CellPadding="4" GridLines="None" ForeColor="#333333">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                        SortExpression="Form_ID" />
                    <asp:BoundField DataField="File_ID" HeaderText="文件编号"
                        SortExpression="File_ID" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtFile" runat="server" CommandName="view"
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
     <script>
        $('textarea').bind('input', function () {
            this.style.height = this.scrollTop + this.scrollHeight + "px";
        })
    </script>
</body>
</html>
