using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess;

namespace DAL.VendorAssess
{
    public class PurchaseChanges_DAL
    {
        public static int add(As_Purchase_Changes asPurchaseChanges)
        {
            string sql = "insert into As_Purchase_Changes(Temp_Vendor_ID,Form_Type_ID,Vendor,Flag,Factory_Name,Form_ID) values(@Temp_Vendor_ID,@Form_Type_ID,@Vendor,@Flag,@Factory_Name,'')select TOP 1 SCOPE_IDENTITY() AS returnName from As_Purchase_Changes";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",asPurchaseChanges.Temp_Vendor_ID),
                new SqlParameter("@Flag",asPurchaseChanges.Flag),
                new SqlParameter("@Form_Type_ID",asPurchaseChanges.Form_Type_ID),
                new SqlParameter("@Factory_Name",asPurchaseChanges.Factory_Name),
                new SqlParameter("@Vendor",asPurchaseChanges.Vendor),
            };
            return DBHelp.GetScalarID(sql, sp);
        }

        public static As_Purchase_Changes get(string formId)
        {
            string sql = "select * from As_Purchase_Changes Where Form_ID='" + formId + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            As_Purchase_Changes asPurchaseChanges = null;
            if (dt.Rows.Count > 0)
            {
                asPurchaseChanges = new As_Purchase_Changes();
                foreach (DataRow dr in dt.Rows)
                {
                    asPurchaseChanges.Form_ID = Convert.ToString(dr["Form_ID"]);
                    asPurchaseChanges.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    asPurchaseChanges.Date = Convert.ToString(dr["Date"]);
                    asPurchaseChanges.Flag = Convert.ToInt32(dr["Flag"]);
                    asPurchaseChanges.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    asPurchaseChanges.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    asPurchaseChanges.Factory_Name = Convert.ToString(dr["Factory_Name"]);
                    asPurchaseChanges.Purchasing_Manager = Convert.ToString(dr["Purchasing_Manager"]);
                    asPurchaseChanges.User_Department_Manager = Convert.ToString(dr["User_Department_Manager"]);
                    asPurchaseChanges.Quality_Dept_Manager = Convert.ToString(dr["Quality_Dept_Manager"]);
                    asPurchaseChanges.Finance_Leader = Convert.ToString(dr["Finance_Leader"]);
                    asPurchaseChanges.GM = Convert.ToString(dr["General_Manager"]);
                    asPurchaseChanges.Vendor = Convert.ToString(dr["Vendor"]);
                    asPurchaseChanges.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    asPurchaseChanges.Currency = Convert.ToString(dr["Currency"]);
                    asPurchaseChanges.Initiator = Convert.ToString(dr["Initiator"]);
                }
            }
            return asPurchaseChanges;
        }

        public static string getVendorPurchaseChangesFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            string formID = "";
            string sql = "select Form_ID from As_Purchase_Changes where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name and ID=@ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID),
                new SqlParameter("Form_Type_ID",fORM_TYPE_ID),
                new SqlParameter("Factory_Name",factory),
                new SqlParameter("@ID",n),
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

        public static DataTable getItems(string formId)
        {
            string sql = "select * from As_Purchase_Changes_Item where Form_ID='" + formId + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            return dt;
        }

