<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="SHZSZHSUPPLY.WebForm2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >  
<head id="Head1" runat="server">  
   <title>无标题页</title>  
       <mce:style type="text/css"><!--  
   .bgcss  
    {  
      background-color:Gray;  
      filter:alpha(opacity=70);  
      opacity:0.7;      
   }  
      
--></mce:style><style type="text/css" mce_bogus="1">    .bgcss  
    {  
      background-color:Gray;  
      filter:alpha(opacity=70);  
      opacity:0.7;      
    }  
    </style>  
</head>  
<body>  
    <form id="form1" runat="server">  

   
   <div style="width:890px ;height:90px"><table cellpadding ="0" cellspacing ="0" style="width:890px;height:30px"><tr><td style="width:890px;height:30px;text-align :center;
    background-color :Green; border-bottom : 1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black; border-top :1.0pt solid black ">
    文档删除</td></tr></table>
    <table cellpadding ="0" cellspacing ="0" style="width:890px;height:30px"><tr><td style="width:80px;height:30px;border-bottom :
    1.0pt solid black; border-left :1.0pt solid black;" >供应商代码</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;
    ">文档类型</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black; font-size :smaller ">文档工厂</td><td style="width:80px;height:30px;
   border-bottom :1.0pt solid black; border-left :1.0pt solid black;">文档状态</td><td style="width:170px;height:30px;border-bottom :1.0pt solid black; 
  border-left :1.0pt solid black;">文档条码</td> ><td style="width:50px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;">起始</td>
  <td style="width:50px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;">结束</td><td  style="width:80px;height:30px;border-bottom :
  1.0pt solid black; border-left :1.0pt solid black;">上传日期</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black; 
  border-right :1.0pt soid black">上传用户</td></tr></table>
   <table cellpadding ="0" cellspacing ="0" style="width:890px;height:30px"><tr><td style="width:80px;height:30px;border-bottom :
 1.0pt solid black; border-left :1.0pt solid black;" >供应商代码</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;
  ">文档类型</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;">文档工厂</td><td style="width:80px;height:30px;
 border-bottom :1.0pt solid black; border-left :1.0pt solid black;">文档状态</td><td style="width:170px;height:30px;border-bottom :1.0pt solid black; 
 border-left :1.0pt solid black;">文档条码</td> ><td style="width:50px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;">起始</td>
 <td style="width:50px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;">结束</td><td  style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :
