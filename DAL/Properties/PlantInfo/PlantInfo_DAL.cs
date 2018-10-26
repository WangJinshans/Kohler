using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PlantInfo;
using System.Data.SqlClient;
using BO.PlantInfo;

namespace DAL.PlantInfo
{
    public class PlantInfo_DAL
    {
        public List<PlantInfo_BO> PlantInfo_DAL_List_Plant(string plantname)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@plantname", plantname) };
            string sqlstr = "select notify_user from plantlist where plant_name=@plantname";
            return Sqlutil.Query<PlantInfo_BO>(sqlstr, parm);
        }
    }
}
