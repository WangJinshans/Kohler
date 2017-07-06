using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.UserInfo;


namespace BLL.UserInfo
{
    public class UserInfo_BLL
    {
        public List<UserInfo_BO> UserInfo_BLL_List(string usernum)
        {
            UserInfo_DAL UserInfo_DAL = new UserInfo_DAL();
            return UserInfo_DAL.UserInfo_DAL_List(usernum);
        }
    }
}
