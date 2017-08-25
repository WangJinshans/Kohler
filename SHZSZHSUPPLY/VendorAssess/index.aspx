<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AendorAssess.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script>
        layui.use(['element','layer'], function () {
            var element = layui.element(); //导航的hover效果、二级菜单等功能，需要依赖element模块
            var layer = layui.layer;
            //监听导航点击
            element.on('nav(demo)', function (elem) {
            });
        });
    </script>
    <script>
        function filterNavigation(a, b, c, d, e) {
            if (a == 'TRUE') {
                document.getElementById('nav1').style = 'display:normal';
            }
            if (b == 'TRUE') {
                document.getElementById('nav2').style = 'display:normal';
            }
            if (c == 'TRUE') {
                document.getElementById('nav3').style = 'display:normal';
            }
            if (d == 'TRUE') {
                document.getElementById('nav4').style = 'display:normal';
            }
            if (e == 'TRUE') {
                document.getElementById('nav5').style = 'display:normal';
            }
        }
    </script>
    <style>
        div {
            height: 28px;
            margin: 0 auto;
        }

        a {
            text-decoration: none;
        }

            a:link {
                color: red;
            }

            a:visited {
                color: burlywood;
            }

            a:active {
                color: blueviolet;
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
        
        <fieldset class="layui-elem-field layui-field-title" style="margin-top: 0px;">
            <legend>审批导航</legend>
        </fieldset>
        <ul class="layui-nav layui-nav-tree" lay-filter="demo">
            <li class="layui-nav-item layui-nav-itemed" id="nav1" style="display:none">
                <a href="javascript:;">新建</a>
                <dl class="layui-nav-child">
                    <dd><a href="VendorInfo.aspx">新建审批</a></dd>
                    <dd><a href="VendorSharedUse.aspx">供应商复用</a></dd>
                </dl>
            </li>
            <li class="layui-nav-item layui-nav-itemed" id="nav2" style="display:none">
                <a href="javascript:;">状态</a>
                <dl class="layui-nav-child">
                    <dd><a href="ApprovalProgress.aspx">审批状态查看</a></dd>
                    <dd><a href="EmployeeVendor.aspx">供应商文件管理</a></dd>
                </dl>
            </li>
            <li class="layui-nav-item layui-nav-itemed" id="nav3" style="display:none">
                <a href="javascript:;">填写</a>
                <dl class="layui-nav-child">
                    <dd><a href="FormWaitToFill.aspx">待填写表格</a></dd>
                </dl>
            </li>
            <li class="layui-nav-item layui-nav-itemed" id="nav4" style="display:none">
                <a href="javascript:;">过期重审</a>
                <dl class="layui-nav-child">
                    <dd><a href="FormOverDue.aspx">申请表过期</a></dd>
                    <dd><a href="FileOverDue.aspx">文件过期</a></dd>
                </dl>
            </li>
            <li class="layui-nav-item layui-nav-itemed" id="nav5" style="display:none">
                <a href="javascript:;">审批</a>
                <dl class="layui-nav-child">
                    <dd><a href="KCI.aspx">KCI审批</a></dd>
                    <dd><a href="ShowApproveForm.aspx">常规审批</a></dd>
                </dl>
            </li>
        </ul>

    </form>
</body>
</html>
