<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowVendorDesignatedApply.aspx.cs" Inherits="VendorAssess.ShowVendorDesignatedApply" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                <td colspan="1" ><asp:TextBox ID="TextBox1" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox2" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox3" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" >Initiator:</td>
                <td colspan="5" ><asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style1" Width="819px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1">Date:</td>
                <td colspan="5"><asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style1" Width="811px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">Approval Signature</td>
            </tr>
            <tr>
                <td colspan="1">Applicant: </td>
                <td colspan="1"><asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1">Request Dept Head: </td>
                <td colspan="1" class="auto-style3"><asp:TextBox ID="TextBox10" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1">FIN Manager: </td>
                <td colspan="1"><asp:TextBox ID="TextBox11" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
            </tr>
             <tr>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox ID="TextBox12" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1" class="auto-style3"><asp:TextBox ID="TextBox13" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox ID="TextBox14" runat="server" CssClass="auto-style1" ReadOnly="True"></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Purchasing Manager: </td>
                <td colspan="2"><asp:TextBox ID="TextBox15" runat="server" CssClass="auto-style1" Width="281px" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">GM: </td>
                <td colspan="2"><asp:TextBox ID="TextBox17" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox ID="TextBox16" runat="server" CssClass="auto-style1" Width="280px" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox ID="TextBox18" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Director: </td>
                <td colspan="2"><asp:TextBox ID="TextBox19" runat="server" CssClass="auto-style1" Width="280px" ReadOnly="True"></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Supply Chain Director: </td>
                <td colspan="2"><asp:TextBox ID="TextBox20" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox ID="TextBox21" runat="server" ReadOnly="True" CssClass="auto-style1" Width="280px" ></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox ID="TextBox22" runat="server" CssClass="auto-style1" Width="344px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1"> President:</td>
                <td colspan="5" style="text-align:left"> <asp:TextBox ID="TextBox23" runat="server" CssClass="auto-style1" Width="407px" ReadOnly="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
            </tr>
              <tr>
                <td colspan="1"> Date:</td>
                <td colspan="5"><asp:TextBox ID="TextBox24" runat="server" CssClass="auto-style1" Width="313px" ReadOnly="True"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                    <td>
                        <div width: 1000px; text-align :center ;height: 100%>
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
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333" >
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
