using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ItemNotifyInfo;
using System.Data.SqlClient;
using BO.ItemNotifyInfo;

namespace DAL.ItemNotifyInfo
{
    public class ItemNotify_DAL
    {
        public List<ItemNotify_BO > ItemNotify_DAL_DeleteUser_Plant(string plantname)
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@plantname", plantname) };
            string Sqlstr = "select Item_Notify_Delete_User from ItemNotifyUser where plant_name=@plantname";
            return SqlUtil.Query<ItemNotify_BO>(Sqlstr, parm);
        }
    }
}
