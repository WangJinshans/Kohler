using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class VendorCreation_DAL
    {
        public static int checkVendorCreation(string formID)
        {
            string sql = "select * from As_VendorCreation where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            return dt.Rows.Count > 0 ? 1 : 0;//查找到有相应的记录后返回1
        }

        public static int getVendorCreationFlag(string formID)//获取标志位
        {
            string sql = "select Flag from As_VendorCreation where Form_ID=@Form_ID";

            As_Vendor_Creation vendorcreation = null;
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorcreation = new As_Vendor_Creation();
                foreach (DataRow item in dt.Rows)
                {
                    vendorcreation.Flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return vendorcreation.Flag;
        }

        public static string getFormID(string tempVendorID)
        {
            string formID = "";
            string sql = "select Form_ID from As_VendorCreation where Temp_Vendor_ID=@Temp_Vendor_ID";
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

        public static int addVendorCreation(As_Vendor_Creation vendorCreation)//添加表
        {
            string sql = "insert into As_VendorCreation(Temp_Vendor_ID,Vendor_Name,Form_Type_ID,Flag,Factory_Name) values(@Temp_Vendor_ID,@Vendor_Name,@Form_Type_ID,@Flag,@Factory_Name) SELECT @@IDENTITY AS returnName";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendorCreation.Temp_Vendor_ID),
                new SqlParameter("@Vendor_Name",vendorCreation.Vendor_Name),
                new SqlParameter("@Form_Type_ID",vendorCreation.Form_Type_ID),
                new SqlParameter("@Flag",vendorCreation.Flag),
                new SqlParameter("@Factory_Name",vendorCreation.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateVendorCreation(As_Vendor_Creation vendorCreation)
        {
            string sql = "update As_VendorCreation SET Purpose=@Purpose,Initiator_Name=@Initiator_Name,Initiator_Tel=@Initiator_Tel,Company_Code=@Company_Code,Vendor_Code=@Vendor_Code,Vendor_Name=@Vendor_Name,Street=@Street,City=@City,Country=@Country,Region=@Region,Language=@Language,Telephone_No=@Telephone_No,Fax_No=@Fax_No,Email_Address_One=@Email_Address_One,Email_Address_Two=@Email_Address_Two,Tax_Identification_Number=@Tax_Identification_Number,Payment_Term=@Payment_Term,Payment_Method=@Payment_Method,Bank_Code=@Bank_Code,Bank_Name=@Bank_Name,Bank_Country=@Bank_Country,Bank_Account=@Bank_Account,Money_Type=@Money_Type,Trade_Onym=@Trade_Onym,Comments=@Comments,flag=@flag,Form_Type_ID=@Form_Type_ID,Temp_Vendor_ID=@Temp_Vendor_ID where Form_ID=@Form_ID";

            //string sqls = "update As_VendorCreation set Purpose=@Purpose,Initiator_Name=@Initiator_Name,"
            //    + "Initiator_Tel=@Initiator_Tel,Company_Code=@Company_Code,Vendor_Code=@Vendor_Code,"
            //    + "Vendor_Name=@Vendor_Name,Street=@Street,City=@City,Country=@Country,Region=@Region,"
            //    + "Language=@Language,Telephone_No=@Telephone_No,Fax_No=@Fax_No,Email_Address_One=@Email_Address_One,"
            //    + "Email_Address_Two=@Email_Address_Two,Tax_Identification_Number=@Tax_Identification_Number,"
            //    + "Payment_Term=@Payment_Term,Payment_Method=@Payment_Method,Bank_Code=@Bank_Code,"
            //    + "Bank_Name=@Bank_Name,Bank_Country=@Bank_Country,Bank_Account=@Bank_Account,"
            //    + "Money_Type=@Money_Type,Trade_Onym=@Trade_Onym,Comments=@Comments,flag=@flag where id=@id";
            //Line_Manager=@Line_Manager,"+"Purchasing_Manager=@Purchasing_Manager,Ministry_Of_Law=@Ministry_Of_Law,"+ "Accounting_Dept=@Accounting_Dept,Chief_Inspector=@Chief_Inspector
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorCreation.Form_ID),
                new SqlParameter("@Purpose",vendorCreation.Purpose),
                new SqlParameter("@Initiator_Name",vendorCreation.Initiator_Name),
                new SqlParameter("@Initiator_Tel",vendorCreation.Initiator_Tel),
                new SqlParameter("@Company_Code",vendorCreation.Company_Code),
                new SqlParameter("@Vendor_Code",vendorCreation.Vendor_Code),
                new SqlParameter("@Vendor_Name",vendorCreation.Vendor_Name),
                new SqlParameter("@Street",vendorCreation.Street),
                new SqlParameter("@City",vendorCreation.City),
                new SqlParameter("@Country",vendorCreation.Country),
                new SqlParameter("@Region",vendorCreation.Region),
                new SqlParameter("@Language",vendorCreation.Language),
                new SqlParameter("@Telephone_No",vendorCreation.Telephone_No),
                new SqlParameter("@Fax_No",vendorCreation.Fax_No),
                new SqlParameter("@Email_Address_One",vendorCreation.Email_Address_One),
                new SqlParameter("@Email_Address_Two",vendorCreation.Email_Address_Two),
                new SqlParameter("@Tax_Identification_Number",vendorCreation.Tax_Identification_Number),
                new SqlParameter("@Payment_Term",vendorCreation.Payment_Term),
                new SqlParameter("@Payment_Method",vendorCreation.Payment_Method),
                new SqlParameter("@Bank_Code",vendorCreation.Bank_Code),
                new SqlParameter("@Bank_Name",vendorCreation.Bank_Name),
                new SqlParameter("@Bank_Country",vendorCreation.Bank_Country),
                new SqlParameter("@Bank_Account",vendorCreation.Bank_Account),
                new SqlParameter("@Money_Type",vendorCreation.Money_Type),
                new SqlParameter("@Trade_Onym",vendorCreation.Trade_Onym),
                //new SqlParameter("@Line_Manager",vendorCreation.Line_Manager),
                //new SqlParameter("@Purchasing_Manager",vendorCreation.Purchasing_Manager),
                //new SqlParameter("@Ministry_Of_Law",vendorCreation.Ministry_Of_Law),
                //new SqlParameter("@Accounting_Dept",vendorCreation.Accounting_Dept),
                //new SqlParameter("@Chief_Inspector",vendorCreation.Chief_Inspector),
                new SqlParameter("@Comments",vendorCreation.Comments),
                new SqlParameter("@flag",vendorCreation.Flag),
                new SqlParameter("@Form_Type_ID",vendorCreation.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",vendorCreation.Temp_Vendor_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static As_Vendor_Creation getVendorCreation(string formID)
        {
            As_Vendor_Creation vendorCreation = null;
            string sql = "select * from As_VendorCreation where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorCreation = new As_Vendor_Creation();
                foreach (DataRow item in dt.Rows)
                {
                    vendorCreation.Form_ID= item["Form_ID"].ToString().Trim();
                    vendorCreation.Purpose = item["Purpose"].ToString().Trim();
                    vendorCreation.Initiator_Name = item["Initiator_Name"].ToString().Trim();
                    vendorCreation.Initiator_Tel = item["Initiator_Tel"].ToString().Trim();
                    vendorCreation.Company_Code = item["Company_Code"].ToString().Trim();
                    vendorCreation.Account_Group = item["Account_Group"].ToString().Trim();
                    vendorCreation.Vendor_Code = item["Vendor_Code"].ToString().Trim(); //TODO::???英文名？？？
                    vendorCreation.Vendor_Name = item["Vendor_Name"].ToString().Trim();
                    vendorCreation.Street = item["Street"].ToString().Trim();
                    vendorCreation.Postal_Code = item["Postal_Code"].ToString().Trim();
                    vendorCreation.City = item["City"].ToString().Trim();
                    vendorCreation.Country = item["Country"].ToString().Trim();
                    vendorCreation.Region = item["Region"].ToString().Trim();
                    vendorCreation.Language = item["Language"].ToString().Trim();
                    vendorCreation.Telephone_No = item["Telephone_No"].ToString().Trim();
                    vendorCreation.Fax_No = item["Fax_No"].ToString().Trim();
                    vendorCreation.Email_Address_One = item["Email_Address_One"].ToString().Trim();
                    vendorCreation.Email_Address_Two = item["Email_Address_Two"].ToString().Trim();
                    vendorCreation.Tax_Identification_Number = item["Tax_Identification_Number"].ToString().Trim();
                    vendorCreation.Payment_Method = item["Payment_Term"].ToString().Trim();
                    vendorCreation.Payment_Term = item["Payment_Method"].ToString().Trim();
                    vendorCreation.Bank_Code = item["Bank_Code"].ToString().Trim();
                    vendorCreation.Bank_Name = item["Bank_Name"].ToString().Trim();
                    vendorCreation.Bank_Country = item["Bank_Country"].ToString().Trim();
                    vendorCreation.Bank_Account = item["Bank_Account"].ToString().Trim();
                    vendorCreation.Money_Type = item["Money_Type"].ToString().Trim();
                    vendorCreation.Trade_Onym = item["Trade_Onym"].ToString().Trim();
                    vendorCreation.Line_Manager = item["Line_Manager"].ToString().Trim();
                    vendorCreation.Purchasing_Manager = item["Purchasing_Manager"].ToString().Trim();
                    vendorCreation.Ministry_Of_Law = item["Legal_Affair_Department"].ToString().Trim();
                    vendorCreation.Accounting_Dept = item["Finance_Leader"].ToString().Trim();
                    vendorCreation.Chief_Inspector = item["General_Manager"].ToString().Trim();
                    vendorCreation.Comments = item["Comments"].ToString().Trim();
                    vendorCreation.Flag = Convert.ToInt32(item["Flag"]);
                }
                return vendorCreation;
            }
            else
            {
                return null;//返回空
            }
        }
    }
}
