using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;
using System.Data.SqlClient;

namespace DAL.VendorAssess
{
    public class EmployeeForm_DAL
    {
        public static int addEmployeeForm(As_Employee_Form item)
        {
            string sql = "insert into As_Employee_Form(Employee_ID,Form_ID,Form_Type_Name,Fill_Flag,Temp_Vendor_ID) VALUES (@Employee_ID,@Form_ID,@Form_Type_Name,@Fill_Flag,@Temp_Vendor_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",item.Employee_ID),
                new SqlParameter("@Form_ID",item.Form_ID),
                new SqlParameter("@Form_Type_Name",item.Form_Type_Name),
                new SqlParameter("@Fill_Flag",item.Fill_Flag),
                new SqlParameter("@Temp_Vendor_ID",item.Temp_Vendor_ID)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int changeFillFlag(string employeeID,string Form_ID, int flag)
        {
            string sql = "update As_Employee_Form set Fill_Flag=@Fill_Flag where Employee_ID=@Employee_ID and Form_ID=@Form_ID";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Employee_ID",employeeID),
                new SqlParameter("@Form_ID",Form_ID),
                new SqlParameter("@Fill_Flag",flag)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }
    }
}
