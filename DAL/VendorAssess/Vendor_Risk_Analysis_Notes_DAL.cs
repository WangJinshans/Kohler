using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MODEL;
using Model;
using System.Data;

namespace DAL.VendorAssess
{
    public class Vendor_Risk_Analysis_Notes_DAL
    {
        public static int addNotes(As_Vendor_Risk_Notes notes)
        {
            string sql = "insert into As_Vendor_Risk_Notes(Form_ID,Notes,Property_Name) VALUES (@Form_ID,@Notes,@Property_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Notes",notes.Notes),
                new SqlParameter("@Property_Name",notes.Property_Name),
                new SqlParameter("@Form_ID",notes.Form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int deleteNotes(string formID)
        {
            string delSql = "delete from As_Vendor_Risk_Notes where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            return DBHelp.ExecuteCommand(delSql, sp);
        }

        public static List<As_Vendor_Risk_Notes> getNotes(string formID)
        {
            string sql = "select * from As_Vendor_Risk_Notes where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable table = DBHelp.GetDataSet(sql, sp);
            List<As_Vendor_Risk_Notes> list = new List<As_Vendor_Risk_Notes>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    As_Vendor_Risk_Notes note = new As_Vendor_Risk_Notes();
                    note.Property_Name = dr["Property_Name"].ToString();
                    note.Notes = dr["Notes"].ToString();
                    list.Add(note);
                }
            }
            return list;
        }
    }
}
