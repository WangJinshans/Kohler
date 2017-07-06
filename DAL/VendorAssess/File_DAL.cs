using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class File_DAL
    {
        public static int addFile(As_File File)//添加文件
        {
            string sql = "insert into As_File(File_ID,File_Name,File_Path,File_Enable_Time,File_Due_Time,Temp_Vendor_Name,File_Type_ID) values(@File_ID,@File_Name,@File_Path,@File_Enable_Time,@File_Due_Time,@Temp_Vendor_Name,@File_Type_ID)";
            sql += " ;SELECT @@IDENTITY";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_ID",File.File_ID),
                new SqlParameter("@File_Name",File.File_Name),
                new SqlParameter("@File_Path",File.File_Path),
                new SqlParameter("@File_Enable_Time",File.File_Enable_Time),
                new SqlParameter("@File_Due_Time",File.File_Due_Time),
                new SqlParameter("@Temp_Vendor_Name",File.Temp_Vendor_Name),
                new SqlParameter("@File_Type_ID",File.File_Type_ID)
            };
            return DBHelp.GetScalar(sql, sp);
        }
        public static string selectFileid(string tempvendorname,string filetypeid)    //返回文件id
        {
            As_File File = null;
            string sql = "select File_ID from As_File where File_Type_ID=@File_Type_ID and Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Temp_Vendor_Name",tempvendorname)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if(dt.Rows.Count>0)
            {
                File = new As_File();
                foreach(DataRow dr in dt.Rows)
                {
                    File.File_ID = Convert.ToString(dr["File_ID"]);
                }
            }
            return File.File_ID;
        }

        public static IList<As_Vendor_FileType> listVendorFileType(string sql)
        {
            IList<As_Vendor_FileType> list = new List<As_Vendor_FileType>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_Vendor_FileType Vendor_FileType = new As_Vendor_FileType();
                    Vendor_FileType.Temp_Vendor_ID = Convert.ToString(dr["Temp_Vendor_ID"]);
                    Vendor_FileType.FileType_ID = Convert.ToString(dr["FileType_ID"]);
                    Vendor_FileType.FileType_Name = Convert.ToString(dr["FileType_Name"]);
                    list.Add(Vendor_FileType);
                }
            }
            return list;
        }

        public static IList<As_File> selectFile(string sql)
        {
            IList<As_File> list = new List<As_File>();
            DataTable dt = DBHelp.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    As_File file = new As_File();
                    file.File_Name = Convert.ToString(dr["File_Name"]);
                    file.Temp_Vendor_Name = Convert.ToString(dr["Temp_Vendor_Name"]);
                    list.Add(file);
                }
            }
            return list;
        }

        public static int selectFileID(string tempvendorname,string filetypeid)//根据供应商名称与文件类型查询文件的id是否存在
        {
            string sql = "select File_ID from As_File where File_Type_ID=@File_Type_ID and Temp_Vendor_Name=@Temp_Vendor_Name";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Temp_Vendor_Name",tempvendorname)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int UpdateFlag(string File_ID, string Temp_Vendor_Name)
        {
            string sql = "";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter()
            };

            return DBHelp.GetScalar(sql, sp);
        }
    }
}
