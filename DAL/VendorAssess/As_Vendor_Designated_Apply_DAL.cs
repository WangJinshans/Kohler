using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class As_Vendor_Designated_Apply_DAL
    {
        public static int updateForm(As_Vendor_Designated_Apply vendor_Designated)
        {
            string sql = "update As_Vendor_Designated_Apply SET vendorName=@vendorName,SAPCode=@SAPCode,businessCategory=@businessCategory,effectiveTime=@effectiveTime,purchaseAmount=@purchaseAmount,reason=@reason,initiator=@initiator,initiatorDate=@initiatorDate,applicant=@applicant where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@vendorName",vendor_Designated.VendorName),
                new SqlParameter("@SAPCode",vendor_Designated.SAPCode1),
                new SqlParameter("@businessCategory",vendor_Designated.BusinessCategory),
                new SqlParameter("@effectiveTime",vendor_Designated.EffectiveTime),
                new SqlParameter("@purchaseAmount",vendor_Designated.PurchaseAmount),
                new SqlParameter("@reason",vendor_Designated.Reason),
                new SqlParameter("@initiator",vendor_Designated.Initiator),
                new SqlParameter("@initiatorDate",vendor_Designated.InitiatorDate),
                new SqlParameter("@applicant",vendor_Designated.Applicant),
                //new SqlParameter("@requestDeptHead",vendor_Designated.RequestDeptHead),
                //new SqlParameter("@finManager",vendor_Designated.FinManager),
                //new SqlParameter("@applicantDate",vendor_Designated.ApplicantDate),
                //new SqlParameter("@purchasingManager",vendor_Designated.PurchasingManager),
                //new SqlParameter("@GM",vendor_Designated.GM),
                //new SqlParameter("@purchasingManagerDtae",vendor_Designated.PurchasingManagerDtae),
                //new SqlParameter("@GMDate",vendor_Designated.GMDate1),
                //new SqlParameter("@director",vendor_Designated.Director),
                //new SqlParameter("@supplyChainDirector",vendor_Designated.SupplyChainDirector),
                //new SqlParameter("@directorDtae",vendor_Designated.DirectorDtae),
                //new SqlParameter("@supplyChainDirectorDate",vendor_Designated.SupplyChainDirectorDate),
                //new SqlParameter("@finalDate",vendor_Designated.FinalDate),
                //new SqlParameter("@president",vendor_Designated.Persident),
                //new SqlParameter("@Form_ID",vendor_Designated.Form_id),
                //new SqlParameter("@Temp_Vendor_ID",vendor_Designated.Temp_Vendor_ID),
                //new SqlParameter("@Form_Type_ID",vendor_Designated.Form_Type_ID),
                //new SqlParameter("@Flag",vendor_Designated.Flag),
                //new SqlParameter("@requestDeptHeadDate",vendor_Designated.RequestDeptHeadDate),
                new SqlParameter("@finManagerDate",vendor_Designated.FinManagerDate)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static As_Vendor_Designated_Apply getForm(object FormId)
        {
            As_Vendor_Designated_Apply vendorApply = null;
            string sql = "select * from As_Vendor_Designated_Apply WHERE Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    vendorApply = new As_Vendor_Designated_Apply();
                    vendorApply.VendorName = Convert.ToString(dr["vendorName"]);
                    vendorApply.SAPCode1 = Convert.ToString(dr["SAPCode"]);
                    vendorApply.BusinessCategory = Convert.ToString(dr["businessCategory"]);
                    vendorApply.EffectiveTime = Convert.ToString(dr["effectiveTime"]);
                    vendorApply.PurchaseAmount = Convert.ToString(dr["purchaseAmount"]);
                    vendorApply.Reason = Convert.ToString(dr["reason"]);
                    vendorApply.Initiator = Convert.ToString(dr["initiator"]);
                    vendorApply.InitiatorDate = Convert.ToString(dr["initiatorDate"]);
                    vendorApply.Applicant = Convert.ToString(dr["applicant"]);
                    vendorApply.RequestDeptHead = Convert.ToString(dr["requestDeptHead"]);
                    vendorApply.RequestDeptHeadDate = Convert.ToString(dr["requestDeptHeadDate"]);
                    vendorApply.FinManager = Convert.ToString(dr["Finance_Leader"]);
                    vendorApply.FinManagerDate = Convert.ToString(dr["Finance_Leader_Date"]);
                    vendorApply.ApplicantDate = Convert.ToString(dr["applicantDate"]);
                    vendorApply.PurchasingManager = Convert.ToString(dr["Purchasing_Manager"]);
                    vendorApply.GM = Convert.ToString(dr["General_Manager"]);
                    vendorApply.PurchasingManagerDtae = Convert.ToString(dr["Purchasing_Manager_Date"]);
                    vendorApply.GMDate1 = Convert.ToString(dr["General_Manager_Date"]);
                    vendorApply.Director = Convert.ToString(dr["Director"]);
                    vendorApply.SupplyChainDirector = Convert.ToString(dr["Supplier_Chain_Leader"]);
                    vendorApply.DirectorDtae = Convert.ToString(dr["Director_Dtae"]);
                    vendorApply.SupplyChainDirectorDate = Convert.ToString(dr["Supplier_Chain_Leader_Date"]);
                    vendorApply.PresidenDate = Convert.ToString(dr["President_Date"]);
                    vendorApply.FinalDate = Convert.ToString(dr["finalDate"]);
                    vendorApply.Persident = Convert.ToString(dr["President"]);
                    vendorApply.Form_id = Convert.ToString(dr["Form_ID"]);
                    vendorApply.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    vendorApply.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    vendorApply.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    vendorApply.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return vendorApply;
        }

        public static int getFlag(object formId)
        {
            int flag = -1;
            string sql = "select Flag from As_Vendor_Designated_Apply where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
             {
                new SqlParameter("@Form_ID",formId)
             };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                   flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return flag;
        }

        public static string getFormID(string tempVendorID)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_Designated_Apply where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("Temp_Vendor_ID",tempVendorID)
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

        public static int addForm(As_Vendor_Designated_Apply vendorDesignatedApply)
        {
            string sql = "insert into As_Vendor_Designated_Apply (vendorName, Temp_Vendor_ID, Form_Type_ID, Flag) VALUES (@vendorName, @Temp_Vendor_ID,@Form_Type_ID,@Flag)";
            SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@vendorName",vendorDesignatedApply.VendorName),
                    new SqlParameter("@Temp_Vendor_ID",vendorDesignatedApply.Temp_Vendor_ID),
                    new SqlParameter("@Form_Type_ID",vendorDesignatedApply.Form_Type_ID),
                    new SqlParameter("@Flag",vendorDesignatedApply.Flag)
                };
            return DBHelp.GetScalar(sql, sp);//ExecuteScalar()方法执行查询返回插入成功的行数
        }

        public static int checkVendorDesignatedApply(string formID)//查询是否有表记录,1为存在 0为不存在
        {
            string sql = "select * from As_Vendor_Designated_Apply where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
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
    }
}
