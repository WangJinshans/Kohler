using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PlantInfo;
using BO.PlantInfo;


namespace BLL.PlantInfo
{
    public class PlantInfo_BLL
    {
        public List<PlantInfo_BO> PlantInfo_BLL_List_Plant(string plantname)
        {
            PlantInfo_DAL PlantInfo_DAL = new PlantInfo_DAL();
            return PlantInfo_DAL.PlantInfo_DAL_List_Plant(plantname);
        }
    }
}
