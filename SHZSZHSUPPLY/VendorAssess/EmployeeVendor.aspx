<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeVendor.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="AendorAssess.EmployeeVendor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <title></title>

    <style>
        .url-enable {
            color: dodgerblue;
            text-decoration: underline;
        }

        .url-disable {
        }
    </style>

    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js?v=9"></script>
    <script>
        window.onload = function () {
            blockBack();
        }

        layui.use(['form', 'layedit', 'laydate', 'element'], function () {
            var form = layui.form()
            , layer = layui.layer
            , layedit = layui.layedit
            , laydate = layui.laydate
            , element = layui.element();

            //监听
            form.on('select', function (data) {
                onSelect(data);
            });
        });
        function onSelect(data) {

            switch (data.elem.id) {
                case 'factory':
                    onFactorySelectChanged();
                    break;
                case 'type':
                    onVendorTypeSelectChanged();
                    break;
                case 'name':
                    currentFactory = document.getElementById('factory').selectedIndex;
                    currentType = document.getElementById('type').selectedIndex;
                    currentName = document.getElementById('name').selectedIndex;
                    storageParams();
                    __myDoPostBack('refreshVendor', document.getElementById('name').value);
                    break;
                default:
                    break;
            }
        }

        function fireRefresh() {
            document.getElementById("<%= btnRefresh.ClientID %>").click();
            //__myDoPostBack('refreshVendor', document.getElementById('name').value);
        }
    </script>
    <script>
        var vendorInfoJson = {};

        function getParams() {
            this.vendorInfoJson = JSON.parse(localStorage.getItem('infoJson'));
            document.getElementById('factory').selectedIndex = localStorage.getItem('factory');
            document.getElementById('type').selectedIndex = localStorage.getItem('type');
            onVendorTypeSelectChanged();
            document.getElementById('name').selectedIndex = localStorage.getItem('name');
        }

        function setParams(infoJson) {
            this.vendorInfoJson = JSON.parse(infoJson);
            localStorage.setItem('infoJson', infoJson);
        }

        function storageParams() {
            localStorage.setItem('factory', currentFactory);
            localStorage.setItem('type', currentType);
            localStorage.setItem('name', currentName);
        }

        function onFactorySelectChanged() {
            var factorySelect = document.getElementById('factory');
            var typeSelect = document.getElementById('type');
            var nameSelect = document.getElementById('name');

            typeSelect.selectedIndex = 0;

            nameSelect.options.length = 0;
            nameSelect.options.add(new Option('直接选择或搜索选择', ''));

            refreshForm();
        }

        function onVendorTypeSelectChanged() {
            var factorySelect = document.getElementById('factory');
            var typeSelect = document.getElementById('type');
            var nameSelect = document.getElementById('name');

            nameSelect.options.length = 0;
            nameSelect.options.add(new Option("直接选择或搜索选择", ""))

            if (typeSelect.selectedIndex == 0) {
                return;
            } else {
                var names = vendorInfoJson[factorySelect.value][typeSelect.value];
                if (names != null) {
                    for (var i = 0; i < names.length; i += 2) {
                        nameSelect.options.add(new Option(names[i], names[i + 1]));
                    }
                }
            }
            refreshForm();
        }

        function refreshForm() {
            layui.use(['form'], function () {
                var form = layui.form();
                form.render('select');
            })
        }

        function recoverSelectData() {
            document.getElementById('factory').selectedIndex = localStorage.getItem('factory');
            document.getElementById('type').selectedIndex = localStorage.getItem('type');
            onVendorTypeSelectChanged();
            var nameSelect = document.getElementById('name');

            var newName = localStorage.getItem('newName');
            //如果是从新建跳转过来
            if (newName != null && newName != '') {
                //nameSelect.value = newName;
                document.getElementById('factory').value = localStorage.getItem('newFactory');
                document.getElementById('type').value = localStorage.getItem('newType');
                nameSelect.value = localStorage.getItem('newName');
                localStorage.setItem('newName', '');
            } else {//否则为恢复现场
                nameSelect.selectedIndex = localStorage.getItem('name');
            }

            var data = { elem: nameSelect, value: nameSelect.value };
            onSelect(data);
        }
    </script>

    <script>
        //弹出询问是否签订合同的提示
        function popHT() {
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;
                layer.open({
                    content: '是否签订合同'
                    , btn: ['立即签订', '暂不签订']
                    , yes: function () {
                        __myDoPostBack('ht','YES');
                    }
                    , btn2: function () {
                        __myDoPostBack('ht', 'NO');
                    }
                })
            });
        }
    </script>