        public static int update(As_Purchase_Changes asPurchaseChanges, List<As_Purchase_Changes_Item> list)
        {
            string sql = "UPDATE As_Purchase_Changes SET Vendor=@Vendor,Vendor_Code=@Vendor_Code,Currency=@Currency,Date=@Date,Submit=@Submit,Flag=@Flag,Initiator=@Initiator WHERE Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",asPurchaseChanges.Form_ID), 
                new SqlParameter("@Flag",asPurchaseChanges.Flag), 
                new SqlParameter("@Submit",asPurchaseChanges.Submit), 
                new SqlParameter("@Date",asPurchaseChanges.Date), 
                new SqlParameter("@Currency",asPurchaseChanges.Currency), 
                new SqlParameter("@Vendor_Code",asPurchaseChanges.Vendor_Code), 
                new SqlParameter("@Vendor",asPurchaseChanges.Vendor),
                new SqlParameter("@Initiator",asPurchaseChanges.Initiator),
            };
            int result = DBHelp.ExecuteCommand(sql, sp);
            int resudlt = DBHelp.ExecuteCommand("Delete From As_Purchase_Changes_Item Where Form_ID='" +asPurchaseChanges.Form_ID + "'");

            StringBuilder builder = new StringBuilder();
            List<SqlParameter> spList = new List<SqlParameter>();
            string sqlsb =
                "INSERT INTO As_Purchase_Changes_Item(Form_ID,SKU,Description,Unit,Last_PO_Price,Last_6_Months_Average_Price,Required_Price,STD_cost,Request_Price_VS_Last_PO_Price,STD_Cost_VS_Request_Price,Yearly_Forecast,Yearly_Amount,PPV,Current_Stock,Main_Material_Cost_Change,Main_Material_Cost_VS_Total_Cost,Required_Cost_Change,Effective_Date,Remark) VALUES";
            builder.Append(sqlsb);
            string sqlsbvls = "(@Form_ID<i>,@SKU<i>,@Description<i>,@Unit<i>,@Last_PO_Price<i>,@Last_6_Months_Average_Price<i>,@Required_Price<i>,@STD_cost<i>,@Request_Price_VS_Last_PO_Price<i>,@STD_Cost_VS_Request_Price<i>,@Yearly_Forecast<i>,@Yearly_Amount<i>,@PPV<i>,@Current_Stock<i>,@Main_Material_Cost_Change<i>,@Main_Material_Cost_VS_Total_Cost<i>,@Required_Cost_Change<i>,@Effective_Date<i>,@Remark<i>),";
            for (int i = 0; i < list.Count; i++)
            {
                As_Purchase_Changes_Item item = list[i];

                builder.Append(sqlsbvls.Replace("<i>", i.ToString()));
                spList.Add(new SqlParameter("@Form_ID"+i,asPurchaseChanges.Form_ID));
                spList.Add(new SqlParameter("@SKU" + i,item.SKU));
                spList.Add(new SqlParameter("@Description" + i,item.Description));
                spList.Add(new SqlParameter("@Unit" + i,item.Unit));
                spList.Add(new SqlParameter("@Last_PO_Price" + i,item.Last_PO_Price));
                spList.Add(new SqlParameter("@Last_6_Months_Average_Price" + i,item.Last_6_Months_Average_Price));
                spList.Add(new SqlParameter("@Required_Price" + i,item.Required_Price));
                spList.Add(new SqlParameter("@STD_cost" + i,item.STD_cost));
                spList.Add(new SqlParameter("@Request_Price_VS_Last_PO_Price" + i,item.Request_Price_VS_Last_PO_Price));
                spList.Add(new SqlParameter("@STD_Cost_VS_Request_Price" + i,item.STD_Cost_VS_Request_Price));
                spList.Add(new SqlParameter("@Yearly_Forecast" + i,item.Yearly_Forecast));
                spList.Add(new SqlParameter("@Yearly_Amount" + i,item.Yearly_Amount));
                spList.Add(new SqlParameter("@PPV" + i,item.PPV));
                spList.Add(new SqlParameter("@Current_Stock" + i,item.Current_Stock));
                spList.Add(new SqlParameter("@Main_Material_Cost_Change" + i,item.Main_Material_Cost_Change));
                spList.Add(new SqlParameter("@Main_Material_Cost_VS_Total_Cost" + i,item.Main_Material_Cost_VS_Total_Cost));
                spList.Add(new SqlParameter("@Required_Cost_Change" + i,item.Required_Cost_Change));
                spList.Add(new SqlParameter("@Effective_Date" + i,item.Effective_Date));
                spList.Add(new SqlParameter("@Remark" + i,item.Remark));
            }
            builder.Replace(',', ';', builder.Length - 1, 1);
            int resu = DBHelp.ExecuteCommand(builder.ToString(),spList.ToArray());
            return result & resu;
        }
    }
}
