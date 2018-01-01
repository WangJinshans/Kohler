using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DAL
{
    public class SelectForm_DAL
    {
        public static IList<As_Form> selectForm(string sql2)
        {
            IList<As_Form> list = new List<As_Form>();
            DataTable dt = DBHelp.GetDataSet(sql2);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Form form = new As_Form();
                    form.Form_Type_Name = Convert.ToString(dr["Form_Type_Name"]);
                    form.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    form.Form_ID = Convert.ToString(dr["Form_ID"]);
                    form.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    try
                    {
                        form.Assess_Status = dr["Assess_Status"].ToString();
                    }
                    catch (Exception)
                    {

                    }
                    list.Add(form);
                }
            }
            return list;
        }

        public static IEnumerable selectAssessFile(string sql)
        {
            IList<As_File> list = new List<As_File>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    As_File file = new As_File();
                    file.File_Path = item["File_Path"].ToString();
                    file.Is_Shared = Convert.ToBoolean(item["Is_Shared"]);
                    file.File_Type_ID = item["File_Type_ID"].ToString();
                    file.File_Type_Range = item["File_Type_Range"].ToString();
                    file.File_Enable_Time = item["File_Enable_Time"].ToString();
                    file.File_Due_Time = item["File_Due_Time"].ToString();
                    file.File_Type_Name = item["File_Type_Name"].ToString();
                    file.Temp_Vendor_ID = item["Temp_Vendor_ID"].ToString();
                    file.File_ID = item["File_ID"].ToString();
                    list.Add(file);
                }
            }
            return list;
        }

        public static IEnumerable selectManageFile(string sql)
        {
            IList<As_File> list = new List<As_File>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    As_File file = new As_File();
                    file.File_Path = item["Item_Path"].ToString();
                    //file.Is_Shared = Convert.ToBoolean(item["Is_Shared"]);
                    //file.File_Type_ID = item["File_Type_ID"].ToString();
                    file.File_Type_Range = item["Item_VenderType"].ToString();
                    file.File_Enable_Time = item["Item_Startdate"].ToString();
                    file.File_Due_Time = item["Item_Enddate"].ToString();
                    file.File_Type_Name = item["Item_Category"].ToString();
                    //file.Temp_Vendor_ID = item["Temp_Vendor_ID"].ToString();
                    //file.File_ID = item["File_ID"].ToString();
                    list.Add(file);
                }
            }
            return list;
        }

        public static IList<As_File> selectFile(string sql)
        {
            IList<As_File> list = new List<As_File>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    As_File file = new As_File();
                    file.Temp_Vendor_Name = item["Temp_Vendor_Name"].ToString();
                    file.File_Type_Range = item["File_Type_Range"].ToString();
                    file.File_Type_Name = item["File_Type_Name"].ToString();
                    file.File_Name = item["File_Name"].ToString();
                    file.File_ID = item["File_ID"].ToString();
                    list.Add(file);
                }
            }
            return list;
        }

        public static IList<As_Vendor_FormType> selectAllForm(string sql2)
        {
            IList<As_Vendor_FormType> list = new List<As_Vendor_FormType>();
            DataTable dt = DBHelp.GetDataSet(sql2);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Vendor_FormType form = new As_Vendor_FormType();
                    form.Temp_Vendor_Name = dr["Temp_Vendor_Name"].ToString();
                    form.Form_Type_Name = dr["Form_Type_Name"].ToString();
                    form.Form_Type_Is_Optional = dr["Form_Type_Is_Optional"].ToString();
                    form.Temp_Vendor_ID = dr["Temp_Vendor_ID"].ToString();
                    form.Flag = Convert.ToInt32(dr["flag"]);
                    form.Form_Type_ID = dr["Form_Type_ID"].ToString();
                    form.Form_ID = dr["Form_ID"].ToString();
                    list.Add(form);
                }
            }
            return list;
        }
    }
}
