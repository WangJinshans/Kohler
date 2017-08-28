using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class FileOverDue_DAL
    {
        public static DataTable getOverDueFile(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }
        public static DataTable getFormnumber(string sql)
        {
            DataTable table = new DataTable();
            table = DBHelp.GetDataSet(sql);
            return table;
        }

        public static List<string> getOverDueForm(string temp_Vendor_ID, string file_Type_Name,string factory)//文件过期找form的方法
        {
            As_Form_OverDue form = new As_Form_OverDue();
            string file_Type_ID = File_Type_DAL.selectFileTypeID(file_Type_Name);
            List<string> list = new List<string>();
            //As_Form_File 是表与文件绑定的地方
            string sql = "select File_ID from As_File where Temp_Vendor_ID ='" + temp_Vendor_ID + "' and File_Type_ID='" + file_Type_ID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";//获取对应的Form_ID
            DataTable table = new DataTable();
            DataTable tables = new DataTable();
            table = FormOverDue_DAL.getOverDueForm(sql);//查到的是File_ID
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    sql = "select Form_ID from As_Form_File where File_ID='" + Convert.ToString(dr["File_ID"]) + "'";
                    tables = FormOverDue_DAL.getOverDueForm(sql);//
                    if (tables.Rows.Count > 0)
                    {
                        foreach (DataRow drs in tables.Rows)
                        {
                            list.Add(drs["Form_ID"].ToString().Trim());
                        }
                    }
                }
                return list;
            }
            else
            {
                return null;//查不到formID就返回空
            }
        }

        public static int reAccessForm(string formID, string temp_Vendor_ID)
        {
            try
            {
                string form_type_ID = AddForm_DAL.GetForm_Type_ID(formID);//获取form_type_ID
                string sql = "delete from As_Approve where Form_ID='" + formID + "'";//可以再次提交
                DBHelp.ExecuteCommand(sql);
                sql = "delete from As_Form where Form_ID='" + formID + "'";//可以再次提交
                DBHelp.ExecuteCommand(sql);
                sql = "delete from As_Form_AssessFlow where Form_ID='" + formID + "'";//可以再次选择审批流程
                DBHelp.ExecuteCommand(sql);
                sql = "update As_Vendor_FormType set flag=0 where Form_Type_ID='" + form_type_ID + "' and Temp_Vendor_ID='" + temp_Vendor_ID + "'";//更新flag
                DBHelp.ExecuteCommand(sql);
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
