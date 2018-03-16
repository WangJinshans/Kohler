using MODEL;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DAL.VendorAssess
{
    public class VendorExtend_DAL
    {
        public static int addVendorExtend(As_Vendor_Extend VendorExtend) //初始化表格赋值表格编号和表格种类编号
        {
            string sql = "insert into As_Vendor_Extend(Temp_Vendor_Name,Flag,Factory_Name)values(@Temp_Vendor_Name,@Flag,@Factory_Name)select TOP 1 SCOPE_IDENTITY() AS returnName from As_Vendor_Extend";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_Name",VendorExtend.Temp_Vendor_Name),
               new SqlParameter("@Flag",VendorExtend.Flag),
               new SqlParameter("@Factory_Name",VendorExtend.Factory_Name)
            };
            return DBHelp.GetScalarID(sql, sp);

        }

        public static int updateVendorExtend(As_Vendor_Extend VendorExtend)//flag未更新
        {
            string sql = "update As_Vendor_Extend set Language=@Language,"
                + "Temp_Vendor_ID=Temp_Vendor_ID,Form_Type_ID=@Form_Type_ID,Bar_Code=@Bar_Code,"
                + "Purpose=@Purpose,Initiator_Name=@Initiator_Name,Initiator_Tel=@Initiator_Tel,"
                + "Company_Code=@Company_Code,Vendor_Code=@Vendor_Code,From_Company=@From_Company,"
                + "Email=@Email,Money_Type=@Money_Type,Comments=@Comments"
                + " where Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Language",VendorExtend.Laguage),
                new SqlParameter("@Temp_Vendor_ID",VendorExtend.Temp_Vendor_ID),
                new SqlParameter("@Form_Type_ID",VendorExtend.Form_Type_ID),
                new SqlParameter("@Bar_Code",VendorExtend.Bar_Code),
                new SqlParameter("@Purpose",VendorExtend.Purpose),
                new SqlParameter("@Initiator_Name",VendorExtend.Initiator_Name),
                new SqlParameter("@Initiator_Tel",VendorExtend.Initiator_Tel),
                new SqlParameter("@Company_Code",VendorExtend.Company_Code),
                new SqlParameter("@Vendor_Code",VendorExtend.Vendor_Code),
                new SqlParameter("@From_Company",VendorExtend.From_Company),
                new SqlParameter("@Email",VendorExtend.Email),
                new SqlParameter("@Money_Type",VendorExtend.Money_Type),
                //new SqlParameter("@Line_Manager",VendorExtend.Line_Manager),
                new SqlParameter("Comments",VendorExtend.Comments),
                new SqlParameter("@Temp_Vendor_Name",VendorExtend.Temp_Vendor_Name)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static string getVendorExtendFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_Extend where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name and ID=@ID";
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

        public static int SubmitOk(string formID)
        {
            int submit = -1;
            string sql = "select Submit from As_Vendor_Extend WHERE Form_ID='" + formID + "'";
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

        public static string getFormID(string tempVendorID,string formTypeID,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Type_ID",formTypeID),
                new SqlParameter("@Factory_Name",factory)

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

        public static int checkVendorExtend(string formID)//查询是否有表记录,1为存在 0为不存在
        {
            string sql = "select * from As_Vendor_Extend where Form_ID=@Form_ID";
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

        public static As_Vendor_Extend getVendorExtend(string Form_ID)
        {
            As_Vendor_Extend VendorExtend = null;
            string sql = "select * from As_Vendor_Extend where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",Form_ID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                VendorExtend = new As_Vendor_Extend();
                foreach (DataRow dr in dt.Rows)
                {
                    VendorExtend.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    VendorExtend.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    VendorExtend.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    VendorExtend.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    VendorExtend.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    VendorExtend.Laguage = Convert.ToString(dr["Language"]);
                    VendorExtend.Purpose = Convert.ToString(dr["Purpose"]);
                    VendorExtend.Initiator_Name = Convert.ToString(dr["Initiator_Name"]);
                    VendorExtend.Initiator_Tel = Convert.ToString(dr["Initiator_Tel"]);
                    VendorExtend.Company_Code = Convert.ToString(dr["Company_Code"]);
                    VendorExtend.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    VendorExtend.From_Company = Convert.ToString(dr["From_Company"]);
                    VendorExtend.Email = Convert.ToString(dr["Email"]);
                    VendorExtend.Money_Type = Convert.ToString(dr["Money_Type"]);
                    VendorExtend.Line_Manager = Convert.ToString(dr["Line_Manager"]);
                    VendorExtend.Comments = Convert.ToString(dr["Comments"]);
                    VendorExtend.Factory_Name= Convert.ToString(dr["Factory_Name"]);
                }

            }
            return VendorExtend;
        }

        public static int getVendorExtendFlag(string FormId)//按照表格编号和供应商名称查询相应记录返回flag
        {
            As_Vendor_Extend VendorExtend = null;
            string sql = "select Flag from As_Vendor_Extend where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                VendorExtend = new As_Vendor_Extend();
                foreach (DataRow dr in dt.Rows)
                {
                    VendorExtend.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return VendorExtend.Flag;
        }

    }
}
