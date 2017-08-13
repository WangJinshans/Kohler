using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

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
            return File_DAL.selectFileID(tempVendorID, filetypeid);
        }

        public static string selectFileid(string tempVendorID, string filetypeid)    //返回文件id
        {
            return File_DAL.selectFileid(tempVendorID,filetypeid);
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
    }
}
