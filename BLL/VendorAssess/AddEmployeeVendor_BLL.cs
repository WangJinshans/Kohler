﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddEmployeeVendor_BLL
    {
        //添加临时供应商
        public static int addEmployeeVendor(As_Employee_Vendor employee_Vendor)
        {
            return AddEmployeeVendor_DAL.addEmployeeVendor(employee_Vendor);
        }

        /// <summary>
        /// 检查此id是否有权限操作该供应商
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="employee_ID"></param>
        /// <returns></returns>
        public static bool hasEmployeeID(string tempVendorID ,string employee_ID,string factory)
        {
            DataTable dt = AddEmployeeVendor_DAL.getEmployeeID(tempVendorID, factory);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    if (item["Employee_ID"].ToString().Equals(employee_ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 从发起人表中获取发起人ko
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string getEmployeeID(string tempVendorID,string factory)
        {
            DataTable dt = AddEmployeeVendor_DAL.getEmployeeID(tempVendorID, factory);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    return item["Employee_ID"].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 获取此供应商的新建者或者复用发起人
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static As_Employee_Vendor getEmployeeVendor(string tempVendorID)
        {
            return AddEmployeeVendor_DAL.get(tempVendorID);
        }
    }
}
