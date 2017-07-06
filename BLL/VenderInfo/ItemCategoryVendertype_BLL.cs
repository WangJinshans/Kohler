using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;


namespace BLL.VenderInfo
{
   public class ItemCategoryVendertype_BLL
    {
        public List<ItemCategory_BO> ItemCategory_BLL_List(string vendercode,string plantname,string vendertype)
        {
            ItemCategoryVendertype_DAL ItemCategory_DAL = new ItemCategoryVendertype_DAL();
            return ItemCategory_DAL.ItemCategory_DAL_List(vendercode,plantname,vendertype);


        }

        public List<ItemCategory_BO> ItemCategory_BLL_ListAll(string vendertype)
        {
            ItemCategoryVendertype_DAL ItemCategory_DAL = new ItemCategoryVendertype_DAL();
            return ItemCategory_DAL.ItemCategory_DAL_ListAll(vendertype);
        }
    }
}
