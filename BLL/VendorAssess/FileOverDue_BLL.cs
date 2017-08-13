using DAL;
using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class FileOverDue_BLL
    {
        public static IList<As_File_OverDue> getOverDueFile(string temp_Vendor_ID)
        {
            As_File_OverDue form = new As_File_OverDue();
            List<As_File_OverDue> list = new List<As_File_OverDue>();
            string sql = "select * from As_VendorFile_OverDue where Temp_Vendor_ID ='" + temp_Vendor_ID + "'";
            DataTable table = new DataTable();
            table = FileOverDue_DAL.getOverDueFile(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    form.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    form.FileType_Name = Convert.ToString(dr["FileType_Name"]);
                    //form.Position = Convert.ToString(dr["Position"]);
                    list.Add(form);
                }
            }
            return list;
        }
        public static IList<As_Form_OverDue> getOverDueForm(string temp_Vendor_ID)//获取所有过期的表
        {
            As_Form_OverDue form = new As_Form_OverDue();
            string fileID = "";
            DataTable table = new DataTable();        
            IList<As_Form_OverDue> formlist = new List<As_Form_OverDue>();//表
            IList<As_File_OverDue> filelist = new List<As_File_OverDue>();//文件
            //获取所有表 通过File_ID
            filelist = getOverDueFile(temp_Vendor_ID);//得到File_Type_Name 的一个list
            if (filelist != null && filelist.Count>0)
            {
                foreach (As_File_OverDue file in filelist)
                {
                    table = FileOverDue_DAL.getOverDueForm(temp_Vendor_ID, file.FileType_Name);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            form.Temp_Vendor_ID = temp_Vendor_ID;
                            form.Form_ID = Convert.ToString(dr["Form_ID"]);
                            //form.Status = "过期";//添加form标志 5 表示过期
                            string status = VendorForm_DAL.isOverDue(temp_Vendor_ID, AddForm_BLL.GetForm_Type_ID(Convert.ToString(dr["Form_ID"])));
                            form.Status = status;
                            form.Form_Type_Is_Optional = FormType_BLL.getOptional(Convert.ToString(dr["Form_ID"]));
                            formlist.Add(form);
                        }
                    }
                }
            }
            return formlist;
        }
        public static int reAccessForm(string formID,string temp_Vendor_ID)
        {
            return FileOverDue_DAL.reAccessForm(formID, temp_Vendor_ID);
        }
    }
}
