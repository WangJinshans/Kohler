<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemListPdf.aspx.cs" Inherits="SHZSZHSUPPLY.ItemListPdf.ItemListPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type ="text/css" >
    
     .style1
     {
     width:100%;
     height:100%;
     }
     
     .style2
     {
         width:900px;
         height:50px;
         
        
     }
     
     .style3
     {
         width:150px;
         height:50px;
     }
     
     .style4
     {
         width:750px;
         height:50px;
     }
     
     .style5
     {
         width:900px;
         height:22px;
     }
     
     .style6
     {
         width:900px;
         height:500px;
     }
     
        
     
        .iFrame1
        {
            width: 900px;
        }
    
    </style>
</head>
<body>
    <form id="form1" runat="server" class="style1">
    
    <div>
    <table class="style6" align="center" cellpadding ="0" cellspacing ="0"> 
    <tr>
    <td class="style6">
    <iframe runat ="server" id="iframe1" class="style6" ></iframe>
    </td></tr></table></div>
    <div>
  <table class="style2" cellpadding ="0" cellspacing ="0" align="center">
  <tr><td style=" font-size :small; font-family :Arial ; text-align:center; border-top:1 " 
          class="style2">上海科勒 2016年12月<input id="Hidden1" type="hidden" /></td></tr></table></div>
   
    </form>

    


</body>
</html>
