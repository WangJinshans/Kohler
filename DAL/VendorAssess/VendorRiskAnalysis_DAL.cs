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
            string sql = "insert into As_Vendor_Risk(Form_ID,Form_Type_ID,Supplier,Flag) values(@Form_ID,@Form_Type_ID,@Supplier,@Flag)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorRisk.Form_ID),
                new SqlParameter("@Supplier",vendorRisk.Supplier),
                new SqlParameter("@Flag",vendorRisk.Flag),
                new SqlParameter("@Form_Type_ID",vendorRisk.Form_Type_ID)
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

        /// <summary>
        /// 查询此风险分析表是否被修改
        /// </summary>
        /// <param name="formID"></param>
        /// <returns>0未修改，1已修改</returns>
        public static int getVendorRiskAnalysisFlag(string formID)
        {
            string sql = "select Flag from As_Vendor_Risk where Form_ID=@Form_ID";

            As_Vendor_Risk vendorRisk = null;
            SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@Form_ID", formID) };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                vendorRisk = new As_Vendor_Risk();
                foreach (DataRow item in dt.Rows)
                {
                    vendorRisk.Flag = Convert.ToInt32(item["Flag"]);
                }
            }
            return vendorRisk.Flag;
        }

        /// <summary>
        /// 更新表
        /// </summary>
        /// <param name="vendorRisk"></param>
        /// <returns></returns>
        public static int updateVendorRisk(As_Vendor_Risk vendorRisk)
        {
            string sql = "update As_Vendor_Risk set Date=@Date,Flag=@Flag where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Date",vendorRisk.Date),
                new SqlParameter("@Flag",vendorRisk.Flag),
                new SqlParameter("@Form_ID",vendorRisk.Form_ID)
            };
            /*string sql = "update As_Vendor_Risk set Product=@Product,Supplier=@Supplier,Part_No=@Part_No,Manufacturer=@Manufacturer,Where_Used=@Where_Used,Annual_Spend=@Annual_Spend,Overall_Risk_Category=@Overall_Risk_Category,General_Assessment=@General_Assessment,Contingency_Plan=@Contingency_Plan,Urgency=@Urgency,Complete_By=@Complete_By,Compiled_By=@Compiled_By,Date=@Date,Corporate_Strategy=@Corporate_Strategy,Stability=@Stability,Contractual=@Contractual,Third_Party_Involvement=@Third_Party_Involvement,Location=@Location,Transport=@Transport,Seasonality=@Seasonality,Environmental_Capacity=@Environmental_Capacity,Stocks=@Stocks,Dedicated_Facilities=@Dedicated_Facilities,Recycling_Policy=@Recycling_Policy,Communication=@Communication,Financial=@Financial,Kohler_Forward_Plan=@Kohler_Forward_Plan,Supplier_Forward_Plan=@Supplier_Forward_Plan,Price=@Price,Change_Of_Source=@Change_Of_Source,Annual_Shutdown=@Annual_Shutdown,Computer_Systems=@Computer_Systems,Intellectual_Property_Kohler=@Intellectual_Property_Kohler,Relationship=@Relationship,Technological_Capacity=@Technological_Capacity,Machine_Breakdown=@Machine_Breakdown,Quality_Accreditation=@Quality_Accreditation,Audit_Failure=@Audit_Failure,Alternative_Supplier=@Alternative_Supplier,Alternative_Materials=@Alternative_Materials,Complexity=@Complexity,Research_And_Development=@Research_And_Development,Rejections_Or_Complaints=@Rejections_Or_Complaints,Specifications=@Specifications,Flag=@Flag where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",vendorRisk.Form_ID),
                new SqlParameter("@Form_Type_ID",vendorRisk.Form_Type_ID),
                new SqlParameter("@Product",vendorRisk.Product),
                new SqlParameter("@Supplier",vendorRisk.Supplier),
                new SqlParameter("@Flag",vendorRisk.Flag),
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
                new SqlParameter("@Price",vendorRisk.Price),
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
                new SqlParameter("@Specifications",vendorRisk.Specifications)
            };*/
            return DBHelp.ExecuteCommand(sql, sp);
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
                foreach (DataRow item in dt.Rows)
                {
                    vendorRisk.Date = Convert.ToDateTime(item["Date"]);
                    vendorRisk.Flag = Convert.ToInt32(item["Flag"]);
                    //TODO::给vendorRisk赋值
                }
            }
            return vendorRisk;
        }
    }
}
