using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebLearning.Model;

namespace DAL.VendorAssess
{
    public class VendorModify_DAL
    {
        public static int updateVendorModification(As_Vendor_Modify vendorModify)
        {
            string sql = "update As_VendorModify SET Purpose=@Purpose,Initiator_Name=@Initiator_Name,Initiator_Tel=@Initiator_Tel,Company_Code=@Company_Code,Vendor_Code=@Vendor_Code,Vendor_Name=@Vendor_Name,Street=@Street,City=@City,Country=@Country,Region=@Region,Language=@Language,Telephone_No=@Telephone_No,Fax_No=@Fax_No,Email_Address_One=@Email_Address_One,Email_Address_Two=@Email_Address_Two,Tax_Identification_Number=@Tax_Identification_Number,Payment_Term=@Payment_Term,Payment_Method=@Payment_Method,Bank_Code=@Bank_Code,Bank_Name=@Bank_Name,Bank_Country=@Bank_Country,Bank_Account=@Bank_Account,Money_Type=@Money_Type,Trade_Onym=@Trade_Onym,Comments=@Comments,flag=@flag,Form_Type_ID=@Form_Type_ID,Temp_Vendor_ID=@Temp_Vendor_ID,Postal_Code=@Postal_Code where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorModify.Form_ID),
                new SqlParameter("@Purpose",vendorModify.Purpose),
                new SqlParameter("@Initiator_Name",vendorModify.Initiator_Name),
                new SqlParameter("@Initiator_Tel",vendorModify.Initiator_Tel),
                new SqlParameter("@Company_Code",vendorModify.Company_Code),
                new SqlParameter("@Vendor_Code",vendorModify.Vendor_Code),
                new SqlParameter("@Vendor_Name",vendorModify.Vendor_Name),
                new SqlParameter("@Street",vendorModify.Street),
                new SqlParameter("@City",vendorModify.City),
                new SqlParameter("@Country",vendorModify.Country),
                new SqlParameter("@Region",vendorModify.Region),
                new SqlParameter("@Language",vendorModify.Language),
                new SqlParameter("@Telephone_No",vendorModify.Telephone_No),
                new SqlParameter("@Fax_No",vendorModify.Fax_No),
                new SqlParameter("@Email_Address_One",vendorModify.Email_Address_One),
                new SqlParameter("@Email_Address_Two",vendorModify.Email_Address_Two),
                new SqlParameter("@Tax_Identification_Number",vendorModify.Tax_Identification_Number),
                new SqlParameter("@Payment_Term",vendorModify.Payment_Term),
                new SqlParameter("@Payment_Method",vendorModify.Payment_Method),
                new SqlParameter("@Bank_Code",vendorModify.Bank_Code),
                new SqlParameter("@Bank_Name",vendorModify.Bank_Name),
                new SqlParameter("@Bank_Country",vendorModify.Bank_Country),
                new SqlParameter("@Bank_Account",vendorModify.Bank_Account),
                new SqlParameter("@Money_Type",vendorModify.Money_Type),
                new SqlParameter("@Trade_Onym",vendorModify.Trade_Onym),
                new SqlParameter("@Comments",vendorModify.Comments),
                new SqlParameter("@flag",vendorModify.Flag),
                new SqlParameter("@Form_Type_ID",vendorModify.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",vendorModify.Temp_Vendor_ID),
                //new SqlParameter("@Account_Group",vendorModify.Account_Group),
                new SqlParameter("@Postal_Code",vendorModify.Postal_Code)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static string getFormID(string tempVendorID, string factory)
        {
            string sql = "select Form_ID from As_VendorModify where Temp_Vendor_ID=@Temp_Vendor_ID AND Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Factory_Name",factory)
            };
            string formID = "";
            DataTable table = DBHelp.GetDataSet(sql, sp);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow dr in table.Rows)
                {
                    formID = dr["Form_ID"].ToString();
                }
            }
            return formID;
        }

        public static DataTable getFilePath(string fileID)
        {
            throw new NotImplementedException();
        }

        public static As_Vendor_Modify getVendorModification(string formID)
        {

            As_Vendor_Modify vendorModify = null;
            string sql = "select * from As_VendorModify where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorModify = new As_Vendor_Modify();
                foreach (DataRow item in dt.Rows)
                {
                    vendorModify.Form_ID = item["Form_ID"].ToString().Trim();
                    vendorModify.Purpose = item["Purpose"].ToString().Trim();
                    vendorModify.Initiator_Name = item["Initiator_Name"].ToString().Trim();
                    vendorModify.Initiator_Tel = item["Initiator_Tel"].ToString().Trim();
                    vendorModify.Company_Code = item["Company_Code"].ToString().Trim();
                    vendorModify.Account_Group = item["Account_Group"].ToString().Trim();
                    vendorModify.Vendor_Code = item["Vendor_Code"].ToString().Trim();
                    vendorModify.Vendor_Name = item["Vendor_Name"].ToString().Trim();
                    vendorModify.Street = item["Street"].ToString().Trim();
                    vendorModify.Postal_Code = item["Postal_Code"].ToString().Trim();
                    vendorModify.City = item["City"].ToString().Trim();
                    vendorModify.Country = item["Country"].ToString().Trim();
                    vendorModify.Region = item["Region"].ToString().Trim();
                    vendorModify.Language = item["Language"].ToString().Trim();
                    vendorModify.Telephone_No = item["Telephone_No"].ToString().Trim();
                    vendorModify.Fax_No = item["Fax_No"].ToString().Trim();
                    vendorModify.Email_Address_One = item["Email_Address_One"].ToString().Trim();
                    vendorModify.Email_Address_Two = item["Email_Address_Two"].ToString().Trim();
                    vendorModify.Tax_Identification_Number = item["Tax_Identification_Number"].ToString().Trim();
                    vendorModify.Payment_Method = item["Payment_Term"].ToString().Trim();
                    vendorModify.Payment_Term = item["Payment_Method"].ToString().Trim();
                    vendorModify.Bank_Code = item["Bank_Code"].ToString().Trim();
                    vendorModify.Bank_Name = item["Bank_Name"].ToString().Trim();
                    vendorModify.Bank_Country = item["Bank_Country"].ToString().Trim();
                    vendorModify.Bank_Account = item["Bank_Account"].ToString().Trim();
                    vendorModify.Money_Type = item["Money_Type"].ToString().Trim();
                    vendorModify.Trade_Onym = item["Trade_Onym"].ToString().Trim();
                    vendorModify.Line_Manager = item["Line_Manager"].ToString().Trim();
                    vendorModify.Purchasing_Manager = item["Purchasing_Manager"].ToString().Trim();
                    vendorModify.Ministry_Of_Law = item["Legal_Affair_Department"].ToString().Trim();
                    vendorModify.Accounting_Dept = item["Finance_Leader"].ToString().Trim();
                    vendorModify.Chief_Inspector = item["General_Manager"].ToString().Trim();
                    vendorModify.Comments = item["Comments"].ToString().Trim();
                    vendorModify.Flag = Convert.ToInt32(item["Flag"]);
                    vendorModify.Temp_Vendor_ID = item["Temp_Vendor_ID"].ToString().Trim();
                    vendorModify.Factory_Name = item["Factory_Name"].ToString().Trim();
                    vendorModify.Form_Type_ID = item["Form_Type_ID"].ToString().Trim();
                }
                return vendorModify;
            }
            else
            {
                return null;//返回空
            }

        }

        public static int checkVendorModification(string formID)
        {
            string sql = "select * from As_VendorModify where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            return dt.Rows.Count > 0 ? 1 : 0;//查找到有相应的记录后返回1
        }

        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_VendorModify where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
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

        public static int getVendorModificationFlag(string formID)
        {
            string sql = "select Flag from As_VendorModify where Form_ID=@Form_ID";

            As_Vendor_Modify vendorModify = null;
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorModify = new As_Vendor_Modify();
                foreach (DataRow item in dt.Rows)
                {
                    vendorModify.Flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return vendorModify.Flag;
        }

        public static int addVendorModification(As_Vendor_Modify vendorModify)
        {
            string sql = "insert into As_VendorModify(Temp_Vendor_ID,Vendor_Name,Form_Type_ID,Flag,Factory_Name) values(@Temp_Vendor_ID,@Vendor_Name,@Form_Type_ID,@Flag,@Factory_Name) SELECT @@IDENTITY AS returnName";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendorModify.Temp_Vendor_ID),
                new SqlParameter("@Vendor_Name",vendorModify.Vendor_Name),
                new SqlParameter("@Form_Type_ID",vendorModify.Form_Type_ID),
                new SqlParameter("@Flag",vendorModify.Flag),
                new SqlParameter("@Factory_Name",vendorModify.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }
    }
}
