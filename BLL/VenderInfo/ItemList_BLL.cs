using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;


namespace BLL.VenderInfo
{
    public class ItemList_BLL
    {
        public int ItemList_BLL_Insert(string vendercode, string itemcategory, string itempath, string itemplant, string itemvendertype,string itemstate, string itemlabel, DateTime  itemstartdate, DateTime  itemenddate, DateTime  uploaddate, string uploadperson, string itemcomment)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_Insert(vendercode, itemcategory, itempath, itemplant,itemvendertype, itemstate, itemlabel, itemstartdate, itemenddate, uploaddate, uploadperson, itemcomment);


        }

        public List<ItemList_BO> ItemList_BLL_List(string vendercode)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_List(vendercode);
        }


        public int ItemList_BLL_Delete(string vendercode, string itemlabel)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_Delete(vendercode, itemlabel);
        }

        public int ItemList_BLL_UpdateDisable(string vendercode, string plantname,string vendertype)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_UpdateDisable(vendercode, plantname,vendertype);
        }

        public int ItemList_BLL_UpdateValidity(string itemlabel, string itemstate, DateTime itemstartdate, DateTime itemenddate)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_UpdateValidity(itemlabel, itemstate, itemstartdate, itemenddate);
        }

        public List<ItemList_BO> ItemList_BLL_List_Plant(string vendercode, string plantname,string vendertype)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_List_Plant(vendercode, plantname,vendertype);
        }

       // public int ItemList_BLL_UpdateVendertype(string vendercode, string oldvendertype, string newvendertype, string plantname)
        //{
           // ItemList_DAL ItemList_DAL = new ItemList_DAL();
            //return ItemList_DAL.ItemList_DAL_UpdateVendertype(vendercode, oldvendertype, newvendertype, plantname);
       // }

        public int ItemList_BLL_UpdateVendercode(string oldvendercode, string newvendercode)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_UpdateVendercode(oldvendercode, newvendercode);
        }


        public List<ItemList_BO> ItemList_BLL_List_Plantname(string vendercode, string plantname, string vendertype)
        {
            ItemList_DAL ItemList_DAL = new ItemList_DAL();
            return ItemList_DAL.ItemList_DAL_List_Plantname(vendercode, plantname, vendertype);
        }

    }
}
