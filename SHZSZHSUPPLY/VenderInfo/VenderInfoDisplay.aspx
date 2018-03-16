<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VenderInfoDisplay.aspx.cs" Inherits="SHZSZHSUPPLY.VenderInfo.VenderInfoDisplay" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="renderer" content="webkit" />
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="../VendorAssess/Script/layui/layui.js" type="text/javascript"></script>
    <script src="../VendorAssess/Script/Own/fileUploader.js" type="text/javascript"></script>
    <style type="text/css">
        .body {
            width: 1000px;
            height: auto;
            margin: 0 auto;
            text-align: center;
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
            width: 300px;
            float: left;
        }

        .div2 {
            width: 690px;
            float: right;
        }
    </style>
    <script type="text/javascript">

        var tempVendor, factorys;
        var vendorInfo = {};

        layui.use(['form'], function () {
            var form = layui.form();

            form.on('select', function (data) {
                onSelect(data);
            })
        });

        function setParameters(factoryName, info) {
            factorys = factoryName;
            vendorInfo = info;
            document.getElementById("FactoryDropDownList").value = factoryName;
            document.getElementById("FactoryDropDownList").disabled = true;
            var vendorcoldlists = document.getElementById("VendorCodeDropDownList");
            var names = JSON.parse(vendorInfo);
            if (names == null || !names.length > 0) {
                return;
            }
            else {
                for (var code in names) {
                    vendorcoldlists.options.add(new Option(names[code], names[code]));
                }
            }
            refreshSelect();
        }


        function refreshSelect() {
            layui.use(['form'], function () {
                var form = layui.form();
                form.render('select');
            });
        }

        function onSelect(data) {
            switch (data.elem.id) {
                case 'FactoryDropDownList':
                    onFactoryChanged();
                    break;
                case 'VendorCodeDropDownList':
                    onVendorChanged();
                    break;
            }
        }
        function onFactoryChanged() {
            var vendorcoldlist = document.getElementById("VendorCodeDropDownList");
            vendorcoldlist.options.add(new Option('直接选择或搜索选择', ''));
        }

        function initVendorCodeList(vendorInfos) {
            var vendorcoldlista = document.getElementById("VendorCodeDropDownList");
            var names = JSON.parse(vendorInfos);
            if (names == null || !names.length > 0) {
                return;
            }
            else {
                for (var code in names) {
                    vendorcoldlista.options.add(new Option(names[code], names[code]));
                }
            }
            //refreshSelect();
        }


        function onVendorChanged() {
            //请求后台
            var code = document.getElementById("VendorCodeDropDownList").value;
            __myDoPostBack('getVendorInfo', code);
            initVendorCodeList();
        }
    </script>
</head>
<body class="body" onload="IFrameResize()" id="document1">
    <form id="form1" class="layui-form body" runat="server">
        <div class="body">
            <fieldset class="layui-elem-field layui-elem-title" style="text-align: center; margin-top: 20px; font-size: x-large;">供应商信息</fieldset>
            <div class="layui-form-item">
                <div class="layui-inline">
                    <label class="layui-form-label" style="text-align: center">工厂：</label>
                    <div class="layui-input-inline">
                        <select id="FactoryDropDownList" runat="server" style="width: 100px; height: 30px; text-align: center; line-height: 30px;" disabled="disabled">
                            <option>上海科勒</option>
                            <option>中山科勒</option>
                            <option>珠海科勒</option>
                        </select>
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label" style="width: 90px; text-align: center">供应商代码：</label>
                    <div class="layui-input-inline">
                        <select id="VendorCodeDropDownList" runat="server" lay-search="" style="width: 100px; height: 30px; line-height: 30px;"></select>
                    </div>
                </div>
                <div class="layui-inline">
                    <label class="layui-form-label" style="width: 90px; text-align: center">供应商名称：</label>
                    <div class="layui-input-inline">
                        <label class="layui-form-label" id="vendorName" runat="server" layui-filter="vendor_Name" style="width: 150px;"></label>
                    </div>
                </div>
            </div>

        </div>
        <div style="width: 1000px; height: auto; margin: 0 auto;">
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False"
                Width="1000px" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="vender_code" HeaderText="供应商代码">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vender_name" HeaderText="供应商名称">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="plant_name" HeaderText="工厂">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vender_type" HeaderText="类型">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="vender_state" HeaderText="供应商状态">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />

                 <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                 <HeaderStyle BackColor="#4e79a5" Font-Bold="true" ForeColor="White"/>
                 <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                 <SortedAscendingCellStyle BackColor="#FEFCEB" />
                 <SortedAscendingHeaderStyle BackColor="#AF0101" />
                 <SortedDescendingCellStyle BackColor="#F6F0C0" />
                 <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
        </div>
        <fieldset class="layui-elem-field layui-elem-title" style="text-align: center; margin-top: 20px; font-size: x-large;">已上传文档清单：</fieldset>
        <div>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="1000px"
                CellPadding="4" ForeColor="#333333" GridLines="None"
                HorizontalAlign="Left">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Vender_Code" HeaderText="供应商代码">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="Item_Path_Absolute"
                        DataNavigateUrlFormatString="../ItemListPdf/ItemListPdf.aspx?id={0}"
                        DataTextField="Item_Category" HeaderText="文档类型" Target="_blank">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="Item_Name" HeaderText="文档名称" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Path" HeaderText="文档路径" Visible="False" />
                    <asp:BoundField DataField="Item_Plant" HeaderText="文档工厂">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_State" HeaderText="文档状态">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Label" HeaderText="文档条码">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Startdate" HeaderText="起始"
                        DataFormatString="{0:yyyy/MM/dd}">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Enddate" HeaderText="结束"
                        DataFormatString="{0:yyyy/MM/dd}">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Upload_Date" HeaderText="上传日期"
                        DataFormatString="{0:yyyy/MM/dd}">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Upload_Person" HeaderText="上传用户">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LastEdit_Date" HeaderText="最近编辑日期" Visible="False" />
                    <asp:BoundField DataField="LastEdit_Person" HeaderText="最近编辑用户"
                        Visible="False" />
                    <asp:BoundField DataField="item_vendertype" HeaderText="文档供应商">
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item_Comment" HeaderText="备注" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>

        <script type="text/javascript">
            function IFrameResize() {
                var obj = parent.document.getElementById("iFrame1");  //取得父页面IFrame对象  
                obj.height = this.document.body.scrollHeight + "px";  //调整父页面中IFrame的高度为此页面的高度
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
