using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddForm_DAL
    {
        public static int addForm(As_Form form)
        {
            string sql = "INSERT INTO As_Form VALUES(@Form_ID,@form_name,@Form_Path,@Form_Type_ID,@Temp_Vendor_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Form_ID",form.Form_ID),
                new SqlParameter("Form_Name",form.Form_Name),
                new SqlParameter("Form_Path",form.Form_Path),
                new SqlParameter("Form_Type_ID",form.Form_Type_ID),
                new SqlParameter("Temp_Vendor_Name",form.Temp_Vendor_Name)

            };
            return DBHelp.GetScalar(sql, sp);
        }
    }
}
