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

        public static int selectFileID(string tempvendorname, string filetypeid)//根据供应商名称与文件类型查询文件的id是否存在
        {
            return File_DAL.selectFileID(tempvendorname, filetypeid);
        }

        public static string selectFileid(string tempvendorname, string filetypeid)    //返回文件id
        {
            return File_DAL.selectFileid(tempvendorname,filetypeid);
        }
    }
}
