using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Web;

namespace BLL
{
    public class File_BLL
    {
        public static int addFile(As_File file)
        {
            return File_DAL.addFile(file);
        }
        public static IList<As_File> selectFile(string sql)
        {
            return File_DAL.selectFile(sql);
        }

        public static int selectFileID(string tempVendorID, string filetypeid)//根据供应商名称与文件类型查询文件的id是否存在
        {
            return File_DAL.selectFileID(tempVendorID, filetypeid, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }

        public static string selectFileid(string tempVendorID, string filetypeid)    //返回文件id
        {
            return File_DAL.selectFileid(tempVendorID,filetypeid,Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));
        }
        
        public static int getLastedFile(string tempVendorID, string filetypeid,string factory_Name)    //返回文件id
        {
            List<int> list = new List<int>();
            int max = -1;
            list = File_DAL.getLastedFile(tempVendorID, filetypeid, factory_Name);
            if (list.Count > 0)
            {
                foreach (int number in list)
                {
                    if (max < number)
                    {
                        max = number;//得到最大值 即为最新的文件
                    }
                }
            }
            return max;
        }

        public static string getSimpleFactory(string factoryName)
        {
            switch (factoryName)
            {
                case "上海科勒":
                    return "SH";
                case "中山科勒":
                    return "ZS";
                case "珠海科勒":
                    return "ZH";
                case "ALL":
                    return "ALL";
                default:
                    break;
            }
            return "";
        }

        public static int updateFileID(string tempVendorID, string fileTypeID, string factoryName, string file_ID)
        {
            return VendorFile_DAL.updateFileID(tempVendorID, fileTypeID, factoryName, file_ID);
        }

        public static string getFileName(string fileTypeID, string temp_Vendor_ID, string factory_Name)
        {
            return VendorFile_DAL.getFileName(fileTypeID, temp_Vendor_ID, factory_Name);
        }
    }
}
