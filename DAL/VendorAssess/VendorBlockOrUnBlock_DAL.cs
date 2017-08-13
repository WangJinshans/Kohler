using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class VendorBlockOrUnBlock_DAL
    {
        public static int addVendorBlock(As_Vendor_Block_Or_UnBlock Block_UnBlock) //初始化表格赋值表格编号和表格种类编号
        {
            string sql = "insert into As_Vendor_Block_Or_UnBlock(Temp_Vendor_Name,Flag,Factory_Name)values(@Temp_Vendor_Name,@Flag,@Factory_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
               new SqlParameter("@Temp_Vendor_Name",Block_UnBlock.Temp_Vendor_Name),
               new SqlParameter("@Flag",Block_UnBlock.Flag),
               new SqlParameter("@Factory_Name",Block_UnBlock.Factory_Name)
            };
            return DBHelp.GetScalar(sql, sp);

        }

        public static string getFormID(string tempVendorID,string form_Name,string factory)
        {
            string formID = "";
            string sql = "select Form_ID from As_NewForms_ID where Temp_Vendor_ID=@Temp_Vendor_ID and Form_Name=@Form_Name and Factory_Name=@Factory_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Form_Name",form_Name),
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
            string sql = "select Submit from As_Vendor_Block_Or_UnBlock WHERE Form_ID='" + formID + "'";
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

        public static int updateVendorBlock(As_Vendor_Block_Or_UnBlock Block_UnBlock)//更新供应商调查表
        {
            string sql = "update As_Vendor_Block_Or_UnBlock set Language=@Language,"
                + "Temp_Vendor_ID=Temp_Vendor_ID,Form_Type_ID=@Form_Type_ID,Bar_Code=@Bar_Code,"
                + "Purpose=@Purpose,Initiator_Name=@Initiator_Name,Initiator_Tel=@Initiator_Tel,"
                + "Company_Code=@Company_Code,Vendor_Code=@Vendor_Code,"
                + "Comments=@Comments where Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",Block_UnBlock.Temp_Vendor_ID),
                new SqlParameter("@Form_Type_ID",Block_UnBlock.Form_Type_ID),
                new SqlParameter("@Bar_Code",Block_UnBlock.Bar_Code),
                new SqlParameter("@Language",Block_UnBlock.Laguage),
                new SqlParameter("@Purpose",Block_UnBlock.Purpose),
                new SqlParameter("@Initiator_Name",Block_UnBlock.Initiator_Name),
                new SqlParameter("@Initiator_Tel",Block_UnBlock.Initiator_Tel),
                new SqlParameter("@Company_Code",Block_UnBlock.Company_Code),
                new SqlParameter("@Vendor_Code",Block_UnBlock.Vendor_Code),
                //new SqlParameter("@Line_Manager",Block_UnBlock.Line_Manager),
                //new SqlParameter("@Purchasing_Manager",Block_UnBlock.Purchasing_Manager),
                new SqlParameter("@Comments",Block_UnBlock.Comments),
                new SqlParameter("@Temp_Vendor_Name",Block_UnBlock.Temp_Vendor_Name)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }



        public static int checkVendorBlock(string formID)//查询是否有表记录,1为存在 0为不存在
        {
            string sql = "select * from As_Vendor_Block_Or_UnBlock where Form_ID=@Form_ID";
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

        public static As_Vendor_Block_Or_UnBlock getVendorBlock(string formID)//按照表格编号和供应商名称查询供应商调查表
        {
            As_Vendor_Block_Or_UnBlock Block_UnBlock = null;
            string sql = "select * from As_Vendor_Block_Or_UnBlock where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",formID)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Block_UnBlock = new As_Vendor_Block_Or_UnBlock();
                foreach (DataRow dr in dt.Rows)
                {
                    Block_UnBlock.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Block_UnBlock.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    Block_UnBlock.Form_Type_ID = Convert.ToString(dr["Form_Type_ID"]);
                    Block_UnBlock.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    Block_UnBlock.Bar_Code = Convert.ToString(dr["Bar_Code"]);
                    Block_UnBlock.Laguage = Convert.ToString(dr["Language"]);
                    Block_UnBlock.Purpose = Convert.ToString(dr["Purpose"]);
                    Block_UnBlock.Initiator_Name = Convert.ToString(dr["Initiator_Name"]);
                    Block_UnBlock.Initiator_Tel = Convert.ToString(dr["Initiator_Tel"]);
                    Block_UnBlock.Company_Code = Convert.ToString(dr["Company_Code"]);
                    Block_UnBlock.Vendor_Code = Convert.ToString(dr["Vendor_Code"]);
                    Block_UnBlock.Line_Manager = Convert.ToString(dr["Line_Manager"]);
                    Block_UnBlock.Purchasing_Manager = Convert.ToString(dr["Purchasing_Manager"]);
                    Block_UnBlock.Comments = Convert.ToString(dr["Comments"]);
                    Block_UnBlock.Factory_Name= Convert.ToString(dr["Factory_Name"]);
                }

            }
            return Block_UnBlock;
        }

        public static int getVendorBlockFlag(string FormId)//按照表格编号和供应商名称查询相应记录返回flag
        {
            As_Vendor_Block_Or_UnBlock Block_UnBlock = null;
            string sql = "select Flag from As_Vendor_Block_Or_UnBlock where Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Form_ID",FormId)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                Block_UnBlock = new As_Vendor_Block_Or_UnBlock();
                foreach (DataRow dr in dt.Rows)
                {
                    Block_UnBlock.Flag = Convert.ToInt32(dr["Flag"]);
                }
            }
            return Block_UnBlock.Flag;
        }

    }
}
