using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VendorDiscovery_BLL
    {
        public static int addVendorDiscovery(As_Vendor_Discovery Vendor_Discovery)//新增供应商赋值
        {
            return VendorDiscovery_DAL.addVendorDiscovery(Vendor_Discovery);
        }

        public static int updateVendorDiscovery(As_Vendor_Discovery Vendor_Discovery)//更新供应商信息
        {
            return VendorDiscovery_DAL.updateVendorDiscovery(Vendor_Discovery);
        }

        public static int checkVendorDiscovery(string FormId)//检查是否有记录
        {
            return VendorDiscovery_DAL.checkVendorDiscovery(FormId);
        }

        public static As_Vendor_Discovery checkFlag(string FormId)//查看供应商信息
        {
            As_Vendor_Discovery VendorDiscovery = new As_Vendor_Discovery();
            int flag = VendorDiscovery_DAL.getVendorDiscoveryFlag(FormId);
            if (flag == 1)
            {
                VendorDiscovery = VendorDiscovery_DAL.getVendorDiscovery(FormId);
                return VendorDiscovery;
            }
            else
            {
                return null;
            }
        }

    }
}
