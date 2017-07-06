<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SHZSZHSUPPLY.MainPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" >
     .style1
     {
         width:1010px;
         height:450px;
         margin :0;
         border :0
     }
 </style>
</head>
 
<body class="style1" onload="mainheight()"  >
    <form id="form1" runat="server" class="style1">
    <div class="style1" >
    <table class="style1" cellpadding ="0" cellspacing ="0">
    <tr>
    <td> <asp:Image ID="Image1" runat="server" CssClass="style1"  
            ImageUrl="~/pic/SKZSZH系统流程.jpg"  ImageAlign ="AbsMiddle" /></td></tr></table>
        
       
        
       
    </div>
    </form>

    <script type="text/javascript" >

    function mainheight()
    {
     

        var objinput = this.parent.document.getElementById("Hidden1");

        objinput.value =document.body.scrollHeight;

       

    }
    </script>

</body>
</html>
