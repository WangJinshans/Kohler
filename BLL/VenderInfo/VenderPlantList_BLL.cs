using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;



namespace BLL.VenderInfo
{
    public class VenderPlantList_BLL
    {
        public int VenderPlantList_BLL_Insert(string vendercode, string plantname, string state,string vendertype)
        {
            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_Insert(vendercode, plantname, state,vendertype);

           
        }


        public List<VenderPlantList_BO> VenderPlantList_BLL_List(string vendercode,string plantname,string vendertype)
        {

            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_List(vendercode,plantname,vendertype);
        }

        public List<VenderPlantList_BO> VenderPlantList_BLL_ListAll(string vendercode)
        {

            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_ListAll(vendercode);
        }

        public int VenderPlantList_BLL_Update(string vendercode, string plantname, string state,string vendertype)
        {

            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_Update(vendercode, plantname, state,vendertype);
        }

        public int VenderPlantList_BLL_Update(string vendercode, string plantname,string vendertype)
        {
            ItemCategoryVendertype_BLL ItemCategoryVendertype_BLL = new ItemCategoryVendertype_BLL();
            List<ItemCategory_BO> ItemCategory_BO_List = new List<ItemCategory_BO>();
            ItemCategory_BO_List = ItemCategoryVendertype_BLL.ItemCategory_BLL_List(vendercode, plantname,vendertype);

            int i=0;

            if (ItemCategory_BO_List.Count > 0)
            {
                bool result = false;

                foreach (ItemCategory_BO ItemCategory in ItemCategory_BO_List)
                {
                    if (ItemCategory.Item_FinishedstateUrl == "../pic/finished.png")
                    {
                        result = true;
                    }

                    else
                    {
                        result = false;
                        i=0;
                        break;
                    }
                }

                if (result == true)
                {
                    VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();

                    i = VenderPlantList_BLL.VenderPlantList_BLL_Update(vendercode, plantname, "Enable",vendertype);

                    if (i > 0)
                    {
                        i = 1;
                    }
                }

                else
                {
                    
                    VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
                   List<VenderPlantList_BO> VenderPlantList_BO = new List<VenderPlantList_BO>();
                    VenderPlantList_BO = VenderPlantList_BLL.VenderPlantList_BLL_List(vendercode, plantname,vendertype);

                    if (VenderPlantList_BO.Count > 0)
                    {
                        if (VenderPlantList_BO[0].Vender_State == "Enable")
                        {
                            i = VenderPlantList_BLL.VenderPlantList_BLL_Update(vendercode, plantname, "Hold",vendertype);

                            if (i > 0)
                            {
                                i = 2;
                            }

                        }


                       



                    }
                }

            }

            else
            {
                i=0;
            }

            return i;
        }

        public int VenderPlantList_BLL_UpdateHold(string vendercode, string plantname,string vendertype)
        {
            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            return VenderPlantList_BLL.VenderPlantList_BLL_Update(vendercode, plantname, "Hold",vendertype);

        }


        public int VenderPlantList_BLL_UpdateDisable(string vendercode, string plantname,string vendertype)
        {
            int i = 0;

            VenderPlantList_BLL VenderPlantList_BLL = new VenderPlantList_BLL();
            i=i+ VenderPlantList_BLL.VenderPlantList_BLL_Update(vendercode, plantname, "Disable",vendertype);

            ItemList_BLL ItemList_BLL = new ItemList_BLL();
            i = i + ItemList_BLL.ItemList_BLL_UpdateDisable(vendercode, plantname,vendertype);

            return i;
        }

        public List<VenderList_BO> VenderPlantList_BLL_List_Plant(string plantname)
        {
            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_List_Plant(plantname);
        }

        public int VenderPlantList_BLL_Update_VenderName(string oldvendercode, string newvendercode, string vendername)
        {
            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_Update_VenderName(oldvendercode, newvendercode, vendername);
        }

        public int VenderPlantList_BLL_Update_VenderType(string vendercode, string plantname, string oldvendertype, string newvendertype)
        {
            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_Update_VenderType(vendercode, plantname, oldvendertype, newvendertype);
        }

        public int VenderPlantList_BLL_DEL(string vendercode, string vendertype, string plantname)
        {
            VenderPlantList_DAL VenderPlantList_DAL = new VenderPlantList_DAL();
            return VenderPlantList_DAL.VenderPlantList_DAL_DEL(vendercode, vendertype, plantname);
        }
    }
}
