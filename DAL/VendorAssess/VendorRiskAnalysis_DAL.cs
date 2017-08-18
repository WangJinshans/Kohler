using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace DAL.VendorAssess
{
    public class VendorRiskAnalysis_DAL
    {
        /// <summary>
        /// 插入风险分析表
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int addVendorRisk(As_Vendor_Risk vendorRisk)
        {
            string sql = "insert into As_Vendor_Risk(Temp_Vendor_ID,Form_Type_ID,Supplier,Flag,Factory_Name) values(@Temp_Vendor_ID,@Form_Type_ID,@Supplier,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",vendorRisk.Temp_Vendor_ID),
                new SqlParameter("@Supplier",vendorRisk.Supplier),
                new SqlParameter("@Flag",vendorRisk.Flag),
                new SqlParameter("@Form_Type_ID",vendorRisk.Form_Type_ID),
                new SqlParameter("@Factory_Name",vendorRisk.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        /// <summary>
        /// 查询是否有风险分析表的记录
        /// </summary>
        /// <param name="formID">风险分析表的指定id</param>
        /// <returns>1有记录，0无记录</returns>
        public static int checkVendorRiskAnalysis(string formID)
        {
            string sql = "select * from As_Vendor_Risk where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);

            return dt.Rows.Count > 0 ? 1 : 0;
        }

        public static string getFormID(string tempVendorID,string form_Name,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_Vendor_FormType where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Type_Name=@Form_Type_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Type_Name",form_Name),
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
            string sql = "select Submit from As_Vendor_Risk WHERE Form_ID='" + formID + "'";
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

        /// <summary>
        /// 查询此风险分析表是否被修改
        /// </summary>
        /// <param name="formID"></param>
        /// <returns>0未修改，1已修改</returns>
        public static int getVendorRiskAnalysisFlag(string formID)
        {
            int flag = -1;
            string sql = "select Flag from As_Vendor_Risk where Form_ID=@Form_ID";

            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return flag;
        }

        /// <summary>
        /// 更新表
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int updateVendorRisk(As_Vendor_Risk vendorRisk, IList<As_Vendor_Risk_Notes> list)
        {
            string sql = "update As_Vendor_Risk SET Form_Type_ID=@Form_Type_ID,Supplier=@Supplier,Part_No=@Part_No,Manufacturer=@Manufacturer,Where_Used=@Where_Used,Annual_Spend=@Annual_Spend,Overall_Risk_Category=@Overall_Risk_Category,General_Assessment=@General_Assessment,Contingency_Plan=@Contingency_Plan,Urgency=@Urgency,Complete_By=@Complete_By,Compiled_By=@Compiled_By,Date=@Date,Corporate_Strategy=@Corporate_Strategy,Stability=@Stability,Contractual=@Contractual,Third_Party_Involvement=@Third_Party_Involvement,Location=@Location,Transport=@Transport,Seasonality=@Seasonality,Environmental_Capacity=@Environmental_Capacity,Stocks=@Stocks,Dedicated_Facilities=@Dedicated_Facilities,Recycling_Policy=@Recycling_Policy,Communication=@Communication,Financial=@Financial,Kohler_Forward_Plan=@Kohler_Forward_Plan,Supplier_Forward_Plan=@Supplier_Forward_Plan,Change_Of_Source=@Change_Of_Source,Annual_Shutdown=@Annual_Shutdown,Computer_Systems=@Computer_Systems,Intellectual_Property_Kohler=@Intellectual_Property_Kohler,Relationship=@Relationship,Technological_Capacity=@Technological_Capacity,Machine_Breakdown=@Machine_Breakdown,Quality_Accreditation=@Quality_Accreditation,Audit_Failure=@Audit_Failure,Alternative_Supplier=@Alternative_Supplier,Alternative_Materials=@Alternative_Materials,Complexity=@Complexity,Research_And_Development=@Research_And_Development,Rejections_Or_Complaints=@Rejections_Or_Complaints,Specifications=@Specifications,Flag=@Flag,Product=@Product,Temp_Vendor_ID=@Temp_Vendor_ID where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorRisk.Form_ID),
                new SqlParameter("@Form_Type_ID",vendorRisk.Form_Type_ID),
                new SqlParameter("@Supplier",vendorRisk.Supplier),
                new SqlParameter("@Part_No",vendorRisk.Part_No),
                new SqlParameter("@Manufacturer",vendorRisk.Manufacturer),
                new SqlParameter("@Where_Used",vendorRisk.Where_Used),
                new SqlParameter("@Annual_Spend",vendorRisk.Annual_Spend),
                new SqlParameter("@Overall_Risk_Category",vendorRisk.Overall_Risk_Category),
                new SqlParameter("@General_Assessment",vendorRisk.General_Assessment),
                new SqlParameter("@Contingency_Plan",vendorRisk.Contingency_Plan),
                new SqlParameter("@Urgency",vendorRisk.Urgency),
                new SqlParameter("@Complete_By",vendorRisk.Complete_By),
                new SqlParameter("@Compiled_By",vendorRisk.Compiled_By),
                new SqlParameter("@Date",vendorRisk.Date),
                new SqlParameter("@Corporate_Strategy",vendorRisk.Corporate_Strategy),
                new SqlParameter("@Stability",vendorRisk.Stability),
                new SqlParameter("@Contractual",vendorRisk.Contractual),
                new SqlParameter("@Third_Party_Involvement",vendorRisk.Third_Party_Involvement),
                new SqlParameter("@Location",vendorRisk.Location),
                new SqlParameter("@Transport",vendorRisk.Transport),
                new SqlParameter("@Seasonality",vendorRisk.Seasonality),
                new SqlParameter("@Environmental_Capacity",vendorRisk.Environmental_Capacity),
                new SqlParameter("@Stocks",vendorRisk.Stocks),
                new SqlParameter("@Dedicated_Facilities",vendorRisk.Dedicated_Facilities),
                new SqlParameter("@Recycling_Policy",vendorRisk.Recycling_Policy),
                new SqlParameter("@Communication",vendorRisk.Communication),
                new SqlParameter("@Financial",vendorRisk.Financial),
                new SqlParameter("@Kohler_Forward_Plan",vendorRisk.Kohler_Forward_Plan),
                new SqlParameter("@Supplier_Forward_Plan",vendorRisk.Supplier_Forward_Plan),
                new SqlParameter("@Change_Of_Source",vendorRisk.Change_Of_Source),
                new SqlParameter("@Annual_Shutdown",vendorRisk.Annual_Shutdown),
                new SqlParameter("@Computer_Systems",vendorRisk.Computer_Systems),
                new SqlParameter("@Intellectual_Property_Kohler",vendorRisk.Intellectual_Property_Kohler),
                new SqlParameter("@Relationship",vendorRisk.Relationship),
                new SqlParameter("@Technological_Capacity",vendorRisk.Technological_Capacity),
                new SqlParameter("@Machine_Breakdown",vendorRisk.Machine_Breakdown),
                new SqlParameter("@Quality_Accreditation",vendorRisk.Quality_Accreditation),
                new SqlParameter("@Audit_Failure",vendorRisk.Audit_Failure),
                new SqlParameter("@Alternative_Supplier",vendorRisk.Alternative_Supplier),
                new SqlParameter("@Alternative_Materials",vendorRisk.Alternative_Materials),
                new SqlParameter("@Complexity",vendorRisk.Complexity),
                new SqlParameter("@Research_And_Development",vendorRisk.Research_And_Development),
                new SqlParameter("@Rejections_Or_Complaints",vendorRisk.Rejections_Or_Complaints),
                new SqlParameter("@Specifications",vendorRisk.Specifications),
                new SqlParameter("@Flag",vendorRisk.Flag),
                new SqlParameter("@Product",vendorRisk.Product),
                new SqlParameter("@Temp_Vendor_ID",vendorRisk.Temp_Vendor_ID)
            };
            int result = DBHelp.ExecuteCommand(sql, sp);

            Vendor_Risk_Analysis_Notes_DAL.deleteNotes(vendorRisk.Form_ID);
            foreach (As_Vendor_Risk_Notes item in list)
            {
                Vendor_Risk_Analysis_Notes_DAL.addNotes(item);
            }
            return result;
        }

        /// <summary>
        /// 获取风险分析表
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static As_Vendor_Risk getVendorRiskAnalysis(string formID)
        {
            As_Vendor_Risk vendorRisk = null;
            string sql = "select * from As_Vendor_Risk where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };

            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count>0)
            {
                vendorRisk = new As_Vendor_Risk();
                foreach (DataRow dr in dt.Rows)
                {
                    vendorRisk.Form_ID = Convert.ToString(dr["Form_ID"]);
                    vendorRisk.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    vendorRisk.Supplier = Convert.ToString(dr["Supplier"]);
                    vendorRisk.Part_No = Convert.ToString(dr["Part_No"]);
                    vendorRisk.Manufacturer = Convert.ToString(dr["Manufacturer"]);
                    vendorRisk.Where_Used = Convert.ToString(dr["Where_Used"]);
                    vendorRisk.Annual_Spend = Convert.ToDouble(dr["Annual_Spend"]);
                    vendorRisk.Overall_Risk_Category = Convert.ToByte(dr["Overall_Risk_Category"]);
                    vendorRisk.General_Assessment = Convert.ToString(dr["General_Assessment"]);
                    vendorRisk.Contingency_Plan = Convert.ToString(dr["Contingency_Plan"]);
                    vendorRisk.Urgency = Convert.ToString(dr["Urgency"]);
                    vendorRisk.Complete_By = Convert.ToString(dr["Complete_By"]);
                    vendorRisk.Compiled_By = Convert.ToString(dr["Compiled_By"]);
                    vendorRisk.Date = Convert.ToDateTime(dr["Date"]);
                    vendorRisk.Corporate_Strategy = Convert.ToByte(dr["Corporate_Strategy"]);
                    vendorRisk.Stability = Convert.ToByte(dr["Stability"]);
                    vendorRisk.Contractual = Convert.ToByte(dr["Contractual"]);
                    vendorRisk.Third_Party_Involvement = Convert.ToByte(dr["Third_Party_Involvement"]);
                    vendorRisk.Location = Convert.ToByte(dr["Location"]);
                    vendorRisk.Transport = Convert.ToByte(dr["Transport"]);
                    vendorRisk.Seasonality = Convert.ToByte(dr["Seasonality"]);
                    vendorRisk.Environmental_Capacity = Convert.ToByte(dr["Environmental_Capacity"]);
                    vendorRisk.Stocks = Convert.ToByte(dr["Stocks"]);
                    vendorRisk.Dedicated_Facilities = Convert.ToByte(dr["Dedicated_Facilities"]);
                    vendorRisk.Recycling_Policy = Convert.ToByte(dr["Recycling_Policy"]);
                    vendorRisk.Communication = Convert.ToByte(dr["Communication"]);
                    vendorRisk.Financial = Convert.ToByte(dr["Financial"]);
                    vendorRisk.Kohler_Forward_Plan = Convert.ToByte(dr["Kohler_Forward_Plan"]);
                    vendorRisk.Supplier_Forward_Plan = Convert.ToByte(dr["Supplier_Forward_Plan"]);
                    //vendorRisk.Price = Convert.ToByte(dr["Price"]);
                    vendorRisk.Change_Of_Source = Convert.ToByte(dr["Change_Of_Source"]);
                    vendorRisk.Annual_Shutdown = Convert.ToByte(dr["Annual_Shutdown"]);
                    vendorRisk.Computer_Systems = Convert.ToByte(dr["Computer_Systems"]);
                    vendorRisk.Intellectual_Property_Kohler = Convert.ToByte(dr["Intellectual_Property_Kohler"]);
                    vendorRisk.Relationship = Convert.ToByte(dr["Relationship"]);
                    vendorRisk.Technological_Capacity = Convert.ToByte(dr["Technological_Capacity"]);
                    vendorRisk.Machine_Breakdown = Convert.ToByte(dr["Machine_Breakdown"]);
                    vendorRisk.Quality_Accreditation = Convert.ToByte(dr["Quality_Accreditation"]);
                    vendorRisk.Audit_Failure = Convert.ToByte(dr["Audit_Failure"]);
                    vendorRisk.Alternative_Supplier = Convert.ToByte(dr["Alternative_Supplier"]);
                    vendorRisk.Alternative_Materials = Convert.ToByte(dr["Alternative_Materials"]);
                    vendorRisk.Complexity = Convert.ToByte(dr["Complexity"]);
                    vendorRisk.Research_And_Development = Convert.ToByte(dr["Research_And_Development"]);
                    vendorRisk.Rejections_Or_Complaints = Convert.ToByte(dr["Rejections_Or_Complaints"]);
                    vendorRisk.Specifications = Convert.ToByte(dr["Specifications"]);
                    vendorRisk.Flag = Convert.ToInt32(dr["Flag"]);
                    vendorRisk.Product = Convert.ToString(dr["Product"]);
                    vendorRisk.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    vendorRisk.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    vendorRisk.Factory_Name= Convert.ToString(dr["Factory_Name"]);
                }
            }
            return vendorRisk;
        }
    }
}
