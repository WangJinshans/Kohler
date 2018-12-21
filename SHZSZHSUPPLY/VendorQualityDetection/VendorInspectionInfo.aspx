<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorInspectionInfo.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.VendorInspectionInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui-v2.4.3/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui-v2.4.3/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    <style>
        .layui-table-cell {
            overflow: visible !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <div class="layui-form-item">
    <label class="layui-form-label">联动选择框</label>
    <div class="layui-input-inline">
      <select name="quiz1">
        <option value="">请选择省</option>
        <option value="浙江" selected="">浙江省</option>
        <option value="你的工号">江西省</option>
        <option value="你最喜欢的老师">福建省</option>
      </select>
    </div>
    <div class="layui-input-inline">
      <select name="quiz2">
        <option value="">请选择市</option>
        <option value="杭州">杭州</option>
        <option value="宁波" disabled="">宁波</option>
        <option value="温州">温州</option>
        <option value="温州">台州</option>
        <option value="温州">绍兴</option>
      </select>
    </div>
    <div class="layui-input-inline">
      <select name="quiz3">
        <option value="">请选择县/区</option>
        <option value="西湖区">西湖区</option>
        <option value="余杭区">余杭区</option>
        <option value="拱墅区">临安市</option>
      </select>
    </div>
    
        </div>
    </form>
    
    
</body>
</html>
