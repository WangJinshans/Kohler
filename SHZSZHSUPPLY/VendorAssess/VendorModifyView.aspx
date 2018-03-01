<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorModifyView.aspx.cs" Inherits="WebLearning.KeLe.VendorModifyView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="Script/layui/css/layui.css" />
    <script src="Script/jquery-3.2.1.min.js"></script>
    <script src="Script/layui/layui.js"></script>
    <script src="Script/Own/fileUploader.js"></script>
    <style>
        body {
            margin: 0px;
            padding: 0px;
            text-align: center;
        }
        div {
            margin: 0 auto;
        }
        .btnTop {
            margin-top: 20px;
        }
        .info {
            width:300px;
        }
        .another-info {
            width:250px;
        }
        .my-btn {
            text-align:right;
            margin-right:5px;
            margin-left:0px;
        }
    </style>


    <script>
        var temp_vendor_id, factory_name;
        var vendorCode;
        var i = 1;
        layui.use('form', function () {
            var form = layui.form()
            , layer = layui.layer;
            var localStorage = window.localStorage;

            form.on('checkbox(checkboxType)', function (data) {

                
                if ((i % 2) == 0) {
                    document.getElementById("dropDiv").style.display = "block";
                    document.getElementById("newTypeLb").style.display = "block";
                }
                else {
                    document.getElementById("dropDiv").style.display = "none";
                    document.getElementById("newTypeLb").style.display = "none";
                }
                i++;


                var checkTypeSelected=document.getElementById('checkType').checked;
                if (checkTypeSelected) {
                    document.getElementById("newTypeLb").style.display = "block";
                    document.getElementById("dropDiv").style.display = "block";
                } else {
                    document.getElementById("newTypeLb").style.display = "none";
                    document.getElementById("dropDiv").style.display = "none";
                }

            });


            form.on('checkbox(switchPartOne)', function (data) {

                var checked = document.getElementById('faren').checked;
                if (checked) {
                    layer.msg('法人更改,请新建供应商！');
                    localStorage.setItem("faren", "on");
                    document.getElementById("switchLegalPerson").style.display = "none";
                } else {
                    document.getElementById("switchLegalPerson").style.display = "block";
                    faren = "off";
                    layer.msg('法人未更改');
                    localStorage.setItem("faren", "off");

                }
                //if (document.getElementById("switchLegalPerson").style.display != "block") {
                //    document.getElementById("switchLegalPerson").style.display = "none";
                //    localStorage.setItem("faren", "on");
                //    layer.msg('法人更改,请新建供应商！');
                //    //location.href = "VendorInfo.aspx";
                //}
                //else {
                //    document.getElementById("switchLegalPerson").style.display = "block";
                //    faren = "off";
                //    layer.msg('法人未更改');
                //    localStorage.setItem("faren", "off");
                //}
            });
            form.on('checkbox(workRange)', function (data) {
                var checked = document.getElementById("workRangeSwitch").checked;
                if (checked) {
                    layer.msg('营业范围变更');
                    localStorage.setItem("range", "on");
                } else {
                    range = "off";
                    localStorage.setItem("range", "off");
                }

            });
            form.on('checkbox(stock)', function (data) {
                var checked = document.getElementById("stockSwitch").checked;
                if (checked) {
                    layer.msg('股份变更');
                    localStorage.setItem("stock", "on");
                } else {
                    localStorage.setItem("stock", "off");
                }
            });
            form.on('checkbox(workPlace)', function (data) {
                var checked = document.getElementById("workPlaceSwitch").checked;
                if (checked) {
                    layer.msg('实际经营场所变更');
                    localStorage.setItem("place", "on");

                } else {
                    localStorage.setItem("place", "off");
                }
            });

            form.on('checkbox(switchPartTwo)', function (data) {
                var checked = document.getElementById("partTwoSwitch").checked;
                if (checked) {
                    layer.msg('供应商地址、电话、传真、邮箱变更');
                    localStorage.setItem("partTwo", "on");
                } else {
                    localStorage.setItem("partTwo", "off");
                }
            });
            form.on('checkbox(switchPartThree)', function (data) {
                var checked = document.getElementById("partThreeSwitch").checked;
                if (checked) {
                    layer.msg('供应商银行信息变更');
                    localStorage.setItem("partThree", "on");
                } else {
                    localStorage.setItem("partThree", "off");

                }
            });
            form.on('checkbox(switchPartFour)', function (data) {
                var checked = document.getElementById("partFourSwitch").checked;
                if (checked) {
                    layer.msg('供应商账期付款方式变更');
                    localStorage.setItem("partFour", "on");

                } else {
                    localStorage.setItem("partFour", "off");
                }
            });

        });
        function postBack() {
            vendorCode = document.getElementById("Temp_Vendor_Name").value;
            localStorage.setItem("vendorCode", vendorCode);
            __myDoPostBack("getVendorType", vendorCode);
        }

        function isChanging(temp_vendor_ID) {
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;

                layer.open({
                    title: '提示'
                    , content: '该供应商已在修改中，点击前往查看'
                    , btn: ['前往查看']
                    , yes: function (index, layero) {
                        location.href = "FileUpload.aspx?temp_vendor_id=" + temp_vendor_ID;
                        layer.close(index);
                    },
                });
            });

        }
        function showVendorInfo(jsonString) {

            //处理获取的字符串 初始化infomation div并显示
            if (jsonString != null) {
                var vendor = $.parseJSON(jsonString);
                document.getElementById("Temp_Vendor_Name").value = vendor.Temp_Vendor_Name;
                document.getElementById("vendorName").innerHTML = vendor.Temp_Vendor_Name;
                document.getElementById("vendorCode").innerHTML = vendor.Normal_Vendor_ID;
                document.getElementById("vendorType").innerHTML = vendor.Vendor_Type_ID;
                document.getElementById("purchaseMoney").innerHTML = vendor.Purchase_Amount + "  (万元)";
                document.getElementById("vendorType").innerHTML = vendor.Vendor_Type;
                document.getElementById("SH").checked = false;
                document.getElementById("ZH").checked = false;
                document.getElementById("ZS").checked = false;
                document.getElementById("vendor_Assign").checked = false;
                document.getElementById("advance_Charge").checked = false;
                document.getElementById("promise").checked = false;
                if (vendor.SH != "") {
                    document.getElementById("SH").checked = true;
                }
                if (vendor.ZH != "") {
                    document.getElementById("ZH").checked = true;
                }
                if (vendor.ZS != "") {
                    document.getElementById("ZS").checked = true;
                }

                if (vendor.Advance_Charge != "FALSE") {
                    document.getElementById("advance_Charge").checked = true;
                }
                if (vendor.Promise != "FALSE") {
                    document.getElementById("promise").checked = true;
                }
                if (vendor.Vendor_Assign != "FALSE") {
                    document.getElementById("vendor_Assign").checked = true;
                }
                localStorage.setItem("temp_vendor_id", vendor.Temp_Vendor_ID);
            } else {
                alert("很遗憾，未能查询到该供应商！");
            }
        }

        //获取类型信息
        function showVendorTypeInfo(tempVendorString) {
            document.getElementById("vendorTypeSelection").style.display = "block";
        }

        //弹出框  
        function popSelection() {
            document.getElementById("vendorCodeInput").value = localStorage.getItem("vendorCode");
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;

                layer.open({
                    title: '请填写修改选项',
                    content: 'Html_Template/VendorModifyInfo.html',
                    type: 2,
                    area: ['600px', '400px'],
                    shade: 0.3,
                    shadeClose: false, //点击遮罩关闭
                    btn: ['确定'],
                    yes: function (index, layero) {
                        var temp_vendor_id = window.localStorage.getItem("temp_vendor_id");
                        var faren = window.localStorage.getItem("faren");
                        var range = window.localStorage.getItem("range");
                        var stock = window.localStorage.getItem("stock");
                        var place = window.localStorage.getItem("place");
                        var partTwo = window.localStorage.getItem("partTwo");
                        var partThree = window.localStorage.getItem("partThree");
                        var partFour = window.localStorage.getItem("partFour");
                        location.href = "FileUpload.aspx?faren=" + faren + "&range=" + range + "&stock=" + stock + "&place=" + place + "&partTwo=" + partTwo + "&partThree=" + partThree + "&partFour=" + partFour + "&temp_vendor_id=" + temp_vendor_id;
                        layer.close(index);
                    },
                    cancel: function (index, layero) {
                        if (confirm('确定要关闭么')) { //只有当点击confirm框的确定时，该层才会关闭
                            postBack();
                            layer.close(index)
                        }
                        return false;
                    },
                    success: function (layero, index) {
                        console.log(layero, index);
                    }
                });
            });

        }

        function showDetail(type) {
            __myDoPostBack("getVendorInfo", type);
        }

        //弹出确认更改提示框 点击确认的时候调用后台的提交函数
        function submitCheck() {
            waiting('正在加载页面');
            return true;
        }

        function showNewTypeDropList() {
            document.getElementById("dropDiv").style.display = "block";
            document.getElementById("newTypeLb").style.display = "block";
        }

        function popTips(temp_Vendor_ID,factory) {
            document.getElementById("vendorCodeInput").value = localStorage.getItem("vendorCode");
            layui.use('form', function () {
                var form = layui.form
                , layer = layui.layer;

                layer.open({
                    title: ['以下更新信息需要完善', 'font-size:25px;text-align:center;color:black;'],
                    content: 'VendorModifyInfo.aspx?ID='+temp_Vendor_ID+'&Factory='+factory,
                    type: 2,
                    scrollbar: true,
                    area: ['600px', '400px'],
                    shade: 0.8,
                    shadeClose: false, //点击遮罩关闭
                    btn: ['确定'],
                    btnAlign: 'c', //按钮居中
                    yes: function (index, layero) {
                        location.href = "EmployeeVendor.aspx"
                    },
                    cancel: function (index, layero) {
                        layer.close(index)
                        return false;
                    },
                    success: function (layero, index) {
                        console.log(layero, index);
                    }
                });
            });

        }
    </script>
