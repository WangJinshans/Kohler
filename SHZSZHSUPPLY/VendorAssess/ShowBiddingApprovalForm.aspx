<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBiddingApprovalForm.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ShowBiddingApprovalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
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
            width: 95%;
            text-align: center;
        }

        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 10px 0px;
        }

        .head {
            border: solid #000000;
            border-width: 0px 0px 0px 0px;
            padding: 10px 0px;
        }

        table {
            border: solid #000000;
            border-width: 0px 1px 1px 1px;
            margin-left: auto;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table style="margin: auto; border-collapse: collapse; width: 100%">
                <caption style="font-size: xx-large">Bidding Approval Form</caption>
                <tr>
                    <td colspan="1">CN_PRC003F</td>
                    <td colspan="1">
                        &nbsp;</td>
                    <td>Serial  No.:</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox1" CssClass="t"></asp:TextBox> </td>
                    <td>Date:</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox2" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td>Product产品
                    </td>
                    <td colspan="5">
                        
                       <asp:TextBox runat="server" ID="TextBox3" CssClass="t"></asp:TextBox> 
                        
                    </td>
                </tr>
                <tr>
                    <td>预计年采购额
                    </td>
                    <td colspan="5">
                        
                       <asp:TextBox runat="server" ID="TextBox4" CssClass="t"></asp:TextBox> 
                        
                    </td>
                </tr>
                <tr>
                    <td>Item项目</td>
                    <td>Description描述</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td>Supplier供应商<br />
                        Unit price单价</td>
                    <td style="width: 30%">Remark</td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox19" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox20" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox21" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox22" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox23" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox24" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox25" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox26" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox27" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox28" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox29" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox30" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox31" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox32" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox33" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox34" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox35" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox36" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox37" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox38" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox39" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox40" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox41" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox42" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox43" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox44" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox45" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox46" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox47" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox48" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td colspan="2">MOQ最小起订量</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox5" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox6" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox7" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td colspan="2">Lead time交期</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox8" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox9" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox10" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td colspan="2">Payment term账期</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox11" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox12" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox13" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td colspan="2">Remark备注</td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox14" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox15" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                       <asp:TextBox runat="server" ID="TextBox16" CssClass="t"></asp:TextBox> 
                        </td>
                    <td>
                        </td>
                </tr>
                <tr>
                    <td colspan="6">以上所有的价格均为人民币不含税价。
                    </td>
                </tr>
                <tr>
                    <td colspan="6">推荐作为供应商,理由如下：
                    </td>
                </tr>
                <tr>
                    <td colspan="1">1
                    </td>
                    <td colspan="5">
                       <asp:TextBox runat="server" ID="TextBox17" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td colspan="1">2
                    </td>
                    <td colspan="5">
                       <asp:TextBox runat="server" ID="TextBox18" CssClass="t"></asp:TextBox> 
                        </td>
                </tr>
                <tr>
                    <td colspan="6">examine and approve</td>
                </tr>
                <tr>
                    <td>Initiator</td>
                    <td colspan="5">
                        <asp:Image ID="Image1" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>Supplier Chain Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image2" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>Finance Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image3" runat="server" />
                        </td>
                </tr>
                <tr>
                    <td>Business Leader</td>
                    <td colspan="5">
                        <asp:Image ID="Image4" runat="server" />
                        </td>
                </tr>
            </table>
        </div>

        <div>
			<table class="gridtable" style="margin: auto; border-collapse: collapse; float: left">
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
											<asp:LinkButton ID="lbtapprovesuccess" runat="server" CommandName="approvesuccess"
												CommandArgument='<%# Eval("Form_ID") %>'>通过审批</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField>
										<ItemTemplate>
											<asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="fail"
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
							<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333">
								<AlternatingRowStyle BackColor="White" />
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
