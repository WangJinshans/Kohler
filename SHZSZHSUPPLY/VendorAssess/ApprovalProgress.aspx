﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovalProgress.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.ApprovalProgress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="renderer" content="webkit" />
    <%--<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>--%>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />

    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js" charset="utf-8"></script>
    <script src="Script/Own/fileUploader.js?v=9"></script>
    <script>
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
                    __myDoPostBack('refreshNewVendor', document.getElementById('name').value);
                    break;
                default:
                    break;
            }
        }

        function refreshForm() {
            layui.use(['form'], function () {
                var form = layui.form();
                form.render('select');
            })
        }
    </script>
    <script>
        (function ($, h, c) {
            var a = $([]),
            e = $.resize = $.extend($.resize, {}),
            i,
            k = "setTimeout",
            j = "resize",
            d = j + "-special-event",
            b = "delay",
            f = "throttleWindow";
            e[b] = 250;
            e[f] = true;
            $.event.special[j] = {
                setup: function () {
                    if (!e[f] && this[k]) {
                        return false;
                    }
                    var l = $(this);
                    a = a.add(l);
                    $.data(this, d, {
                        w: l.width(),
                        h: l.height()
                    });
                    if (a.length === 1) {
                        g();
                    }
                },
                teardown: function () {
                    if (!e[f] && this[k]) {
                        return false;
                    }
                    var l = $(this);
                    a = a.not(l);
                    l.removeData(d);
                    if (!a.length) {
                        clearTimeout(i);
                    }
                },
                add: function (l) {
                    if (!e[f] && this[k]) {
                        return false;
                    }
                    var n;
                    function m(s, o, p) {
                        var q = $(this),
                        r = $.data(this, d);
                        r.w = o !== c ? o : q.width();
                        r.h = p !== c ? p : q.height();
                        n.apply(this, arguments);
                    }
                    if ($.isFunction(l)) {
                        n = l;
                        return m;
                    } else {
                        n = l.handler;
                        l.handler = m;
                    }
                }
            };
            function g() {
                i = h[k](function () {
                    a.each(function () {
                        var n = $(this),
                        m = n.width(),
                        l = n.height(),
                        o = $.data(this, d);
                        if (m !== o.w || l !== o.h) {
                            n.trigger(j, [o.w = m, o.h = l]);
                        }
                    });
                    g();
                },
                e[b]);
            }
        })(jQuery, this);

        $(document).ready(function () {
            $('#detailInfo').resize(function (e) {
                console.log(this.scrollHeight);
                var iframe = parent.document.getElementById("iFrame1");
                iframe.height = document.body.scrollHeight + 200 + "px";
            });
        })

    </script>
    <script>
        var vendorInfoJson = {};
        var currentFactory, currentType, currentName;

        function getParams() {
            this.vendorInfoJson = JSON.parse(localStorage.getItem('infoJson'));
            document.getElementById('factory').selectedIndex = localStorage.getItem('progressFactory') == null ? 0 : localStorage.getItem('progressFactory');
            document.getElementById('type').selectedIndex = localStorage.getItem('progressType') == null ? 0 : localStorage.getItem('progressType');
            onVendorTypeSelectChanged();
            document.getElementById('name').selectedIndex = localStorage.getItem('progressName') == null ? 0 : localStorage.getItem('progressName');
        }

        function setParams(infoJson) {
            this.vendorInfoJson = JSON.parse(infoJson);
            localStorage.setItem('infoJson', infoJson);
        }

        function storageParams() {
            localStorage.setItem('progressFactory', currentFactory);
            localStorage.setItem('progressType', currentType);
            localStorage.setItem('progressName', currentName);
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

        function recoverSelectData() {
            document.getElementById('factory').selectedIndex = localStorage.getItem('progressFactory');
            document.getElementById('type').selectedIndex = localStorage.getItem('progressType');
            onVendorTypeSelectChanged();
            var nameSelect = document.getElementById('name');

            //否则为恢复现场
            nameSelect.selectedIndex = localStorage.getItem('progressName');

            var data = { elem: nameSelect, value: nameSelect.value };
            onSelect(data);
        }

    </script>
    <script>
        function setVendorName(name) {
            document.getElementById('vendorName').innerText = name;
        }
        function setFormName(name) {
            document.getElementById('formName').innerText = name;
        }
        function setNormalInfo(info) {
            document.getElementById('normalInfoDetail').innerText = info;
        }
        function setExceptionInfo(info) {
            document.getElementById('exceptionInfoDetail').innerText = info;
        }
        function setFormProgress(percent) {
            layui.use(['element'], function () {
                var element = layui.element();
                element.progress('formProgress', percent + '%');
            });
        }
        function modifyTransfor() {
            __myDoPostBack('vendorModifyTransfer', "");
        }
    </script>

    <script>
        function openNormalCodeDialog() {
            layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.prompt({
                    title: '请输供应商代码'
                }, function (value, index, elem) {
                    //if (value.length != 6) {
                    //    layer.msg("请输入正确的编码");
                    //} else if (isNaN(value)) {
                    //    layer.msg("请输入数字");
                    //} else {
                    //    layer.msg(value);
                    //    layer.close(index);
                    //    __myDoPostBack('vendorTransfer', value);
                    //}
                    if (value.length != 0) {
                        layer.msg(value);
                        layer.close(index);
                        __myDoPostBack('vendorTransfer', value);
                    }
                });
            });
            return false;
        }
        function openTransferConditionDialog() {
            var index = layui.use(['layer'], function () {
                var layer = layui.layer;
                layer.open({
                    title: '选项',
                    content: './Html_Template/TransferComparison.aspx?v=1',
                    type: 2,
                    maxmin: true,
                    area: ['650px', '450px'],
                    shade: 0.3,
                    shadeClose: false, //点击遮罩关闭
                    btn: ['关闭窗口'],
                    yes: function (index, layero) {
                        layer.close(index);
                    },
                    cancel: function (index, layero) {
                        layer.close(index);
                    },
                    success: function (layero, index) {
                        console.log(layero, index);
                        layer.full(index);
                    }
                });
            });
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" class="layui-form" runat="server">


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

        <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
            <legend id="vendorName" runat="server">供应商名称</legend>
        </fieldset>
        <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView Style="width: 1000px; margin: 0 auto" ID="GridView3" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="0px" CellPadding="4" OnRowCommand="GridView3_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Temp_Vendor_Name" HeaderText="供应商名称"
                            SortExpression="Temp_Vendor_Name" />
                        <asp:BoundField DataField="Form_Type_Name" HeaderText="表格名称"
                            SortExpression="Form_Type_Name" />
                        <asp:BoundField DataField="Form_ID" HeaderText="表格编号" SortExpression="Form_ID" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="showForm" runat="server" CommandArgument='<%#Eval("Form_ID") %>'  HeaderText="查看表格" SortExpression="Form_ID" OnClientClick="waiting('正在加载')" >查看表格</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DepotSummary" HeaderText="DepotSummary"
                            SortExpression="DepotSummary" Visible="False" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtShowDetails" runat="server" CommandName="showDetails"
                                    CommandArgument='<%# Eval("Form_ID") %>'>详情</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                </asp:GridView>


                <fieldset class="layui-elem-field layui-field-title" style="width: 1000px; margin: 50px auto 20px auto;">
                    <legend id="formName" runat="server">表格名称</legend>
                </fieldset>
                <div id="detailInfo" class="layui-collapse" lay-filter="formDetailCollapse" style="width: 1000px; margin: 0 auto">
                    <div class="layui-colla-item">
                        <h2 class="layui-colla-title">常规进度信息</h2>
                        <div class="layui-colla-content layui-show">
                            <p id="normalInfoDetail" runat="server">
                            </p>
                        </div>
                    </div>
                    <div class="layui-colla-item">
                        <h2 class="layui-colla-title">当前文件或表格出现的问题</h2>
                        <div class="layui-colla-content layui-show">
                            <p id="exceptionInfoDetail" runat="server">
                            </p>
                        </div>
                    </div>
                </div>

                <div style="width: 500px; margin: 50px auto 30px auto; text-align: center">
                    <asp:Button ID="btnTransfer" runat="server" CssClass="layui-btn layui-btn-disabled" Enabled="false" Text="转移" ToolTip="请等待所有表格审批完毕" OnClientClick="return openTransferConditionDialog();" OnClick="btnTransfer_Click1" />
                    <%--&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp--%>
                    <asp:Button ID="btnModifyTransfer" runat="server" style="visibility:hidden;display:none" CssClass="layui-btn layui-btn-disabled" Enabled="false" Text="信息修改转移" ToolTip="请等待所有表格审批完毕" OnClientClick="return modifyTransfor();" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