</head>
<body>
    <style></style>
    <form id="form1" class="layui-form" runat="server">
        <%--<div style="font-size: medium; width:1000px;height:20px; color: White; text-align: center; margin:0 auto; background-color: #3f6d6b">新建供应商审批文件管理</div>--%>
        <div class="layui-form-item" style="width: 1000px; margin: 0 auto">
            <a href="./index.aspx" class="layui-btn layui-btn layui-btn-small" style="float: left; margin-right: 100px; visibility: hidden">返回</a>
            <label class="layui-form-label">供应商选择</label>
            <div class="layui-input-inline">
                <select id="factory" name="quiz1" onchange="onFactorySelectChanged()">
                    <option value="">请选择工厂</option>
                    <option value="上海科勒" selected="">上海科勒</option>
                    <option value="中山科勒">中山科勒</option>
                    <option value="珠海科勒">珠海科勒</option>
                </select>
            </div>
            <div class="layui-input-inline">
                <select id="type" name="quiz2" onchange="onVendorTypeSelectChanged()">
                    <option value="">请选择供应商类型</option>
                    <option value="直接物料常规">直接物料常规</option>
                    <option value="直接物料危化品">直接物料危化品</option>
                    <option value="非生产性质量部有标准的物料">非生产性质量部有标准的物料</option>
                    <option value="非生产性危化品">非生产性危化品</option>
                    <option value="非生产性特种劳防品">非生产性特种劳防品</option>
                    <option value="非生产性常规">非生产性常规</option>
                </select>
            </div>
            <div class="layui-input-inline">
                <select id="name" name="quiz3" lay-verify="required" lay-search="">
                    <option value="">直接选择或搜索选择</option>
                    <option value="name">name</option>
                </select>
            </div>
        </div>
        <div style="width:1000px;margin:0 auto">
            <div style="width:495px;float:left">
                <fieldset class="layui-elem-field layui-field-title" style=" margin: 50px auto 20px auto;">
                    <legend id="Legend2" runat="server">待填写表格</legend>
                </fieldset>
                <asp:ScriptManager ID="scriptManager" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                <asp:UpdatePanel ID="updatePanelWaitingFill" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:GridView Style=" margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <Columns>
                                <asp:BoundField DataField="Prority" HeaderText="填写顺序"
                                    SortExpression="Prority" Visible="TRUE" />
                                <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                                    SortExpression="Temp_Vendor_ID" Visible="False" />
                                <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                                    SortExpression="Temp_Vendor_Name" />
                                <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                                    SortExpression="Form_Type_ID" Visible="False" />
                                <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                                    SortExpression="Form_Type_Name" />
                                <asp:BoundField DataField="Form_Type_Is_Optional" HeaderText="性质" NullDisplayText=""
                                    SortExpression="Form_Type_Is_Optional" />

                                <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                    SortExpression="DepotSummary" Visible="False" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton OnClientClick="waiting('正在加载')" ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                            CommandArgument='<%# Eval("Form_Type_ID")%>'>填写表格</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                            <%--<HeaderStyle BackColor="#006F83" Font-Bold="True" ForeColor="#FEFEFE" />--%>
                            <HeaderStyle BackColor="#4e79a5" Font-Bold="true" ForeColor="White"/>
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <SortedAscendingCellStyle BackColor="#FEFCEB" />
                            <SortedAscendingHeaderStyle BackColor="#AF0101" />
                            <SortedDescendingCellStyle BackColor="#F6F0C0" />
                            <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div style="width:495px;float:right">
                <fieldset id="Legend1" runat="server" class="layui-elem-field layui-field-title" style=" margin: 50px auto 20px auto;">
                    <legend>已提交表格</legend>
                </fieldset>
                <asp:GridView Style=" margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView3" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView3_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                            SortExpression="Temp_Vendor_Name" />
                        <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                            SortExpression="Form_Type_Name" />
                        <asp:BoundField DataField="Form_ID" HeaderText="表格编号" SortExpression="Form_ID" />

                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtFormStatus" runat="server" CommandName="showStatus"
                                    CommandArgument='<%# Eval("Form_ID") %>' Text='<%# Eval("Assess_Status").ToString()=="0"?"正在审批":"审批完成" %>' ForeColor='<%# Eval("Assess_Status").ToString()=="0"?System.Drawing.Color.Orange:System.Drawing.Color.Green%>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                            SortExpression="Form_Type_ID" Visible="False" />
                        <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                            SortExpression="DepotSummary" Visible="False" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick="waiting('正在加载')" ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                    CommandArgument='<%# Eval("Form_Type_ID") %>'>查看</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                    <%--<HeaderStyle BackColor="#04A5C2" Font-Bold="True" ForeColor="#FEFEFE" />--%>
                    <HeaderStyle BackColor="#3e62a7" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </div>
            <div>
                <fieldset runat="server" id="Legend3" class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
                    <legend>等待其他部门填写的表格</legend>
                </fieldset>
                <asp:GridView Style="width: 1000px; margin: 0 auto" class="layui-table" lay-even="" lay-skin="nob" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView3_RowCommand" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                    <Columns>
                        <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                            SortExpression="Temp_Vendor_Name" />
                        <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                            SortExpression="Form_Type_Name" />
                        <asp:BoundField DataField="Form_ID" HeaderText="表格编号" SortExpression="Form_ID" />

                        <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <asp:Label runat="server" Text="填写中" ForeColor="Orange"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Form_Type_ID" HeaderText="表格类型编号"
                            SortExpression="Form_Type_ID" Visible="False" />
                        <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                            SortExpression="DepotSummary" Visible="False" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton OnClientClick="waiting('正在加载')" ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                    CommandArgument='<%# Eval("Form_Type_ID") %>'>查看</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                    <FooterStyle BackColor="#FFF" ForeColor="#330099" />
                    <%--<HeaderStyle BackColor="#04A5C2" Font-Bold="True" ForeColor="#FEFEFE" />--%>
                    <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </div>
            
            <div>
                <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
                    <legend id="vendorName" runat="server">文件上传</legend>
                </fieldset>
                <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:Button runat="server" style="display:none" ID="btnRefresh" OnClick="btnRefresh_Click" />
                        <asp:GridView Style="width: 1000px; margin: 0 auto; margin-bottom: 50px;" class="layui-table" lay-even="" lay-skin="nob" ID="GridView4" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView4_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id"
                                    SortExpression="id" Visible="False" />
                                <asp:BoundField DataField="Temp_Vendor_ID" HeaderText="供应商编号"
                                    SortExpression="Temp_Vendor_ID" />
                                <asp:BoundField DataField="FileType_ID" HeaderText="文件类型编号"
                                    SortExpression="FileType_ID" />
                                <asp:TemplateField HeaderText="类型">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("File_Is_Necessary").ToString() == "TRUE" ?"必选":""%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="File_Type_Range" HeaderText="范围"
                                    SortExpression="File_Type_Range" />
                                <asp:BoundField DataField="Item_Valid" HeaderText="有效期"
                                    SortExpression="Item_Valid" />

                                <asp:TemplateField HeaderText="文件类型名称">
                                    <ItemTemplate>
                                        <asp:LinkButton Enabled='<%# Eval("Flag").ToString() == "1"?true:false %>' CssClass='<%# Eval("Flag").ToString() == "1"?"url-enable":"url-disable" %>' Text='<%# Bind("FileType_Name") %>' ID="lbFileNameDetail" runat="server" CommandName="FileDetail" CommandArgument='<%# Eval("FileType_ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                                    SortExpression="DepotSummary" Visible="False" />
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <img src="<%# Eval("Flag").ToString() == "1" ? "./Script/layui/images/check.png" : "./Script/layui/images/uncheck.png" %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="动作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtUpLoad" runat="server" CommandName='<%# Eval("Flag").ToString() == "1" ?"ReLoad" :"UpLoad" %>' CommandArgument='<%# Eval("FileType_ID") %>'><%# Eval("Flag").ToString()=="1"?"覆盖":"上传" %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <%--<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />--%>
                            <HeaderStyle BackColor="#515a6d" Font-Bold="true" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
