using DAL.VendorAssess;
using MODEL.VendorAssess;
using System.Data;

namespace BLL.VendorAssess
{
    public class NewForms_BLL
    {
        public static int addNewForm(As_New_Forms form)
        {
            return NewForms_DAL.addNewForm(form);
        }
        public static int upDateNewForm(As_New_Forms form, As_New_Forms oldform)
        {
            return NewForms_DAL.upDateNewForm(form, oldform);
        }

        public static string getNewFormID(As_New_Forms form)
        {
            string formID = "";
            DataTable table = new DataTable();
            table = NewForms_DAL.getNewFormID(form);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString().Trim();
                }
            }
            return formID;
        }

    }
}
