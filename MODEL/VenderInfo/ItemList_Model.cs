using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.ItemList
{
    public class ItemList
    {
        public string Vender_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Path { get; set; }
        public bool Item_SK { get; set; }
        public bool Item_ZS { get; set; }
        public bool Item_ZH { get; set; }
        public bool Item_State { get; set; }
        public string Item_Comment { get; set; }
        public string Item_Label { get; set; }
        public DateTime Item_Startdate { get; set; }
        public DateTime Item_Enddate { get; set; }
        public DateTime Item_Notifydate { get; set; }
    }
}
