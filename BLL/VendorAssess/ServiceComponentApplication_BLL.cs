using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class ServiceComponentApplication_BLL
    {
        public static int addVendorServiceComponent(As_ServiceComponentApplication vendor_ServiceComponent)
        {
            return ServiceComponentApplication_DAL.addVendorServiceComponent(vendor_ServiceComponent);
        }

        public static int updateVendorServiceComponent(As_ServiceComponentApplication vendor_ServiceComponent)
        {
            return ServiceComponentApplication_DAL.updateVendorServiceComponent(vendor_ServiceComponent);
        }

        public static int checkVendorServiceComponent(string FormId)
        {
            return ServiceComponentApplication_DAL.checkVendorServiceComponent(FormId);
        }

        public static As_ServiceComponentApplication checkFlag(string FormId)
        {
            As_ServiceComponentApplication vendor_ServiceComponent = new As_ServiceComponentApplication();
            int flag = ServiceComponentApplication_DAL.getVendorServiceComponentFlag(FormId);
            if (flag == 1)
            {
                vendor_ServiceComponent = ServiceComponentApplication_DAL.getServiceComponent(FormId);
                return vendor_ServiceComponent;
            }
            else if (flag == 2)
            {
                vendor_ServiceComponent = ServiceComponentApplication_DAL.getServiceComponent(FormId);
                return vendor_ServiceComponent;
            }
            else if (flag == 0)
            {
                vendor_ServiceComponent = ServiceComponentApplication_DAL.getServiceComponent(FormId);
                return vendor_ServiceComponent;
            }
            else
            {
                return null;
            }
        }

        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            return ServiceComponentApplication_DAL.getFormID(tempVendorID, formTypeID, factory);
        }

        public static string getVendorServiceComponentFormID(string tempVendorID, string fORM_TYPE_ID, string factory, int n)
        {
            return ServiceComponentApplication_DAL.getVendorServiceComponentFormID(tempVendorID, fORM_TYPE_ID, factory, n);
        }
    }
}
