<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="VendorSelection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.VendorSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="./Script/layui/css/layui.css" />
    <script src="./Script/jquery-3.2.1.min.js"></script>
    <script src="./Script/layui/layui.js"></script>
    <script src="./Script/Own/fileUploader.js?v=10"></script>
    <script type="text/javascript" src="Script/My97DatePicker/WdatePicker.js"></script>
    <script>
        var la_layer;
    </script>
    <script>
        function viewFile(filePath) {
            window.open(filePath);
        }
    </script>
     <script>
        //防止页面后退  
        history.pushState(null, null, document.URL);
        window.addEventListener('popstate', function () {
            history.pushState(null, null, document.URL);
        });
        // 浏览器回退禁止  
        function noBack() {
            // 历史记录栈中记录页数  
            var numberOfEntries = window.history.length;
            if (window.history && window.history.pushState) {
                $(window).on('popstate', function () {
                    // 当点击浏览器的 后退和前进按钮 时才会被触发，  
                    window.history.pushState('forward', null, '');
                    window.history.forward(1);
                });
            }
            // 新弹出页对应  
            if (numberOfEntries != 1) {
                // 页面间跳转用  
                window.history.pushState('forward', null, '');
                window.history.forward(1);
            }
        };
    </script>
    <script>
        function JSONLength(obj) {  
            var size = 0, key;  
            for (key in obj) {  
                if (obj.hasOwnProperty(key))
                    size++;
            }
            return size;
        };

        function R_D_Confirm(hasFile, tempVendorID, tempVendorName) {
            layui.use(['layer'], function () {
                la_layer = layui.layer;
                la_layer.open({
                    content: '是否已经获得R&D部分填写授权？',
                    btn: ['是', '否'],
                    yes: function (index, layero) {
                        if (hasFile) {
                            la_layer.msg("表单已保存并提交，即将跳转...", { time: 1000 }, function () {
                                __myDoPostBack("fileUploadResult", true);
                            });
                        } else {
                            la_layer.msg("请上传填写授权文件或其他证明材料", { time: 1500 }, function () {
                                requestType = "multiFillUpload";
                                fileTypeID = "032";
                                uploadFile(requestType, tempVendorID, tempVendorName, fileTypeID,false, function (result) {
                                    if (result['success']) {
                                        __myDoPostBack("fileUploadResult", true);
                                    } else {
                                        la_layer.msg("文件检查失败");
                                    }
                                });
                            });
                        }
                    },
                    btn2: function (index, layero) {
                        la_layer.msg("表单已保存并提交，即将跳转...", { icon: 1, time: 1500 }, function () {
                            __myDoPostBack("fileUploadResult", true);
                        });

                    },
                    cancel: function (index, layero) {
                        return false;
                    }
                });
            });
        }

        function selectEmployeeID(departments, idList, nameList) {
            var dpL = eval(departments);
            var idL = eval(idList);
            var nameL = eval(nameList);

            layui.use(['form', 'layer'], function () {
                var layer = layui.layer;
                layer.open({
                    type: 2,
                    title: '选择部门',
                    maxmin: true,
                    content: './Html_Template/EditEmployeeSelection.html',
                    area: ['500px', '420px'],
                    shadeClose: false,
                    btn: ['确定'],
                    yes: function (index, layero) {
                        var iframeWin = window[layero.find('iframe')[0]['name']];
                        var result = iframeWin.getResult(dpL);
                        if (JSONLength(result) != dpL.length) {
                            layer.msg("请确认是否已经正确选择");
                        } else {
                            layer.close(index);
                            layer.open({
                                title: '提示',
                                content: '填写选择完毕，请重新提交本表格', btn: ['确定'],
                                yes: function (index, layero) {__myDoPostBack("selectResult", JSON.stringify(result));},
                                cancel: function () { return false;}
                            });
                        }
                    },
                    success: function (layero, index) {
                        var iframeWin = window[layero.find('iframe')[0]['name']];
                        for (var i = 0; i < dpL.length; i++) {
                            iframeWin.addSelect(dpL[i], idL, nameL);
                        }
                    }/*,
                    cancel: function (index, layero) {
                        return false;
                    }*/
                });
            });
        }

        function layerMsgFunc(msg, func) {
            layui.use(['layer'], function () {
                la_layer = layui.layer;
                la_layer.msg(msg, { time: 1000 }, function () {
                    if (func != null) {
                        func();
                    }
                });
            });
        }

        function layerMsg(msg) {
            layui.use(['layer'], function () {
                la_layer = layui.layer;
                la_layer.msg(msg);
            });
        }
    </script>

    <script>
        function setScore(textbox, score) {
            var tb = document.getElementById(textbox);
            tb.value = score;
            if (tb.fireEvent) {
                tb.fireEvent("onchange");
            } else {
                tb.onchange();
            }
        }

        function showSupplier(pos, list) {
            var indexArray = new Array(1, 37, 48, 90, 94, 136, 140, 182, 186, 228);
            var supplier = eval(list);
            var textboxList = document.getElementsByClassName("tb-score");
            var count = 1;
            for (var i = indexArray[2 * pos]; i <= indexArray[2 * pos + 1] && count <= 19; i++) {
                var textBox = document.getElementById("TextBox" + i);
                if (!textBox.readOnly) {
                    setScore(textBox.id, supplier[count]);
                    count++;
                }
            }
        }

        function setPoint(point, total, percent) {
            document.getElementById("TextBox" + point).value = (parseFloat(total) * percent).toFixed(2);
        }

        function setSmallTotal(totalPoint, start, end) {
            var total = 0;
            for (var i = start; i <= end; i += 2) {
                try {
                    total += parseFloat(document.getElementById("TextBox" + i).value);
                } catch (e) {
                    total += 0;
                }
            }
            document.getElementById("TextBox" + totalPoint).value = total.toFixed(2);
            return total.toFixed(2);
        }

        function onScoreChange(value, name, percent, totalPos, pointPos, start, end, pointPercent) {
            var index = parseInt((String(name).replace("TextBox", "")))
            index = index + 1;
            document.getElementById("TextBox" + index).value = (parseFloat(value) * percent).toFixed(2);
            setSmallTotal(totalPos, start, end);
            setPoint(pointPos, document.getElementById("TextBox" + totalPos).value, pointPercent);
            setTotal();
        }

        function setTotal() {
            var array = [43, 44, 45, 46, 47, 59, 77, 89, 93, 105, 123, 135, 139, 151, 169, 181, 185, 197, 215, 227];
            for (var i = 0; i < 5; i++) {
                var total = 0.0;
                for (var t = i*4; t < (i+1)*4; t++) {
                    var vl = document.getElementById("TextBox" + array[t]).value;
                    if (vl == NaN || vl == null || vl == "") {
                        continue;
                    } else {
                        total += parseFloat(vl);
                    }
                }
                document.getElementById("total" + (i + 1)).textContent = total.toFixed(2);
            }
        }
	</script>

    <style>
        .totalTd {
            color: red;
            text-decoration: underline;
        }

        .td-border-none-right {
            border-right: none;
        }

        .td-border-none-left {
            border-left: none;
        }

        td {
            border: solid #000000;
            border-width: 1px 1px 1px 1px;
            padding: 0px 0px;
            height: 20px;
        }

        .tb {
            border: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
        }

        .tb-score {
            border: 0px;
            overflow: hidden;
            width: 95%;
            text-align: center;
        }

        .button {
            font-family: Arial;
            color: #000000;
            font-size: 27px;
            padding: 9px;
            text-decoration: none;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            -webkit-box-shadow: 0px 1px 0px #666666;
            -moz-box-shadow: 0px 1px 0px #666666;
            box-shadow: 0px 1px 0px #666666;
            text-shadow: 1px 1px 3px #666666;
            border: solid #e0e0e0 0px;
            background: -webkit-gradient(linear, 0 0, 0 100%, from(#dbd8da), to(#c9c9c9));
            background: -moz-linear-gradient(top, #dbd8da, #c9c9c9);
        }
    </style>
    <link rel="stylesheet" href="Script\layui\css\layui.css" />
</head>

<body>
    <form id="form1" runat="server">
        <%--<input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
		<input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />--%>
        <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updatePanelTable" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div>
            <table style="width: 1500px; margin: auto; border-collapse: collapse" border="1">
                <caption style="font-size: xx-large">Supplier Selection Form     供应商选择表</caption>
                <tr>
                    <td colspan="7" style="text-align: left" class="td-border-none-right">CN_PRC001F</td>
                    <td colspan="10" style="text-align: right" class="td-border-none-left">编号：PR-05-11-0</td>
                </tr>
                <tr>
                    <td colspan="7" style="text-align: right">Ref. No.</td>
                    <td>
                        <asp:TextBox runat="server" ID="txbRef" CssClass="tb"></asp:TextBox></td>
                    <td colspan="8" style="text-align: right">Date</td>
                    <td>
                        <asp:TextBox runat="server" ID="txbDate" CssClass="tb" type="text" class="Wdate" onfocus="WdatePicker({lang:'zh-cn',dateFmt:'yyyy-MM-dd HH:mm:ss'})" Height="100%" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td colspan="1">Supplier</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="tb" ID="txbOne"></asp:TextBox></td>
                    <td colspan="1">Supplier</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="tb" ID="txbTwo"></asp:TextBox></td>
                    <td colspan="1">Supplier</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="tb" ID="txbThree"></asp:TextBox></td>
                    <td colspan="1">Supplier</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="tb" ID="txbFour"></asp:TextBox></td>
                    <td colspan="1">Supplier</td>
                    <td colspan="2">
                        <asp:TextBox runat="server" CssClass="tb" ID="txbFive"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Criteria 标准</td>
                    <td>Weight权重</td>
                    <td>Score分数</td>
                    <td>Point得分</td>
                    <td>Comments</td>
                    <td>Score分数</td>
                    <td>Point得分</td>
                    <td>Comments</td>
                    <td>Score分数</td>
                    <td>Point得分</td>
                    <td>Comments</td>
                    <td>Score分数</td>
                    <td>Point得分</td>
                    <td>Comments</td>
                    <td>Score分数</td>
                    <td>Point得分</td>
                    <td>Comments</td>
                </tr>
                <tr>
                    <td>ASSURANCE OF SUPPLIER 供应商保证</td>
                    <td>10%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox43" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton1" Text="Approved" runat="server" GroupName="1" /><br />
                        <asp:RadioButton ID="RadioButton2" Text="Conditional Approval" runat="server" GroupName="1" /><br />
                        <asp:RadioButton ID="RadioButton3" Text="Reject" runat="server" GroupName="1" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox47" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton13" Text="Approved" runat="server" GroupName="11" /><br />
                        <asp:RadioButton ID="RadioButton14" Text="Conditional Approval" runat="server" GroupName="11" /><br />
                        <asp:RadioButton ID="RadioButton15" Text="Reject" runat="server" GroupName="11" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox93" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton25" Text="Approved" runat="server" GroupName="111" /><br />
                        <asp:RadioButton ID="RadioButton26" Text="Conditional Approval" runat="server" GroupName="111" /><br />
                        <asp:RadioButton ID="RadioButton27" Text="Reject" runat="server" GroupName="111" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox139" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton37" Text="Approved" runat="server" GroupName="1111" /><br />
                        <asp:RadioButton ID="RadioButton38" Text="Conditional Approval" runat="server" GroupName="1111" /><br />
                        <asp:RadioButton ID="RadioButton39" Text="Reject" runat="server" GroupName="1111" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox185" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton49" Text="Approved" runat="server" GroupName="11111" /><br />
                        <asp:RadioButton ID="RadioButton50" Text="Conditional Approval" runat="server" GroupName="11111" /><br />
                        <asp:RadioButton ID="RadioButton51" Text="Reject" runat="server" GroupName="11111" />
                    </td>
                </tr>
                <tr>
                    <td>- Sales breakdown of OEM and own brand OEM和自有品牌的占比*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,39,43,2,10,0.1)" ViewStateMode="Enabled"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox48" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,58,47,49,57,0.1)" ViewStateMode="Enabled"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox49" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox94" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,104,93,95,103,0.1)" ViewStateMode="Enabled"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox95" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox140" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,150,139,141,149,0.1)" ViewStateMode="Enabled"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox141" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox186" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,196,185,187,195,0.1)" ViewStateMode="Enabled"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox187" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Annual Turn Over vs Kohler business 科勒业务占年营业额比例*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,39,43,2,10,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox50" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,58,47,49,57,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox51" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox96" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,104,93,95,103,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox97" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox142" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,150,139,141,149,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox143" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox188" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,196,185,187,195,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox189" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- In-house Production 自有生产的比例*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,39,43,2,10,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox52" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,58,47,49,57,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox53" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox98" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,104,93,95,103,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox99" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox144" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,150,139,141,149,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox145" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox190" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,196,185,187,195,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox191" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Capacity Utilization 产能*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,39,43,2,10,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox54" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,58,47,49,57,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox55" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox100" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,104,93,95,103,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox101" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox146" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,150,139,141,149,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox147" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox192" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,196,185,187,195,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox193" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Payment term 账期*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,39,43,2,10,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox56" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,58,47,49,57,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox57" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox102" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,104,93,95,103,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox103" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox148" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,150,139,141,149,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox149" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox194" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,196,185,187,195,0.1)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox195" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>100%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox39" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox58" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox104" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox150" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox196" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>

                <!--   QUALITY质量 -->
                <tr>
                    <td>QUALITY质量</td>
                    <td>20%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox44" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="10">
                        <asp:RadioButton ID="RadioButton4" Text="Approved" runat="server" GroupName="2" /><br />
                        <asp:RadioButton ID="RadioButton5" Text="Conditional Approval" runat="server" GroupName="2" /><br />
                        <asp:RadioButton ID="RadioButton6" Text="Reject" runat="server" GroupName="2" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox59" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="10">
                        <asp:RadioButton ID="RadioButton16" Text="Approved" runat="server" GroupName="22" /><br />
                        <asp:RadioButton ID="RadioButton17" Text="Conditional Approval" runat="server" GroupName="22" /><br />
                        <asp:RadioButton ID="RadioButton18" Text="Reject" runat="server" GroupName="22" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox105" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="10">
                        <asp:RadioButton ID="RadioButton28" Text="Approved" runat="server" GroupName="222" /><br />
                        <asp:RadioButton ID="RadioButton29" Text="Conditional Approval" runat="server" GroupName="222" /><br />
                        <asp:RadioButton ID="RadioButton30" Text="Reject" runat="server" GroupName="222" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox151" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="10">
                        <asp:RadioButton ID="RadioButton40" Text="Approved" runat="server" GroupName="2222" /><br />
                        <asp:RadioButton ID="RadioButton41" Text="Conditional Approval" runat="server" GroupName="2222" /><br />
                        <asp:RadioButton ID="RadioButton42" Text="Reject" runat="server" GroupName="2222" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox197" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="10">
                        <asp:RadioButton ID="RadioButton52" Text="Approved" runat="server" GroupName="22222" /><br />
                        <asp:RadioButton ID="RadioButton53" Text="Conditional Approval" runat="server" GroupName="22222" /><br />
                        <asp:RadioButton ID="RadioButton54" Text="Reject" runat="server" GroupName="22222" />
                    </td>
                </tr>
                <tr>
                    <td>- Quality system/Documentation/Training 质量体系/文件编制/培训*</td>
                    <td>14%</td>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.14,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox12" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox60" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.14,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox61" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox106" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.14,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox107" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox152" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.14,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox153" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox198" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.14,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox199" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Quality Control in Design and Develpoment 研发领域质量控制*</td>
                    <td>12%</td>
                    <td>
                        <asp:TextBox ID="TextBox13" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox62" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox63" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox108" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox109" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox154" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox155" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox200" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox201" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Quality Control for Purchased Material 材料采购质量控制住*</td>
                    <td>12%</td>
                    <td>
                        <asp:TextBox ID="TextBox15" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox16" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox64" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox65" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox110" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox111" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox156" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox157" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox202" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox203" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Process Quality Control流程质量控制*</td>
                    <td>16%</td>
                    <td>
                        <asp:TextBox ID="TextBox17" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.16,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox18" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox66" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.16,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox67" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox112" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.16,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox113" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox158" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.16,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox159" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox204" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.16,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox205" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Life test/Reliability/Product Audit 耐久试验/可靠性/产品审核*</td>
                    <td>10%</td>
                    <td>
                        <asp:TextBox ID="TextBox19" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox20" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox68" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox69" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox114" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox115" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox160" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox161" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox206" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox207" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Control for Measurement System测量系统控制*</td>
                    <td>12%</td>
                    <td>
                        <asp:TextBox ID="TextBox21" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox22" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox70" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox71" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox116" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox117" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox162" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox163" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox208" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox209" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Control for Non-conformity 不合格控制*</td>
                    <td>12%</td>
                    <td>
                        <asp:TextBox ID="TextBox23" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox24" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox72" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox73" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox118" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox119" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox164" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox165" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox210" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox211" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Continuous Improvement 持续改善*</td>
                    <td>12%</td>
                    <td>
                        <asp:TextBox ID="TextBox25" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,40,44,12,26,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox26" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox74" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,76,59,61,75,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox75" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox120" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,122,105,107,121,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox121" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox166" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,168,151,153,167,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox167" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox212" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.12,214,197,199,213,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox213" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>100%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox40" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox76" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox122" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox168" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox214" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>

                <!--   PRODUCTION ,  R&D 产品研发-->
                <tr>
                    <td>PRODUCTION ,  R&D 产品研发</td>
                    <td>20%</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox45" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton7" Text="Approved" runat="server" GroupName="3" /><br />
                        <asp:RadioButton ID="RadioButton8" Text="Conditional Approval" runat="server" GroupName="3" /><br />
                        <asp:RadioButton ID="RadioButton9" Text="Reject" runat="server" GroupName="3" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox77" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton19" Text="Approved" runat="server" GroupName="33" /><br />
                        <asp:RadioButton ID="RadioButton20" Text="Conditional Approval" runat="server" GroupName="33" /><br />
                        <asp:RadioButton ID="RadioButton21" Text="Reject" runat="server" GroupName="33" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox123" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton31" Text="Approved" runat="server" GroupName="333" /><br />
                        <asp:RadioButton ID="RadioButton32" Text="Conditional Approval" runat="server" GroupName="333" /><br />
                        <asp:RadioButton ID="RadioButton33" Text="Reject" runat="server" GroupName="333" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox169" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton43" Text="Approved" runat="server" GroupName="3333" /><br />
                        <asp:RadioButton ID="RadioButton44" Text="Conditional Approval" runat="server" GroupName="3333" /><br />
                        <asp:RadioButton ID="RadioButton45" Text="Reject" runat="server" GroupName="3333" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextBox215" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="7">
                        <asp:RadioButton ID="RadioButton55" Text="Approved" runat="server" GroupName="33333" /><br />
                        <asp:RadioButton ID="RadioButton56" Text="Conditional Approval" runat="server" GroupName="33333" /><br />
                        <asp:RadioButton ID="RadioButton57" Text="Reject" runat="server" GroupName="33333" />
                    </td>
                </tr>
                <tr>
                    <td>- R&D Capability研发能力*</td>
                    <td>30%</td>
                    <td>
                        <asp:TextBox ID="TextBox27" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,41,45,28,36,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox28" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox78" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,88,77,79,87,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox79" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox124" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,134,123,125,133,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox125" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox170" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,180,169,171,179,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox171" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox216" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,226,215,217,225,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox217" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Production & Manufacture Capability产品和制造能力*</td>
                    <td>20%</td>
                    <td>
                        <asp:TextBox ID="TextBox29" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,41,45,28,36,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox30" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox80" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,88,77,79,87,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox81" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox126" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,134,123,125,133,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox127" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox172" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,180,169,171,179,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox173" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox218" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.2,226,215,217,225,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox219" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Outsourcing Material Development 外包材料研发 *</td>
                    <td>10%</td>
                    <td>
                        <asp:TextBox ID="TextBox31" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,41,45,28,36,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox32" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox82" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,88,77,79,87,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox83" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox128" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,134,123,125,133,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox129" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox174" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,180,169,171,179,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox175" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox220" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,226,215,217,225,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox221" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Process Control 过程控制  *</td>
                    <td>30%</td>
                    <td>
                        <asp:TextBox ID="TextBox33" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,41,45,28,36,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox34" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox84" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,88,77,79,87,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox85" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox130" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,134,123,125,133,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox131" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox176" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,180,169,171,179,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox177" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox222" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.3,226,215,217,225,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox223" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>- Service Warranty 服务保障*</td>
                    <td>10%</td>
                    <td>
                        <asp:TextBox ID="TextBox35" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,41,45,28,36,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox36" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox86" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,88,77,79,87,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox87" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox132" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,134,123,125,133,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox133" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox178" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,180,169,171,179,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox179" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox224" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,0.1,226,215,217,225,0.2)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox225" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>100%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox41" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox88" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox134" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox180" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox226" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>

                <!-- PRICE -->
                <tr>
                    <td>PRICE</td>
                    <td>50%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox46" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="3">
                        <asp:RadioButton ID="RadioButton10" Text="Approved" runat="server" GroupName="4" /><br />
                        <asp:RadioButton ID="RadioButton11" Text="Conditional Approval" runat="server" GroupName="4" /><br />
                        <asp:RadioButton ID="RadioButton12" Text="Reject" runat="server" GroupName="4" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox89" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="3">
                        <asp:RadioButton ID="RadioButton22" Text="Approved" runat="server" GroupName="44" /><br />
                        <asp:RadioButton ID="RadioButton23" Text="Conditional Approval" runat="server" GroupName="44" /><br />
                        <asp:RadioButton ID="RadioButton24" Text="Reject" runat="server" GroupName="44" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox135" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="3">
                        <asp:RadioButton ID="RadioButton34" Text="Approved" runat="server" GroupName="444" /><br />
                        <asp:RadioButton ID="RadioButton35" Text="Conditional Approval" runat="server" GroupName="444" /><br />
                        <asp:RadioButton ID="RadioButton36" Text="Reject" runat="server" GroupName="444" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox181" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="3">
                        <asp:RadioButton ID="RadioButton46" Text="Approved" runat="server" GroupName="4444" /><br />
                        <asp:RadioButton ID="RadioButton47" Text="Conditional Approval" runat="server" GroupName="4444" /><br />
                        <asp:RadioButton ID="RadioButton48" Text="Reject" runat="server" GroupName="4444" />
                    </td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox227" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td rowspan="3">
                        <asp:RadioButton ID="RadioButton58" Text="Approved" runat="server" GroupName="44444" /><br />
                        <asp:RadioButton ID="RadioButton59" Text="Conditional Approval" runat="server" GroupName="44444" /><br />
                        <asp:RadioButton ID="RadioButton60" Text="Reject" runat="server" GroupName="44444" />
                    </td>
                </tr>
                <tr>
                    <td>- Competitiveness (see bidding result)竞争力（见比价表)*</td>
                    <td>100%</td>
                    <td>
                        <asp:TextBox ID="TextBox37" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,1,42,46,38,38,0.5)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox38" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox90" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,1,92,89,91,91,0.5)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox91" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox136" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,1,138,135,137,137,0.5)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox137" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox182" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,1,184,181,183,183,0.5)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox183" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox228" runat="server" CssClass="tb-score" onchange="onScoreChange(this.value,this.name,1,230,227,229,229,0.5)"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox229" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp</td>
                    <td>100%</td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox42" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox92" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox138" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox184" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="TextBox230" runat="server" CssClass="tb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                    <td style=" color: red; text-decoration: underline; text-align: center;" id="total1">score</td>
                    <td colspan="2"></td>
                    <td style=" color: red; text-decoration: underline; text-align: center;" id="total2">score</td>
                    <td colspan="2"></td>
                    <td style=" color: red; text-decoration: underline; text-align: center;" id="total3">score</td>
                    <td colspan="2"></td>
                    <td style=" color: red; text-decoration: underline; text-align: center;" id="total4">score</td>
                    <td colspan="2"></td>
                    <td style=" color: red; text-decoration: underline; text-align: center;" id="total5">score</td>
                    <td  colspan="2"></td>
                </tr>
            </table>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <div style="margin:0 auto;margin-top:50px;width:1000px;height:80px">
            We recommend<asp:TextBox ID="txbRecommend" runat="server" TextMode="MultiLine" style="width:100%"></asp:TextBox>
        </div>
        <table style="width:1000px;margin:0 auto">
            <tr>
                <td>Purchasing Dept</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image1" runat="server" Visible="false"/></td>
                <td>Manager</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image2" runat="server" Visible="false" /></td>
                <td>Department Header</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image3" runat="server" Visible="false" /></td>
            </tr>
            <tr>
                <td>Engineering Dept</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image4" runat="server" Visible="false" /></td>
                <td>Manager</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image5" runat="server" Visible="false" /></td>
                <td>Department Header</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image6" runat="server" Visible="false" /></td>
            </tr>
            <tr>
                <td>Quality Dept</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image7" runat="server" Visible="false" /></td>
                <td>Manager</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image8" runat="server" Visible="false" /></td>
                <td>Department Header</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image9" runat="server" Visible="false" /></td>
            </tr>
            <tr>
                <td>Finance Dept</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image10" runat="server" Visible="false" /></td>
                <td>Manager</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image11" runat="server" Visible="false" /></td>
                <td>Department Header</td>
                <td><asp:Image ImageUrl="imageurl" ID="Image12" runat="server" Visible="false" /></td>
            </tr>
        </table>
        <%--<div style="text-align: center;margin-bottom:50px">
            <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
   
            <asp:Button ID="Button4" runat="server" Text="确认" CssClass="layui-btn" OnClick="Button4_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
	
            <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	
            <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
        </div>--%>
        <asp:UpdatePanel ID="updatePanel" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div style="text-align: center;margin-bottom:50px">
            <asp:Button ID="Button1" runat="server" Text="提交" CssClass="layui-btn" OnClientClick="waiting('正在执行...')" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
   
            <asp:Button ID="Button4" runat="server" Text="确认" CssClass="layui-btn" OnClientClick="waiting('正在执行...')" OnClick="Button4_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
	
            <asp:Button ID="Button2" runat="server" Text="保存" CssClass="layui-btn layui-btn-normal" OnClientClick="waiting('正在执行...')" OnClick="Button2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
	
            <asp:Button ID="Button3" runat="server" Text="返回" CssClass="layui-btn layui-btn-danger" OnClick="Button3_Click" />
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="float: left;display:none">

            <table>
                <tr>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                                SortExpression="Form_ID" />
                            <asp:BoundField DataField="Position_Name" HeaderText="职位名称"
                                SortExpression="Position_Name" />
                            <asp:BoundField DataField="Assess_Flag" HeaderText="审批状态"
                                SortExpression="Assess_Flag" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtapprovesuccess" runat="server" CommandName="approvesuccess"
                                        CommandArgument='<%# Eval("Form_ID") %>'>通过审批</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="fail"
                                        CommandArgument='<%# Eval("Form_ID") %>'>拒绝审批</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </tr>
                <tr>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" ForeColor="#333333" OnRowCommand="GridView2_RowCommand">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Form_ID" HeaderText="表格编号"
                                SortExpression="Form_ID" />
                            <asp:BoundField DataField="File_ID" HeaderText="文件编号"
                                SortExpression="File_ID" />

					<asp:TemplateField>
						<ItemTemplate>
							<asp:LinkButton ID="lbtapprovefail" runat="server" CommandName="view"
								CommandArgument='<%# Eval("File_ID") %>'>查看文件</asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
						<EditRowStyle BackColor="#999999" />
				<FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
				<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
				<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
				<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
				<SortedAscendingCellStyle BackColor="#E9E7E2" />
				<SortedAscendingHeaderStyle BackColor="#506C8C" />
				<SortedDescendingCellStyle BackColor="#FFFDF8" />
				<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
			</asp:GridView>
			</tr>
		</table>
	</div>

    </form>

     <script>
        $('textarea').bind('input', function () {
            this.style.height = this.scrollTop + this.scrollHeight + "px";
        })
    </script>
</body>
</html>
