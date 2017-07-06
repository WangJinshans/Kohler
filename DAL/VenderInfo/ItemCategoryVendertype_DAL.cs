﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using System.Data.SqlClient;
using BO.VenderInfo;



namespace DAL.VenderInfo
{
    public class ItemCategoryVendertype_DAL
    {
        public List<ItemCategory_BO  > ItemCategory_DAL_List(string vendercode,string plantname,string vendertype)
            
        {
            
            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            SqlParameter[] parm = new SqlParameter[] { new SqlParameter("@vendercode", vendercode), new SqlParameter("@plantname", plantname),new SqlParameter ("@vendertype",vendertype) };
            string strsql = "select  item_category,item_option,item_upload,item_valid,item_label,item_label_spec,item_plant_all,item_vendertype_all,item_notify,item_notify_day_before,item_notify_day_before_first,item_notify_day_before_second,item_notify_day_before_third,case when Item_Category not in (select item_category from itemList where vender_code=@vendercode and (item_plant='ALL' OR item_plant=@plantname) and (item_vendertype='ALL' or item_vendertype=@vendertype) and item_state='Enable' ) then '../pic/unfinished.png'  else '../pic/finished.png' end as Item_FinishedstateUrl   from itemCategoryvendertype where Item_Option ='True' and vender_type=@vendertype order by id";
            return SqlUtil.Query<ItemCategory_BO >(strsql,parm);
        }

        
        public List<ItemCategory_BO> ItemCategory_DAL_ListAll(string vendertype)
        {

            Utility.SqlUtil SqlUtil = new Utility.SqlUtil();
            string strsql = "select item_category,item_option,item_upload,item_valid,item_label,item_label_spec,item_plant_all,item_vendertype_all,item_notify,item_notify_day_before,item_notify_day_before_first,item_notify_day_before_second,item_notify_day_before_third from itemCategoryvendertype where vender_type=@vendertype  order by id";
            SqlParameter[] Parm = new SqlParameter [] { new SqlParameter("@vendertype", vendertype) };
            return SqlUtil.Query<ItemCategory_BO>(strsql,Parm);
        }
    }
}
