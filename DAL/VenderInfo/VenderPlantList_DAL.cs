using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient ;
using DAL.VenderInfo ;
using BO.VenderInfo;

namespace DAL.VenderInfo
{
  public class VenderPlantList_DAL
    {

      public int VenderPlantList_DAL_Insert(string vendercode, string plantname, string state,string vendertype )
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname), new SqlParameter ("@vendertype",vendertype),new SqlParameter("@state", state) };
          string sqlstr = "insert into venderPlantinfo(vender_code,plant_name,vender_type,vender_state) values(@vendercode,@plantname,@vendertype,@state) ";
          return Sqlutil.ExecuteNonQuery(sqlstr, parm);
      }

     

      public List<VenderPlantList_BO> VenderPlantList_DAL_List(string vendercode,string plantname,string vendertype)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter [] parm=new SqlParameter  []{new SqlParameter ("@vendercode",vendercode),new SqlParameter ("@plantname",plantname),new SqlParameter ("@vendertype",vendertype)};
          string sqlstr = "select a.vender_code,b.vender_name,a.plant_name,a.vender_type,a.vender_state from (select vender_code,plant_name,vender_type,vender_state from venderplantinfo where vender_code=@vendercode and plant_name=@plantname and vender_type=@vendertype)a left join venderlist b on a.vender_code=b.vender_code ";
          return Sqlutil.Query<VenderPlantList_BO>(sqlstr, parm);
      }


      public List<VenderPlantList_BO> VenderPlantList_DAL_ListAll(string vendercode)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode) };
          string sqlstr = "select a.vender_code as vender_code,b.vender_name as vender_name,a.plant_name as plant_name,a.vender_type as vender_type,a.vender_state as vender_state from (select vender_code,plant_name,vender_state,vender_type from venderplantinfo where vender_code=@vendercode )a left join ( select distinct vender_code,vender_name from venderlist where vender_code=@vendercode) b on a.vender_code=b.vender_code ";
          return Sqlutil.Query<VenderPlantList_BO>(sqlstr, parm);
      }


      public int VenderPlantList_DAL_Update(string vendercode, string plantname, string state,string vendertype)
      {
          Utility.SqlUtil SqlUTIL = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname), new SqlParameter("@venderstate", state),new SqlParameter ("@vendertype",vendertype) };
          string sqlstr = "update venderPlantinfo set vender_state=@venderstate where vender_code=@vendercode and plant_name=@plantname and vender_type=@vendertype";
          return SqlUTIL.ExecuteNonQuery(sqlstr, parm);
      }

      public List<VenderList_BO> VenderPlantList_DAL_List_Plant(string plantname)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@plantname", plantname) };
          string sqlstr = "select distinct vender_code from venderplantinfo where plant_name=@plantname";
          return Sqlutil.Query<VenderList_BO>(sqlstr, parm);
      }

      public int VenderPlantList_DAL_Update_VenderName(string oldvendercode,string newvendercode,string vendername)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@oldvendercode", oldvendercode),new SqlParameter ("@newvendercode",newvendercode ),new SqlParameter ("@vendername",vendername ) };
          string sqlstr = "update venderplantinfo set vender_code=@newvendercode where vender_code=@oldvendercode";
          return Sqlutil.ExecuteNonQuery(sqlstr, parm);
      }

      public int VenderPlantList_DAL_Update_VenderType(string vendercode, string plantname, string oldvendertype, string newvendertype)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname), new SqlParameter("@oldvendertype", oldvendertype), new SqlParameter("@newvendertype", newvendertype) };
          string sqlstr = "update venderplantinfo set vender_type=@newvendertype where vender_code=@vendercode and plant_name=@plantname and vender_type=@oldvendertype";
          return Sqlutil.ExecuteNonQuery(sqlstr, parm);
      }

      public int VenderPlantList_DAL_DEL(string vendercode, string vendertype, string plantname)
      {
          Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
          SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@vendertype", vendertype), new SqlParameter("@plantname", plantname) };
          string sqlstr = "delete from venderplantinfo where vender_code=@vendercode and vender_type=@vendertype and plant_name=@plantname";
          return Sqlutil.ExecuteNonQuery(sqlstr, Parm);
      }

      

    }
}
