using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using MODEL.QualityDetection;
using System.Data;
using System.Data.OleDb;

namespace SHZSZHSUPPLY.QualityDetection.Utils
{
    public class LocalExcelReadingUtil
    {
        /// <summary>
        /// 传入路径 读取文件 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSet readFiles(string path)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            DataSet ds = new DataSet();
            OleDbDataAdapter oada = new OleDbDataAdapter("select * from [Sheet1$]", strConn);
            oada.Fill(ds,"table");
            return ds;
        }
        
    }
}