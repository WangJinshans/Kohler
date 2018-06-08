<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Biddingformlists.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.Html_Template.Biddingformlists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .div-center {
            width:600px;
            margin:0 auto;
            text-align:center;
            border:1px solid red
        }
    </style>
    <link href="../Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../Script/jquery-3.2.1.min.js"></script>
    <script src="../Script/layui/layui.js"></script>
    <script src="../Script/Own/fileUploader.js"></script>
    <script>

        function hide(placeNumber) {
            if (placeNumber == '1') {
                document.getElementById('bidingTip').style.display = "block";
            }
            if (placeNumber == '2') {
                document.getElementById('zhidingTip').style.display = "block";
            } 
            if (placeNumber == '3') {
                document.getElementById('selectionTip').style.display = "block";
            }
            
        }

        function hidebtn() {
            document.getElementById('Button1').style.display = "none";
        }

        function biddingSuccess() {
            layui.use(['form'], function () {
                var form = layui.form
                    , layer = layui.layer;
                    var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                    parent.layer.close(index); //再执行关闭   
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div-center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView1_RowCommand" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_Path" HeaderText="表格"
						SortExpression="Form_Path" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="showform" runat="server" CommandName="show"
								CommandArgument='<%# Eval("Form_Path") %>'>查看文件</asp:LinkButton>
						</ItemTemplate>
                        <ItemTemplate>
							<asp:LinkButton ID="selectform" runat="server" CommandName="select"
								CommandArgument='<%# Eval("Form_Path") %>'>确认</asp:LinkButton>
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
            <p id="bidingTip" style="color:red;display:none;">没有已经审批完成的比价表</p>
        </div>
       <%-- <div class="div-center">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView2_RowCommand" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_Path" HeaderText="表格编号"
						SortExpression="Form_Path" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="showform" runat="server" CommandName="show"
								CommandArgument='<%# Eval("Form_Path") %>'>查看文件</asp:LinkButton>
						</ItemTemplate>
                        <ItemTemplate>
							<asp:LinkButton ID="selectform" runat="server" CommandName="select"
								CommandArgument='<%# Eval("Form_Path") %>'>确认</asp:LinkButton>
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
            <p id="zhidingTip" style="color:red;display:none;">没有已经审批完成的指定供应商表</p>
        </div>
        <div class="div-center">
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4" OnRowCommand="GridView3_RowCommand" GridLines="None" ForeColor="#333333">
						<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
				<Columns>
					<asp:BoundField DataField="Form_Path" HeaderText="表格编号"
						SortExpression="Form_Path" />
					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="showform" runat="server" CommandName="show"
								CommandArgument='<%# Eval("Form_Path") %>'>查看文件</asp:LinkButton>
						</ItemTemplate>
                        <ItemTemplate>
							<asp:LinkButton ID="selectform" runat="server" CommandName="select"
								CommandArgument='<%# Eval("Form_Path") %>'>确认</asp:LinkButton>
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
            <p id="selectionTip" style="color:red;display:none;">没有已经审批完成的选择表</p>
        </div>--%>
        <div class="div-center">
            <asp:Button ID="Button1" runat="server" Text="确认绑定" CssClass="layui-btn" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
