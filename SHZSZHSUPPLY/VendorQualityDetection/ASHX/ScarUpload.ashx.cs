using BLL.QualityDetection;
using System.Web;
using System.Web.Script.Serialization;

namespace SHZSZHSUPPLY.VendorQualityDetection.ASHX
{
    /// <summary>
    /// ScarUpload 的摘要说明
    /// </summary>
    public class ScarUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            HttpPostedFile file = context.Request.Files["qqfile"];

            string vendorCode = context.Request.Params["vendorCode"];
            string batchNo = context.Request.Params["batchNo"];

            string path = "../scar/";
            string fileName = file.FileName;

            string file_Path = HttpContext.Current.Server.MapPath(path + vendorCode + batchNo + fileName);
            file.SaveAs(file_Path);


            //更新该batch的Scar记录 确认已经上传反馈 
            SCAR_BLL.updateScarStatus(batchNo, vendorCode, file_Path);
            context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true }));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

}
public class Msg
{
    public bool success { get; set; }
    public bool preventRetry { get; set; }
    public bool reset { get; set; }
    public string newUuid { get; set; }
    public string error { get; set; }
    public string message { get; set; }
    public int status { get; set; }
    public string datas { get; set; }
}