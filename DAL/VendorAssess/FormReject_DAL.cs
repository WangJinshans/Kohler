using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;

namespace DAL.VendorAssess
{
    public class FormReject_DAL
    {
        /// <summary>
        /// Status 为true表示真的拒绝 false 表示拒绝已经处理过
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static int insertFormReject(As_Form_Reject form)
        {
            string sql = "insert into As_FormAsscess_Reject(Form_ID,Status)values('" + form.Form_ID + "','" + form.Status + "')";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateRejectFormStatus(As_Form_Reject form)
        {
            string sql = "update As_FormAsscess_Reject set Status='" + form.Status + "' where Form_ID='" + form.Form_ID + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static bool isExist(As_Form_Reject form)
        {
            string sql = "select Form_ID from As_FormAsscess_Reject where Form_ID='" + form.Form_ID + "' and Status='TRUE'";
            using (SqlDataReader reader = DBHelp.GetReader(sql))
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }
}
