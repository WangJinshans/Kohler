using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using System.Data.SqlClient;
using BO.VenderInfo;
using System.Data;

namespace DAL.VenderInfo
{
    public class VenderList_DAL
    {
        public List<VenderList_BO> VenderList_DAL_List(string vendercode)
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm=new SqlParameter []{new SqlParameter ("@vendercode",vendercode )};
            string strsql = "select Vender_Code,Vender_Name from venderList where vender_code=@vendercode";
            return SqlUtil.Query<VenderList_BO>(strsql, parm);
        }


      


        public int VenderList_DAL_Insert(string vendercode, string vendername)
        {

            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode),new SqlParameter("@vendername",vendername) };
            string strsql="insert into venderList(vender_code,vender_name) values(@vendercode,@vendername)";
            return SqlUtil.ExecuteNonQuery (strsql,parm);

        }

        public List<string> listAllVendor(string factory)
        {
            List<string> list = new List<string>();
            string strsql = "select distinct Vender_Code from View_NormalVendorList where Plant_Name='" + factory + "' order by Vender_Code";
            DataTable table = DBHelp.GetDataSet(strsql);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    list.Add(dr["Vender_Code"].ToString().Trim());
                }
            }
            return list;
        }

        public List<VenderList_BO> VenderList_DAL_ListAll()
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            string strsql = "select distinct vender_code from venderList order by vender_code";
            return SqlUtil.Query<VenderList_BO>(strsql);
        }

        public int VenderList_DAL_Update_CodeName(string oldvendercode,string newvendercode,string vendername)
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendername", vendername), new SqlParameter ("@newvendercode",newvendercode ),new SqlParameter("@oldvendercode", oldvendercode) };
            string strsql = "update venderlist set vender_name=@vendername,vender_code=@newvendercode where vender_code=@oldvendercode ";
            return SqlUtil.ExecuteNonQuery(strsql, parm);
        }

        public int VenderList_DAL_Del(string vendercode)
        {
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] {  new SqlParameter("@vendercode", vendercode) };
            string strsql = "delete from venderlist where vender_code=@vendercode ";
            return SqlUtil.ExecuteNonQuery(strsql, parm);
        }

 

     
      
    }
}
