using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    form.Form_Name = Convert.ToString(dr["Form_Name"]);
                    form.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    form.Form_ID = Convert.ToString(dr["Form_ID"]);
                    list.Add(form);
                }
            }
            return list;
        }
    }
}
