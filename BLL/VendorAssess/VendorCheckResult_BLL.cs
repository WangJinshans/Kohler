using DAL.VendorAssess;
using Model;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class VendorCheckResult_BLL
    {
        public static List<As_Modify_CheckResult> getData(string tempVendorID, string factory_Name)
        {
            return VendorCheckResult_DAL.getData(tempVendorID, factory_Name);
        }

        public static void modify_CheckResult(string procedureName, string vendor_Name, string factory_Name, string newType, string oldType, bool promise, bool assign, bool charge, float money,string employeeID)
        {
            As_Temp_Vendor Temp_Vendor = new As_Temp_Vendor();
            Temp_Vendor.Temp_Vendor_Name = vendor_Name;
            string oldTempVendorID = TempVendor_BLL.getTempVendorIDFixed(vendor_Name, oldType,factory_Name);
            
            //不需要进行新建  只需要更新vendorTypeID就行了
            
            //if (oldType != newType)
            //{
            //    vendorTypeID = FillVendorInfo_BLL.selectVendorTypeId(promise, charge, assign, newType);
            //    Temp_Vendor.Vendor_Type_ID = vendorTypeID;
            //    Temp_Vendor.Purchase_Amount = Convert.ToInt32(money);
            //    Temp_Vendor.Normal_Vendor_ID = TempVendor_BLL.getNormalCode(oldTempVendorID);
            //    int joinTempVendor = FillVendorInfo_BLL.addTempVendor(Temp_Vendor);
            //}

            //获取临时供应商编号
            //如果类型未更改 newType和oldType一样 且oldType必须存在
            //然后判断金额

            VendorCheckResult_DAL.modify_CheckResult(procedureName, oldTempVendorID, factory_Name, newType, oldType, promise,assign,charge,money);

            //string newTemp_Vendor_ID= TempVendor_BLL.getTempVendorIDFixed(Temp_Vendor.Temp_Vendor_Name, newType, factory_Name);//新类型的temp_Vendor_ID
                                                                                                                 //添加到As_Employee_Vendor中
            //if (oldType != newType)
            //{
            //    As_Employee_Vendor vendor = new As_Employee_Vendor();
            //    vendor.Employee_ID = employeeID;
            //    vendor.Temp_Vendor_ID = newTemp_Vendor_ID;
            //    vendor.Vendor_Type_ID = vendorTypeID;
            //    vendor.Temp_Vendor_Name = TempVendor_BLL.getTempVendorName(newTemp_Vendor_ID);
            //    vendor.Type = "类型更改";
            //    AddEmployeeVendor_BLL.addEmployeeVendor(vendor);

            //    //更新共享文件上传标志
            //    List<string> fileTypeIDlist = VendorCheckResult_DAL.getShareFileTypeIDs(newTemp_Vendor_ID, factory_Name);
            //    if (fileTypeIDlist != null || !(fileTypeIDlist.Count > 0))
            //    {
            //        foreach (string fileTypeID in fileTypeIDlist)
            //        {
            //            //如果原来已经提交则更新
            //            if (VendorCheckResult_DAL.isUpload(oldTempVendorID, factory_Name, fileTypeID))
            //            {
            //                VendorCheckResult_DAL.upDateShareFlag(newTemp_Vendor_ID, factory_Name, fileTypeID);
            //            }
            //        }
            //    }
            //    //更新oldTempVendorID的所有信息
            //    upDateAll(newTemp_Vendor_ID, oldTempVendorID, factory_Name);
            //    //删除原来的记录
            //    FillVendorInfo_BLL.deleteVendorType(oldTempVendorID, factory_Name);
            //}
            //return newTemp_Vendor_ID;
          
        }

        private static void upDateAll(string newTempVendorID, string oldTempVendorID,string factory)
        {
            VendorCheckResult_DAL.upDateAll(newTempVendorID,oldTempVendorID, factory);
        }

        public static void addVendorModifyInfo(string sqls)
        {
            VendorCheckResult_DAL.addVendorModifyInfo(sqls);
        }
    }
}
