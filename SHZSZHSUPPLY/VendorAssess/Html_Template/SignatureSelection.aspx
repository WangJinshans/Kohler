<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignatureSelection.aspx.cs" Inherits="SHZSZHSUPPLY.VendorAssess.Html_Template.SignatureSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="renderer" content="webkit"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>

    <title></title>
    <script src="../Script/jquery-3.2.1.min.js"></script>
    <script src="../Script/layui/layui.js"></script>
    <script src="../Script/Own/fileUploader.js?v=6"></script>
    <link rel="stylesheet" href="../Script/layui/css/layui.css" />
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
                case 'department':
                    onDepartmentSelectChanged();
                    break;
                case 'employee':
                    $('img#preView').attr('src', '../TEST/files/'+document.getElementById('employee').value+'.png');
                    break;
                default:
                    break;
            }
        }

    </script>
    <script>
        var vendorInfoJson = {};

        function setParams(infoJson) {
            this.vendorInfoJson = JSON.parse(infoJson);
            var departmentSelect = document.getElementById('department');
            if (vendorInfoJson != null) {
                for (key in vendorInfoJson) {
                    departmentSelect.options.add(new Option(key, key));
                }
            }
        }

        function onDepartmentSelectChanged() {
            var departmentSelect = document.getElementById('department');
            var nameSelect = document.getElementById('employee');

            nameSelect.options.length = 0;
            nameSelect.options.add(new Option("请选择员工", ""))

            if (departmentSelect.selectedIndex == 0) {
                return;
            } else {
                var names = vendorInfoJson[departmentSelect.value];
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

        function getResult() {
            return './TEST/files/' + document.getElementById('employee').value + '.png';
        }
    </script>
</head>
<body>
    <fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
        <legend>签名选择</legend>
    </fieldset>
    <form id="form1" runat="server" class="layui-form">
        <div class="layui-form-item" style="visibility:hidden;display:none" id="selectTemplate">
            <div class="layui-inline">
                <label class="layui-form-label">选择</label>
                <div class="layui-input-inline">
                    <select name="modules" lay-verify="required" lay-search="">
                        <option value="">选择或搜索</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">部门选择</label>
            <div class="layui-input-inline">
                <select id="department" name="quiz1" onchange="onDepartmentSelectChanged()">
                    <option value="">请选择部门</option>
                </select>
            </div>
        </div>
        <div class="layui-form-item">
            <label class="layui-form-label">人员选择</label>
            <div class="layui-input-inline">
                <select id="employee" name="quiz3">
                    <option value="">请选择员工</option>
                </select>
            </div>
        </div>
        <img id="preView" src="../../pic/app.png"/>
    </form>
</body>
</html>
