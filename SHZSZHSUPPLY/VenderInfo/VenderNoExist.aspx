<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderNoExist.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderNoExist" EnableSessionState ="True"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css" >
    
    .body
    {
        width:1000px;
        height:100%;
        margin :0
    }
    
    .leftdiv
    {
        width:10px;
       
        float:left;
        
    }
    
    .middlediv
    {
        width:350px;
       
        float:left;
    }
    
    .rightdiv
    {
        width:640px;
       
        float:right;
    }
    
    .rightdiv1
    {
        width:990px;
        float:right;
    }
    
    .table
    {
        width:350px;
        height:25px;
        
    }
    
    </style>
</head>
<body class="body" onload ="IFrameResize()" >


    <form id="form1" runat="server" class="body">

     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" 
        PopupButtonID="Image1" TargetControlID="TextBox1" Format="yyyy-MM-dd">
</cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled ="True"
     PopupButtonID="Image2" TargetControlID="TextBox2" Format="yyyy-MM-dd">
    </cc1:CalendarExtender>
 <div class="leftdiv" style="height:100px"></div>
 <div class="middlediv" style="height:100px">
 <table cellpadding ="0" cellspacing ="0" class="div1" style="height:100px">
 <tr><td class ="middlediv" style=" font-size :small; font-family :Arial ">供应商-工厂：</td></tr></table></div>
 <div class="rightdiv" style="height:100px">
     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
     <ContentTemplate >
      <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" 
          CssClass ="rightdiv" >
         <AlternatingRowStyle BackColor="White" Width="540px"  />
         <Columns>
             <asp:BoundField HeaderText="代码" DataField="vender_code">
             <HeaderStyle HorizontalAlign="Left" Width="80px" />
             <ItemStyle HorizontalAlign="Left" Width="80px" />
             </asp:BoundField>
             <asp:BoundField HeaderText="供应商名称" DataField="vender_name">
             <HeaderStyle HorizontalAlign="Left" Width="150px" />
             <ItemStyle HorizontalAlign="Left" Width="150px" />
             </asp:BoundField>
             <asp:BoundField HeaderText="工厂" DataField="plant_name">
             <HeaderStyle HorizontalAlign="Left" Width="100px" />
             <ItemStyle HorizontalAlign="Left" Width="80px" />
             </asp:BoundField>
             <asp:BoundField HeaderText="类型" DataField="vender_type">
             <HeaderStyle HorizontalAlign="Left" />
             <ItemStyle Width="150px" />
             </asp:BoundField>
             <asp:BoundField DataField="vender_state" HeaderText="状态">
             <HeaderStyle HorizontalAlign="Left" Width="50px" />
             <ItemStyle HorizontalAlign="Left" Width="50px" />
             </asp:BoundField>
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
     </ContentTemplate>
     <Triggers ><asp:AsyncPostBackTrigger ControlID = "GridView2" />
     <asp:PostBackTrigger ControlID ="Button1" /></Triggers>
     </asp:UpdatePanel>
    
    </div>
  <div class="leftdiv" style="height:25px"></div>
  <div class="middlediv" style="height:25px">
  <table  cellpadding ="0" cellspacing ="0" class="middlediv" style="height:25px">
  <tr><td style=" font-size :small; font-family :Arial  ">上传文档</td></tr></table></div>
  <div class="rightdiv" style="height:25px">
  <table cellpadding ="0" cellspacing ="0" class="rightdiv" style="height:25px">
  <tr><td style=" font-size :small">必选文档</td></tr></table></div>
    <div class="leftdiv" style="height:550px"></div>
    <div class="middlediv" style="height:550px">
    <table class="middlediv" cellpadding ="0" cellspacing ="0">
       <tr>
    <td style="width:90px; height:25px; font-size :small" >工厂:</td>
    <td style="width:180px; height:25px;font-size :small">
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </td>
          <td style="width:30px; height:25px"></td>
    </tr>
    <tr>
    <td style="width:30%; height:25px; font-size :small" >供应商代码:</td>
    <td style="width:60%; height:25px;font-size :small">
        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
        </td>
          <td style="width:10%; height:25px">&nbsp;</td>
    </tr>
    <tr>
    <td style="width:30%; height:25px; font-size :small; font-family :Arial " >供应商类型:</td>
    <td style="width:60%; height:25px;font-size :small">
        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
        </td>
          <td style="width:10%; height:25px"></td>
    </tr>
    <tr>
    <td style="width:30%; height:25px; font-size :small; font-family :Arial " >上传用户:</td>
    <td style="width:60%; height:25px;font-size :small">
        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
        </td>
          <td style="width:10%; height:25px"></td>
    </tr>
    <tr>
    <td style="width:90px; height:25px; font-size :small" >文档类型:</td>
    <td style="width:180px; height:25px">
        <asp:DropDownList ID="DropDownList1" runat="server" style="width:180px;  " 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        </td>
          <td style="width:30px; height:25px"></td>
    </tr>
    
      
 
    <tr>
    <td style="width:30%; height:25px; font-size :small">文档需求:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label1" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>

      <tr>
     <td style="width:30%; height:25px; font-size :small">有效期需求:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label3" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
      <tr>
     <td style="width:30%; height:25px; font-size :small">起始日期:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:TextBox ID="TextBox1" runat="server" Width ="60%"></asp:TextBox>

        </td>
        <td style="width:10%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/pic/datePicker.gif" />
          </td>
    </tr>
         <tr>
     <td style="width:30%; height:25px; font-size :small">结束日期:</td>
      <td style=" width:60%; height:25px; font-size :small">
       
            <asp:TextBox ID="TextBox2" runat="server" Width="60%"></asp:TextBox>
       
       
           

              </td>
        <td style="width:10%">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/pic/datePicker.gif" />
             </td>
    </tr>
        <tr>
     <td style="width:30%; height:25px; font-size :small">条码需求:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label4" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
           <tr>
     <td style="width:90px; height:25px; font-size :small">文档条码:</td>
    <td style=" width:180px; height:25px; font-size :small">
        <asp:Label ID="Label5" runat="server" Text="Label" Width ="180px"></asp:Label>
        </td>
          <td style="width:30px"></td>
    </tr>
               <tr>
     <td style="width:30%; height:25px; font-size :small">通知需求:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label6" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
                 <tr>
     <td style="width:30%; height:25px; font-size :small">提前通知时间:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label7" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
                   <tr>
     <td style="width:30%; height:25px; font-size :small">一级通知时间:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label8" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
                   <tr>
     <td style="width:30%; height:25px; font-size :small">二级通知时间:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label9" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
                   <tr>
     <td style="width:30%; height:25px; font-size :small">三级通知时间:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label10" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
                     <tr>
     <td style="width:30%; height:25px; font-size :small">工厂共享:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label11" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>

                        <tr>
     <td style="width:30%; height:25px; font-size :small">类型共享:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label16" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>

                     <tr>
     <td style="width:30%; height:25px; font-size :small">所属工厂:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label12" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>

    <tr>
     <td style="width:30%; height:25px; font-size :small">所属类型:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:Label ID="Label17" runat="server" Text="Label" Width ="60%"></asp:Label>
        </td>
          <td style="width:10%"></td>
    </tr>
     <tr>
     <td style="width:30%; height:25px; font-size :small">备注:</td>
    <td style=" width:60%; height:25px; font-size :small">
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </td>
          <td style="width:10%">&nbsp;</td>
    </tr>
        </table>

        <table class="middlediv" cellpadding ="0" cellspacing ="0">
     
        <tr>
        <td style="width:80%; height:25px">

         

        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
        <td>
              
               <asp:Button ID="Button1" runat="server" Text="上传" width="100%" 
                onclick="Button1_Click"/>
                        
            </td></tr>
           
            
            </table>
    </div>
    <div class="rightdiv" style="height:550px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" Font-Size="Small" 
            ShowHeaderWhenEmpty="True" CssClass ="rightdiv" GridLines="None" 
            HorizontalAlign="Left" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="资料类型" DataField="Item_category" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" Width="180px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="必选" DataField="Item_option" Visible="False" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="上传" DataField="Item_upload" Visible="False" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="有效期" DataField="Item_valid" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="条码" DataField="Item_label" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="通知" DataField="Item_notify" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="50px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="提前通知" DataField="Item_notify_month" 
                    Visible="False" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="75px" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Plant_All" HeaderText="工厂共享" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_VenderType_All" HeaderText="类型共享">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:ImageField   ControlStyle-Height ="20px" ControlStyle-Width ="20px" HeaderText="完成状态" ReadOnly="True" 
                    DataImageUrlField="Item_FinishedstateUrl" NullImageUrl="~/pic/unfinished.png" ControlStyle-BorderWidth ="0"  >
