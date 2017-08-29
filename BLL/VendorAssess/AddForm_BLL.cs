using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddForm_BLL
    {
        public static int addForm(As_Form form)
        {
            return AddForm_DAL.addForm(form);
        }
        public static string GetVendorName(string formID)
        {
            return AddForm_DAL.GetVendorName(formID);
        }
        public static string GetTempVendorID(string formID)
        {
            return AddForm_DAL.GetTempVendorID(formID);
        }

        public static bool deleteForm(string formID)
        {
            return AddForm_DAL.deleteForm(formID);
        }

        public static string GetForm_Type_ID(string formID)
        {
            return AddForm_DAL.GetForm_Type_ID(formID);
        }

        public static int upDateFormPath(string formID, string newPath)
        {
            string sql = "update As_Form set Form_Path='" + newPath + "' where Form_ID='" + formID + "'";
            return AddForm_DAL.upDateFormPath(sql);
        }
    }
}
