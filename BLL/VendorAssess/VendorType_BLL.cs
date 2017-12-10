using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class VendorType_BLL
    {
        /// <summary>
        /// 获取该供应商承诺与非承诺性属性
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string selectVendorPromise(string tempVendorID)
        {
            return VendorType_DAL.selectVendorPromise(tempVendorID);
        }

        //internal static string getTypeIDByType(string newType)
        //{
        //    return VendorType_DAL.getTypeIDByType(newType);
        //}
    }
}
