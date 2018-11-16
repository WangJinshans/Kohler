<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThirdPartySubmit.aspx.cs" Inherits="SHZSZHSUPPLY.VendorQualityDetection.ThirdPartySubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../VendorAssess/Script/jquery-3.2.1.min.js"></script>
    <script src="../VendorAssess/Script/layui/layui.js"></script>
    <link href="../VendorAssess/Script/layui/css/layui.css" rel="stylesheet" />
    <script>
        $('#down').click(function () {
            var that = this;
            var page_url = '../ASHX/Progress.ashx';

            var req = new XMLHttpRequest();
            req.open("POST", page_url, true);

            req.addEventListener('progress', function (evt) {
                if (evt.lengthComputable) {
                    var percentComplete = evt.loaded / evt.total;
                    console.log(percentComplete);
                    $('#progressing').html((percentComplete * 100) + '%');
                }
            }, false);

            req.responseType = "blob";
            req.onreadystatechange = function () {
                if (req.readyState === 4 && req.status === 200) {
                    var filename = $(that).data('filename');
                    if (typeof window.chrome !== 'undefined') {
                        var link = document.createElement('a');
                        link.href = URL.createObjectURL(req.response);
                        link.download = filename;
                        link.click();
                    } else {
                        var file = new File([req.response], filename, { type: 'application/force-download' });
                    }
                };
                req.send();
            }
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="progressing"></div>
            <button id="down">文件下载</button>
        </div>
    </form>
</body>
</html>
