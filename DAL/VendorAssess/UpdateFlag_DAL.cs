using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UpdateFlag_DAL
    {
        public static int updateFlag(string formTypeId,string tempVendorName)
        {
            string sql= "UPDATE As_Vendor_FormType SET flag=1 WHERE Form_Type_ID='"+ formTypeId+ "'AND Temp_Vendor_Name='"+ tempVendorName + "'";
            return DBHelp.ExecuteCommand(sql);
        }

        public static int updateFileFlag(string fileTypeId, string tempVendorid)
        {
            string sql = "UPDATE As_Vendor_FileType SET flag=1 WHERE FileType_ID='" + fileTypeId + "'AND Temp_Vendor_ID='" + tempVendorid + "'";
            return DBHelp.ExecuteCommand(sql);
        }
    }
}
