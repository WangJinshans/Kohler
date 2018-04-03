using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;
using System.Data;

namespace DAL.VendorAssess
{
    public class ServiceComponentApplication_DAL
    {
        public static int addVendorServiceComponent(As_ServiceComponentApplication vendor_ServiceComponent)
        {
            string sql = "insert into As_Vendor_ServiceComponentApplication(Form_Type_ID,Temp_Vendor_ID,Temp_Vendor_Name,Flag,Factory_Name)values(@Form_Type_ID,@Temp_Vendor_ID,@Temp_Vendor_Name,@Flag,@Factory_Name)select TOP 1 SCOPE_IDENTITY() AS returnName from As_Vendor_ServiceComponentApplication";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_Name",vendor_ServiceComponent.Temp_Vendor_Name),
               new SqlParameter("@Flag",vendor_ServiceComponent.Flag),
               new SqlParameter("@Form_Type_ID",vendor_ServiceComponent.Form_Type_ID),
               new SqlParameter("@Temp_Vendor_ID",vendor_ServiceComponent.Temp_Vendor_ID),
               new SqlParameter("@Factory_Name",vendor_ServiceComponent.Factory_Name)
            };
            return DBHelp.GetScalarID(sql, sp);
        }

        public static int updateVendorServiceComponent(As_ServiceComponentApplication vendor_ServiceComponent)
        {
            string sql = "insert into As_Vendor_ServiceComponentApplication_Item(Item_No,Description,Sku_Number,UOM,Supplier,Service_Cost,Original_Cost,MOQ,MOQ_PO,Lead_time,Form_ID)values(@Item_No,@Description,@Sku_Number,@UOM,@Supplier,@Service_Cost,@Original_Cost,@MOQ,@MOQ_PO,@Lead_time,@Form_ID)";
            string del_sql = "delete from As_Vendor_ServiceComponentApplication_Item where Form_ID=@Form_ID";
            if (vendor_ServiceComponent != null && vendor_ServiceComponent.ComponentApplicationItem != null && vendor_ServiceComponent.ComponentApplicationItem.Count > 0)
            {
                SqlParameter[] sq = new SqlParameter[]
                    {
                        new SqlParameter("@Form_ID",vendor_ServiceComponent.Form_ID)
                    };
                DBHelp.ExecuteCommand(del_sql, sq);
            }

            string sql1 = "UPDATE As_Vendor_ServiceComponentApplication SET Initiator=@Initiator,Remark=@Remark WHERE Form_ID=@Form_ID";
            SqlParameter[] up_spp = new SqlParameter[]
            {
                new SqlParameter("@Initiator", vendor_ServiceComponent.Initiator),
                new SqlParameter("@Remark",vendor_ServiceComponent.Remark),
                new SqlParameter("@Form_ID",vendor_ServiceComponent.Form_ID)
            };
            DBHelp.ExecuteCommand(sql1, up_spp);


            if (vendor_ServiceComponent != null && vendor_ServiceComponent.ComponentApplicationItem != null && vendor_ServiceComponent.ComponentApplicationItem.Count > 0)
            {
                int index = 1;
                foreach (As_ServiceComponentApplication_Item item in vendor_ServiceComponent.ComponentApplicationItem)
                {
                    SqlParameter[] sp = new SqlParameter[]
                    {
                        new SqlParameter("@Item_No",Convert.ToString(index)),
                        new SqlParameter("@Description",item.Description),
                        new SqlParameter("@Sku_Number",item.Sku_Number),
                        new SqlParameter("@UOM",item.UOM),
                        new SqlParameter("@Supplier",item.Supplier),
                        new SqlParameter("@Service_Cost",item.Service_Cost),
                        new SqlParameter("@Original_Cost",item.Original_Cost),
                        new SqlParameter("@MOQ",item.MOQ),
                        new SqlParameter("@MOQ_PO",item.MOQ_PO),
                        new SqlParameter("@Lead_Time",item.Lead_Time),
                        new SqlParameter("@Form_ID",item.Form_ID)
                    };
                    DBHelp.ExecuteCommand(sql, sp);
                    index++;
                }
            }
            return 1;//正常执行
        }

        public static string getVendorServiceComponentFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_ServiceComponentApplication where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name and ID=@ID";
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

        public static int checkVendorServiceComponent(string formId)
        {
            string sql = "select * from As_Vendor_ServiceComponentApplication where Form_ID=@Form_ID";
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

        public static int getVendorServiceComponentFlag(string formId)
        {
            As_ServiceComponentApplication vendorServiceComponent = null;
            string sql = "select distinct Flag from As_Vendor_ServiceComponentApplication where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorServiceComponent = new As_ServiceComponentApplication();
                foreach (DataRow dr in dt.Rows)
                {
                    vendorServiceComponent.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return vendorServiceComponent.Flag;
        }

        public static As_ServiceComponentApplication getServiceComponent(string formId)
        {
            string sql = "select * from As_Vendor_ServiceComponentApplication where Form_ID=@Form_ID";
            string sql1 = "select * from As_Vendor_ServiceComponentApplication_Item where Form_ID=@Form_ID";
            As_ServiceComponentApplication serviceComponent = null;
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            SqlParameter[] sp1 = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formId)
            };
            As_ServiceComponentApplication_Item item = null;
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow drs in table.Rows)
                {
                    serviceComponent = new As_ServiceComponentApplication();
                    serviceComponent.ComponentApplicationItem = new List<As_ServiceComponentApplication_Item>();
                    serviceComponent.Form_ID = drs["Form_ID"].ToString();
                    serviceComponent.Initiator = drs["Initiator"].ToString();
                    serviceComponent.Flag = Convert.ToInt32(drs["Flag"].ToString());
                    serviceComponent.Form_Type_ID = drs["Form_Type_ID"].ToString();
                    serviceComponent.Initiator = drs["Initiator"].ToString();
                    serviceComponent.Supply_Chain_Manager = drs["Purchasing_Manager"].ToString();
                    serviceComponent.Finance_Manager = drs["Finance_Leader"].ToString();
                    serviceComponent.GM = drs["General_Manager"].ToString();
                    serviceComponent.Remark = drs["Remark"].ToString();
                }
            }
            DataTable table_item = DBHelp.GetDataSet(sql1,sp1);
            if (table_item != null && table_item.Rows.Count > 0)
            {
                foreach (DataRow dr in table_item.Rows)
                {
                    item = new As_ServiceComponentApplication_Item();
                    item.Item_No = dr["Item_No"].ToString();
                    item.Description = dr["Description"].ToString();
                    item.Sku_Number = dr["Sku_Number"].ToString();
                    item.UOM = dr["UOM"].ToString();
                    item.Supplier = dr["Supplier"].ToString();
                    item.Service_Cost = dr["Service_Cost"].ToString();
                    item.Original_Cost = dr["Original_Cost"].ToString();
                    item.MOQ = dr["MOQ"].ToString();
                    item.MOQ_PO = dr["MOQ_PO"].ToString();
                    item.Lead_Time = dr["Lead_time"].ToString();
                    serviceComponent.ComponentApplicationItem.Add(item);
                }
            }
            return serviceComponent;
        }

        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_ServiceComponentApplication where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
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
    }
}
