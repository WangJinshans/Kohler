<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScareList.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ScareList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <script src="Scripts/commonUtil.js?v=2"></script>
    <script>

        //调整textarea的高度
        window.onload = function () {
            showAllText();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--
            手动触发Scare
            batch_No

            vendorCode 
            --%>
            <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox1" />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="TextBox2" />
            <asp:TextBox runat="server" TextMode="MultiLine" ID="reason" />
            <asp:Button Text="text" ID="Button1" OnClick="Button1_Click" runat="server" />
        </div>
        <div>
            <%--Scar 列表   状态标识--%> 
        </div>
    </form>
</body>
</html>