</head>
<body>
    <form id="form1" class="layui-form" runat="server">
        <div style="width:1000px;margin:0 auto;margin-top:50px;">

        <div class="layui-inline" style="width:495px;float:left">
            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>供应商信息更改</legend>
            </fieldset>
            <div class="layui-form-item" style="padding:0px;"> 
                <div class="layui-input-inline" style="margin-left:5px;width:350px;">
                    <input type="text" id="Temp_Vendor_Name" runat="server" placeholder="请输入供应商名称" autocomplete="off" class="layui-input"  style="text-align: left;width:350px;"/>
                </div>
                <div class="layui-input-inline" style="margin-left:0px;width:55px;">
                    <button id="getvendorinfo" class="layui-btn" style="margin-left:0px;" onclick="postBack()"><i class="layui-icon">&#xe615;</i></button>
                </div>
            </div>
            <div class="layui-form-item">
                <div id="vendorTypeSelection" class="layui-input-inline" style="margin-top: 20px; width: 350px; display: none;">
                    <asp:Button ID="type1" CssClass="layui-btn" Text="直接物料常规" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                    <asp:Button ID="type2" CssClass="layui-btn" Text="直接物料危化品" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                    <asp:Button ID="type3" CssClass="layui-btn" Text="非生产性特种劳防品" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                    <asp:Button ID="type4" CssClass="layui-btn" Text="非生产性危化品" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                    <asp:Button ID="type5" CssClass="layui-btn" Text="非生产性常规" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                    <asp:Button ID="type6" CssClass="layui-btn" Text="非生产性质量部有标准的物料" Visible="false" runat="server" OnClientClick="waiting('正在加载页面')" OnClick="types1_Click" />
                </div>
            </div>
