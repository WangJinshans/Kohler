using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace DAL
{
    public class VendorFile_DAL
    {
        public static int addVendorFileType(As_Vendor_FileType Vendor_FileType)
        {
            string sql = "INSERT INTO As_Vendor_FileType(Temp_Vendor_ID,FileType_ID,FileType_Name)VALUES(@Temp_Vendor_ID,@FileType_ID,@FileType_Name)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Temp_Vendor_ID",Vendor_FileType.Temp_Vendor_ID),
                new SqlParameter("@FileType_ID",Vendor_FileType.FileType_ID),
                new SqlParameter("@FileType_Name",Vendor_FileType.FileType_Name),

            };
            return DBHelp.GetScalar(sql, sp);
        }
    }
}
