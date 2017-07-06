using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO.ItemNotifyInfo
{
    public class ItemNotify_BO
    {
        public string Plant_Name
        { get; set; }

        public string Item_Notify_Before_First_User
        { get; set; }

        public string Item_Notify_Before_Second_User
        { get; set; }

        public string Item_Notify_Before_Third_User
        { get; set; }

        public string Item_Notify_Expired_User
        { get; set; }

        public string Item_Notify_Delete_User
        { get; set; }
    }
}
