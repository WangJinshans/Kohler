 function takeScreenshot() {
             var p = $(this).data("table1");
             var filename = p + "_fansImages.pdf";
             html2canvas(document.getElementById("table1"), {
                 // 渲染完成时调用，获得 canvas
                 onrendered: function (canvas) {
                     // 从 canvas 提取图片数据
                     var imgData = canvas.toDataURL('image/jpeg');
                     var canWidth = canvas.width;
                     var canHeight = canvas.height;
                     var arrDPI = js_getDPI();//获取显示器DPI
                     var dpiX = 96;
                     var dpiY = 96;
                     if (arrDPI.length > 0) {
                         dpiX = arrDPI[0];
                         dpiY = arrDPI[1];
                     }
                     var doc = new jsPDF("p", "mm", [230,315]);
                     //doc.text('', 10, 20);
                     //var doc = new jsPDF('', 'in', [(canWidth) / dpiX, (canHeight + 10) / dpiY]);//设置PDF宽高为要显示的元素的宽高，将像素转化为英寸  
                     doc.addImage(imgData, 'JPEG', 10, 10,209,297);
                     //doc.addImage(imgData, 'JPEG', 0, 0, 0, 0);
                     doc.save(filename);
                 },
                 background: "#f7f7f7"    //设置PDF背景色（默认透明，实际显示为黑色）
             });
         }
 function js_getDPI() {
     var arrDPI = new Array();
     if (window.screen.deviceXDPI != undefined) {
         arrDPI[0] = window.screen.deviceXDPI;
         arrDPI[1] = window.screen.deviceYDPI;
     }
     else {
         var tmpNode = document.createElement("DIV");
         tmpNode.style.cssText = "width:1in;height:1in;position:absolute;left:0px;top:0px;z-index:99;visibility:hidden";
         document.body.appendChild(tmpNode);
         arrDPI[0] = parseInt(tmpNode.offsetWidth);
         arrDPI[1] = parseInt(tmpNode.offsetHeight);
         tmpNode.parentNode.removeChild(tmpNode);
     }
     return arrDPI;
 }
 function pdfview(url)
 {
     location.href = url;
 }