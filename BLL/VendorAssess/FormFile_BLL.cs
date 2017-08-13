using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class FormFile_BLL
    {
        public static IList<As_Form_File> listFile(string sql)
        {
            return Form_File_DAL.listFile(sql);
        }
        public static IList<string> listFileID(string Temp_Vendor_ID,string Form_ID)
        {
            IList<string> filelist = new List<string>();
            string file_ID = "";
            DataTable table = new DataTable();
            table = Form_File_DAL.listFileID(Temp_Vendor_ID, Form_ID);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    file_ID = dr["File_ID"].ToString().Trim();
                    filelist.Add(file_ID);
                }
            }
            return filelist;
        }
        public static int addFormFile(As_Form_File asFormFile)
        {
            return Form_File_DAL.addFormFile(asFormFile);
        }

        public static void dataReBind(string newform_ID, string temp_Vendor_ID, string form_ID)
        {
            IList<string> filelist = new List<string>();
            filelist = FormFile_BLL.listFileID(temp_Vendor_ID, form_ID);//获取了所有文件ID
            if (filelist.Count > 0)
            {
                foreach (string file_ID in filelist)
                {
                    As_Form_File formfile = new As_Form_File();
                    formfile.File_ID = file_ID;
                    formfile.Form_ID = newform_ID;
                    formfile.Temp_Vendor_ID = temp_Vendor_ID;
                    Form_File_DAL.addFormFile(formfile);
                }
            }
        }

    }
}