1.0pt solid black;">上传日期</td><td style="width:80px;height:30px;border-bottom :1.0pt solid black; border-left :1.0pt solid black;border-right :1.0pt soid black"
>上传用户</td></tr></table></div>
   
   <div style="width:600px;height:90px"><table cellpadding ="0" cellspacing ="0" style="width:600px;height:30px"><tr><td style="  text-align :center ; background-color :Green; border-bottom : 1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black; border-top :1.0pt solid black  ">供应商状态</td></tr>
   </table><table cellpadding ="0" cellspacing ="0"><tr><td style="width:120px; height:30px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;">工厂</td><td style="width:110px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;">供应商代码</td><td style="width:300px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;">供应商名称</td><td style="width:70px; border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;">状态</td></tr></table>
   <table cellpadding ="0" cellspacing ="0"><tr><td style="width:120px; height:30px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;"></td><td style="width:110px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;"></td><td  style="width:300px; border-bottom :1.0pt solid black; border-left :1.0pt solid black;"></td><td style="width:70px; border-bottom :1.0pt solid black; border-left :1.0pt solid black; border-right :1.0pt solid black;"></td></tr></table></div><p></p><p></p>
        
       


        <asp:ScriptManager ID="ScriptManager1" runat="server">  
        </asp:ScriptManager>  
        <asp:Panel ID="Panel1" runat="server" Height="167px" Width="190px"　BackColor="#d0F7DE">  
            <br />  
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="137px">  
                <asp:ListItem>看书</asp:ListItem>  
                <asp:ListItem>上网</asp:ListItem>  
                <asp:ListItem>洗衣服</asp:ListItem>  
                <asp:ListItem>出去玩</asp:ListItem>  
            </asp:RadioButtonList>  
            <asp:Button ID="Button2" runat="server" Text="确定" OnClick ="Button2_Click"  />  
           <asp:Button ID="Button3" runat="server" Text="取消" onclick="Button3_Click" />  
           </asp:Panel>  


           <asp:Panel ID="Panel3" runat="server" CssClass ="panel1" BackColor="#CCCCCC" 
            BorderColor="#333333" BorderWidth="1px" style="display:none">
            <table style="height:25px;width:300px" cellpadding ="0" cellspacing ="0" >
            <tr>
            <td style="height:25px; background-color :#666633; font-size:medium  ; text-align :center">有效期编辑</td></tr>
            </table>
            <table cellpadding ="0" cellspacing ="0" style="height:175px;width:300px" >
            <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                <asp:Label ID="Label16" runat="server" Text="供应商代码:" Font-Size ="Small" ></asp:Label>
                </td><td style="width:150px; height:30px">
                    <asp:Label ID="Label17" runat="server" Text="Label" Font-Size ="Small"></asp:Label></td >
                <td style="width:50px; height:30px"> <asp:Label ID="Label25" runat="server" Text="Label" Visible="False"></asp:Label></td></tr>
             <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                 <asp:Label ID="Label18" runat="server" Text="文档类型:" Font-Size ="Small"></asp:Label>
                 </td><td style="width:150px; height:30px">
                     <asp:Label ID="Label19" runat="server" Text="Label" Font-Size ="Small"></asp:Label>
                 </td>
                  <td style="width:50px; height:30px"> </td></tr>
              <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                  <asp:Label ID="Label20" runat="server" Text="文档工厂:" Font-Size ="Small"></asp:Label>
                  </td><td style="width:150px; height:30px">
                      <asp:Label ID="Label21" runat="server" Text="Label" Font-Size ="Small"></asp:Label>
                  </td> <td style="width:50px; height:30px"></td></tr>
               <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                   <asp:Label ID="Label22" runat="server" Text="起始日期:" Font-Size ="Small"></asp:Label>
                   </td><td style="width:150px; height:30px">
                       <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                      
                   </td> <td style="width:50px; height:30px"> <asp:Image ID="Image3" runat="server" ImageUrl="~/pic/datePicker.gif" /></td></tr>
                <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                    <asp:Label ID="Label24" runat="server" Text="结束日期:" Font-Size ="Small"></asp:Label>
                    </td><td style="width:150px; height:30px">
                        <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>
                       
                    </td> <td style="width:50px; height:30px"><asp:Image ID="Image5" runat="server" ImageUrl="~/pic/datePicker.gif" /></td></tr>
                 <tr><td style="width:10px;height:25px"></td><td style="width:90px; height :25px">
                     <asp:Button id="Button4"  style="width:80px" 
                         runat="server" Text="确定" />
                     </td><td style="width:150px; height:25px">
                         <asp:Button id="Button5"  style="width:80px" 
                             runat="server" Text="取消" 
                               />
                     </td><td style="width:50px; height:25px"></td></tr>
            </table>
           </asp:Panel>
       <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  
         TargetControlID="Button1"  
         PopupControlID="Panel3"  
         DropShadow="true"       
         OkControlID="Button4"     
         CancelControlID="Button5"          
         Drag="true"  
         BackgroundCssClass="bgcss"  
         
         >  
        </cc1:ModalPopupExtender>  
            <asp:Panel ID="Panel2" runat="server" Height="83px" Width="187px">  
            今天都要做些什么？<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />  
            <asp:Button ID="Button1" runat="server" Text="查看" />  
</asp:Panel>  
    </div>  
</form>  
</body>  
</html>  


