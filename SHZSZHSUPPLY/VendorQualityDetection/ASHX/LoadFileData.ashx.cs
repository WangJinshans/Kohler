using BLL.QualityDetection;
using MODEL.QualityDetection;
using SHZSZHSUPPLY.QualityDetection.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace SHZSZHSUPPLY.VendorQualityDetection.ASHX
{
    /// <summary>
    /// LoadFileData 的摘要说明
    /// </summary>
    public class LoadFileData : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            //保存每天的导入信息  需要知道每一批数据是什么时候导入的 属于那一份导入文件

            HttpPostedFile postFile = context.Request.Files["qqfile"];
            string path = "../upload/";
            string real_Path = HttpContext.Current.Server.MapPath(path) + postFile.FileName;
            postFile.SaveAs(real_Path);
            DataTable table = LocalExcelReadingUtil.readFiles(real_Path).Tables[0];
            QT_Inspection_Item item = null;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new QT_Inspection_Item();

                    //补全即可
                    item.Batch_No = Convert.ToString(dr["Purchase order"]);
                    item.Product_Describes = Convert.ToString(dr["Material Description"]);
                    item.SKU = Convert.ToString(dr["Material（SKU）"]);
                    item.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    item.Detection_Count = Convert.ToString(dr["Quantity(数量)"]);

                    item.Status = "待检";
                    item.Factory_Name = Convert.ToString(context.Session["Factory_Name"]);
                    item.Add_Time = Convert.ToString(DateTime.Now.ToString());

                    item.Import_KO = Convert.ToString(dr["User Name"]);

                    Inspection_Item_BLL.addInspection(item);
                }
            }

            //string data = DataTableToJson(table);
            context.Response.Write(new JavaScriptSerializer().Serialize(new Msg() { success = true }));
        }


        private static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                if (dt.Columns.Count > 0)
                {
                    jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                }
                jsonBuilder.Append("},");
            }
            if (dt.Rows.Count > 0)
            {
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            }

            return jsonBuilder.ToString();
        }
        public bool IsReusable
        {
            get
            {
                return false;
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
}