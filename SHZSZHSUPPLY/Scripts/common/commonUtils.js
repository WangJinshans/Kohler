function maintainSKU(msg) {
    layui.use('form', function () {
        var form = layui.form
        , layer = layui.layer;
        layer.open({
            title: ['零件维护', 'text-align:center;'],
            type: 1,
            area: ['800px', '300px'],
            content: msg+' 在零件清单中暂不存在,是否需要添加该SKU?'
            , btn: ['添加', '取消']
            , yes: function () {
                __myDoPostBack('AddSKU', '');
            }
            , btn1: function () {
                layer.closeAll();
            }
            , cancle: function () {
                layer.closeAll();
            }
        })
    });
}


function mytips(msg) {
    layui.use('form', function () {
        var layer = layui.layer;
        layer.msg(msg);
    });
}