<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderCreate.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderCreate"  EnableSessionState ="True"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" >
    .body
    {
        width:1000px;
        height:100%;
        margin :0;
    }
    
    .style1
     {
         width:1000px;
         height:20px;
         margin:0;
               
     }
     
     .leftdiv
     {
         width:10px;
         float:left;
         height:25px;
     }
     
     .rightdiv
     {
         width:990px;
         float:right;
         height:25px;
     }
     

     
 
     
    </style>
</head>
<body  class ="body" onload="iframeresize()"   >
   


    <form id="form1" runat="server" class ="body" >

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


   <div class="style1" style=" font-size :medium ; color :White; text-align :center; background-color :#666633"  >供应商创建</div>
 <div class="leftdiv" ></div>
 <div class="rightdiv">
 <table class="rightdiv" cellpadding ="0" cellspacing ="0">
 <tr>
<td style=" width :5%; font-size :small">工厂:</td>
    <td style="width:10%">
        <asp:DropDownList ID="DropDownList1" runat="server" style="width:90%" 
            Enabled="False">
            <asp:ListItem>上海科勒</asp:ListItem>
            <asp:ListItem>中山科勒</asp:ListItem>
            <asp:ListItem>珠海科勒</asp:ListItem>
            <asp:ListItem>无</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td style=" width :8%; font-size :small">供应商代码:</td>
    <td style="width:8%">
        <asp:TextBox ID="TextBox1" runat="server" Width ="90%"></asp:TextBox>
        </td>
    <td style=" width :8%; font-size :small">供应商名称:</td>
    <td style="width:25%">

       
         <asp:TextBox ID="TextBox2" runat="server" Width="95%"></asp:TextBox>
  
       
        </td>
        <td style=" width :8%; font-size :small">供应商类型:</td>
        <td style="width:15%">
            <asp:TextBox ID="TextBox3" Width ="70%" runat="server" Height="19px" ></asp:TextBox>
            <cc1:PopupControlExtender ID="TextBox3_PopupControlExtender" runat="server" 
                DynamicServicePath="" Enabled="True" ExtenderControlID="ListBox1" PopupControlID ="Panel1" 
                TargetControlID="TextBox3">
            </cc1:PopupControlExtender>
         
     </td>
        <td style=" width :8%; font-size :small">

           <asp:Button ID="Button1" runat="server" Text="创建" Width="80%" 
                onclick="Button1_Click" />
          

           
     </td>
      
 </tr></table>
 </div>

 <div  >    <asp:Panel ID="Panel1"  runat="server" style="display:none"><asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ListBox1_SelectedIndexChanged"  ></asp:ListBox> 
    </asp:Panel> </div>
 <div>
 <table cellpadding ="0" cellspacing ="0">
 <tr>
 <td class ="body">
 <iframe  frameborder="0" id="iFrame1" width="1000px" scrolling ="no" runat ="server"  ></iframe>
 </td></tr></table></div>
 

   

 
 </form>



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

     if (window.addEventListener) {
         window.addEventListener("load", dyniframesize, false);

        
     }

     else if (window.attachEvent) {
         window.attachEvent("onload", dyniframesize);
         
     }
     else {
         window.onload = dyniframesize

     }

    </script>


        <script type="text/javascript"  >

            function iframeresize() {

                var obj1 = parent.document.getElementById("iFrame1");
                var obj = parent.document.getElementById("Hidden1");

               

                if (obj.value > document.body.scrollHeight) {

                    obj1.height = obj.value;

                }

            }
    
    </script>


</body>




</html>
