using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.VenderInfo;
using BO.VenderInfo;


namespace BLL.VenderInfo
{
    public class VenderType_BLL
    {
        public List<VenderType_BO> VenderType_ALLList_BLL()
        {
            VenderType_DAL VenderType_DAL = new VenderType_DAL();
            return VenderType_DAL.Vendertype_DAL();
                
        }

      

        public List<VenderType_BO> VenderType_List_VendercodePlantname_BLL(string vendercode, string plantname)
        {
            VenderType_DAL VenderType_DAL = new VenderType_DAL();
            return VenderType_DAL.Vendertype_DAL_VendercodePlantname(vendercode,plantname );
        }
    }
}
