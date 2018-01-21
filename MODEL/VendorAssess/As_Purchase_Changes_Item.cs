using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.VendorAssess
{
    public class As_Purchase_Changes_Item
    {

        public int ID { get; set; }
        public string Form_ID { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Last_PO_Price { get; set; }
        public string Last_6_Months_Average_Price { get; set; }
        public string Required_Price { get; set; }
        public string STD_cost { get; set; }
        public string Request_Price_VS_Last_PO_Price { get; set; }
        public string STD_Cost_VS_Request_Price { get; set; }
        public string Yearly_Forecast { get; set; }
        public string Yearly_Amount { get; set; }
        public string PPV { get; set; }
        public string Current_Stock { get; set; }
        public string Main_Material_Cost_Change { get; set; }
        public string Main_Material_Cost_VS_Total_Cost { get; set; }
        public string Required_Cost_Change { get; set; }
        public string Effective_Date { get; set; }
        public string Remark { get; set; }

    }
}
