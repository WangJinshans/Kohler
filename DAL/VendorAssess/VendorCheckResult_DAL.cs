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
            if (tempVendorID == "")
            {
                return -1;
            }
            SqlCommand cmd = new SqlCommand(procedureName, DBHelp.Connection);
            cmd.CommandType = CommandType.StoredProcedure;//存储过程
            cmd.Parameters.Add(new SqlParameter("@temp_vendor_id", SqlDbType.NVarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@type", SqlDbType.NVarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@oldType", SqlDbType.NVarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@promise", SqlDbType.NVarChar, 10));
            cmd.Parameters.Add(new SqlParameter("@assign", SqlDbType.NVarChar, 10));
            cmd.Parameters.Add(new SqlParameter("@charge", SqlDbType.NVarChar, 10));
            cmd.Parameters.Add(new SqlParameter("@money", SqlDbType.NVarChar, 10));
            cmd.Parameters.Add(new SqlParameter("@factory", SqlDbType.NVarChar, 10));
            cmd.Parameters["@temp_vendor_id"].Value = tempVendorID;
            cmd.Parameters["@type"].Value = newType;
            cmd.Parameters["@oldType"].Value = oldType;
            cmd.Parameters["@promise"].Value = promise;
            cmd.Parameters["@assign"].Value = assign;
            cmd.Parameters["@charge"].Value = charge;
            cmd.Parameters["@money"].Value = money;
            cmd.Parameters["@factory"].Value = factory_Name;
            int number = cmd.ExecuteNonQuery();
            return number;
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

        public static void upDateAll(string newTempVendorID,string oldTempVendorID,string factory)
        {
            string sql = "update As_Approve set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Approve_History set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Contract_Approval set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Employee_Form set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_File set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Form set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Bidding_Approval_Form set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Form_AssessFlow set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Form_EditFlow set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Form_File set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_KCI_Approval set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Block_Or_UnBlock set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Designated_Apply set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Discovery set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Extend set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            //sql = "update As_Vendor_FormType set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + " and Factory='" + factory + "'";
            //DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_FormType_History set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Risk set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_Vendor_Selection set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            //sql = "update As_Vendor_FormType set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + " and Factory='" + factory + "'";
            //DBHelp.ExecuteCommand(sql);

            sql = "update As_VendorCreation set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_VendorFile_OverDue set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            sql = "update As_VendorModify set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "' and Factory_Name='" + factory + "'";
            DBHelp.ExecuteCommand(sql);

            //sql = "update As_Vendor_FormType set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + " and Factory='" + factory + "'";
            //DBHelp.ExecuteCommand(sql);

            sql = "update As_Write set Temp_Vendor_ID='" + newTempVendorID + "' where Temp_Vendor_ID='" + oldTempVendorID + "'";
            DBHelp.ExecuteCommand(sql);

            //更新文件的ID
            sql = "select File_Path from As_File where Temp_Vendor_ID='" + newTempVendorID + "' and Factory_Name='" + factory + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string fileID;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileID = dr["File_Path"].ToString().Replace(oldTempVendorID, newTempVendorID);
                    string sqls = "update As_File set File_Path='" + fileID + "' where Temp_Vendor_ID='" + newTempVendorID + "' and Factory_Name='" + factory + "'";
                    DBHelp.ExecuteCommand(sqls);
                }
            }

            //更新表的路径
            sql = "select Form_Path from As_Form where Temp_Vendor_ID='" + newTempVendorID + "' and Factory_Name='" + factory + "'";
            DataTable tables = DBHelp.GetDataSet(sql);
            string formID;
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_Path"].ToString().Replace(oldTempVendorID, newTempVendorID);
                    string sqls = "update As_Form set Form_Path='" + formID + "' where Temp_Vendor_ID='" + newTempVendorID + "' and Factory_Name='" + factory + "'";
                    DBHelp.ExecuteCommand(sqls);
                }
            }
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
