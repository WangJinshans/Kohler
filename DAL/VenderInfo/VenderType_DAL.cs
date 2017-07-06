using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo ;
using System.Data.SqlClient;
using BO.VenderInfo;

namespace DAL.VenderInfo
{
    public class VenderType_DAL
    {
        public List<VenderType_BO > Vendertype_DAL ()
    {
        Utility.SqlUtil Sqlutil =new Utility.SqlUtil();
        string sqlstring = "select distinct Vender_Type from ItemCategoryVenderType";
        return Sqlutil.Query<VenderType_BO>(sqlstring);
    }

       

        public List<VenderType_BO> Vendertype_DAL_VendercodePlantname(string vendercode, string plantname)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            string sqlstring = "select Vender_Type from venderplantinfo where vender_code=@vendercode and plant_name=@plantname";
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode),new SqlParameter ("@plantname",plantname ) };
            return Sqlutil.Query<VenderType_BO>(sqlstring, Parm);

        }


    }
}
