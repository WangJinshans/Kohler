using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UpdateFlag_BLL
    {
        public static int updateFlag(string formTypeID, string tempVendorID)//更新供应商信息
        {
            return UpdateFlag_DAL.updateFlag(formTypeID, tempVendorID);
        }

        public static int updateNonStandardConstractFlag(string formID)//更新供应商信息
        {
            return UpdateFlag_DAL.updateNonStandardConstractFlag(formID);
        }


        public static int updateFileFlag(string fileTypeID, string tempVendorid)
        {
            return UpdateFlag_DAL.updateFileFlag(fileTypeID, tempVendorid);
        }

        public static int updateFlagAsHold(string fORM_TYPE_ID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateFlagAsHold(fORM_TYPE_ID, tempVendorID);
        }

        public static int updateFlagAsFinish(string FORM_TYPE_ID,string tempVendorID)
        {
            return UpdateFlag_DAL.updateFlagAsFinish(FORM_TYPE_ID, tempVendorID);
        }

        public static int updateEditFlowFlag(string formID, string tempVendorID)
        {
            return UpdateFlag_DAL.updateEditFlowFlag(formID, tempVendorID);
        }
    }
}
