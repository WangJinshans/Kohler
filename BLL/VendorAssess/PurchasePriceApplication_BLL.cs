using BLL.VendorAssess;
using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class PurchasePriceApplication_BLL
    {
        public static int addVendorPurchasePriceApplication(As_PurchasePriceApplication Vendor_PurchasePrice)
        {
            return PurchasePriceApplication_DAL.addVendorPurchasePrice(Vendor_PurchasePrice);
        }

        public static int updateVendorPurchasePriceApplication(As_PurchasePriceApplication purchasePrice)
        {
            return PurchasePriceApplication_DAL.updateVendorPurchasePrice(purchasePrice);
        }

        public static int checkVendorPurchasePriceApplication(string FormId)
        {
            return PurchasePriceApplication_DAL.checkVendorPurchasePrice(FormId);
        }

        public static As_PurchasePriceApplication checkFlag(string FormId)
        {
            As_PurchasePriceApplication VendorPurchasePrice = new As_PurchasePriceApplication();
            int flag = PurchasePriceApplication_DAL.getVendorPurchasePriceFlag(FormId);
            if (flag == 1)
            {
                VendorPurchasePrice = PurchasePriceApplication_DAL.getPurchasePrice(FormId);
                return VendorPurchasePrice;
            }
            else if (flag == 2)
            {
                VendorPurchasePrice = PurchasePriceApplication_DAL.getPurchasePrice(FormId);
                return VendorPurchasePrice;
            }
            else if (flag == 0)
            {
                VendorPurchasePrice = PurchasePriceApplication_DAL.getPurchasePrice(FormId);
                return VendorPurchasePrice;
            }
            else
            {
                return null;
            }
        }

        public static string getFormID(string tempVendorID, string formTypeID, string factory)
        {
            return PurchasePriceApplication_DAL.getFormID(tempVendorID, formTypeID, factory);
        }
    }
}
