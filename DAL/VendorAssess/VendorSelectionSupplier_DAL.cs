using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;
using System.Data;

namespace DAL.VendorAssess
{
    public class VendorSelectionSupplier_DAL
    {
        public static int addVendorSupplier(As_Vendor_Selection_Supplier supplier)
        {
            string sql = "insert into As_Vendor_Selection_Supplier(Sales_Breakdown, Annual_Turn_Over, In_House_Production, Capacity_Utilization, Payment_Term, Quality_Documentation_Training, Quality_In_Design_Develpoment, Quality_Purchased_Material, Process_Quality, Reliability, Measurement_System, Non_Conformity, Continuous_Improvement, R_D_Capability, P_M_Capability, Outsourcing_Material_Development, Process_Control, Service_Warranty, Competitiveness, Supplier_Pos, Assurance_Of_Supplier_Comments, Quality_Comments, R_D_Comments, Price_Comments,Form_ID) VALUES (@Sales_Breakdown,@Annual_Turn_Over,@In_House_Production,@Capacity_Utilization,@Payment_Term,@Quality_Documentation_Training,@Quality_In_Design_Develpoment,@Quality_Purchased_Material,@Process_Quality,@Reliability,@Measurement_System,@Non_Conformity,@Continuous_Improvement,@R_D_Capability,@P_M_Capability,@Outsourcing_Material_Development,@Process_Control,@Service_Warranty,@Competitiveness,@Supplier_Pos,@Assurance_Of_Supplier_Comments,@Quality_Comments,@R_D_Comments,@Price_Comments,@Form_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Sales_Breakdown",supplier.Sales_Breakdown),
                new SqlParameter("@Annual_Turn_Over",supplier.Annual_Turn_Over),
                new SqlParameter("@In_House_Production",supplier.In_House_Production),
                new SqlParameter("@Capacity_Utilization",supplier.Capacity_Utilization),
                new SqlParameter("@Payment_Term",supplier.Payment_Term),
                new SqlParameter("@Quality_Documentation_Training",supplier.Quality_Documentation_Training),
                new SqlParameter("@Quality_In_Design_Develpoment",supplier.Quality_In_Design_Develpoment),
                new SqlParameter("@Quality_Purchased_Material",supplier.Quality_Purchased_Material),
                new SqlParameter("@Process_Quality",supplier.Process_Quality),
                new SqlParameter("@Reliability",supplier.Reliability),
                new SqlParameter("@Measurement_System",supplier.Measurement_System),
                new SqlParameter("@Non_Conformity",supplier.Non_Conformity),
                new SqlParameter("@Continuous_Improvement",supplier.Continuous_Improvement),
                new SqlParameter("@R_D_Capability",supplier.R_D_Capability),
                new SqlParameter("@P_M_Capability",supplier.P_M_Capability),
                new SqlParameter("@Outsourcing_Material_Development",supplier.Outsourcing_Material_Development),
                new SqlParameter("@Process_Control",supplier.Process_Control),
                new SqlParameter("@Service_Warranty",supplier.Service_Warranty),
                new SqlParameter("@Competitiveness",supplier.Competitiveness),
                new SqlParameter("@Supplier_Pos",supplier.Supplier_Pos),
                new SqlParameter("@Assurance_Of_Supplier_Comments",supplier.Assurance_Of_Supplier_Comments),
                new SqlParameter("@Quality_Comments",supplier.Quality_Comments),
                new SqlParameter("@R_D_Comments",supplier.R_D_Comments),
                new SqlParameter("@Price_Comments",supplier.Price_Comments),
                new SqlParameter("@Form_ID",supplier.Form_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        /// <summary>
        /// 删除所有相关
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static int deleteVendorSupplier(string formID)
        {
            string sql = "delete from As_Vendor_Selection_Supplier where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int updateVendorSupplier(List<As_Vendor_Selection_Supplier> list)
        {
            deleteVendorSupplier(list[0].Form_ID);
            foreach (As_Vendor_Selection_Supplier item in list)
            {
                addVendorSupplier(item);
            }
            return 1;
        }

        public static List<As_Vendor_Selection_Supplier> checkSupplier(string formID)
        {
            string sql = "select * from As_Vendor_Selection_Supplier where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            List<As_Vendor_Selection_Supplier> list = new List<As_Vendor_Selection_Supplier>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    As_Vendor_Selection_Supplier supplier = new As_Vendor_Selection_Supplier();
                    supplier.Supplier_ID = item["Supplier_ID"].ToString();
                    supplier.Sales_Breakdown = Convert.ToDouble(item["Sales_Breakdown"]);
                    supplier.Annual_Turn_Over = Convert.ToDouble(item["Annual_Turn_Over"]);
                    supplier.In_House_Production = Convert.ToDouble(item["In_House_Production"]);
                    supplier.Capacity_Utilization = Convert.ToDouble(item["Capacity_Utilization"]);
                    supplier.Payment_Term = Convert.ToDouble(item["Payment_Term"]);
                    supplier.Quality_Documentation_Training = Convert.ToDouble(item["Quality_Documentation_Training"]);
                    supplier.Quality_In_Design_Develpoment = Convert.ToDouble(item["Quality_In_Design_Develpoment"]);
                    supplier.Quality_Purchased_Material = Convert.ToDouble(item["Quality_Purchased_Material"]);
                    supplier.Process_Quality = Convert.ToDouble(item["Process_Quality"]);
                    supplier.Reliability = Convert.ToDouble(item["Reliability"]);
                    supplier.Measurement_System = Convert.ToDouble(item["Measurement_System"]);
                    supplier.Non_Conformity = Convert.ToDouble(item["Non_Conformity"]);
                    supplier.Continuous_Improvement = Convert.ToDouble(item["Continuous_Improvement"]);
                    supplier.R_D_Capability = Convert.ToDouble(item["R_D_Capability"]);
                    supplier.P_M_Capability = Convert.ToDouble(item["P_M_Capability"]);
                    supplier.Outsourcing_Material_Development = Convert.ToDouble(item["Outsourcing_Material_Development"]);
                    supplier.Process_Control = Convert.ToDouble(item["Process_Control"]);
                    supplier.Service_Warranty = Convert.ToDouble(item["Service_Warranty"]);
                    supplier.Competitiveness = Convert.ToDouble(item["Competitiveness"]);
                    supplier.Supplier_Pos = Convert.ToString(item["Supplier_Pos"]);
                    supplier.Assurance_Of_Supplier_Comments = Convert.ToByte(item["Assurance_Of_Supplier_Comments"]);
                    supplier.Quality_Comments = Convert.ToByte(item["Quality_Comments"]);
                    supplier.R_D_Comments = Convert.ToByte(item["R_D_Comments"]);
                    supplier.Price_Comments = Convert.ToByte(item["Price_Comments"]);
                    supplier.Form_ID = Convert.ToString(item["Form_ID"]);
                    list.Add(supplier);
                }
            }
            list.Sort((x,y)=> (x.Supplier_Pos.CompareTo(y.Supplier_Pos)));
            return list;
        }
    }
}
