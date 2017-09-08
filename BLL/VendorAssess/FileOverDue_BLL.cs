using DAL;
using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.VendorAssess
{
    public class FileOverDue_BLL
    {
        /// <summary>
        /// 从As_VendorFile_OverDue中取出所有过期的文件
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IList<As_File_OverDue> getOverDueFile(string temp_Vendor_ID,string factory)
        {
            List<As_File_OverDue> list = new List<As_File_OverDue>();
            string sql = "select * from As_VendorFile_OverDue where Temp_Vendor_ID ='" + temp_Vendor_ID + "' and (Factory_Name='" + factory + "' or Factory_Name='ALL')";
            DataTable table = new DataTable();
            table = FileOverDue_DAL.getOverDueFile(sql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    As_File_OverDue form = new As_File_OverDue();
                    form.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    form.FileType_Name = Convert.ToString(dr["FileType_Name"]);
                    //form.Position = Convert.ToString(dr["Position"]);
                    list.Add(form);
                }
            }
            return list;
        }
        /// <summary>
        /// //获取所有过期的表
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static IList<As_Form_OverDue> getOverDueForm(string temp_Vendor_ID,string factory)
        {
            As_Form_OverDue form = new As_Form_OverDue();
            string fileID = "";
            IList<string> formlist = new List<string>();//表
            IList<As_Form_OverDue> formlists = new List<As_Form_OverDue>();//表
            IList<As_File_OverDue> filelist = new List<As_File_OverDue>();//文件
            //获取所有表 通过File_ID
            filelist = getOverDueFile(temp_Vendor_ID, factory);//得到File_Type_Name 的一个list
            if (filelist == null)
            {
                return null;
            }
            if (filelist != null && filelist.Count>0)
            {
                foreach (As_File_OverDue file in filelist)
                {
                    //返回Form_ID的一个list
                    formlist = FileOverDue_DAL.getOverDueForm(temp_Vendor_ID, file.FileType_Name,factory);
                    if (formlist == null)
                    {
                        return null;
                    }
                    if (formlist.Count > 0)
                    {
                        foreach (string formid in formlist)
                        {
                            if (formid == "")
                            {
                                continue;
                            }
                            form.Temp_Vendor_ID = temp_Vendor_ID;
                            form.Form_ID = formid;
                            //string status = VendorForm_DAL.isOverDue(temp_Vendor_ID, AddForm_BLL.GetForm_Type_ID(formid),factory);
                            //form.Status = status;
                            form.Status = "过期";
                            form.Form_Type_Is_Optional = FormType_BLL.getOptional(formid);
                            formlists.Add(form);
                        }
                    }
                }
            }
            return formlists;
        }
        public static int reAccessForm(string formID,string temp_Vendor_ID)
        {
            return FileOverDue_DAL.reAccessForm(formID, temp_Vendor_ID);
        }

        /// <summary>
        /// 判断form_ID对应的文件是否存在过期  只有存在文件过期的时候才会返回true
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static bool isFileOverDue(string formID)
        {
            bool isFileOverDue = false;
            DataTable table = new DataTable();
            DataTable tables = new DataTable();
            string tempvendorID, fileTypeID, factory;
            //获取绑定的所有的File_ID
            table = FormOverDue_DAL.getBindFiles(formID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    string fileID = dr["File_ID"].ToString().Trim();
                    tables = FileOverDue_DAL.isFileOverDueInfo(fileID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow d in tables.Rows)
                        {
                            tempvendorID = d["Temp_Vendor_ID"].ToString().Trim();
                            fileTypeID= d["File_Type_ID"].ToString().Trim();
                            factory = d["Factory_Name"].ToString();
                            isFileOverDue = FileOverDue_DAL.isFileOverDue(tempvendorID, fileTypeID, factory);
                            if (isFileOverDue)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return isFileOverDue;
        }
        /// <summary>
        /// 以list的形式返回该文件绑定的所有的File_ID
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static List<string> getFileIDsByFormID(string formID)
        {
            List<string> FileIDs = new List<string>();
            string fileID = "";
            DataTable table = FormOverDue_DAL.getBindFiles(formID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    fileID = dr["File_ID"].ToString().Trim();
                    FileIDs.Add(fileID);
                }
            }
            return FileIDs;
        }
    }
}
