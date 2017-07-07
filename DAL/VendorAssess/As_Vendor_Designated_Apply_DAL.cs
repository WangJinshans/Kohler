using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class As_Vendor_Designated_Apply_DAL
    {
        public static int SaveWholeForm(As_Vendor_Designated_Apply avda)
        {
            string sql = "INSERT INTO As_Vendor_Designated_Apply(vendorName,SAPCode,businessCategory,effectiveTime) VALUES(@vendorName,@SAPCode,@businessCategory,@effectiveTime)";
            SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@vendorName",avda.VendorName),
                    new SqlParameter("@SAPCode",avda.SAPCode1),
                    new SqlParameter("@businessCategory",avda.BusinessCategory),
                    new SqlParameter("@effectiveTime",avda.EffectiveTime),
                    //new SqlParameter("@purchaseAmount",avda.PurchaseAmount),
                    //new SqlParameter("@reason",avda.Reason),
                    //new SqlParameter("@initiator",avda.Initiator),
                    //new SqlParameter("@initiatorDate",avda.Date),
                    //new SqlParameter("@applicant",avda.Applicant),
                    //new SqlParameter("@requestDeptHead",avda.RequestDeptHead),
                    //new SqlParameter("@finManager",avda.FinManager),
                    //new SqlParameter("@applicantDate",avda.ApplicantDate),
                    //new SqlParameter("@requestDeptHeadDate",avda.RequestDeptHeadDate),
                    //new SqlParameter("@finManagerDate",avda.FinManagerDate),
                    //new SqlParameter("@purchasingManager",avda.PurchasingManager),
                    //new SqlParameter("@GM",avda.GM1),
                    //new SqlParameter("@purchasingManagerDtae",avda.PurchasingManagerDtae),
                    //new SqlParameter("@GMDate",avda.GMDate1),
                    //new SqlParameter("@director",avda.Director),
                    //new SqlParameter("@supplyChainDirector",avda.SupplyChainDirector),
                    //new SqlParameter("@directorDtae",avda.DirectorDtae),
                    //new SqlParameter("@supplyChainDirectorDate",avda.SupplyChainDirectorDate),
                    //new SqlParameter("@persident",avda.Persident),
                    //new SqlParameter("@presidenDate",avda.PresidenDate),
                    //new SqlParameter("@finalDate",avda.FinalDate)
                };
            return DBHelp.GetScalar(sql, sp);//ExecuteScalar()方法执行查询返回插入成功的行数
        }

        public static int GetAsVendorDesignatedApplyFormID(As_Vendor_Designated_Apply avda)
        {
            string sql = "select ID from As_Vendor_Designated_Apply where vendorName=@vendorName";
            SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@vendorName",avda.VendorName),
                    //new SqlParameter("@SAPCode",avda.SAPCode1),
                    //new SqlParameter("@businessCategory",avda.BusinessCategory)
                    //new SqlParameter("@effectiveTime",avda.EffectiveTime),
                    //new SqlParameter("@purchaseAmount",avda.PurchaseAmount),
                    //new SqlParameter("@reason",avda.Reason),
                    //new SqlParameter("@initiator",avda.Initiator),
                    //new SqlParameter("@initiatorDate",avda.Date),
                    //new SqlParameter("@applicant",avda.Applicant),
                    //new SqlParameter("@requestDeptHead",avda.RequestDeptHead),
                    //new SqlParameter("@finManager",avda.FinManager),
                    //new SqlParameter("@applicantDate",avda.ApplicantDate),
                    //new SqlParameter("@requestDeptHeadDate",avda.RequestDeptHeadDate),
                    //new SqlParameter("@finManagerDate",avda.FinManagerDate),
                    //new SqlParameter("@purchasingManager",avda.PurchasingManager),
                    //new SqlParameter("@GM",avda.GM1),
                    //new SqlParameter("@purchasingManagerDtae",avda.PurchasingManagerDtae),
                    //new SqlParameter("@GMDate",avda.GMDate1),
                    //new SqlParameter("@director",avda.Director),
                    //new SqlParameter("@supplyChainDirector",avda.SupplyChainDirector),
                    //new SqlParameter("@directorDtae",avda.DirectorDtae),
                    //new SqlParameter("@supplyChainDirectorDate",avda.SupplyChainDirectorDate),
                    //new SqlParameter("@persident",avda.Persident),
                    //new SqlParameter("@presidenDate",avda.PresidenDate),
                    //new SqlParameter("@finalDate",avda.FinalDate)
                };
            DataTable dt = new DataTable();
            dt= DBHelp.GetDataSet(sql, sp);//初始化dt
            int ID = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                ID = int.Parse(dt.Rows[0]["ID"].ToString().Trim());//获取ID
            }
            return ID;//ExecuteScalar()方法执行查询返回插入成功的行数
        }

        public static As_Vendor_Designated_Apply GetWholeFormInfo(string vendorname)
        {
            As_Vendor_Designated_Apply vda = new As_Vendor_Designated_Apply();
            string sql = "select * from As_Vendor_Designated_Apply where vendorName='" + vendorname + "'";
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0 && dt != null)
            {
                vda.VendorName = dt.Rows[0]["vendorName"].ToString().Trim();
                vda.SAPCode1 = dt.Rows[0]["SAPCode"].ToString().Trim();
                vda.BusinessCategory = dt.Rows[0]["businessCategory"].ToString().Trim();
                vda.EffectiveTime = Convert.ToDateTime(dt.Rows[0]["effectiveTime"].ToString().Trim());
            }
            return vda;
        }
        public static int UpdateWholeFormInfo(As_Vendor_Designated_Apply avda)
        {
            As_Vendor_Designated_Apply vda = new As_Vendor_Designated_Apply();
            //string sql = "UPDATE As_Vendor_Designated_Apply SET vendorName=@vendorName,"
            //    +"SAPCode=@SAPCode, businessCategory=@businessCategory,effectiveTime=@effectiveTime,"
            //    +"purchaseAmount=@purchaseAmount,reason=@reason,initiator=@initiator,"
            //    +"initiatorDate=@initiatorDate, applicant =@applicant, requestDeptHead =@requestDeptHead,"
            //    +"finManager =@finManager,applicantDate=@applicantDate ,requestDeptHeadDate =@requestDeptHeadDate,"
            //    +"finManagerDate =@finManagerDate,purchasingManager=@purchasingManager,GM=@GM, "
            //    +"purchasingManagerDtae = @purchasingManagerDtae,GMDate = @GMDate, director = @director,"
            //    +"supplyChainDirector = @supplyChainDirector, directorDtae =@directorDtae,"
            //    +"supplyChainDirectorDate=@supplyChainDirectorDate,persident=@persident,"
            //    +"finalDate=@finalDate";
            string sql = "UPDATE As_Vendor_Designated_Apply SET vendorName=@vendorName,"
                + "SAPCode=@SAPCode, businessCategory=@businessCategory,effectiveTime=@effectiveTime";
            SqlParameter[] sp = new SqlParameter[]
                {
                    new SqlParameter("@vendorName",avda.VendorName),
                    new SqlParameter("@SAPCode",avda.SAPCode1),
                    new SqlParameter("@businessCategory",avda.BusinessCategory),
                    new SqlParameter("@effectiveTime",avda.EffectiveTime),
                    //new SqlParameter("@purchaseAmount",avda.PurchaseAmount),
                    //new SqlParameter("@reason",avda.Reason),
                    //new SqlParameter("@initiator",avda.Initiator),
                    //new SqlParameter("@initiatorDate",avda.Date),
                    //new SqlParameter("@applicant",avda.Applicant),
                    //new SqlParameter("@requestDeptHead",avda.RequestDeptHead),
                    //new SqlParameter("@finManager",avda.FinManager),
                    //new SqlParameter("@applicantDate",avda.ApplicantDate),
                    //new SqlParameter("@requestDeptHeadDate",avda.RequestDeptHeadDate),
                    //new SqlParameter("@finManagerDate",avda.FinManagerDate),
                    //new SqlParameter("@purchasingManager",avda.PurchasingManager),
                    //new SqlParameter("@GM",avda.GM1),
                    //new SqlParameter("@purchasingManagerDtae",avda.PurchasingManagerDtae),
                    //new SqlParameter("@GMDate",avda.GMDate1),
                    //new SqlParameter("@director",avda.Director),
                    //new SqlParameter("@supplyChainDirector",avda.SupplyChainDirector),
                    //new SqlParameter("@directorDtae",avda.DirectorDtae),
                    //new SqlParameter("@supplyChainDirectorDate",avda.SupplyChainDirectorDate),
                    //new SqlParameter("@persident",avda.Persident),
                    //new SqlParameter("@finalDate",avda.FinalDate)
                };
            return DBHelp.ExecuteCommand(sql, sp);
        }
        
    }
}
