using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.VendorAssess
{
    public class As_Bidding_Approval_DAL
    {
        public static int checkVendorBiddingApprovalForm(string formID)
        {
            string sql = "select * from As_Bidding_Approval_Form where Form_ID=@Form_ID";
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

        public static int getVendorBiddingApprovalFormFlag(string tempVendorID)
        {
            As_Bidding_Approval VendorApproval = null;
            string sql = "select Flag from As_Bidding_Approval_Form where Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                VendorApproval = new As_Bidding_Approval();
                foreach (DataRow dr in dt.Rows)
                {
                    VendorApproval.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return VendorApproval.Flag;
        }

        public static string getFormID(string tempVendorID,string Form_Type_ID, string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_ID=@Form_Type_ID and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Type_ID",Form_Type_ID),
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

        public static int SubmitOk(string formID)
        {
            int submit = -1;
            string sql = "select Submit from As_Bidding_Approval_Form WHERE Form_ID='" + formID + "'";
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

        public static int addVendorBiddingApprovalForm(As_Bidding_Approval vendorApproval)
        {
            string sql = "insert into As_Bidding_Approval_Form(Temp_Vendor_ID,Flag,Factory_Name)values(@Temp_Vendor_ID,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_ID",vendorApproval.Temp_Vendor_ID),
               new SqlParameter("@Flag",vendorApproval.Flag),
               new SqlParameter("@Factory_Name",vendorApproval.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        public static int updateVendorBiddingApprovalForm(As_Bidding_Approval vendorApproval)
        {
            string sql = "update As_Bidding_Approval_Form SET Serial_No=@Serial_No,Date=@Date,Product=@Product,Purchase_Amount=@Purchase_Amount,MOQ1=@MOQ1,MOQ2=@MOQ2,MOQ3=@MOQ3,Lead_Time1=@Lead_Time1,Lead_Time2=@Lead_Time2,Lead_Time3=@Lead_Time3,Payment_Term1=@Payment_Term1,Payment_Term2=@Payment_Term2,Payment_Term3=@Payment_Term3,Remark1=@Remark1,Remark2=@Remark2,Remark3=@Remark3,Reason_One=@Reason_One,Reason_Two=@Reason_Two,Form_Type_ID=@Form_Type_ID,Temp_Vendor_ID=@Temp_Vendor_ID,Temp_Vendor_Name=@Temp_Vendor_Name, Flag=@Flag where Form_ID=@Form_ID";

            string sql1 = "insert into As_Bidding_Approval_Form_Item(Item,Description,Price,Price1,Price2,Remark,Form_ID) values(@Item,@Description,@Price,@Price1,@Price2,@Remark,@Form_ID)";

            string delStr = "delete from As_Bidding_Approval_Form_Item where Form_ID=@Form_ID";
            SqlParameter[] spDel = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorApproval.Form_ID)
            };

            DBHelp.ExecuteCommand(delStr, spDel);

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Serial_No",vendorApproval.Serial_No),
                new SqlParameter("@Date",vendorApproval.Date),
                new SqlParameter("@Product",vendorApproval.Product),
                new SqlParameter("@Purchase_Amount",vendorApproval.Purchase_Amount),
                new SqlParameter("@MOQ1",vendorApproval.MOQ1),
                new SqlParameter("@MOQ2",vendorApproval.MOQ2),
                new SqlParameter("@MOQ3",vendorApproval.MOQ3),
                new SqlParameter("@Lead_Time1",vendorApproval.Lead_Time1),
                new SqlParameter("@Lead_Time2",vendorApproval.Lead_Time2),
                new SqlParameter("@Lead_Time3",vendorApproval.Lead_Time3),
                new SqlParameter("@Payment_Term1",vendorApproval.Payment_Term1),
                new SqlParameter("@Payment_Term2",vendorApproval.Payment_Term2),
                new SqlParameter("@Payment_Term3",vendorApproval.Payment_Term3),
                new SqlParameter("@Remark1",vendorApproval.Remark1),
                new SqlParameter("@Remark2",vendorApproval.Remark2),
                new SqlParameter("@Remark3",vendorApproval.Remark3),
                new SqlParameter("@Reason_One",vendorApproval.Reason_One),
                new SqlParameter("@Reason_Two",vendorApproval.Reason_Two),
                new SqlParameter("@Form_ID",vendorApproval.Form_ID),
                new SqlParameter("@Form_Type_ID",vendorApproval.Form_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",vendorApproval.Temp_Vendor_ID),
                new SqlParameter("@Temp_Vendor_Name",vendorApproval.Temp_Vendor_Name),
                new SqlParameter("@Flag",vendorApproval.Flag)
            };
            //new SqlParameter("@Initiator",vendorApproval.Initiator),
            //new SqlParameter("@Supplier_Chain_Leader",vendorApproval.Supplier_Chain_Leader),
            //new SqlParameter("@Finance_Leader",vendorApproval.Finance_Leader),
            //new SqlParameter("@Business_Leader",vendorApproval.Business_Leader),
            if (vendorApproval.ProjectList != null)//
            {
                for (int i = 0; i < vendorApproval.ProjectList.Count; i++)
                {
                    SqlParameter[] sp1 = new SqlParameter[]
                    {
                        new SqlParameter("@Item",vendorApproval.ProjectList[i].Item),
                        new SqlParameter("@Description",vendorApproval.ProjectList[i].Description),
                        new SqlParameter("@Price",vendorApproval.ProjectList[i].Price1),
                        new SqlParameter("@Price1",vendorApproval.ProjectList[i].Price2),
                        new SqlParameter("@Price2",vendorApproval.ProjectList[i].Price3),
                        new SqlParameter("@Remark",vendorApproval.ProjectList[i].Remark),
                        new SqlParameter("@Form_ID",vendorApproval.ProjectList[i].Form_ID)
                    };
                    DBHelp.ExecuteCommand(sql1, sp1);
                }
            }
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static As_Bidding_Approval getVendorBiddingApprovalForm(string formID)
        {
            As_Bidding_Approval Vendor_Approval = null;
            string sql = "select * from As_Bidding_Approval_Form where Form_ID=@Form_ID";
            string sql1 = "select * from As_Bidding_Approval_Form_Item where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };

            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Vendor_Approval = new As_Bidding_Approval();
                foreach (DataRow dr in dt.Rows)
                {
                    Vendor_Approval.Serial_No = Convert.ToString(dr["Serial_No"]);
                    Vendor_Approval.Date = Convert.ToString(dr["Date"]);
                    Vendor_Approval.Product = Convert.ToString(dr["Product"]);
                    Vendor_Approval.Purchase_Amount = Convert.ToString(dr["Purchase_Amount"]);
                    Vendor_Approval.MOQ1 = Convert.ToString(dr["MOQ1"]);
                    Vendor_Approval.MOQ2 = Convert.ToString(dr["MOQ2"]);
                    Vendor_Approval.MOQ3 = Convert.ToString(dr["MOQ3"]);
                    Vendor_Approval.Lead_Time1 = Convert.ToString(dr["Lead_Time1"]);
                    Vendor_Approval.Lead_Time2 = Convert.ToString(dr["Lead_Time2"]);
                    Vendor_Approval.Lead_Time3 = Convert.ToString(dr["Lead_Time3"]);
                    Vendor_Approval.Payment_Term1 = Convert.ToString(dr["Payment_Term1"]);
                    Vendor_Approval.Payment_Term2 = Convert.ToString(dr["Payment_Term2"]);
                    Vendor_Approval.Payment_Term3 = Convert.ToString(dr["Payment_Term3"]);
                    Vendor_Approval.Remark1 = Convert.ToString(dr["Remark1"]);
                    Vendor_Approval.Remark2 = Convert.ToString(dr["Remark2"]);
                    Vendor_Approval.Remark3 = Convert.ToString(dr["Remark3"]);
                    Vendor_Approval.Reason_One = Convert.ToString(dr["Reason_One"]);
                    Vendor_Approval.Reason_Two = Convert.ToString(dr["Reason_Two"]);
                    //Vendor_Approval.Initiator = Convert.ToString(dr["Initiator"]);
                    //Vendor_Approval.Supplier_Chain_Leader = Convert.ToString(dr["Supplier_Chain_Leader"]);
                    //Vendor_Approval.Finance_Leader = Convert.ToString(dr["Finance_Leader"]);
                    //Vendor_Approval.Business_Leader = Convert.ToString(dr["Business_Leader"]);
                    Vendor_Approval.Form_ID = Convert.ToString(dr["Form_ID"]);
                    Vendor_Approval.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    Vendor_Approval.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    Vendor_Approval.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Vendor_Approval.Factory_Name= Convert.ToString(dr["Factory_Name"]);
                    //Vendor_Approval.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    Vendor_Approval.Flag = Convert.ToInt32(dr["Flag"]);
                }
                SqlParameter[] sp1 = new SqlParameter[]
                {
                     new SqlParameter("@Form_ID",Vendor_Approval.Form_ID)
                };
                Vendor_Approval.ProjectList = new List<As_Bidding_Approval_Item>();
                DataTable dts = DBHelp.GetDataSet(sql1, sp1);
                if (dts.Rows.Count > 0)
                {
                    for (int j = 0; j < dts.Rows.Count; j++)
                    {
                        As_Bidding_Approval_Item item = new As_Bidding_Approval_Item();
                        item.Item = dts.Rows[j]["Item"].ToString().Trim();
                        item.Description = dts.Rows[j]["Description"].ToString().Trim();
                        item.Price1 = dts.Rows[j]["Price"].ToString().Trim();
                        item.Price2 = dts.Rows[j]["Price1"].ToString().Trim();
                        item.Price3 = dts.Rows[j]["Price2"].ToString().Trim();
                        item.Form_ID = dts.Rows[j]["Form_ID"].ToString().Trim();
                        Vendor_Approval.ProjectList.Add(item);
                    }
                }
                return Vendor_Approval;
            }
            return null;
        }
    }
}
