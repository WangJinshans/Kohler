using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;
using MODEL.VendorAssess;

namespace DAL
{
    public class File_DAL
    {
        public static int addFile(As_File File)//添加文件
        {
            string sql = "insert into As_File(File_ID,File_Name,File_Path,File_Enable_Time,File_Due_Time,Temp_Vendor_Name,File_Type_ID,Temp_Vendor_ID,Factory_Name,Source_From) values(@File_ID,@File_Name,@File_Path,@File_Enable_Time,@File_Due_Time,@Temp_Vendor_Name,@File_Type_ID,@Temp_Vendor_ID,@Factory_Name,@Source_From)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_ID",File.File_ID),
                new SqlParameter("@File_Name",File.File_Name),
                new SqlParameter("@File_Path",File.File_Path),
                new SqlParameter("@File_Enable_Time",File.File_Enable_Time),
                new SqlParameter("@File_Due_Time",File.File_Due_Time),
                new SqlParameter("@Temp_Vendor_Name",File.Temp_Vendor_Name),
                new SqlParameter("@File_Type_ID",File.File_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",File.Temp_Vendor_ID),
                new SqlParameter("@Factory_Name",File.Factory_Name),
                new SqlParameter("@Source_From",File.Source_From)
            };
            return DBHelp.ExecuteCommand(sql, sp);
        }

        public static int addFile(As_Kci_File file)
        {
            string sql = "insert into As_KCI_File(File_ID,File_Name,File_Path,File_Enable_Time,File_Due_Time,Temp_Vendor_Name,File_Type_ID,Temp_Vendor_ID,Form_ID) values(@File_ID,@File_Name,@File_Path,@File_Enable_Time,@File_Due_Time,@Temp_Vendor_Name,@File_Type_ID,@Temp_Vendor_ID,@Form_ID)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_ID",file.File_ID),
                new SqlParameter("@File_Name",file.File_Name),
                new SqlParameter("@File_Path",file.File_Path),
                new SqlParameter("@File_Enable_Time",file.File_Enable_Time),
                new SqlParameter("@File_Due_Time",file.File_Due_Time),
                new SqlParameter("@Temp_Vendor_Name",file.Temp_Vendor_Name),
                new SqlParameter("@File_Type_ID",file.File_Type_ID),
                new SqlParameter("@Temp_Vendor_ID",file.Temp_Vendor_ID),
                new SqlParameter("@Form_ID",file.Form_ID)
            };
            return DBHelp.GetScalar(sql, sp);
        }

        internal static string getFileTypeNameByFileID(string fileID)
        {
            string sql = "select As_File_Type.File_Type_Name from As_File,As_File_Type where As_File_Type.File_Type_ID=As_File.File_Type_ID and As_File.[File_ID]='" + fileID + "'";
            DataTable table = DBHelp.GetDataSet(fileID);
            string fileTypeName = "";
            if (table.Rows.Count > 0)
            {
                foreach(DataRow dr in table.Rows)
                {
                    fileTypeName = dr["File_Type_Name"].ToString().Trim();
                }
            }
            return fileTypeName;
        }

        /// <summary>
        /// 获取指定id供应商的已上传文件id
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="filetypeid"></param>
        /// <returns></returns>
        public static string selectFileid(string tempVendorID,string filetypeid,string factory)    //返回文件id
        {
            As_File File = null;
            string sql = "select File_ID from As_File where File_Type_ID=@File_Type_ID and Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name in (@Factory_Name,'ALL')";
            string sql2 = "select File_ID from View_File where File_Type_ID=@File_Type_ID and Normal_Vendor_ID=@Normal_Vendor_ID and Factory_Name in (@Factory_Name,'ALL')";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Factory_Name",factory)
            };
            SqlParameter[] sp2 = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Normal_Vendor_ID",TempVendor_DAL.getNormalCode(tempVendorID)),
                new SqlParameter("@Factory_Name",factory)
            };

            DataTable dt = DBHelp.GetDataSet(sql, sp);
            DataTable dt2 = DBHelp.GetDataSet(sql2, sp2);
            if (dt.Rows.Count>0)
            {
                File = new As_File();
                foreach(DataRow dr in dt.Rows)
                {
                    File.File_ID = Convert.ToString(dr["File_ID"]);
                }
            }
            else if (dt2.Rows.Count>0)
            {
                File = new As_File();
                foreach (DataRow dr in dt2.Rows)
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
                    Vendor_FileType.File_Type_Range = Convert.ToString(dr["File_Type_Range"]);
                    Vendor_FileType.FileType_Name = Convert.ToString(dr["FileType_Name"]);
                    Vendor_FileType.File_Is_Necessary = Convert.ToString(dr["File_Is_Necessary"]);
                    Vendor_FileType.Flag = Convert.ToInt32(dr["flag"]);
                    Vendor_FileType.Item_Valid = Convert.ToString(dr["Item_Valid"]);
                    list.Add(Vendor_FileType);
                }
            }
            dt.Dispose();
            return list;
        }

        /// <summary>
        /// 查询是否有此文件，另外如果是复用的状态下，需要使用sql2进行查询
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="filetypeid"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static int selectFileID(string tempVendorID,string filetypeid,string factory)//根据供应商名称与文件类型查询文件的id是否存在
        {
            int result = 0;
            string sql = "select File_ID from As_File where File_Type_ID=@File_Type_ID and Temp_Vendor_ID=@Temp_Vendor_ID and Factory_Name in (@Factory_Name,'ALL')";
            string sql2 = "select File_ID from View_File where File_Type_ID=@File_Type_ID and Normal_Vendor_ID=@Normal_Vendor_ID and Factory_Name in (@Factory_Name,'ALL')";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Temp_Vendor_ID",tempVendorID),
                new SqlParameter("@Factory_Name",factory)
            };
            SqlParameter[] sp2 = new SqlParameter[]
            {
                new SqlParameter("@File_Type_ID",filetypeid),
                new SqlParameter("@Normal_Vendor_ID",TempVendor_DAL.getNormalCode(tempVendorID)),
                new SqlParameter("@Factory_Name",factory)
            };
            DataTable dt = DBHelp.GetDataSet(sql, sp);
            DataTable dt2 = DBHelp.GetDataSet(sql2, sp2);
            if (dt.Rows.Count > 0 || dt2.Rows.Count>0)
            {
                result = 1;
            }

            dt.Dispose();
            dt2.Dispose();
            return result;
        }
    }
}
