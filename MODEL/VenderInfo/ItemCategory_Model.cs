using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL.ItemCategory
{
    class ItemCategory
    {
        public string Item_Name { get; set; }
        public bool Item_Option { get; set; }
        public bool Item_Upload { get; set; }
        public bool Item_Valid { get; set; }
        public bool Item_Label { get; set; }
        public bool Item_Notify { get; set; }
        public int Item_Notify_Month { get; set; }
    }
}
