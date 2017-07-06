<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderExist.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderExist"  EnableSessionState ="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/webform1_iframe_redirect_VenderMaintenance.js" type="text/javascript"></script>
    <style type="text/css" >
    .body
    {
        width:1000px;
        height:100%;
        margin :0
    }
.div
{
    width:1000px;
    height:30px;
}
    
   
    </style>
</head>
<body class="body"  onload="iframeresize()"  >
    <form id="form1" runat="server" class="body">
    <div class ="div">
    <table cellpadding ="0" cellspacing ="0" class="div" >
    <tr>
    <td style="width:10px" ></td>
    <td style=" font-size :small;">供应商已存在，继续创建请选择使用</td></tr>
 
    </table>
    </div>
    <div>
        <table cellpadding ="0" cellspacing ="0" class="div" >
    <tr>
    <td style="width:10px" ></td>
    <td  style="width:150px">
        <asp:Button ID="Button1" runat="server" Text="使用" Width ="100px" 
       
             onclick="Button1_Click" 
            />
        </td>
    <td >
        <asp:Button ID="Button2" runat="server" Text="查看" Width="100px"
         OnClientClick ="webform1_iframe_redirect_VenderInfoDisplay()" 
            onclick="Button2_Click" />
        </td></tr>
 
    </table></div>
    
    </form>

   

    <script type="text/javascript"  >
    
    function iframeresize()
    {

        var obj1 = parent.parent.document.getElementById("iFrame1");
        var obj = parent.parent.document.getElementById("Hidden1");
      
      
        if (obj.value > document.body.scrollHeight) {

            obj1.height = obj.value;

        }

    }


    function webform1_iframe_redirect_VenderMaintenance() {

        var obj = parent.parent.document.getElementById("iFrame1")
        obj.src = "VenderInfo/VenderMaintenance.aspx"
    }

   

    function webform1_iframe_redirect_VenderInfoDisplay() {

        var obj = parent.parent.document.getElementById("iFrame1")
        obj.src = "VenderInfo/VenderInfoDisplay.aspx"
    }

    
    </script>

</body>
</html>
