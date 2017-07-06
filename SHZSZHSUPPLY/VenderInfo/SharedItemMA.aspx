<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SharedItemMA.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.SharedItemMA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" >
    .body
    {
        width:1000px;
        height:auto;
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
        
     }
     
     .rightdiv
     {
         width:990px;
         float:right;
       
     }
     
     .div1
     {
         width:400px;
         float:left;
     }
     
     .div2
     {
         width:590px;
         float:right;
     }
     
   .bgcss  
    {  
      background-color:Gray;  
      filter:alpha(opacity=90);
	  opacity:0.8;
        
   }  

      .panel1
   
   {
       width:300px;
       height:230px;
     
   }
 
     
        </style>
</head>
<body class ="body" onload ="IFrameResize()" >

    <form id="form1" runat="server" class ="body" >
    
   <div class="style1" style=" font-size :medium ; color :White; text-align :center; background-color :#666633"  >  
   

  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       供应商文档删除</div>
 <div class="leftdiv" style="height:25px" ></div>
 
 <div class="rightdiv" style="height:25px">
    
     <table cellpadding ="0" cellspacing ="0" class="rightdiv" style="height:25px">
 <tr>
 <td style="width:5% ; font-size :small; font-family :Arial ">工厂:</td>
 <td style="width:10%">
     <asp:DropDownList ID="DropDownList1" runat="server" style="width:90%" 
            Enabled="False">
            <asp:ListItem>上海科勒</asp:ListItem>
            <asp:ListItem>中山科勒</asp:ListItem>
            <asp:ListItem>珠海科勒</asp:ListItem>
            <asp:ListItem>无</asp:ListItem>
     </asp:DropDownList>
     </td>
  
 <td style="width:8% ; font-size :small; font-family :Arial ">供应商代码：</td>
 <td style="width:9%">
     <asp:DropDownList ID="DropDownList2" runat="server" Width ="80%" 
         AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
     </asp:DropDownList>
     </td>
 <td style="width:8%;font-size :small; font-family :Arial">供应商名称：</td>
 <td style="width:32%; font-size :small; font-family :Arial ">
     <asp:Label ID="Label1" runat="server" Text="Label" Width ="90%"></asp:Label>
     </td>
     <td style=" width :1%; font-size :small">&nbsp;</td>
        <td style="width:15%">
            <asp:DropDownList ID="DropDownList3" runat="server" style="width:90%" 
                Enabled="False" Visible="False">
            </asp:DropDownList>
     </td>

 <td style="width:8%">
     <asp:Button ID="Button1" runat="server" Text="确定" Width="80px" 
         onclick="Button1_Click1" />
     </td></tr></table>
  
 
 </div>
  
 <div class="leftdiv" style="height:150px"></div>
  

  
 <div class="div1" style ="height:150px; font-size :small ">
 
    
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" 
            Width ="400px" CellPadding="4" ForeColor="#333333" GridLines="None" 
             onrowcommand="GridView5_RowCommand" onrowdeleting="GridView5_RowDeleting" 
            
          >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="vender_code" HeaderText="供应商代码" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="vender_name" HeaderText="供应商名称" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:ButtonField CommandName="delete" HeaderText="删除" Text="删除">
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="change" HeaderText="编辑" Text="编辑">
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" HorizontalAlign="Left" />
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

         <asp:Panel ID="Panel3" runat="server" CssClass ="panel1" BackColor="#CCCCCC" 
            BorderColor="#333333" BorderWidth="1px" style="display:none   " >
            <table style="height:25px;width:300px" cellpadding ="0" cellspacing ="0" >
            <tr>
            <td style="height:25px; width :300px; background-color :#666633; font-size:medium  ; text-align :center">供应商名称变更</td></tr>
            </table>
            <table cellpadding ="0" cellspacing ="0" style="height:175px;width:300px" >
            <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                <asp:Label ID="Label16" runat="server" Text="供应商代码:" Font-Size ="Small" ></asp:Label>
                </td><td style="width:150px; height:30px">
                  <asp:TextBox ID="TextBox1" runat="server" Width ="100%"></asp:TextBox> </td >
                
                <td style="width:50px; height:30px"> <asp:Label ID="Label25" runat="server" Text="Label" Visible ="False" ></asp:Label></td></tr>
             <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                 <asp:Label ID="Label18" runat="server" Text="供应商名称:" Font-Size ="Small"></asp:Label>
                 </td><td style="width:150px; height:30px">
                     <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                 </td>
                 </tr>
                <tr><td style="width:10px;height:30px"></td><td style="width:90px; height :30px">
                  <asp:Label ID="Label13" runat="server" Text="Label" Visible ="False"></asp:Label></td><td style="width:150px; height:30px">
                        &nbsp;</td> <td style="width:50px; height:30px">&nbsp;</td></tr>
                 <tr><td style="width:10px;height:25px"></td><td style="width:90px; height :25px">
                     <asp:Button id="Button4"  style="width:80px" 
                         runat="server" Text="确定" OnClick ="vendersave" />
                     </td><td style="width:150px; height:25px">
                         <asp:Button id="Button5"  style="width:80px" 
                             runat="server" Text="取消" 
                               />
                     </td><td style="width:50px; height:25px"></td></tr>
            </table>
           </asp:Panel>
    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White">[LinkButton]</asp:LinkButton>
    
     <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
        BackgroundCssClass="bgcss" CancelControlID="Button5" Drag="True" 
        PopupControlID="Panel3" TargetControlID="LinkButton1">


    </cc1:ModalPopupExtender>
     


     


    
   
 
 
 </div>


 <div class="div2" style="height:150px">
    
    
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            Width ="590px" CellPadding="4" ForeColor="#333333" GridLines="None" 
          onrowdeleting="GridView4_RowDeleting" 
          >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="vender_code" HeaderText="供应商代码" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="vender_name" HeaderText="供应商名称" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="plant_name" HeaderText="工厂" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="vender_type" HeaderText="类型">
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:BoundField DataField="vender_state" HeaderText="供应商状态" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
                </asp:BoundField>
                <asp:ButtonField CommandName="delete" HeaderText="删除" Text="删除">
                <HeaderStyle Font-Size="Small" HorizontalAlign="Left" />
                <ItemStyle Font-Size="Small" />
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
    
          
  
     

    
    </div>
  
  
    <div class="rightdiv" style="height:100%"><table cellpadding ="0" cellspacing ="0"><tr><td class="rightdiv1"  style=" font-size :small; height :20px ">已上传文档清单：<asp:Label 
            ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
        </td></tr></table></div>
    <div class="leftdiv" style="height:100%"></div>
    <div class="rightdiv" style="height:100%">
        
         <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width ="990px" 
            CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Left" onrowdeleting="GridView3_RowDeleting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Vender_Code" HeaderText="供应商代码" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="Item_Path_Absolute" 
                    DataNavigateUrlFormatString="../ItemListPdf/ItemListPdf.aspx?id={0}" 
                    DataTextField="Item_Category" HeaderText="文档类型" Target="_blank">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="Item_Path" HeaderText="文档路径" Visible="False" />
                <asp:BoundField DataField="Item_Plant" HeaderText="文档工厂" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_State" HeaderText="文档状态" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Label" HeaderText="文档条码" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Startdate" HeaderText="起始" 
                    DataFormatString="{0:yyyy/MM/dd}" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Enddate" HeaderText="结束" 
                    DataFormatString="{0:yyyy/MM/dd}" >
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
                <asp:BoundField DataField="Item_Comment" HeaderText="备注" Visible="False">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="item_vendertype" HeaderText="文档供应商" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:ButtonField CommandName="delete" HeaderText="删除" Text="删除">
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
   
        
        
    </div>
    
  <script type ="text/javascript" >
      function IFrameResize() {

          //alert(this.document.body.scrollHeight); //弹出当前页面的高度  
          var obj = parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
          //alert(obj.height); //弹出父页面中IFrame中设置的高度

         
              obj.height = this.document.body.scrollHeight + "px";  //调整父页面中IFrame的高度为此页面的高度  
         
      }  
</script>  
   

  
    
   

  
 </form>

  </body>




</html>
