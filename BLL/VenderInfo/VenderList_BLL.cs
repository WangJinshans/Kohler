using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;


namespace BLL.VenderInfo
{
    public class VenderList_BLL
    {
        public List<VenderList_BO> VenderList_BLL_List(string vendercode)
        {
            VenderList_DAL  VenderList_DAL=new VenderList_DAL() ;

            return VenderList_DAL.VenderList_DAL_List(vendercode);

        }


      

        public int VenderList_BLL_Insert(string vendercode, string vendername)
        {
            VenderList_DAL VenderList_DAL = new VenderList_DAL();
            return VenderList_DAL.VenderList_DAL_Insert(vendercode, vendername);
        }

        public List<VenderList_BO> VenderList_BLL_ListAll()
        {
            VenderList_DAL VenderList_DAL = new VenderList_DAL();
            return VenderList_DAL.VenderList_DAL_ListAll();
        }

        public List<string> listAllVendor(string factory)
        {
            VenderList_DAL VenderList_DAL = new VenderList_DAL();
            return VenderList_DAL.listAllVendor(factory);
        }

        public Boolean  VenderList_BLL_Check(string vendercode, string vendertype,string plantname)
        {
            Boolean result = false;
            VenderType_BLL VenderType_BLL = new VenderType_BLL();
            List<VenderType_BO >VenderType_BO =new List<VenderType_BO >();
            VenderType_BO = VenderType_BLL.VenderType_List_VendercodePlantname_BLL (vendercode,plantname);

            if (VenderType_BO.Count == 0)
            {
                result = true;
            }
            else if (VenderType_BO.Count == 1)
            {
                if ((VenderType_BO[0].Vender_Type == "非生产性常规" || VenderType_BO[0].Vender_Type == "非生产性特种劳防品" || VenderType_BO[0].Vender_Type == "非生产性危化品" || VenderType_BO[0].Vender_Type == "非生产性质量部有标准的物料") && (vendertype == "直接物料常规" || vendertype == "直接物料危化品"))
                { result = true; }

                if ((VenderType_BO[0].Vender_Type == "直接物料常规" || VenderType_BO[0].Vender_Type == "直接物料危化品") && (vendertype == "非生产性常规" || vendertype == "非生产性特种劳防品" || vendertype == "非生产性危化品"))
                { result = true; }

                if (VenderType_BO[0].Vender_Type == "非生产性危化品" && vendertype == "非生产性质量部有标准的物料")
                { result = true; }

                if (vendertype == "非生产性危化品" && VenderType_BO[0].Vender_Type == "非生产性质量部有标准的物料")
                { result = true; }

                if (vendertype == VenderType_BO[0].Vender_Type)
                { result = true; }

            }
            else
            { result = false; }


            return result;
        }

   

        public int VenderList_BLL_Update_CodeName(string oldvendercode, string newvendercode, string vendername)
        {

            VenderList_DAL VenderList_DAL = new VenderList_DAL();
            return VenderList_DAL.VenderList_DAL_Update_CodeName(oldvendercode, newvendercode, vendername);
        }

        public int VenderList_BLL_Del(string vendercode)
        {
            VenderList_DAL VenderList_DAL = new VenderList_DAL();
            return VenderList_DAL.VenderList_DAL_Del(vendercode);
        }
    }


}
