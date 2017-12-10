using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebLearning.Model;
using Model;

namespace WebLearning.DAL
{
    public class Vendor_Modify_File_DAL
    {
        public static IList<Model.Vendor_Modify_File> getFileList(string sql)
        {
            IList<Vendor_Modify_File> fileList = new List<Vendor_Modify_File>();
            Vendor_Modify_File file;
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    file = new Vendor_Modify_File();
                    file.Factory_Name = dr["Factory_Name"].ToString();
                    file.Temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString();
                    file.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    file.Flag = dr["Flag"].ToString();
                    file.File_Type_Name = dr["File_Type_Name"].ToString();
                    file.File_Type_ID = dr["File_Type_ID"].ToString();
                    fileList.Add(file);
                }
            }
            return fileList;
        }

        public static bool isFilesUpload(string sql)
        {
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())//查到 说明有没有提交的文件
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        /// <summary>
        /// Count获取所有的类型数 并返回
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static string getTempVendorTypeNumber(string vendorCode)
        {
            string sql = "select COUNT(*)as TypeNumber from As_Temp_Vendor where Temp_Vendor_Name='" + vendorCode + "'";
            string number = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    number = dr["TypeNumber"].ToString().Trim();
                }
            }
            return number;
        }

        /// <summary>
        /// 获取供应商所有的类型
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static List<string> getTypeList(string vendorCode)
        {
            string sql = "select distinct Vendor_Type_ID from As_Temp_Vendor where Temp_Vendor_Name='" + vendorCode + "'";
            List<string> typeIDList = new List<string>();
            List<string> typeList = new List<string>();
            string type = "";
            string typeID = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    typeID = dr["Vendor_Type_ID"].ToString().Trim();
                    typeIDList.Add(typeID);
                }
            }
            if (typeIDList.Count > 0)
            {
                foreach (string vendorTypeID in typeIDList)
                {
                    type = getType(vendorTypeID, vendorCode);
                    typeList.Add(type);
                }
            }
            return typeList;
        }



        public static List<string> getTypeListByName(string vendorName)
        {
            string sql = "select distinct Vendor_Type_ID from As_Temp_Vendor where Temp_Vendor_Name='" + vendorName + "'";
            List<string> typeIDList = new List<string>();
            List<string> typeList = new List<string>();
            string type = "";
            string typeID = "";
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    typeID = dr["Vendor_Type_ID"].ToString().Trim();
                    typeIDList.Add(typeID);
                }
            }
            if (typeIDList.Count > 0)
            {
                foreach (string vendorTypeID in typeIDList)
                {
                    type = getTypeByName(vendorTypeID, vendorName);
                    typeList.Add(type);
                }
            }
            return typeList;
        }


        /// <summary>
        /// 获取供应商类型
        /// </summary>
        /// <param name="vendorTypeID"></param>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        private static string getType(string vendorTypeID, string vendorCode)
        {
            string sql = "select As_Vendor_Type.Vendor_Type from As_Temp_Vendor,As_Vendor_Type where As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendor.Temp_Vendor_Name='" + vendorCode + "' and As_Temp_Vendor.Vendor_Type_ID='" + vendorTypeID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string type = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    type = dr["Vendor_Type"].ToString().Trim();
                }
            }
            return type;
        }


        private static string getTypeByName(string vendorTypeID, string vendorName)
        {
            string sql = "select As_Vendor_Type.Vendor_Type from As_Temp_Vendor,As_Vendor_Type where As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID and As_Temp_Vendor.Temp_Vendor_Name='" + vendorName + "' and As_Temp_Vendor.Vendor_Type_ID='" + vendorTypeID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string type = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    type = dr["Vendor_Type"].ToString().Trim();
                }
            }
            return type;
        }

        public static object getModifyFormID(string temp_vendor_ID)
        {
            string sql = "select Form_ID from As_VendorModify where Temp_Vendor_ID='" + temp_vendor_ID + "'";
            DataTable table = DBHelp.GetDataSet(sql);
            string formID = "";
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                }
            }
            return formID;
        }

        public static bool vendorModifyIsSubmit(string temp_vendor_ID)
        {
            string sql = "select Form_ID from As_VendorModify where Temp_Vendor_ID='" + temp_vendor_ID + "' and flag=2";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 更新文件上传的标志
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int upDataUploadFlag(string sql)
        {
            return DBHelp.ExecuteCommand(sql);
        }

        public static IList<Vendor_Modify_File> listFile(string sql)
        {
            IList<Vendor_Modify_File> fileList = new List<Vendor_Modify_File>();
            Vendor_Modify_File modify;
            DataTable table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    modify = new Vendor_Modify_File();
                    modify.File_Type_Name = dr["File_Type_Name"].ToString().Trim();
                    fileList.Add(modify);
                }
            }
            return fileList;
        }

        public static int initVendorFile(Dictionary<string, string> list)
        {
            if (list.Count != 9)
            {
                return -1;
            }
            return DBHelp.ExecuteStoredProcedure("vendor_Modify_Procedure", list);
        }

        /// <summary>
        /// 判断该供应商是否正在修改中
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <returns></returns>
        public static string isVendorChanging(string temp_Vendor_ID)
        {
            string sql = "select IsChanging from As_Vendor_Modify_Info where Temp_Vendor_ID='" + temp_Vendor_ID + "'";
            DataTable table = new DataTable();
            string ischanging = "";
            table = DBHelp.GetDataSet(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    ischanging = dr["IsChanging"].ToString().Trim();
                }
            }
            return ischanging;
        }

        /// <summary>
        /// 查询是否更改了银行或账期信息
        /// </summary>
        /// <param name="temp_vendor_ID"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static bool isNeedFinance(string temp_vendor_ID, string factory_Name)
        {
            string sql = "select Temp_Vendor_ID from As_Vendor_Modify_Info where Temp_Vendor_ID='" + temp_vendor_ID + "' and Factory_Name='" + factory_Name + "' and (NamePartThreeSwitch='true' or NamePartFourSwitch='true')";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
            {
                if (reader.Read())//查到 说明更改了银行或账期信息
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 当添加到As_Vendor_Modify_Info这个表的时候说明该供应商正在建立修改流程
        /// 当修改流程完成之后  需要更新该字段
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <returns></returns>
        public static int upDateVendorChanging(string temp_Vendor_ID)
        {
            string sql = "update As_Vendor_Modify_Info set IsChanging='NO' where Temp_Vendor_ID='" + temp_Vendor_ID + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}