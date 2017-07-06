using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.SystemAdmin ;
using BO.SystemAdmin;
using System.Data.SqlClient;


namespace DAL.SystemAdmin
{
    public class SystemAdmin_DAL


    {

        public List<SystemAdmin_BO > SystemAdmin_DAL_List(string usernum)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter Parm = new SqlParameter("@usernum", usernum);
            string sqlstr = "select user_num from systemadmin where user_num=@usernum ";
            return Sqlutil.Query<SystemAdmin_BO>(sqlstr,Parm);
        }
       
    }
}
