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
                <td colspan="1" ><asp:TextBox ID="TextBox4" runat="server" CssClass="t" Height="35px"></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox5" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
                <td colspan="1" ><asp:TextBox ID="TextBox6" runat="server" CssClass="t" Height="35px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1" >Initiator:</td>
                <td colspan="5" ><asp:TextBox ID="TextBox7" runat="server" CssClass="auto-style1" Width="819px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1">Date:</td>
                <td colspan="5"><asp:TextBox ID="TextBox8" runat="server" CssClass="auto-style1" Width="811px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">Approval Signature</td>
            </tr>
            <tr>
                <td colspan="1">Applicant: </td>
                <td colspan="1"><asp:TextBox ID="TextBox9" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
                <td colspan="1">Request Dept Head: </td>
                <td colspan="1" class="auto-style3"><asp:TextBox ID="TextBox10" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
                <td colspan="1">FIN Manager: </td>
                <td colspan="1"><asp:TextBox ID="TextBox11" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
            </tr>
             <tr>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox ID="TextBox12" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1" class="auto-style3"><asp:TextBox ID="TextBox13" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
                <td colspan="1">Date: </td>
                <td colspan="1"><asp:TextBox ID="TextBox14" runat="server" CssClass="auto-style1" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Purchasing Manager: </td>
                <td colspan="2"><asp:TextBox ID="TextBox15" runat="server" CssClass="auto-style1" Width="281px" ></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">GM: </td>
                <td colspan="2"><asp:TextBox ID="TextBox17" runat="server" CssClass="auto-style1" Width="344px" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox ID="TextBox16" runat="server" CssClass="auto-style1" Width="280px" ></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox ID="TextBox18" runat="server" CssClass="auto-style1" Width="344px" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="1">Director: </td>
                <td colspan="2"><asp:TextBox ID="TextBox19" runat="server" CssClass="auto-style1" Width="280px" ></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Supply Chain Director: </td>
                <td colspan="2"><asp:TextBox ID="TextBox20" runat="server" CssClass="auto-style1" Width="344px" ></asp:TextBox> </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:right">(Note: purchase value equal to or above RMB 100K,  Supply Chain Director's approval is required)</td>
            </tr>
            <tr>
                <td colspan="1">Dtae: </td>
                <td colspan="2"><asp:TextBox ID="TextBox21" runat="server" CssClass="auto-style1" Width="280px" ></asp:TextBox> </td>
                <td colspan="1" class="auto-style3">Date: </td>
                <td colspan="2"><asp:TextBox ID="TextBox22" runat="server" CssClass="auto-style1" Width="344px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="1"> President:</td>
                <td colspan="5" style="text-align:left"> <asp:TextBox ID="TextBox23" runat="server" CssClass="auto-style1" Width="407px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="6" style="text-align:left">(Note: purchase value equal to or above RMB 100K,  President's approval is required)</td>
            </tr>
              <tr>
                <td colspan="1"> Date:</td>
                <td colspan="5"><asp:TextBox ID="TextBox24" runat="server" CssClass="auto-style1" Width="313px" ></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div style="text-align:center">
        <asp:Button ID="Button1" runat="server" Text="保存" CssClass="auto-style4" OnClick="Button1_Click" Width="66px" />&nbsp&nbsp&nbsp&nbsp&nbsp
        <asp:Button ID="Button2" runat="server" Text="提交" Width="66px" OnClick="Button2_Click" style="height: 21px" />
    </div>
    </form>
   
</body>
</html>
