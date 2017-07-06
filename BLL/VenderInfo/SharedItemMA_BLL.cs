using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;
using BLL.ErrorMessage;


namespace BLL.VenderInfo
{
    public class SharedItemMA_BLL
    {
        public int VenderPlantInfo_DEL_BLL(string vendercode, string vendertype, string plantname)
        {
           int itemresult = 0;
           bool venderplantresult1 = false;
           bool venderplantresult2 = false;
           bool venderplantresult3 = false;
           bool venderplantresult4 = false;
            VenderPlantList_BLL VenderPlantListBLL = new VenderPlantList_BLL();

            List<VenderPlantList_BO> VenderPlantList_BO = new List<VenderPlantList_BO>();

            VenderList_BLL VenderList_BLL = new VenderList_BLL();

            VenderPlantList_BO = VenderPlantListBLL.VenderPlantList_BLL_ListAll(vendercode);

            ItemList_BLL ItemList_BLL = new ItemList_BLL();
         

            if (VenderPlantList_BO.Count == 1)
            {
                venderplantresult1 = true;
                List<ItemList_BO> ItemList_BO = new List<ItemList_BO>();
                ItemList_BO = ItemList_BLL.ItemList_BLL_List (vendercode);

                if (ItemList_BO.Count > 0)
                {
                    itemresult = 1;
                 
                   //需要删除所有文档
                }

                else
                {
                    VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                    
                  
                }

               
            }

            else
            {
                foreach (VenderPlantList_BO VenderPlant in VenderPlantList_BO)

                {
                    if (VenderPlant .Plant_Name ==plantname && VenderPlant .Vender_Type ==vendertype)
                    {
                        venderplantresult1 =true;
                    }


                    if (VenderPlant.Plant_Name == plantname && VenderPlant.Vender_Type != vendertype)
                    {
                        venderplantresult2 = true;
                    }

                    if (VenderPlant.Plant_Name != plantname && VenderPlant.Vender_Type == vendertype)
                    {
                        venderplantresult3 = true;
                    }

                    if (VenderPlant.Plant_Name != plantname && VenderPlant.Vender_Type != vendertype)
                    {
                        venderplantresult4 = true;
                    }
                }

                //1,2
                if (venderplantresult1 == true && venderplantresult2 == true && venderplantresult3 == false && venderplantresult4 == false)
                {
                    List<ItemList_BO> ItemList_BO_Plantname = new List<ItemList_BO>();
                    List<ItemList_BO> ItemList_BO_Plantnameall = new List<ItemList_BO>();
                    ItemList_BO_Plantname = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);
                    ItemList_BO_Plantnameall = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, "ALL", vendertype);

                    if (ItemList_BO_Plantname.Count > 0 || ItemList_BO_Plantnameall.Count > 0)
                    {
                        itemresult = 2;
                        //需要删除所有vendertype文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                       
                    }


                }
                //1,2,3,4
                if (venderplantresult1 == true && venderplantresult2 == true && venderplantresult3 == true && venderplantresult4 ==true )
                {
                    List<ItemList_BO> ItemList_BO_Plantname = new List<ItemList_BO>();
                    ItemList_BO_Plantname = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);

                    if (ItemList_BO_Plantname.Count > 0)
                    {
                        itemresult = 3;
                        //需要删除所有plantname,vendertype文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                    }

                }
                //1,2,3
                if (venderplantresult1 == true && venderplantresult2 == true && venderplantresult3 == true && venderplantresult4 == false)
                {
                    List<ItemList_BO> ItemList_BO_Plantname = new List<ItemList_BO>();
                    ItemList_BO_Plantname = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);

                    if (ItemList_BO_Plantname.Count > 0)
                    {
                        itemresult = 3;
                        //需要删除所有plantname,vendertype文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                    }

                }

               
                //1,3
                if (venderplantresult1 == true && venderplantresult2 == false && venderplantresult3 == true && venderplantresult4 == false )
                {
                    List<ItemList_BO> ItemList_BO_Vendertype = new List<ItemList_BO>();
                    List<ItemList_BO> ItemList_BO_Vendertypeall = new List<ItemList_BO>();
                    ItemList_BO_Vendertype = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);
                    ItemList_BO_Vendertypeall = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, "ALL");

                    if (ItemList_BO_Vendertype.Count > 0 || ItemList_BO_Vendertypeall.Count > 0)
                    {
                        itemresult = 4;
                        //需要删除所有plantname文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                     
                    }
                }
                //1,3,4
                if (venderplantresult1 == true && venderplantresult2 == false && venderplantresult3 == true && venderplantresult4 == true)
                {
                    List<ItemList_BO> ItemList_BO_Vendertype = new List<ItemList_BO>();
                    List<ItemList_BO> ItemList_BO_Vendertypeall = new List<ItemList_BO>();
                    ItemList_BO_Vendertype = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);
                    ItemList_BO_Vendertypeall = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, "ALL");

                    if (ItemList_BO_Vendertype.Count > 0 || ItemList_BO_Vendertypeall.Count > 0)
                    {
                        itemresult = 4;
                        //需要删除所有plantname文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);

                    }
                }

                //1,4
                if (venderplantresult1 == true && venderplantresult2 == false && venderplantresult3 == false && venderplantresult4 == true)
                {
                    List<ItemList_BO> ItemList_BO_Vendertype = new List<ItemList_BO>();
                    List<ItemList_BO> ItemList_BO_Vendertypeall = new List<ItemList_BO>();
                    ItemList_BO_Vendertype = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);
                    ItemList_BO_Vendertypeall = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, "ALL", vendertype);

                    if (ItemList_BO_Vendertype.Count > 0 || ItemList_BO_Vendertypeall.Count > 0)
                    {
                        itemresult = 5;
                        //需要删除所有vendertype文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);
                      

                    }
                }



               


                //1,2,4
                if (venderplantresult1 == true && venderplantresult2 == true && venderplantresult3 == false && venderplantresult4 == true)
                {
                    List<ItemList_BO> ItemList_BO_Vendertype = new List<ItemList_BO>();
                    List<ItemList_BO> ItemList_BO_Vendertypeall = new List<ItemList_BO>();
                    ItemList_BO_Vendertype = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, plantname, vendertype);
                    ItemList_BO_Vendertypeall = ItemList_BLL.ItemList_BLL_List_Plantname(vendercode, "ALL", vendertype);

                    if (ItemList_BO_Vendertype.Count > 0 || ItemList_BO_Vendertypeall.Count > 0)
                    {
                        itemresult = 6;
                        //需要删除所有vendertype文档
                    }

                    else
                    {
                        VenderPlantListBLL.VenderPlantList_BLL_DEL(vendercode, vendertype, plantname);


                    }
                }

            }

          

          

            

            return itemresult;
        }


       
    }
}
