﻿using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MODEL.VendorAssess;

namespace BLL
{
    public class SelectEmployeeVendor_BLL
    {
        public static IList<As_Employee_Vendor> selectEmployeeVendor(string sql)
        {
            return SelectEmployeeVendor_DAL.selectEmployeeVendor(sql);
        }

        /// <summary>
        /// 通过表格类型编号查询表格类型对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="isEdit">是否是从绑定表中查询，true为填写，false为多部门填写</param>
        /// <returns></returns>
        public static IList<As_Vendor_FormType> listVendorFormType(string sql,bool isEdit = false)
        {
            return VendorForm_DAL.listVendorFormType(sql,isEdit);
        }
        public static IList<As_Vendor_FileType> listVendorFileType(string sql)
        {
            return File_DAL.listVendorFileType(sql);
        }


        /// <summary>
        /// 获取该供应商的所有填写过但是为提交的表格
        /// </summary>
        /// <param name="sqlkeepfill"></param>
        /// <returns></returns>
        public static IList<As_MutipleForm> listVendorKeepFillForms(string sqlkeepfill)
        {
            return SelectEmployeeVendor_DAL.listVendorKeepFillForms(sqlkeepfill);
        }
    }
}
