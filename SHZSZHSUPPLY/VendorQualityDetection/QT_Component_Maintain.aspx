<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QT_Component_Maintain.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.QT_Component_Maintain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Language" content="zh-CN"/>
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
	<link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script src="../VendorAssess/Script/Own/fileUploader.js"></script>
    
    <script>
        function selectSKUError() {
            layui.use('layer', function () {
                var layer = layui.layer;

                layer.open({
                    title: '提醒！',
                    content: '查无此SKU对应Component信息,请重新输入！',
                    btn: ['返回'],
                    yes: function () {
                        layer.close(index);
                    },
                    cancel: function (index, layero) {
                        layer.close(index);
                    }
                });
            });
        }

        function whetherInsert() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '提示',
					content: '确定添加检验项?',
					btn: ['确定', '返回'],
					yes: function (index, layero) {
						__myDoPostBack('add_Click', '');
					},
					btn2: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

        function whetherChange() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '提示',
					content: '确定修改检验项?',
					btn: ['确定', '返回'],
					yes: function (index, layero) {
						__myDoPostBack('change_Click', '');
					},
					btn2: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

        function deleteError() {
			layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '删除错误',
					content: '请输入要删除的项',
					btn: ['返回'],

					yes: function (index, layero) {
						layer.close(index);
					},
					cancel: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}

        function test1() {
            layui.use('layer', function () {
				var layer = layui.layer;

				layer.open({
					title: '删除错误',
					content: '请输入要删除的项',
					btn: ['返回'],

					yes: function (index, layero) {
						layer.close(index);
					},
					cancel: function (index, layero) {
						layer.close(index);
					}
				});
			});
		}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="layui-form-item" style="width: 85%; margin: 0 auto">
            <fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">修改SKU对应Compnent</legend>
            </fieldset>
            <div style="text-align: center">
                <div class="layui-form-item" style="margin: 0 auto; width: 350px; display: inline-block;">

                    <label class="layui-form-label" style="width: 100px; text-align: center">请输入SKU</label>

                    <asp:TextBox ID="inputSKU" Style="width: 200px; text-align: center" class="layui-input" runat="server"></asp:TextBox>

                </div>
                
                <div style="display: inline-block;">
                    <asp:Button ID="selectSKU" Style="width: 100px" runat="server" Text="查询" class="layui-btn" OnClick="selectSKU_Click" />
                </div>
            </div>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" Style="width: 1300px; margin: 0 auto; margin-bottom: 50px;" class="layui-table" lay-even="" lay-skin="nob" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"  >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="SKU" HeaderText="SKU"
                                SortExpression="SKU" />
                            <asp:BoundField DataField="Product_Name" HeaderText="产品名称"
                                SortExpression="Product_Name" />
                            <asp:BoundField DataField="Product_Describes" HeaderText="产品描述"
                                SortExpression="Product_Describes" />
                            <asp:BoundField DataField="Detection_Requirement" HeaderText="检验要求"
								SortExpression="Detection_Requirement" />
							<asp:BoundField DataField="PPAP" HeaderText="PPAP"
								SortExpression="PPAP" />
							<asp:BoundField DataField="Broken_Detection" HeaderText="破坏性检测"
								SortExpression="Broken_Detection" />
							<asp:BoundField DataField="MBR_Distinction" HeaderText="MRB_Distinction"
								SortExpression="MBR_Distinction" />
                            <asp:BoundField DataField="Factory_Name" HeaderText="工厂名称"
                                SortExpression="Factory_Name" />
                            <asp:BoundField DataField="Vendor_Code" HeaderText="供应商编号"
                                SortExpression="Vendor_Code" />
                            <asp:BoundField DataField="Class_Leval" HeaderText="Class_Leval"
                                SortExpression="Class_Leval" />
                            <asp:BoundField DataField="AQL" HeaderText="AQL"
                                SortExpression="AQL" />
                            <asp:BoundField DataField="Surface_Inspection" HeaderText="表面检验"
                                SortExpression="Surface_Inspection" />
                            <asp:BoundField DataField="Suitability_Inspection" HeaderText="适应性检验"
                                SortExpression="Suitability_Inspection" />
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#515a6d" Font-Bold="true" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#5AA700" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />

                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <div>
                <table class="layui-table" style="width: 80%; text-align: center; margin-left: 10%; margin-right: 10%">
                    <colgroup>
                        <col width="150" />
                        <col width="200" />
                        <col />
                    </colgroup>
                    <tbody>
                        <thead>
                            <tr>
                                <th colspan="6" style="text-align:center;">请填写修改数据内容</th>
                            </tr>
                        </thead>
                        <tr>
                            <td>产品名称:</td>
                            <td>
                                <asp:TextBox ID="change1" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>产品描述:</td>
                            <td>
                                <asp:TextBox ID="change2" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>检验要求:</td>
                            <td>
                                <asp:TextBox ID="change3" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>PPAP:</td>
                            <td>
                                <asp:TextBox ID="change4" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>破坏性检测:</td>
                            <td>
                                <asp:TextBox ID="change5" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>

                            <td>MRB_Distinction:</td>
                            <td>
                                <asp:TextBox ID="change6" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>工厂名称:</td>
                            <td>
                                <asp:TextBox ID="change7" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>供应商编号:</td>
                            <td>
                                <asp:TextBox ID="change8" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>

                            <td>Class_Leval:</td>
                            <td>
                                <asp:TextBox ID="change9" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>AQL:</td>
                            <td>
                                <asp:TextBox ID="change10" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>表面检验:</td>
                            <td>
                                <asp:TextBox ID="change11" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>

                            <td>适应性检验:</td>
                            <td>
                                <asp:TextBox ID="change12" Style="width: 100%; height: 100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
                <div style="text-align:center">
                    <asp:Button ID="clear" runat="server" Text="清空" class="layui-btn layui-btn-warm" OnClick="clear_Click" />
                    &nbsp 
                    <input type="button" value="修改(test)" class="layui-btn layui-btn-danger" onclick="whetherChange()"/>
                    <%--<asp:Button ID="change" runat="server" Text="修改" class="layui-btn layui-btn-danger" OnClick="change_Click" />--%>
                </div>
            </div>
            </div>

            <fieldset class="layui-field-title layui-elem-field" style="margin: 50px auto 20px auto;">
                <legend style="text-align: center;" runat="server">添加Component</legend>
            </fieldset>
            <div class="layui-form-item" style="width: 85%; margin: 0 auto">
                <table class="layui-table" style="width:80%;text-align:center;margin-left:10%;margin-right:10%">
                    <colgroup>
                        <col width="150"/>
                        <col width="200"/>
                        <col />
                    </colgroup>
                    <tbody>
                        <tr>
                            <td>SKU:</td>
                            <td><asp:TextBox ID="insert1" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>产品名称:</td>                                      
                            <td><asp:TextBox ID="insert2" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>产品描述:</td>                                      
                            <td><asp:TextBox ID="insert3" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>                                                             
                        <tr>                                                              
                            <td>检验要求:</td>                                             
                            <td><asp:TextBox ID="insert4" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>PPAP:</td>       
                            <td><asp:TextBox ID="insert5" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>破坏性检测:</td>                                    
                            <td><asp:TextBox ID="insert6" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>                                                             
                        <tr>                                                              
                            <td>MRB_Distinction:</td>                                      
                            <td><asp:TextBox ID="insert7" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>工厂名称:</td>                                      
                            <td><asp:TextBox ID="insert8" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                            <td>供应商编号:</td> 
                            <td><asp:TextBox ID="insert9" Style="width: 100%;height:100%;"  class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Class_Leval:</td>
                            <td><asp:TextBox ID="insert10" Style="width: 100%;height:100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>AQL:</td>        
                            <td><asp:TextBox ID="insert11" Style="width: 100%;height:100%;" class="layui-input" runat="server"></asp:TextBox></td>
                            <td>表面检验:</td>   
                            <td><asp:TextBox ID="insert12" Style="width: 100%;height:100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>适应性检验:</td>
                            <td><asp:TextBox ID="insert13" Style="width: 100%;height:100%;" class="layui-input" runat="server"></asp:TextBox></td>
                        </tr>
                    </tbody>
                </table>
             </div>
             <br />
            <div class="layui-form-item" style="text-align:center">
                <asp:Button ID="clearInsert" runat="server" Text="清空" class="layui-btn layui-btn-warm" OnClick="clearInsert_Click" />
                    &nbsp 
                <input type="button" value="添加(test)" class="layui-btn" onclick="whetherInsert()"/>
			    <%--<asp:Button ID="add" runat="server" Text="添加" class="layui-btn" OnClick="add_Click"/>--%>
            </div>
        
    </form>
</body>
</html>
