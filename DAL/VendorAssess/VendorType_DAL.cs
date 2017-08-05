using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VendorType_DAL
    {
        //通过表格类型编号查询表格类型对象
        public static IList<As_VendorType_FormType> listVendorTypeFormType(string sql)
        {
            IList < As_VendorType_FormType >list= new List<As_VendorType_FormType>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_VendorType_FormType VendorType_FormType = new As_VendorType_FormType();
                    VendorType_FormType.Id = Convert.ToInt32(dr["id"]);
                    VendorType_FormType.Form_Type_ID= Convert.ToString(dr["Form_Type_ID"]);
                    VendorType_FormType.Vendor_Type_ID = Convert.ToString(dr["Vendor_Type_ID"]);
                    VendorType_FormType.Form_Type_Name = Convert.ToString(dr["Form_Type_Name"]);
                    list.Add(VendorType_FormType);
                }
            }
            return list;
        }
        //通过文件类型编号查询文件类型对象
        public static IList<As_VendorType_FileType> listVendorTypeFileType(string sql)
        {
            IList<As_VendorType_FileType> list = new List<As_VendorType_FileType>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_VendorType_FileType VendorType_FileType = new As_VendorType_FileType();
                    VendorType_FileType.VendorType_ID = Convert.ToString(dr["VendorType_ID"]);
                    VendorType_FileType.FileType_ID = Convert.ToString(dr["FileType_ID"]);
                    VendorType_FileType.FileType_Name = Convert.ToString(dr["FileType_Name"]);
                    list.Add(VendorType_FileType);
                }
            }
            return list;
        }

        //查询供应商类型编号
        public static string selectVendorTypeId(bool promise, bool advanceCharge, bool vendorAssign, string vendorType)
        {
            As_Vendor_Type vendor_Type = new As_Vendor_Type();

            string sql = "Select Vendor_Type_ID FROM As_Vendor_Type WHERE Promise=@Promise and Advance_Charge=@Advance_Charge and Vendor_Assign=@Vendor_Assign and Vendor_Type=@Vendor_Type";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Promise",promise),
                new SqlParameter("@Advance_Charge",advanceCharge),
                new SqlParameter("@Vendor_Assign",vendorAssign),
                new SqlParameter("@Vendor_Type",vendorType)
            };
            using (SqlDataReader dr = DBHelp.GetReader(sql, sp))
            {
                if (dr.Read())
                {
                    vendor_Type.Vendor_Type_ID = dr["Vendor_Type_ID"].ToString();
                }
                return vendor_Type.Vendor_Type_ID = dr["Vendor_Type_ID"].ToString();
            }
        }

        public static string selectVendorPromise(string tempVendorID)
        {
            string promise = null;
            string sql = "Select Promise FROM As_Vendor_Type,As_Temp_Vendor WHERE "
                + "As_Temp_Vendor.Vendor_Type_ID=As_Vendor_Type.Vendor_Type_ID "
                + "and As_Temp_Vendor.Temp_Vendor_ID=@Temp_Vendor_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID)
            };
            using (SqlDataReader dr = DBHelp.GetReader(sql, sp))
            {
                if (dr.Read())
                {
                    promise = dr["Promise"].ToString();
                }
                return promise;
            }
        }
    }
}
