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
            string sql = "update As_Vendor_Designated_Apply SET vendorName=@vendorName,SAPCode=@SAPCode,businessCategory=@businessCategory,effectiveTime=@effectiveTime,purchaseAmount=@purchaseAmount,reason=@reason,vendorName1=@vendorName1,SAPCode_1=@SAPCode_1,businessCategory1=@businessCategory1,effectiveTime1=@effectiveTime1,purchaseAmount1=@purchaseAmount1,reason1=@reason1,vendorName2=@vendorName2,SAPCode_2=@SAPCode_2,businessCategory2=@businessCategory2,effectiveTime2=@effectiveTime2,purchaseAmount2=@purchaseAmount2,reason2=@reason2,vendorName3=@vendorName3,SAPCode_3=@SAPCode_3,businessCategory3=@businessCategory3,effectiveTime3=@effectiveTime3,purchaseAmount3=@purchaseAmount3,reason3=@reason3,vendorName4=@vendorName4,SAPCode_4=@SAPCode_4,businessCategory4=@businessCategory4,effectiveTime4=@effectiveTime4,purchaseAmount4=@purchaseAmount4,reason4=@reason4,initiator=@initiator,initiatorDate=@initiatorDate,applicant=@applicant where Form_ID=@Form_ID";
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



                new SqlParameter("@vendorName1",vendor_Designated.VendorName1),
                new SqlParameter("@SAPCode_1",vendor_Designated.SAPCode_1),
                new SqlParameter("@businessCategory1",vendor_Designated.BusinessCategory1),
                new SqlParameter("@effectiveTime1",vendor_Designated.EffectiveTime1),
                new SqlParameter("@purchaseAmount1",vendor_Designated.PurchaseAmount1),
                new SqlParameter("@reason1",vendor_Designated.Reason1),


                new SqlParameter("@vendorName2",vendor_Designated.VendorName2),
                new SqlParameter("@SAPCode_2",vendor_Designated.SAPCode_2),
                new SqlParameter("@businessCategory2",vendor_Designated.BusinessCategory2),
                new SqlParameter("@effectiveTime2",vendor_Designated.EffectiveTime2),
                new SqlParameter("@purchaseAmount2",vendor_Designated.PurchaseAmount2),
                new SqlParameter("@reason2",vendor_Designated.Reason2),


                new SqlParameter("@vendorName3",vendor_Designated.VendorName3),
                new SqlParameter("@SAPCode_3",vendor_Designated.SAPCode_3),
                new SqlParameter("@businessCategory3",vendor_Designated.BusinessCategory3),
                new SqlParameter("@effectiveTime3",vendor_Designated.EffectiveTime3),
                new SqlParameter("@purchaseAmount3",vendor_Designated.PurchaseAmount3),
                new SqlParameter("@reason3",vendor_Designated.Reason3),


                new SqlParameter("@vendorName4",vendor_Designated.VendorName4),
                new SqlParameter("@SAPCode_4",vendor_Designated.SAPCode_4),
                new SqlParameter("@businessCategory4",vendor_Designated.BusinessCategory4),
                new SqlParameter("@effectiveTime4",vendor_Designated.EffectiveTime4),
                new SqlParameter("@purchaseAmount4",vendor_Designated.PurchaseAmount4),
                new SqlParameter("@reason4",vendor_Designated.Reason4),

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
                new SqlParameter("@Form_ID",vendor_Designated.Form_id)
                //new SqlParameter("@Temp_Vendor_ID",vendor_Designated.Temp_Vendor_ID),
                //new SqlParameter("@Form_Type_ID",vendor_Designated.Form_Type_ID),
                //new SqlParameter("@Flag",vendor_Designated.Flag),
                //new SqlParameter("@requestDeptHeadDate",vendor_Designated.RequestDeptHeadDate),
                //new SqlParameter("@finManagerDate",vendor_Designated.FinManagerDate)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int SubmitOk(string formID)
        {
            int submit = -1;
            string sql = "select Submit from As_Vendor_Designated_Apply WHERE Form_ID='" + formID + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    submit = Convert.ToInt32(dr["Submit"]);
                }
            }
            return submit;
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
                    vendorApply.RequestDeptHead = Convert.ToString(dr["User_Department_Manager"]);
                    vendorApply.RequestDeptHeadDate = Convert.ToString(dr["User_Department_Manager_Date"]);
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
                    vendorApply.Factory_Name= Convert.ToString(dr["Factory_Name"]);


                    vendorApply.VendorName1 = Convert.ToString(dr["vendorName1"]);
                    vendorApply.SAPCode_1 = Convert.ToString(dr["SAPCode_1"]);
                    vendorApply.BusinessCategory1 = Convert.ToString(dr["businessCategory1"]);
                    vendorApply.EffectiveTime1 = Convert.ToString(dr["effectiveTime1"]);
                    vendorApply.PurchaseAmount1 = Convert.ToString(dr["purchaseAmount1"]);
                    vendorApply.Reason1 = Convert.ToString(dr["reason1"]);


                    vendorApply.VendorName2 = Convert.ToString(dr["vendorName2"]);
                    vendorApply.SAPCode_2 = Convert.ToString(dr["SAPCode_2"]);
                    vendorApply.BusinessCategory2 = Convert.ToString(dr["businessCategory2"]);
                    vendorApply.EffectiveTime2 = Convert.ToString(dr["effectiveTime2"]);
                    vendorApply.PurchaseAmount2 = Convert.ToString(dr["purchaseAmount2"]);
                    vendorApply.Reason2 = Convert.ToString(dr["reason2"]);


                    vendorApply.VendorName3 = Convert.ToString(dr["vendorName3"]);
                    vendorApply.SAPCode_3 = Convert.ToString(dr["SAPCode_3"]);
                    vendorApply.BusinessCategory3 = Convert.ToString(dr["businessCategory3"]);
                    vendorApply.EffectiveTime3 = Convert.ToString(dr["effectiveTime3"]);
                    vendorApply.PurchaseAmount3 = Convert.ToString(dr["purchaseAmount3"]);
                    vendorApply.Reason3 = Convert.ToString(dr["reason3"]);


                    vendorApply.VendorName4 = Convert.ToString(dr["vendorName4"]);
                    vendorApply.SAPCode_4 = Convert.ToString(dr["SAPCode_4"]);
                    vendorApply.BusinessCategory4 = Convert.ToString(dr["businessCategory4"]);
                    vendorApply.EffectiveTime4 = Convert.ToString(dr["effectiveTime4"]);
                    vendorApply.PurchaseAmount4 = Convert.ToString(dr["purchaseAmount4"]);
                    vendorApply.Reason4 = Convert.ToString(dr["reason4"]);

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

        public static string getFormID(string tempVendorID,string formTypeID,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
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

        public static int addForm(As_Vendor_Designated_Apply vendorDesignatedApply)
        {
            string sql = "insert into As_Vendor_Designated_Apply (vendorName, Temp_Vendor_ID, Form_Type_ID, Flag,Factory_Name) VALUES (@vendorName, @Temp_Vendor_ID,@Form_Type_ID,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@vendorName",vendorDesignatedApply.VendorName),
                    new SqlParameter("@Temp_Vendor_ID",vendorDesignatedApply.Temp_Vendor_ID),
                    new SqlParameter("@Form_Type_ID",vendorDesignatedApply.Form_Type_ID),
                    new SqlParameter("@Flag",vendorDesignatedApply.Flag),
                    new SqlParameter("@Factory_Name",vendorDesignatedApply.Factory_Name)
                };
            return DBHelp.ExecuteCommand(sql, sp);//ExecuteScalar()方法执行查询返回插入成功的行数
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
