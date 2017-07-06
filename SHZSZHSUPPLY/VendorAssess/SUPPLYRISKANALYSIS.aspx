<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SUPPLYRISKANALYSIS.aspx.cs" Inherits="AendorAssess.SUPPLYRISKANALYSIS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SUPPLY RISK ANALYSIS</title>
    
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
                <h1>SUPPLY RISK ANALYSIS</h1>
            </tr>
            <tr>
                <td width="20%">Product: 产品</td>
                <td colspan="2"><asp:TextBox ID="TextBox49" runat="server" CssClass="t"></asp:TextBox></td>
                <td>Part No.零件号</td>
                <td colspan="2"><asp:TextBox ID="TextBox1" runat="server" CssClass="t"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Supplier:供应商*</td>
                <td colspan="2"><asp:TextBox ID="TextBox2" runat="server" CssClass="t"></asp:TextBox></td>
                <td>Manufacturer (if Different)生产者(如果不同)*:</td>
                <td colspan="2"><asp:TextBox ID="TextBox3" runat="server" CssClass="t"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Where Used: 用在何处*</td>
                <td colspan="2"><asp:TextBox ID="TextBox4" runat="server" CssClass="t"></asp:TextBox></td>
                <td width="20%">Annual Spend:年开支*</td>
                <td colspan="2"><asp:TextBox ID="TextBox5" runat="server" CssClass="t"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Overall Risk Category</td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
