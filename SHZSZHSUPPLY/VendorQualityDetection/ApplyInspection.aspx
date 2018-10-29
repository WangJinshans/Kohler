<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyInspection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ApplyInspection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
	<script src="../VendorAssess/Script/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
	<script src="../VendorAssess/Script/Own/fileUploader.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--
            仓库领取记录，方便 领取之后 忘记检验批 通过SKU进行筛选查找
            申请检验某一批，通过检验批来确认    需要检验员将检验批写入仓库货物中

            查出检验报告？  重新进行检验就行  




            

            车间报验之后 决定是否需要重新检验（只能重新检验一次 不用多次检验）    单位是个  或者  千克 或着sheng

            --%>
           

        <%--输入  SKU  以及  检验批--%>
        <asp:DropDownList runat="server" ID="SKU" >

        </asp:DropDownList>
        <asp:TextBox runat="server" ID="batchNo" />
        <asp:RadioButton ID="ge" Text="件/个" runat="server" Checked="true" GroupName="radio" />
        <asp:RadioButton ID="kg" Text="千克/升" runat="server" GroupName="radio" />
        <asp:TextBox runat="server" ID="takeout" TextMode="MultiLine" />
        <asp:TextBox runat="server" ID="amount" TextMode="MultiLine" />
        <asp:Button Text="text" ID="apply" OnClick="apply_Click" runat="server" />
    </div>
    </form>
</body>
</html>
