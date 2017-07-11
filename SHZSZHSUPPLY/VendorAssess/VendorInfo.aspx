<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorInfo.aspx.cs" Inherits="AendorAssess.VendorInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table{
            width:800px;
            height:400px;
            margin:0 auto;
        }
        .auto-style1 {
            height: 58px;
        }
    </style>

    <script src="Script/jquery-3.2.1.min.js"></script>  
	<script src="Script/layer/layer.js"></script>  
    <script>
        function messageBox(msg) {
            layer.open({
                title:'提示信息',
                content: '' + msg,
            })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <table >
                <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td colspan="2" class="auto-style1">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="供应商全称:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="Temp_Vendor_Name" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="供应商类型:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>直接物料常规</asp:ListItem>
                            <asp:ListItem>直接物料危化品</asp:ListItem>
                            <asp:ListItem>非生产性特种劳防品</asp:ListItem>
                            <asp:ListItem>非生产性危化品</asp:ListItem>
                            <asp:ListItem>非生产性常规</asp:ListItem>
                            <asp:ListItem>非生产性质量部有标准的物料</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="采购金额（万）:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="Purchase_Money" runat="server"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="是否承诺性"></asp:Label>
            <asp:CheckBox ID="Promise" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="是否预付款"></asp:Label>
            <asp:CheckBox ID="Advance_Charge" runat="server" />
                    </td>
                    <td>
                        
            <asp:Label ID="Label4" runat="server" Text="是否指定供应商"></asp:Label>
            <asp:CheckBox ID="Vendor_Assign" runat="server" /><br />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="button1_click" Style="width: 40px" />                        
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
