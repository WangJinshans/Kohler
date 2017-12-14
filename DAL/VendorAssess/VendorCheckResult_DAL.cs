using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class VendorCheckResult_DAL
    {

        /// <summary>
        /// 初始化供应商信息更改的显示数据
        /// </summary>
        /// <returns></returns>
        public static List<As_Modify_CheckResult> getData(string tempVendorID, string factory_Name)
        {
            List<As_Modify_CheckResult> list = new List<As_Modify_CheckResult>();
            As_Modify_CheckResult checkResult;
            string sql = "select Form_Or_File_Type_ID,Type from As_Creat_CheckResult where Temp_Vendor_ID='" + tempVendorID + "' and Factory_Name='" + factory_Name + "'";
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    checkResult = new As_Modify_CheckResult();
                    checkResult.Type = dr["Type"].ToString();
                    checkResult.Form_Or_File_Type_ID = dr["Form_Or_File_Type_ID"].ToString();
                    list.Add(checkResult);
                }
            }

            //处理每条记录 将Form_Or_File_Type_ID对应到具体的文件或者表格名称
            if (list.Count > 0)
            {
                foreach (As_Modify_CheckResult result in list)
                {
                    result.Item_Name = getItemName(result);
                }
            }
            return list;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="vendor_Name"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static int modify_CheckResult(string procedureName, string tempVendorID, string factory_Name, string newType,string oldType, bool promise, bool assign, bool charge, float money)
        {
            return DBHelp.ExecuteModifyCheckResultStoredProcedure(procedureName, tempVendorID, factory_Name, newType, oldType, promise, assign, charge, money);
        }

        public static List<string> getShareFileTypeIDs(string newTemp_Vendor_ID, string factory_Name)
        {
            //判断是否有上传过共享文件
            //如果有则更新共享文件的Flag 否则不更新
            List<string> fileTypeIDList = new List<string>();
            //获取供应商名称
            string temp_Vendor_Name = TempVendor_DAL.getTempVendorName(newTemp_Vendor_ID);
            //查看该供应商是否提交过共享文件
            string shareSql= "select distinct FileType_ID from As_Vendor_FileType WHERE FileType_ID in (SELECT File_Type_ID FROM As_File_Type WHERE Is_Shared='TRUE') AND Temp_Vendor_ID in(select Temp_Vendor_ID from As_Temp_Vendor where Temp_Vendor_Name='"+temp_Vendor_Name + "') AND Flag='0'";
            DataTable table = DBHelp.GetDataSet(shareSql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileTypeIDList.Add(dr["FileType_ID"].ToString().Trim());
                }
            }
            return fileTypeIDList;

               
        }

        public static bool isUpload(string oldTempVendorID, string factory_Name, string fileTypeID)
        {
            string sql = "select FileType_ID from As_Vendor_FileType where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory_Name + "' and FileType_ID='" + fileTypeID + "' and flag=1";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public static int upDateShareFlag(string newTemp_Vendor_ID, string factory_Name,string fileTypeID)
        {
            string sql = "update As_Vendor_FileType set flag='1' where Temp_Vendor_ID='" + newTemp_Vendor_ID + "' and Factory_Name='" + factory_Name + "' and FileType_ID='" + fileTypeID + "'";
            return DBHelp.GetScalar(sql);
        }

        private static string getItemName(As_Modify_CheckResult results)
        {
            string item_Name = "";
            if (results != null)
            {
                if (results.Type.Equals("文件"))
                {
                    item_Name= File_Type_DAL.getFileTypeNameByID(results.Form_Or_File_Type_ID);
                }
                if (results.Type.Equals("表格"))
                {
                    item_Name = getFormNameByTypeID(results.Form_Or_File_Type_ID);
                }
            }
            return item_Name;
        }


        /// <summary>
        /// 获取表格名称
        /// </summary>
        /// <param name="form_Type_ID"></param>
        /// <returns></returns>
        private static string getFormNameByTypeID(string form_Type_ID)
        {
            string form_Type_Name = "";
            DataTable table = FormType_DAL.getFormNameByTypeID(form_Type_ID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    form_Type_Name = dr["Form_Type_Name"].ToString().Trim();
                }
            }
            return form_Type_Name;
        }

    }
}
