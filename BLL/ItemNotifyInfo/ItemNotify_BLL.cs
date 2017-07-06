using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.ItemNotifyInfo;
using BO.ItemNotifyInfo;


namespace BLL.ItemNotifyInfo
{
    public class ItemNotify_BLL
    {
        public List<ItemNotify_BO> ItemNotify_BLL_DeleteUser_Plant(string plantname)
        {
            ItemNotify_DAL ItemNotify_DAL = new ItemNotify_DAL();
            return ItemNotify_DAL.ItemNotify_DAL_DeleteUser_Plant(plantname);
        }
    }
}
