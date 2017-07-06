using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using System.Data.SqlClient;
using BO.VenderInfo;


namespace DAL.VenderInfo
{
    public class ItemList_DAL
    {
        public int ItemList_DAL_Insert(string vendercode, string itemcategory, string itempath, string itemplant,string itemvendertype, string itemstate, string itemlabel,DateTime  itemstartdate, DateTime  itemenddate, DateTime  uploaddate, string uploadperson, string itemcomment)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[]{new SqlParameter ("@vendercode",vendercode ),new SqlParameter ("@itemcategory",itemcategory ), 
            new SqlParameter ("@itempath",itempath),new SqlParameter ("@itemplant",itemplant),new SqlParameter ("@itemvendertype",itemvendertype ),new SqlParameter ("@itemstate",itemstate),
            new SqlParameter("@itemlabel",itemlabel),new SqlParameter ("@itemstartdate",itemstartdate ),new SqlParameter ("@itemenddate",itemenddate ),
            new SqlParameter ("@uploaddate",uploaddate ),new SqlParameter ("@uploadperson",uploadperson ),new SqlParameter ("@itemcomment",itemcomment )};
            string sqlstr = "insert into itemList(vender_code,item_category,item_path,item_plant,item_vendertype,item_state,item_label,item_startdate,item_enddate,upload_date,upload_person,item_comment) values (@vendercode,@itemcategory,@itempath,@itemplant,@itemvendertype,@itemstate,@itemlabel,@itemstartdate,@itemenddate,@uploaddate,@uploadperson,@itemcomment)";

            return Sqlutil.ExecuteNonQuery(sqlstr, Parm);
        }

        public List<ItemList_BO> ItemList_DAL_List(string vendercode)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode) };
            string sqlstr = "select vender_code,item_category,item_path,('..'+SUBSTRING(item_path,PATINDEX('%\\Upload%',item_path),len(item_path)))as item_path_absolute,item_plant,item_vendertype,item_state,item_label,case when cast(item_startdate as date)=cast('1900-01-01'as date) then '' else cast(cast(item_startdate as date)as nvarchar) end as item_startdate,case when cast(item_enddate as date)=cast('1900-01-01' as date) then '' else cast(cast(item_enddate as date)as nvarchar) end as item_enddate,cast(upload_date as date)as upload_date,upload_person,item_comment from itemlist where vender_code=@vendercode  order by item_plant, item_vendertype,item_Category ";
            return Sqlutil.Query<ItemList_BO>(sqlstr, Parm);

        }

        public int ItemList_DAL_Delete(string vendercode, string itemlabel)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode),new SqlParameter ("@itemlabel",itemlabel ) };
            string sqlstr = "delete from itemList where vender_code=@vendercode and item_label=@itemlabel";

            return Sqlutil.ExecuteNonQuery(sqlstr, Parm);
        }

        public int ItemList_DAL_UpdateDisable(string vendercode, string plantname,string vendertype)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname),new SqlParameter ("@vendertype",vendertype) };
            string sqlstr = "update itemList set item_state='Disable' where vender_code=@vendercode and item_plant=@plantname and item_vendertype=@vendertype";
            return Sqlutil.ExecuteNonQuery(sqlstr, Parm);

        }

        public int ItemList_DAL_UpdateValidity(string itemlabel,string itemstate,DateTime itemstartdate,DateTime itemenddate)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@itemlabel", itemlabel),new SqlParameter ("@itemstate",itemstate ),new SqlParameter ("@itemstartdate",itemstartdate ),new SqlParameter ("@itemenddate",itemenddate ) };

            string sqlstr = "update itemList set item_state=@itemstate,item_startdate=@itemstartdate,item_enddate=@itemenddate where item_label=@itemlabel";
            return Sqlutil.ExecuteNonQuery(sqlstr, Parm);

        }

        public List<ItemList_BO> ItemList_DAL_List_Plant(string vendercode, string plantname,string vendertype)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname),new SqlParameter ("@vendertype",vendertype) };
            string sqlstr = "select vender_code,item_category,item_path,('..'+SUBSTRING(item_path,PATINDEX('%\\Upload%',item_path),len(item_path)))as item_path_absolute,item_plant,item_vendertype,item_state,item_label,case when cast(item_startdate as date)=cast('1900-01-01'as date) then '' else cast(cast(item_startdate as date)as nvarchar) end as item_startdate,case when cast(item_enddate as date)=cast('1900-01-01' as date) then '' else cast(cast(item_enddate as date)as nvarchar) end as item_enddate,cast(upload_date as date)as upload_date,upload_person,item_comment from itemlist where vender_code=@vendercode and (item_plant=@plantname or item_plant='ALL') and (item_vendertype=@vendertype or item_vendertype='ALL') order by item_plant,item_vendertype, item_Category ";
            return Sqlutil.Query<ItemList_BO>(sqlstr, Parm);
        }


        public List<ItemList_BO> ItemList_DAL_List_Plantname(string vendercode, string plantname, string vendertype)
        {
            Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
            SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname), new SqlParameter("@vendertype", vendertype) };
            string sqlstr = "select vender_code,item_category,item_path,('..'+SUBSTRING(item_path,PATINDEX('%\\Upload%',item_path),len(item_path)))as item_path_absolute,item_plant,item_vendertype,item_state,item_label,case when cast(item_startdate as date)=cast('1900-01-01'as date) then '' else cast(cast(item_startdate as date)as nvarchar) end as item_startdate,case when cast(item_enddate as date)=cast('1900-01-01' as date) then '' else cast(cast(item_enddate as date)as nvarchar) end as item_enddate,cast(upload_date as date)as upload_date,upload_person,item_comment from itemlist where vender_code=@vendercode and item_plant=@plantname and item_vendertype=@vendertype order by item_plant,item_vendertype, item_Category ";
            return Sqlutil.Query<ItemList_BO>(sqlstr, Parm);
        }


        public int ItemList_DAL_UpdateVendercode(string oldvendercode,string newvendercode)
        {
             Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
             SqlParameter[] Parm = new SqlParameter[] { new SqlParameter("@oldvendercode", oldvendercode),new SqlParameter ("@newvendercode",newvendercode) };
             string sqlstr = "update itemList set vender_code=@newvendercode where vender_code=@oldvendercode";
             return Sqlutil.ExecuteNonQuery(sqlstr, Parm);
        }

       // public int ItemList_DAL_UpdateVendertype(string vendercode,string oldvendertype,string newvendertype,string plantname)
        //{
            //Utility.SqlUtil Sqlutil = new Utility.SqlUtil();
           // SqlParameter[] Parm = new SqlParameter[] { new SqlParameter ("@vendercode",vendercode), new SqlParameter("@oldvendertype", oldvendertype),new SqlParameter ("@newvendertype",newvendertype),new SqlParameter ("@plantname",plantname ) };
           // string sqlstr = "update itemList set item_vendertype=@newvendertype where vender_code=@vendercode and item_vendertype=@oldvendertype and item_plant=@plantname";
           // return Sqlutil.ExecuteNonQuery(sqlstr, Parm);
       // }
        
    }
}
