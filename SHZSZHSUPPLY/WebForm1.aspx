﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SHZSZHSUPPLY.WebForm1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" >
          
              
        
    .style1
     {
     width:100%;
     height:100%;
     }
     
     .style2
     {
         width:1000px;
         height:50px;
         
        
     }
     
     .style3
     {
         width:150px;
         height:50px;
     }
     
     .style4
     {
         width:850px;
         height:50px;
     }
     
     .style5
     {
         width:1000px;
         height:22px;
     }
     
     .style6
     {
         width:100%;
         height:100%;
     }
     
        
     
        .iFrame1
        {
            width: 100%;
            height: 637px;
            margin-left: 0px;
        }
             
     
     
       #jsddm
{	margin: 0;
	padding: 0;
            height: 22px;
            width :750px
        }

	#jsddm li
	{	float: left;
		list-style: none;
		font: 12px Tahoma, Arial}

	#jsddm li a
	{	display: block;
		background: #324143;
		padding: 5px 12px;
		text-decoration: none;
		border-left: 1px solid white;
		
		width: 70px;
		color: #EAFFED;
		white-space: nowrap}

	#jsddm li a:hover
	{	background: #24313C}
		
		#jsddm li ul
		{	margin: 0;
			padding: 0;
			position:absolute ;
			visibility: hidden;
			border-top: 1px solid white
			}
		
			#jsddm li ul li
			{	float: none;
				display: inline}
			
			#jsddm li ul li a
			{	width: auto;
				background: #A9C251;
				color: #24313C}
			
			#jsddm li ul li a:hover
			{	background: #8EA344}
     
     
   
      
     
    </style>
</head>
<body   style ="margin:0">
    <form id="form1" runat="server" class="style1"  >
        <table cellpadding="0" cellspacing="0" class="style2" align="center">
            <tr>
                <td class="style3">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/pic/logo1.jpg" CssClass="style3" ImageAlign="AbsBottom" />
                </td>
                <td class="style4">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/pic/logo2.jpg" CssClass="style4" ImageAlign="AbsBottom" />
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" class="style5" align="center">
            <tr>
                <td bgcolor="#324143" style="width: 250px">
                    <asp:Label ID="Label1" runat="server" Text="Welcome:" Style="font-weight: 700; font-size: small; color: #FFFFFF"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label" Style="font-weight: 700; font-size: small; color: #FFFFFF"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Label" Style="font-weight: 700; font-size: small; color: #FFFFFF"></asp:Label>
                </td>

                <td bgcolor="#324143">

                    <ul id="jsddm">
                        <li><a href="#" style="text-align: center">供应商管理</a>
                            <ul>
                                <li><a href="VenderInfo/VenderCreate.aspx" target="iFrame1">供应商信息创建 </a></li>
                                <li><a href="VenderInfo/VenderMaintenance.aspx" target="iFrame1">供应商信息编辑</a></li>
                                <li><a href="VenderInfo/VenderInfoDisplay.aspx" target="iFrame1">供应商信息查看</a></li>
                                <li><a href="VenderInfo/SharedItemMA.aspx" target="iFrame1">供应商变更及文档删除</a></li>
                            </ul>
                        </li>
                        <li><a href="#" style="text-align: center">供应商评估</a>
                            <ul>
                                <li><a href="#" target="iFrame1">供应商评估</a></li>
                            </ul>
                        </li>
                        <li><a href="VendorAssess/login.aspx" target="iFrame1">供应商审批</a>
                        </li>
                        <li><a href="#" style="text-align: center">价格走势</a>
                            <ul>
                                <li><a href="#" target="iFrame1">价格走势</a></li>

                            </ul>
                        </li>
                        <li><a href="#" style="text-align: center">报表</a>
                            <ul>
                                <li><a href="#" target="iFrame1">报表</a></li>

                            </ul>
                        </li>

                        <li style="border-right: 1px solid white;"><a href="#" style="text-align: center">系统管理</a>
                            <ul>
                                <li><a href="#" target="iFrame1">文档类型管理</a></li>
                                <li><a href="#" target="iFrame1">用户权限分配</a></li>

                            </ul>
                        </li>
                        <li style="border-right: 1px solid white;"><a href="Login.aspx" style="text-align: center">退出</a>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>

        <div style="position:relative;width:100%">
            <table class="style6" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td>
                        <iframe name="iFrame1" class="iFrame1" marginwidth="0" frameborder="0" id="iFrame1" scrolling="yes"
                            runat="server"></iframe>
                    </td>
                </tr>
            </table>
        </div>
        <div style="position:fixed;bottom:0px;left:40%; margin:0 auto;width:20%;height:50px">
            <div style="font-size: small; font-family: Arial; text-align: center; border-top: 1;margin-top:20px">上海科勒 2016年12月</div>
            <%--<table cellpadding="0" cellspacing="0" align="center" style="width:100%;height:50px;">
                <tr>
                    <td style="font-size: small; font-family: Arial; text-align: center; border-top: 1"
                        class="style2">上海科勒 2016年12月<input id="Hidden1" type="hidden" /></td>
                </tr>
            </table>--%>
        </div>
    <script type="text/javascript">
        var iframeids = ["iFrame1"]
        var iframehide = "yes"
        function dyniframesize() {
            var dyniframe = new Array()
            for (i = 0; i < iframeids.length; i++) {
                if (document.getElementById) {
                    dyniframe[dyniframe.length] = document.getElementById(iframeids[i]);
                    if (dyniframe[i] && !window.opera) {
                        dyniframe[i].style.display = "block"
                        if (dyniframe[i].contentDocument && dyniframe[i].contentDocument.body.offsetHeight)
                            dyniframe[i].height = dyniframe[i].contentDocument.body.offsetHeight;
                        else if (dyniframe[i].Document && dyniframe[i].Document.body.scrollHeight)
                            dyniframe[i].height = dyniframe[i].Document.body.scrollHeight;
                    }
                }
                if ((document.all || document.getElementById) && iframehide == "no") {
                    var tempobj = document.all ? document.all[iframeids[i]] : document.getElementById(iframeids[i])
                    tempobj.style.display = "block"
                }
            }
        }

        if (window.addEventListener)
            window.addEventListener("load", dyniframesize, false)
        else if (window.attachEvent)
            window.attachEvent("onload", dyniframesize)
        else
            window.onload = dyniframesize

            

    </script>


     <script language="javaScript" type="text/javascript"  src="jsddm.0.25/jquery.min.js"></script>
     <script type="text/javascript">
         var timeout = 500;
         var closetimer = 0;
         var ddmenuitem = 0;

         function jsddm_open() {
             jsddm_canceltimer();
             jsddm_close();
             ddmenuitem = $(this).find('ul').eq(0).css('visibility', 'visible');
         }

         function jsddm_close()
         { if (ddmenuitem) ddmenuitem.css('visibility', 'hidden'); }

         function jsddm_timer()
         { closetimer = window.setTimeout(jsddm_close, timeout); }

         function jsddm_canceltimer() {
             if (closetimer) {
                 window.clearTimeout(closetimer);
                 closetimer = null;
             }
         }

         $(document).ready(function () {
             $('#jsddm > li').bind('mouseover', jsddm_open);
             $('#jsddm > li').bind('mouseout', jsddm_timer);
         });

         document.onclick = jsddm_close;
        
         

     </script>

    </form>
</body>

</html>
