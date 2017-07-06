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
        public static int updateFlag(string formTypeID, string tempVendorName)//更新供应商信息
        {
            return UpdateFlag_DAL.updateFlag(formTypeID, tempVendorName);
        }

        public static int updateFileFlag(string fileTypeID, string tempVendorid)
        {
            return UpdateFlag_DAL.updateFileFlag(fileTypeID, tempVendorid);
        }
    }
}
