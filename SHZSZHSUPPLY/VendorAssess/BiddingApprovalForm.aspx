<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BiddingApprovalForm.aspx.cs" Inherits="AendorAssess.BiddingApprovalForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BiddingApprovalForm</title>
    
    <style type="text/css">
        h1{text-align:center;}
        h3{text-align:right;}
        p{text-align:right;}
        .t{
            border:0px; 
            overflow:hidden;
            width:95%;
            text-align:center;
        }        
        td{border:solid #000000; border-width:1px 1px 1px 1px; padding:10px 0px;}
        .head{border:solid #000000; border-width:0px 0px 0px 0px; padding:10px 0px;}
        table{border:solid #000000; border-width:0px 1px 1px 1px;margin-left:auto}
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="margin:auto;border-collapse:collapse" width="70%">
            <tr>
                <h1>BiddingApprovalForm</h1>
            </tr>
            <tr>
                <td colspan="1">CN_PRC003F</td>
                    <td colspan="1"><asp:TextBox ID="TextBox49" runat="server" CssClass="t"></asp:TextBox></td>
                <td>Serial  No.:</td>
                    <td><asp:TextBox ID="TextBox50" runat="server" CssClass="t"></asp:TextBox></td>
                <td>Date:</td>
                    <td><asp:TextBox ID="TextBox51" runat="server" CssClass="t"></asp:TextBox></td>       
            </tr>
            <tr>
                <td>
                    Product产品
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="t"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    预计年采购额
                </td>
                <td colspan="5">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="t"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Item项目</td>
                <td>Description描述</td>
                <td>Supplier供应商/Unit price单价</td>
                <td>Supplier供应商/Unit price单价</td>
                <td>Supplier供应商/Unit price单价</td>
                <td width="20%">Remark</td>
            </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox3" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox7" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox6" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox5" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox8" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox4" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox9" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox10" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox11" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox12" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox13" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox14" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox15" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox16" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox17" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox18" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox19" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox20" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox21" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox22" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox23" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox24" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox25" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox26" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="TextBox27" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox28" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox29" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox30" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox31" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox32" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">MOQ最小起订量</td>
                    <td><asp:TextBox ID="TextBox33" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox34" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox35" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox36" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">Lead time交期</td>
                    <td><asp:TextBox ID="TextBox37" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox38" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox39" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox40" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">Payment term账期</td>
                    <td><asp:TextBox ID="TextBox41" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox42" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox43" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox44" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">Remark备注</td>
                    <td><asp:TextBox ID="TextBox45" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox46" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox47" runat="server" CssClass="t"></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBox48" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="6">
                        以上所有的价格均为人民币不含税价。
                        </td>
                </tr>
                <tr>
                    <td colspan="6">
                        推荐作为供应商,理由如下：
                        </td>
                </tr>
                <tr>
                    <td colspan="1">1
                        </td>
                    <td colspan="5"><asp:TextBox ID="TextBox52" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="1">2
                        </td>
                    <td colspan="5"><asp:TextBox ID="TextBox53" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
            <tr>
                <td colspan="6">examine and approve</td>
                </tr>
            <tr>
                <td>Initiator</td>
                <td colspan="5"><asp:TextBox ID="TextBox54" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
            <tr>
                <td>Supplier Chain Leader</td>
                <td colspan="5"><asp:TextBox ID="TextBox55" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
            <tr>
                <td>Finance Leader</td>
                <td colspan="5"><asp:TextBox ID="TextBox56" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
            <tr>
                <td>Business Leader</td>
                <td colspan="5"><asp:TextBox ID="TextBox57" runat="server" CssClass="t"></asp:TextBox></td>
                </tr>
        </table>
    </div>
    </form>
</body>
</html>
