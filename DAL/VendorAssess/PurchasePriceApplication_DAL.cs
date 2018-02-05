using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;
using System.Data;

namespace DAL.VendorAssess
{
    public class PurchasePriceApplication_DAL
    {
        public static int addVendorPurchasePrice(As_PurchasePriceApplication vendor_PurchasePrice)
        {
            string sql = "insert into As_Vendor_PurchasePriceApplication(Form_Type_ID,Temp_Vendor_ID,Temp_Vendor_Name,Flag,Factory_Name)values(@Form_Type_ID,@Temp_Vendor_ID,@Temp_Vendor_Name,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_Name",vendor_PurchasePrice.Temp_Vendor_Name),
               new SqlParameter("@Flag",vendor_PurchasePrice.Flag),
               new SqlParameter("@Form_Type_ID",vendor_PurchasePrice.Form_Type_ID),
               new SqlParameter("@Temp_Vendor_ID",vendor_PurchasePrice.Temp_Vendor_ID),
               new SqlParameter("@Factory_Name",vendor_PurchasePrice.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateVendorPurchasePrice(As_PurchasePriceApplication purchasePrice)
        {
            string sql = "insert into As_Vendor_PurchasePriceApplication_Item(NO,SKU,Description,Supplier,USD_Cost,Tooling_Cost,TTL_Cost,MOQ,Lead_time,Other_Source,Order_Share,Now_Price,Form_ID)values(@NO,@SKU,@Description,@Supplier,@USD_Cost,@Tooling_Cost,@TTL_Cost,@MOQ,@Lead_time,@Other_Source,@Order_Share,@Now_Price,@Form_ID)";
            string del_sql = "delete from As_Vendor_PurchasePriceApplication_Item where Form_ID=@Form_ID";

            string sql1 = "UPDATE As_Vendor_PurchasePriceApplication SET Initiator=@Initiator WHERE Form_ID=@Form_ID";
            SqlParameter[] up_spp = new SqlParameter[]
            {
                new SqlParameter("@Initiator", purchasePrice.Initiator),
                new SqlParameter("@Form_ID",purchasePrice.Form_ID)
            };
            DBHelp.ExecuteCommand(sql1, up_spp);

            if (purchasePrice != null && purchasePrice.PurchasePriceItem != null && purchasePrice.PurchasePriceItem.Count > 0)
            {
                SqlParameter[] sq = new SqlParameter[]
                    {
                        new SqlParameter("@Form_ID",purchasePrice.Form_ID)
                    };
                DBHelp.ExecuteCommand(del_sql, sq);
            }
            

            if (purchasePrice != null && purchasePrice.PurchasePriceItem != null && purchasePrice.PurchasePriceItem.Count > 0)
            {
                int index = 1;
                foreach (As_PurchasePriceApplication_Item vendor_PurchasePrice in purchasePrice.PurchasePriceItem)
                {
                    SqlParameter[] sp = new SqlParameter[]
                    {
                        new SqlParameter("@NO",Convert.ToString(index)),
                        new SqlParameter("@SKU",vendor_PurchasePrice.SKU),
                        new SqlParameter("@Description",vendor_PurchasePrice.Description),
                        new SqlParameter("@Supplier",vendor_PurchasePrice.Supplier),
                        new SqlParameter("@USD_Cost",vendor_PurchasePrice.USD_Cost),
                        new SqlParameter("@Tooling_Cost",vendor_PurchasePrice.Tooling_Cost),
                        new SqlParameter("@TTL_Cost",vendor_PurchasePrice.TTL_Cost),
                        new SqlParameter("@MOQ",vendor_PurchasePrice.MOQ),
                        new SqlParameter("@Lead_time",vendor_PurchasePrice.Lead_time),
                        new SqlParameter("@Other_Source",vendor_PurchasePrice.Other_Source),
                        new SqlParameter("@Order_Share",vendor_PurchasePrice.Order_Share),
                        new SqlParameter("@Now_Price",vendor_PurchasePrice.Now_Price),
                        new SqlParameter("@Form_ID",vendor_PurchasePrice.Form_ID)
                    };
                    DBHelp.ExecuteCommand(sql, sp);
                    index++;
                }
            }
            return 1;//正常执行
        }

        public static int checkVendorPurchasePrice(string formId)
        {
            string sql = "select * from As_Vendor_PurchasePriceApplication where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_PurchasePriceApplication where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID),
                new SqlParameter("Form_Type_ID",formTypeID),
                new SqlParameter("Factory_Name",factory),
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static As_PurchasePriceApplication getPurchasePrice(string formId)
        {
            string sql = "select * from As_Vendor_PurchasePriceApplication where Form_ID=@Form_ID";
            string sql1 = "select * from As_Vendor_PurchasePriceApplication_Item where Form_ID=@Form_ID";
            As_PurchasePriceApplication purchasePrice = null;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            SqlParameter[] sp1 = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            As_PurchasePriceApplication_Item item = null;
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow drs in table.Rows)
                {
                    purchasePrice = new As_PurchasePriceApplication();
                    purchasePrice.PurchasePriceItem = new List<As_PurchasePriceApplication_Item>();
                    purchasePrice.Form_ID = drs["Form_ID"].ToString();
                    purchasePrice.Initiator = drs["Initiator"].ToString();
                    purchasePrice.Flag = Convert.ToInt32(drs["Flag"].ToString());
                    purchasePrice.Form_Type_ID = drs["Form_Type_ID"].ToString();
                    purchasePrice.Initiator = drs["Initiator"].ToString();
                    purchasePrice.Supply_Chain_Manager = drs["Supplier_Chain_Leader"].ToString();
                    purchasePrice.Finance_Manager = drs["Finance_Leader"].ToString();
                    purchasePrice.GM = drs["General_Manager"].ToString();
                    purchasePrice.Director_Sourcing_KCI = drs["Director_Sourcing_KCI"].ToString();
                    purchasePrice.Finance_Director_KCI = drs["Finance_Director_KCI"].ToString();
                }
            }
            DataTable table_item = DBHelp.GetDataSet(sql1, sp1);
            if(table_item != null&& table_item.Rows.Count>0)
            {
                foreach (DataRow dr in table_item.Rows)
                {
                    item = new As_PurchasePriceApplication_Item();
                    item.NO = dr["NO"].ToString();
                    item.SKU = dr["SKU"].ToString();
                    item.Description = dr["Description"].ToString();
                    item.Supplier = dr["Supplier"].ToString();
                    item.USD_Cost = dr["USD_Cost"].ToString();
                    item.Tooling_Cost = dr["Tooling_Cost"].ToString();
                    item.TTL_Cost = dr["TTL_Cost"].ToString();
                    item.MOQ = dr["MOQ"].ToString();
                    item.Lead_time = dr["Lead_time"].ToString();
                    item.Other_Source = dr["Other_Source"].ToString();
                    item.Order_Share = dr["Order_Share"].ToString();
                    item.Now_Price = dr["Now_Price"].ToString();
                    purchasePrice.PurchasePriceItem.Add(item);
                }
            }
            return purchasePrice;
        }

        public static int getVendorPurchasePriceFlag(string formId)
        {
            As_PurchasePriceApplication vendorPurchasePrice = null;
            string sql = "select distinct Flag from As_Vendor_PurchasePriceApplication where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorPurchasePrice = new As_PurchasePriceApplication();
                foreach (DataRow dr in dt.Rows)
                {
                    vendorPurchasePrice.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return vendorPurchasePrice.Flag;
        }
    }
}
