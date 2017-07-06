<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AendorAssess.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        div{
            height:50px;
            margin:0 auto;
        }
        a 
        {
            text-decoration:none
        }
            a:link 
            {
                color:red;
            }
            a:visited 
            {
                color:burlywood
            }
            a:active 
            {
                color:blueviolet
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label4" runat="server" Text="职位"></asp:Label>&nbsp
        <asp:Label ID="Label1" runat="server" Text="员工ko号"></asp:Label>&nbsp      
        <asp:Label ID="Label2" runat="server" Text="姓名"></asp:Label>&nbsp
        <asp:Label ID="Label3" runat="server" Text="你好"></asp:Label>
    </div>
    <div>
        <a href="VendorInfo.aspx">新建审批</a>
    </div>
    <div>
        <a href="VendorInfo.aspx">审批状态查看</a>
    </div>
    <div>
        <a href="EmployeeVendor.aspx">供应商文件管理</a>
    </div>
    <div>
        <a href="ShowApproveForm.aspx">待审批表格</a>
    </div>
    </form>
</body>
</html>
