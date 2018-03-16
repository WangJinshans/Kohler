using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using BLL.VenderInfo;

namespace BLL
{
    public class SelectForm_BLL
    {
        public static IList<As_Form> selectForm(string sql2)
        {
            return SelectForm_DAL.selectForm(sql2);
        }

        public static IList<As_Vendor_FormType> selectAllForm(string sql2)
        {
            return SelectForm_DAL.selectAllForm(sql2);
        }

        public static IList<As_File> selectFile(string sql)
        {
            return SelectForm_DAL.selectFile(sql);
        }

        public static IEnumerable selecManageFile(string sql)
        {
            return SelectForm_DAL.selectManageFile(sql);
        }

        public static IEnumerable selectAssessFile(string sql,string normalID,string tempVendorID)
        {
            IList<As_File> list = (IList<As_File>)SelectForm_DAL.selectAssessFile(sql);
            foreach (As_File file in list.ToArray())
            {
                if (ItemList_BLL.isFileIDExists((file.File_ID).Replace(tempVendorID, normalID)))
                {
                    list.Remove(file);
                    
                }
            }
            return list;
        }
    }
}