<%--            <div class="layui-form-item">
                <label class="layui-form-label">原供应商类型</label>
                <div class="layui-input-block info">
                    <asp:DropDownList ID="DropDownList2" CssClass="info" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>

            <div class="layui-form-item">
                <label id="labelPartOne" class="layui-form-label" style="width: 230px; text-align: left">法人</label>
                <div class="layui-input-block">
                    <input type="checkbox"  runat="server" id="faren" name="legalPerson" lay-skin="primary" lay-filter="switchPartOne" title="更改">
                </div>
            </div>
            <div id="switchLegalPerson" class="layui-form-item">
                <div class="layui-form-item">
                    <label class="layui-form-label" style="width: 230px;text-align: left">营业范围</label>
                    <input id="workRangeSwitch" runat="server" type="checkbox" name="range" style="margin-right: 5px;" lay-skin="primary" lay-filter="workRange" title="更改">
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label" style="width: 230px;text-align: left">股份</label>
                    <input id="stockSwitch" runat="server" type="checkbox" style="margin-right: 5px;" name="stocks" lay-skin="primary" lay-filter="stock" title="更改">
                </div>
                <div class="layui-form-item">
                    <label class="layui-form-label" style="width: 230px;text-align: left">经营场所</label>
                    <input id="workPlaceSwitch" runat="server" style="margin-right: 5px;" type="checkbox" name="place" lay-skin="primary" lay-filter="workPlace" title="更改">
                </div>
            </div>


            <!--供应商地址、电话、传真、邮箱修改是否修改-->
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 230px; text-align: left">供应商地址、电话、传真、邮箱</label>
                <div class="layui-input-block">
                    <input type="checkbox" runat="server" style="margin-right: 5px;" id="partTwoSwitch" name="namePartTwoSwitch" lay-skin="primary" lay-filter="switchPartTwo" title="更改">
                </div>
            </div>


            <!--供应商银行信息是否修改-->
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 230px; text-align: left">供应商银行信息</label>
                <div class="layui-input-block">
                    <input type="checkbox" runat="server" id="partThreeSwitch" style="margin-right: 5px;" name="namePartThreeSwitch" lay-skin="primary" lay-filter="switchPartThree" title="更改">
                </div>
            </div>

            <!--供应商账期付款方式修改-->
            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 230px; text-align: left">供应商账期付款方式</label>
                <div class="layui-input-block">
                    <input type="checkbox" runat="server" id="partFourSwitch" style="margin-right: 5px;" name="namePartFourSwitch" lay-skin="primary" lay-filter="switchPartFour" title="更改">
                </div>
            </div>


            <div class="layui-form-item">
                <label class="layui-form-label" style="width: 230px; text-align: left">类型</label>
                <div class="layui-input-block">
                    <input type="checkbox" style="margin-right: 5px;" name="like1[write]" lay-filter="checkboxType" lay-skin="primary" title="更改" runat="server" id="checkType" checked>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" id="newTypeLb">新供应商类型</label>
                <div class="layui-input-block info" id="dropDiv" style="width:250px;">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>直接物料常规</asp:ListItem>
                        <asp:ListItem>直接物料危化品</asp:ListItem>
                        <asp:ListItem>非生产性特种劳防品</asp:ListItem>
                        <asp:ListItem>非生产性危化品</asp:ListItem>
                        <asp:ListItem>非生产性常规</asp:ListItem>
                        <asp:ListItem>非生产性质量部有标准的物料</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label">采购金额(万)</label>
                <div class="layui-input-block info">
                    <asp:TextBox ID="Purchase_Money" placeholder="金额" runat="server" class="layui-input another-info"></asp:TextBox>
                </div>
            </div>
            <div class="layui-form-item">
                <input id="Promise" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="承诺" />
                <input id="Advance_Charge" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="预付款" />
                <input id="Vendor_Assign" runat="server" type="checkbox" name="like1[write]" lay-skin="primary" title="指定" />
            </div>
            </div>

        <div class="layui-inline" style="width:495px;float:right" id="infomation">

            <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
                <legend>供应商基本信息</legend>
            </fieldset>
            <div class="layui-form-item">
                <label class="layui-form-label">供应商名称</label>
                <div class="layui-input-block">
                    <label id="vendorName" class="layui-form-label"></label>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="text-align: left">供应商正式编号</label>
                <div class="layui-input-block">
                    <label id="vendorCode" class="layui-form-label"></label>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="text-align: left;">使用厂方</label>
                <div class="layui-input-block">
                    <input id="SH" type="checkbox" name="like1[write]" lay-skin="primary" title="上海" disabled="">
                    <input id="ZS" type="checkbox" name="like1[read]" lay-skin="primary" title="中山" disabled="">
                    <input id="ZH" type="checkbox" name="like1[game]" lay-skin="primary" title="珠海" disabled="">
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="text-align: left;">供应商类型</label>
                <div class="layui-input-block">
                    <label id="vendorType" class="layui-form-label"></label>
                </div>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="text-align: left;">年采购金额</label>
                <label id="purchaseMoney" class="layui-form-label"></label>
            </div>
            <div class="layui-form-item">
                <label class="layui-form-label" style="text-align: left;">供应商选项</label>
                <input type="checkbox" id="promise" lay-skin="primary" title="承诺" disabled="">
                <input type="checkbox" id="advance_Charge" lay-skin="primary" title="预付款" disabled="">
                <input type="checkbox" id="vendor_Assign" lay-skin="primary" title="指定" disabled="">
            </div>
        </div>
        </div>

        <div style="width:500px;margin:0 auto">
            <asp:Button CssClass="layui-btn btnTop" ID="Button1" runat="server" Text="提交" OnClientClick="return submitCheck();" OnClick="Button1_Click" />
            <asp:Button CssClass="layui-btn layui-btn-primary btnTop" ID="Button2" runat="server" Text="返回" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
