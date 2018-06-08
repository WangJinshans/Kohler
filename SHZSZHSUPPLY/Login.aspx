<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SHZSZHSUPPLY.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SK/ZH/ZS供应商管理系统</title>

    <style type="text/css" >
        
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
         margin:0;
         
       
     }
     
     .style4
     {
         width:750px;
         height:50px;
         margin :0;
         
     }
     
      .style5
     {
         width:900px;
         height:22px;
     }
     
        #Select1 {
            width: 358px;
            margin-left: 86px;
        }
     
    </style>
    <script type="text/javascript" src="VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="VendorAssess/Script/layui/layui.js"></script>
    <script type="text/javascript" src="VendorAssess/Script/Own/fileUploader.js?v=9"></script>
    <script type="text/javascript">
        function QusEmployee(parameters) {
            
        }


        function setSession() {
            alert("请退出另一个账户！");
            location.href = "Login.aspx";
        }
        function setuid(uid) {
            localStorage.setItem("uid", uid);
        }
        function redirecturl(name, uid) {
            setuid(uid);
            parent.location.href = 'WebForm1.aspx?name1=' + name + '&name2=' + uid;
        }
    </script>
</head>
<body   style ="margin:0">
    <form id="form1" runat="server" class="style1"  >
    
   <div style=" width :100%; height :72px;">
   <table  cellpadding="0" cellspacing="0" class="style2" align="center"  >
  <tr>
  <td class="style3">
      <asp:Image ID="Image1" runat="server"  ImageUrl="~/pic/logo1.jpg"  CssClass ="style3" ImageAlign ="AbsBottom"  />
      </td>
  <td class="style4">
      <asp:Image ID="Image2" runat="server" ImageUrl="~/pic/logo2.jpg" CssClass ="style4" ImageAlign ="AbsBottom" />
      </td>
  </tr>
 
   </table>
  
    <table class ="style5" cellpadding ="0" cellspacing ="0" align="center">
    <tr><td bgcolor="#324143"></td></tr></table></div>


    <div><table class ="style5" cellpadding ="0" cellspacing ="0" align="center">
    <tr><td></td></tr></table></div>
    <div><table  class ="style5" cellpadding ="1" cellspacing ="1" align="center">
    <tr>
    <td style="width:80px; font-size :medium ; font-family :Arial; font-weight :bold   ">用户名:</td>
    <td>
        <asp:TextBox ID="TextBox1" runat="server" style="width:30%"></asp:TextBox>
        </td>
    <td style=" width:450px; font-family :Arial ; text-align :center;font-weight :bold   ">上海科勒，中山科勒，珠海科勒</td></tr></table></div>
    <div><table  class ="style5" cellpadding ="1" cellspacing ="1" align="center">
    <tr>
    <td style="width:80px; font-size :medium ; font-family :Arial;font-weight :bold   ">密码:</td>
    <td><asp:TextBox ID="TextBox2" runat="server" style="width:30%" TextMode="Password"></asp:TextBox></td>
    <td style="width:450px;font-family :Arial ; text-align :center;font-weight :bold ">供应商管理系统(科勒中国)</td></tr></table></div>
    <div><table class ="style5" cellpadding ="0" cellspacing ="0" align="center">
    <tr><td>
        <asp:DropDownList ID="EmployeeList" Visible="False" runat="server" style="margin-left: 85px" Width="361px">
        </asp:DropDownList>
        </td></tr></table></div>
    <div><table  class ="style5" cellpadding ="0" cellspacing ="0" align="center">
    <tr>
    <td style="width:80px;  ">
        <asp:Button ID="Button1" runat="server" Text="登录" width="100%" 
            Font-Size ="Medium" Font-Names="Arial" onclick="Button1_Click"  />
        </td>
        <td></td>
    <td style=" width:450px">
        <asp:Label ID="Label1" runat="server"></asp:Label>
        </td></tr></table></div>
    </form>

    <script language ="javascript " type ="text/javascript" >

        if (window != top) {

            top.location.href = location.href;
        }
    </script>

</body>
</html>
