using DAL.VendorAssess;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class MultiEdit_BLL
    {
        public static As_Approve getMultiEditTop(string formID)
        {
            DataTable dt = MultiEdit_DAL.getMultiEditTop(formID);
            As_Approve ap = null;
            if (dt.Rows.Count>0)
            {
                ap = new As_Approve();
                ap.Employee_ID = dt.Rows[0]["Employee_ID"].ToString();
                ap.Email = dt.Rows[0]["Employee_Email"].ToString();
                ap.Form_Type_ID = dt.Rows[0]["Form_Type_ID"].ToString();
                ap.Form_Type_Name = dt.Rows[0]["Form_Type_Name"].ToString();
                ap.Temp_Vendor_ID = dt.Rows[0]["Temp_Vendor_ID"].ToString();
                ap.Temp_Vendor_Name = dt.Rows[0]["Temp_Vendor_Name"].ToString();
                ap.Employee_Name = dt.Rows[0]["Employee_Name"].ToString();
            }
            return ap;
        }
    }
}
