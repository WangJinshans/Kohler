using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SelectApproveForm_DAL
    {
        public static IList<As_Approve> selectApproveForm(string sql)
        {
            IList<As_Approve> list = new List<As_Approve>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Approve Approve = new As_Approve();
                    Approve.Form_ID = Convert.ToString(dr["Form_ID"]);
                    Approve.Position_Name = Convert.ToString(dr["Position_Name"]);
                    Approve.Assess_Flag = Convert.ToString(dr["Assess_Flag"]);
                    Approve.Assess_Time= Convert.ToString(dr["Assess_Time"]);
                    Approve.Assess_Reason = Convert.ToString(dr["Assess_Reason"]);
                    Approve.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Approve.Form_Type_Name = Convert.ToString(dr["Form_Type_Name"]);
                    Approve.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    list.Add(Approve);
                }

            }
            return list;
        }
    }
}
