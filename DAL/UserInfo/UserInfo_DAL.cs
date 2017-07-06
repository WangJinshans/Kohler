using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.UserInfo ;
using System.Data.SqlClient;

namespace DAL.UserInfo
{
    public class UserInfo_DAL
    {
        public List<UserInfo_BO> UserInfo_DAL_List(string usernum)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter [] parm=new SqlParameter []{new SqlParameter ("@usernum",usernum )};
            string sqlstr = "select user_num,write_plant from userinfo where user_num=@usernum";
            return Sqlutil.Query<UserInfo_BO>(sqlstr, parm);
        }
    }
}
