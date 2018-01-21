using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL.VendorAssess;
using MODEL.VendorAssess;
using SHZSZHSUPPLY.VendorAssess;

namespace BLL.VendorAssess
{
    public class PurchaseChanges_BLL
    {
        public static int add(As_Purchase_Changes asPurchaseChanges)
        {
            return PurchaseChanges_DAL.add(asPurchaseChanges);
        }

        public static As_Purchase_Changes get(string formId)
        {
            return PurchaseChanges_DAL.get(formId);
        }

        public static List<As_Purchase_Changes_Item> getItems(string formId)
        {
            DataTable dt = PurchaseChanges_DAL.getItems(formId);
            List<As_Purchase_Changes_Item> list = new List<As_Purchase_Changes_Item>();
            As_Purchase_Changes_Item item = null;
            if (dt!=null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    item = new As_Purchase_Changes_Item()
                    {
                        SKU = row[2].ToString(),
                        Description = row[3].ToString(),
                        Unit = row[4].ToString(),
                        Last_PO_Price = row[5].ToString(),
                        Last_6_Months_Average_Price = row[6].ToString(),
                        Required_Price = row[7].ToString(),
                        STD_cost = row[8].ToString(),
                        Request_Price_VS_Last_PO_Price = row[9].ToString(),
                        STD_Cost_VS_Request_Price = row[10].ToString(),
                        Yearly_Forecast = row[11].ToString(),
                        Yearly_Amount = row[12].ToString(),
                        PPV = row[13].ToString(),
                        Current_Stock = row[14].ToString(),
                        Main_Material_Cost_Change = row[15].ToString(),
                        Main_Material_Cost_VS_Total_Cost = row[16].ToString(),
                        Required_Cost_Change = row[17].ToString(),
                        Effective_Date = row[18].ToString(),
                        Remark = row[19].ToString()
                    };
                    list.Add(item);
                }
            }
            return list;
        }

        public static int update(As_Purchase_Changes asPurchaseChanges, List<As_Purchase_Changes_Item> list)
        {
            return PurchaseChanges_DAL.update(asPurchaseChanges, list);
        }

        public static int check(string formId)
        {
            return get(formId)==null?0:1;
        }
    }
}
