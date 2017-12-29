<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderMaintenance.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderMaintenance" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .body {
            width: 1000px;
            height: 100%;
            margin: 0 auto;
        }

        .style1 {
            width: 1000px;
            height: 20px;
            margin: 0;
        }

        .middlediv {
            width: 350px;
            float: left;
        }

        .leftdiv {
            width: 10px;
            float: left;
        }

        .rightdiv {
            width: 990px;
            float: right;
        }

        .div1 {
            width: 350px;
            float: left;
        }

        .rightdiv1 {
            width: 640px;
            float: right;
        }



        .div2 {
            width: 640px;
            float: right;
        }


        .panel1 {
            width: 300px;
            height: 230px;
        }



        .style2 {
            width: 30%;
            height: 16px;
        }

        .style3 {
            width: 60%;
            height: 16px;
        }

        .style4 {
            width: 10%;
            height: 16px;
        }

        .style5 {
            width: 90px;
            height: 34px;
        }

        .style6 {
            width: 180px;
            height: 34px;
        }

        .style7 {
            width: 30px;
            height: 34px;
        }

        .bgcss {
            background-color: Gray;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .style8 {
            width: 30%;
            height: 25px;
        }

        .style9 {
            width: 50%;
            height: 25px;
        }

        .style10 {
            width: 20%;
            height: 25px;
        }
    </style>
</head>
<body class="body" onload="IFrameResize()">
    <form id="form1" runat="server" class="body">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="style1" style="font-size: medium; color: White; text-align: center; background-color: #666633">供应商编辑</div>
        <div class="leftdiv" style="height: 25px"></div>
        <div class="rightdiv" style="height: 25px">
            <table cellpadding="0" cellspacing="0" class="rightdiv" style="height: 25px">
                <tr>
                    <td style="width: 5%; font-size: small; font-family: Arial">工厂:</td>
                    <td style="width: 10%">
                        <asp:DropDownList ID="DropDownList3" runat="server" Style="width: 90%"
                            Enabled="False">
                            <asp:ListItem>上海科勒</asp:ListItem>
                            <asp:ListItem>中山科勒</asp:ListItem>
                            <asp:ListItem>珠海科勒</asp:ListItem>
                            <asp:ListItem>无</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 8%; font-size: small; font-family: Arial">供应商代码：</td>
                    <td style="width: 9%">
                        <asp:DropDownList ID="DropDownList1" runat="server" Style="width: 90%"
                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 8%; font-size: small; font-family: Arial">供应商名称：</td>
                    <td style="width: 25%; font-size: small; font-family: Arial">
                        <asp:Label ID="Label1" runat="server" Text="Label" Width="100%"></asp:Label>
                    </td>
                    <td style="width: 8%; font-size: small">供应商类型:</td>
                    <td style="width: 15%">
                        <asp:DropDownList ID="DropDownList2" runat="server" Style="width: 90%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 8%">
                        <asp:Button ID="Button1" runat="server" Text="确定" Width="80px"
                            OnClick="Button1_Click1" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="leftdiv" style="height: 80px"></div>
        <div class="div1" style="height: 80px">
            <table cellpadding="0" cellspacing="0" class="div1" style="height: 80px">
                <tr>
                    <td style="font-size: small; font-family: Arial">供应商-工厂：.</td>
                </tr>
            </table>
        </div>
        <div class="div2" style="height: 80px">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None"
                        OnRowCommand="GridView1_RowCommand">
                        <AlternatingRowStyle BackColor="White" Width="690px" />
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
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="类型" DataField="vender_type">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="90px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="状态" DataField="vender_state">
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:ButtonField HeaderText="Enable" Text="Enable" CommandName="Enable">
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                <ItemStyle Width="50px" />
                            </asp:ButtonField>
                            <asp:ButtonField HeaderText="Disable" Text="Disable" CommandName="Disable">
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                <ItemStyle Width="50px" />
                            </asp:ButtonField>
                            <asp:ButtonField HeaderText="Hold" Text="Hold" CommandName="Hold">
                                <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                <ItemStyle Width="50px" />
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
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView2" />
                    <asp:PostBackTrigger ControlID="Button2" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
        <div class="leftdiv" style="height: 20px"></div>
        <div class="div1" style="height: 20px">
            <table cellpadding="0" cellspacing="0" class="div1" style="height: 20px">
                <tr>
                    <td style="font-size: small; font-family: Arial">上传文档：</td>
                </tr>
            </table>
        </div>
        <div class="div2" style="height: 20px">
            <table cellpadding="0" cellspacing="0" class="div2" style="height: 20px">
                <tr>
                    <td style="font-size: small; font-family: Arial">必选文档：</td>
                </tr>
            </table>
        </div>
        <div class="leftdiv" style="height: 550px"></div>
        <div class="div1" style="height: 550px">
            <table class="middlediv" cellpadding="0" cellspacing="0">


                <tr>

                    <td style="width: 90px; height: 25px; font-size: small">工厂:</td>
                    <td style="width: 180px; height: 25px; font-size: small">
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width: 30px; height: 25px"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">供应商代码:</td>
                    <td style="width: 60%; height: 25px; font-size: small">
                        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width: 10%; height: 25px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">供应商类型:</td>
                    <td style="width: 60%; height: 25px; font-size: small">
                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="width: 10%; height: 25px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="font-size: small; font-family: Arial" class="style2">上传用户:</td>
                    <td style="font-size: small" class="style3">
                        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td class="style4"></td>
                </tr>
                <tr>
                    <td style="font-size: small" class="style5">文档类型:</td>
                    <td class="style6">
                        <asp:DropDownList ID="DropDownList4" runat="server" Style="width: 180px;"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="style7"></td>
                </tr>




                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">文档需求:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label2" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>

                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">有效期需求:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label3" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>




                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">起始日期:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:TextBox ID="TextBox1" runat="server" Width="60%"></asp:TextBox>

                    </td>
                    <td style="width: 20%">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/pic/datePicker.gif" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">结束日期:</td>
                    <td style="width: 50%; height: 25px; font-size: small">





                        <asp:TextBox ID="TextBox2" runat="server" Width="60%"></asp:TextBox>




                    </td>
                    <td>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/pic/datePicker.gif" />
                    </td>
                </tr>









                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">条码需求:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label4" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">文档条码:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label5" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">通知需求:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label6" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="font-size: small" class="style8">提前通知时间:</td>
                    <td style="font-size: small" class="style9">
                        <asp:Label ID="Label7" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td class="style10"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">一级通知时间:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label8" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">二级通知时间:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label9" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">三级通知时间:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label10" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">工厂共享:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label11" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>

                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">类型共享:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label29" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">所属工厂:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label12" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">所属类型:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:Label ID="Label28" runat="server" Text="Label" Width="60%"></asp:Label>
                    </td>
                    <td style="width: 20%"></td>
                </tr>
                <tr>
                    <td style="width: 30%; height: 25px; font-size: small">备注:</td>
                    <td style="width: 50%; height: 25px; font-size: small">
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 20%">&nbsp;</td>
                </tr>
            </table>
            <table class="middlediv" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 80%; height: 25px">
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="上传" Width="80%"
                            OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>

        </div>
        <div class="div2" style="height: 550px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" Font-Size="Small"
                        ShowHeaderWhenEmpty="True" CssClass="rightdiv1" GridLines="None"
                        HorizontalAlign="Left">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField HeaderText="资料类型" DataField="Item_category">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Font-Size="Small" Width="180px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="必选" DataField="Item_option" Visible="False">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="50px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="上传" DataField="Item_upload" Visible="False">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="50px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="有效期" DataField="Item_valid">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="50px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="条码" DataField="Item_label">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="50px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="通知" DataField="Item_notify">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="50px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="提前通知" DataField="Item_notify_month"
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="75px" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Plant_All" HeaderText="工厂共享">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="item_vendertype_all" HeaderText="类型共享">
                                <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:ImageField ControlStyle-Height="20px" ControlStyle-Width="20px"
                                HeaderText="完成状态" ReadOnly="True"
                                DataImageUrlField="Item_FinishedstateUrl"
                                NullImageUrl="~/pic/unfinished.png" ControlStyle-BorderWidth="0">
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
                <Triggers>

                    <asp:AsyncPostBackTrigger ControlID="Gridview2" />
                    <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                    <asp:PostBackTrigger ControlID="Button2" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
        <div class="leftdiv" style="height: 100%"></div>
        <div class="rightdiv" style="height: 100%">
        </div>

        <div class="leftdiv" style="height: 100%"></div>
        <div class="rightdiv" style="height: 100%;margin-top:50px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="rightdiv" style="font-size: small; height: 20px">已上传文档清单：</td>
                </tr>
            </table>
        </div>
        <div class="leftdiv" style="height: 100%"></div>
        <div class="rightdiv" style="height: 100%;">



            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" style="display:none" ForeColor="White">[LinkButton]</asp:LinkButton>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" Font-Size="Small" ForeColor="#333333" GridLines="None" Width="990px"
                        HorizontalAlign="Left" OnRowDeleting="GridView2_RowDeleting">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Vender_Code" HeaderText="供应商代码">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:HyperLinkField DataNavigateUrlFields="Item_Path_Absolute"
                                DataTextField="Item_Category" HeaderText="文档类型"
                                DataNavigateUrlFormatString="../ItemListPdf/ItemListPdf.aspx?id={0}"
                                Target="_blank">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Item_Path" HeaderText="文档路径" Visible="False">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Plant" HeaderText="文档工厂">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_State" HeaderText="文档状态">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Label" HeaderText="文档条码">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Startdate" HeaderText="起始" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Enddate" HeaderText="结束" HtmlEncode="false">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Upload_Date" HeaderText="上传日期"
                                DataFormatString="{0:yyyy/MM/dd}">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Upload_Person" HeaderText="上传用户">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_Comment" HeaderText="备注" Visible="False">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="item_vendertype" HeaderText="文档供应商">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:ButtonField HeaderText="删除" Text="删除" CommandName="delete">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:ButtonField>
                            <asp:TemplateField HeaderText="编辑" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="编辑" OnClick="Edit"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
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
                    <asp:Panel ID="Panel3" runat="server" CssClass="panel1" BackColor="#CCCCCC"
                        BorderColor="#333333" BorderWidth="1px" Style="display: none">
                        <table style="height: 25px; width: 300px" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 25px; width: 300px; background-color: #666633; font-size: medium; text-align: center">有效期编辑</td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" style="height: 175px; width: 300px">
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label16" runat="server" Text="供应商代码:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:Label ID="Label17" runat="server" Text="Label" Font-Size="Small"></asp:Label></td>
                                <td style="width: 50px; height: 30px">
                                    <asp:Label ID="Label25" runat="server" Text="Label" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label18" runat="server" Text="文档类型:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:Label ID="Label19" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 50px; height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label23" runat="server" Text="文档条码:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:Label ID="Label26" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 50px; height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label20" runat="server" Text="文档工厂:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:Label ID="Label21" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 50px; height: 30px"></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label22" runat="server" Text="起始日期:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>

                                </td>
                                <td style="width: 50px; height: 30px">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/pic/datePicker.gif" /></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 30px"></td>
                                <td style="width: 90px; height: 30px">
                                    <asp:Label ID="Label24" runat="server" Text="结束日期:" Font-Size="Small"></asp:Label>
                                </td>
                                <td style="width: 150px; height: 30px">
                                    <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>

                                </td>
                                <td style="width: 50px; height: 30px">
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/pic/datePicker.gif" /></td>
                            </tr>
                            <tr>
                                <td style="width: 10px; height: 25px"></td>
                                <td style="width: 90px; height: 25px">
                                    <asp:Button ID="Button4" Style="width: 80px"
                                        runat="server" Text="确定" OnClick="Save" />
                                </td>
                                <td style="width: 150px; height: 25px">
                                    <asp:Button ID="Button5" Style="width: 80px"
                                        runat="server" Text="取消" />
                                </td>
                                <td style="width: 50px; height: 25px"></td>
                            </tr>
                        </table>
                    </asp:Panel>

                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True"
                        PopupButtonID="Image3" TargetControlID="TextBox4" Format="yyyy-MM-dd">
                    </cc1:CalendarExtender>

                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True"
                        PopupButtonID="Image5" TargetControlID="TextBox5" Format="yyyy-MM-dd">
                    </cc1:CalendarExtender>

                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                        TargetControlID="LinkButton2"
                        PopupControlID="Panel3"
                        DropShadow="false"
                        CancelControlID="Button5"
                        Drag="true"
                        BackgroundCssClass="bgcss">
                    </cc1:ModalPopupExtender>


                </ContentTemplate>


                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridView2" />
                    <asp:AsyncPostBackTrigger ControlID="Button4" />
                    <asp:AsyncPostBackTrigger ControlID="Gridview1" />
                    <asp:AsyncPostBackTrigger ControlID="Gridview4" />
                    <asp:PostBackTrigger ControlID="Button2" />
                </Triggers>




            </asp:UpdatePanel>
        </div>



        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True"
            PopupButtonID="Image1" TargetControlID="TextBox1" Format="yyyy-MM-dd">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True"
            PopupButtonID="Image2" TargetControlID="TextBox2" Format="yyyy-MM-dd">
        </cc1:CalendarExtender>











    </form>

    <script type="text/javascript">
        function IFrameResize() {

            //alert(this.document.body.scrollHeight); //弹出当前页面的高度  
            var obj = parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
            //alert(obj.height); //弹出父页面中IFrame中设置的高度  

            obj.height = this.document.body.scrollHeight + "px";  //调整父页面中IFrame的高度为此页面的高度  

        }


</script>



</body>




</html>
