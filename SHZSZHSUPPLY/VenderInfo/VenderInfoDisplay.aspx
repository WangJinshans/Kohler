<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderInfoDisplay.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderInfoDisplay" EnableSessionState ="True"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" >
    .body
    {
        width:1000px;
        height:auto;
        margin :0 auto;
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
         width:300px;
         float:left;
     }
     
     .div2
     {
         width:690px;
         float:right;
     }
     
   

     
 
     
        </style>
</head>
<body class ="body" onload ="IFrameResize()" id="document1"   >
    <form id="form1" runat="server" class ="body" >
    <div class ="body" >
   <div class="style1" style=" font-size :medium ; color :White; text-align :center; background-color :#666633"  >供应商信息</div>
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
 <div class="div1" style ="height:150px; font-size :small ">供应商工厂：</div>
 <div class="div2" style="height:150px">
    
    
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            Width ="690px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
 
  
    <div class="rightdiv" style="height:100%"><table cellpadding ="0" cellspacing ="0"><tr><td class="rightdiv1"  style=" font-size :small; height :20px ">已上传文档清单：</td></tr></table></div>
    <div class="leftdiv" style="height:100%"></div>
    <div class="rightdiv" style="height:100%">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width ="990px" 
            CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" 
            HorizontalAlign="Left">
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
                <asp:BoundField DataField="Item_Name" HeaderText="文档名称" Visible="False" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
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
                <asp:BoundField DataField="LastEdit_Date" HeaderText="最近编辑日期" Visible="False" />
                <asp:BoundField DataField="LastEdit_Person" HeaderText="最近编辑用户" 
                    Visible="False" />
                <asp:BoundField DataField="item_vendertype" HeaderText="文档供应商" >
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Item_Comment" HeaderText="备注" Visible="False">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
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
    </div>

  <script type ="text/javascript" >
      function IFrameResize() {

         
          var obj = parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
          //alert(obj.height); //弹出父页面中IFrame中设置的高度

         
          obj.height = this.document.body.scrollHeight  + "px";  //调整父页面中IFrame的高度为此页面的高度

          
                
      }  
</script>  
  
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </div>
 </form>

  </body>




</html>
