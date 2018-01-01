using BLL;
using Model;
using MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebLearning.DAL;
using WebLearning.Model;

namespace WebLearning.BLL
{
    public class Vendor_Modify_File_BLL
    {
        /// <summary>
        /// 获取指定的供应商需要上传的所有文件 
        /// </summary>
        /// <param name="temp_Vendor_Name"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static IList<Vendor_Modify_File> getFileList(string temp_Vendor_ID, string factory_Name)
        {
            string sql = "select * from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "'";
            return Vendor_Modify_File_DAL.getFileList(sql);
        }

        /// <summary>
        /// 查询是否所有的文件都已经提交
        /// </summary>
        /// <param name="temp_Vendor_Name"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        /// 
        public static bool isFilesUpload(string temp_Vendor_ID, string factory_Name)
        {
            string sql = "select File_Type_Name from As_Vendor_Modify_File where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "' and Flag='0'";
            return Vendor_Modify_File_DAL.isFilesUpload(sql);
        }


        /// <summary>
        /// 写此方法的原因是 6个类型对应了6张信息表 而绝大多数信息都应该是一样的 但是本系统没有抽出来
        /// </summary>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static As_Temp_Vendor getTempVendorInfo(string vendorName)
        {
            As_Temp_Vendor temp = new As_Temp_Vendor();
            List<string> typeList = new List<string>();
            temp.Temp_Vendor_Name = vendorName;
            temp.TypeNumber = Vendor_Modify_File_DAL.getTempVendorTypeNumber(vendorName);
            typeList = Vendor_Modify_File_DAL.getTypeList(vendorName);
            for (int i = 0; i < typeList.Count; i++)
            {
                if (typeList[i].Equals("直接物料常规"))
                {
                    temp.VendorTypeOne = "直接物料常规";
                }
                if (typeList[i].Equals("直接物料危化品"))
                {
                    temp.VendorTypeTwo = "直接物料危化品";
                }
                if (typeList[i].Equals("非生产性特种劳防品"))
                {
                    temp.VendorTypeThree = "非生产性特种劳防品";
                }
                if (typeList[i].Equals("非生产性危化品"))
                {
                    temp.VendorTypeFour = "非生产性危化品";
                }
                if (typeList[i].Equals("非生产性常规"))
                {
                    temp.VendorTypeFive = "非生产性常规";
                }
                if (typeList[i].Equals("非生产性质量部有标准的物料"))
                {
                    temp.VendorTypeSix = "非生产性质量部有标准的物料";
                }
            }
            return temp;
        }


        /// <summary>
        /// 更新文件上传标志
        /// </summary>
        /// <param name="temp_Vendor_Name"></param>
        /// <param name="factory_Name"></param>
        /// <param name="file_Type_Name"></param>
        /// <returns></returns>
        public static int upDataUploadFlag(string temp_Vendor_Name, string factory_Name,string file_Type_Name)
        {
            string sql = "update As_Vendor_Modify_File set Flag='1' where Temp_Vendor_Name='" + temp_Vendor_Name + "' and Factory_Name='" + factory_Name + "' and File_Type_Name='" + file_Type_Name + "'";
            return Vendor_Modify_File_DAL.upDataUploadFlag(sql);
        }


        /// <summary>
        /// 更新该供应商是否正在更改类型的标志
        /// 不同类型 temp_Vendor_ID不同
        /// </summary>
        /// <param name="temp_Vendor_ID"></param>
        /// <param name="factory_Name"></param>
        /// <returns></returns>
        public static int upDataVendorChangingFlag(string temp_Vendor_ID, string factory_Name)
        {
            string sql = "update As_Vendor_Modify_Info set IsChanging='NO' where Temp_Vendor_ID='" + temp_Vendor_ID + "' and Factory_Name='" + factory_Name + "'";
            return Vendor_Modify_File_DAL.upDataUploadFlag(sql);
        }


        /// <summary>
        /// 获取供应商修改页面时上传的所有文件附件列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static IList<Vendor_Modify_File> listFile(string sql)
        {
            IList<Vendor_Modify_File> fileList = Vendor_Modify_File_DAL.listFile(sql);
            return fileList;
        }

        /// <summary>
        /// 调用存储过程初始化所有需要上传的文件 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int initVendorFile(Dictionary<string, string> dc)
        {
            return Vendor_Modify_File_DAL.initVendorFile(dc);
        }


        /// <summary>
        /// 判断该供应商是否正在修改中
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <returns></returns>
        public static string isVendorChanging(string vendorCode,string vendorType)
        {
            string temp_Vendor_ID=TempVendor_BLL.getTempVendorIDByCodeAndType(vendorCode, vendorType);
            return Vendor_Modify_File_DAL.isVendorChanging(temp_Vendor_ID);
        }

        public static bool isNeedFinance(string temp_vendor_ID, string factory_Name)
        {
            return Vendor_Modify_File_DAL.isNeedFinance(temp_vendor_ID,factory_Name);
        }

        public static bool vendorModifyIsSubmit(string temp_vendor_ID)
        {
            return Vendor_Modify_File_DAL.vendorModifyIsSubmit(temp_vendor_ID);
        }

        public static object getModifyFormID(string temp_vendor_ID)
        {
            return Vendor_Modify_File_DAL.getModifyFormID(temp_vendor_ID);
        }
    }
}