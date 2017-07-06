using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient ;

namespace DAL.VenderInfo
{
    public class OperationLog_DAL
    {
        public int ItemOperationLog_DAL_Insert(string itemlabel, string itemoperation, string username)
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            string sqlstr = "insert into itemOperationLog(item_label,item_operation,operation_user) values(@itemlabel,@itemoperation,@username)";
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@itemlabel", itemlabel), new SqlParameter("@itemoperation", itemoperation), new SqlParameter("@username", username) };
            return SqlUtil.ExecuteNonQuery(sqlstr, Parm);
        }


        public int VenderOperationLog_DAL_Insert(string vendercode, string vendertype, string plantname, string venderoperation, string username)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            string sqlstr = "insert into venderOperationLog(vender_code,vender_type,plant_name,vender_operation,operation_user) values(@vendercode,@vendertype,@plantname,@venderoperation,@username)";
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@vendertype", vendertype), new SqlParameter("@plantname", plantname),new SqlParameter ("@venderoperation",venderoperation ), new SqlParameter("@username", username) };
            return Sqlutil.ExecuteNonQuery(sqlstr, Parm);

        }
    }
}
