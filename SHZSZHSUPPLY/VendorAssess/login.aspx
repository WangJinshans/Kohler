<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AendorAssess.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="账号"></asp:Label><asp:TextBox ID="Employee_ID" runat="server"></asp:TextBox><br/>
        <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label><asp:TextBox ID="Employee_Password" runat="server" TextMode="Password"></asp:TextBox><br/>
        <asp:Button ID="Button2" runat="server" Text="登录" OnClick="Button2_Click" />
    </div>
    </form>
</body>
</html>