<ControlStyle BorderWidth="0px" Height="20px" Width="20px"></ControlStyle>

                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Font-Size="Small" Height="20px" 
                        Width="100px" />
                </asp:ImageField>
                <asp:BoundField DataField="Item_Notify_Day_After_First" HeaderText="通知一" 
                    Visible="False" />
                <asp:BoundField DataField="Item_Notify_Day_After_Second" HeaderText="通知二" 
                    Visible="False" />
                <asp:BoundField DataField="Item_Notify_Day_After_Third" HeaderText="通知三" 
                    Visible="False" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </ContentTemplate>
        <Triggers >
        <asp:PostBackTrigger ControlID ="Button1" />
        <asp:AsyncPostBackTrigger ControlID ="Gridview2" />
        </Triggers>
        </asp:UpdatePanel>


    
    </div>
    <div class="leftdiv" style="height:20px"></div>
    <div class="rightdiv1" style="height:20px"><table cellpadding ="0" cellspacing ="0"><tr><td class="rightdiv1"  style=" font-size :small; height :20px ">已上传文档清单</td></tr></table></div>
  <div class="leftdiv" style="height:100%"></div>
    <div class="rightdiv1" style="height:100%">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate >
         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"  
            CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" width="990px"
            HorizontalAlign="Left" onrowdeleting="GridView2_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Vender_Code" HeaderText="供应商代码" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="Item_Path_Absolute" 
                    DataTextField="Item_Category" HeaderText="文档类型" 
                    
                    
                    DataNavigateUrlFormatString="../ItemListPdf/ItemListPdf.aspx?id={0}" 
                    Target="_blank"  >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="Item_Path" HeaderText="文档路径" Visible="False" >
                <ItemStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Plant" HeaderText="文档工厂" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_State" HeaderText="文档状态" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Label" HeaderText="文档条码" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Startdate" HeaderText="起始" DataFormatString="{0:yyyy/MM/dd}"  HtmlEncode ="false" 
                   
                    >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Enddate" HeaderText="结束" DataFormatString="{0:yyyy/MM/dd}"  HtmlEncode ="false" 
                    >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Upload_Date" HeaderText="上传日期" 
                    DataFormatString="{0:yyyy/MM/dd}" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Upload_Person" HeaderText="上传用户" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Comment" HeaderText="备注" Visible="False" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="item_vendertype" HeaderText="文档供应商" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:ButtonField HeaderText="删除" Text="删除" CommandName="delete" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:ButtonField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </ContentTemplate>
        <Triggers >
        <asp:PostBackTrigger ControlID ="Button1" /></Triggers>
        </asp:UpdatePanel>
       
    </div>
          

   

    </form>

    <script type ="text/javascript" >
        function IFrameResize() {

            //alert(this.document.body.scrollHeight); //弹出当前页面的高度  
            var obj = parent.parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
            //alert(obj.height); //弹出父页面中IFrame中设置的高度  
            
            obj.height = this.document.body.scrollHeight+50+"px";  //调整父页面中IFrame的高度为此页面的高度

            var obj1 = parent.document.getElementById("iFrame1");

            obj1.height = this.document.body.scrollHeight + "px";

         
           

        }  
</script>  
    


</body>

</html>

