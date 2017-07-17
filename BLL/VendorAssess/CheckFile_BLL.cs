using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using BLL.VendorAssess;

namespace BLL
{
    public class CheckFile_BLL
    {
        /// <summary>
        /// 检查必要的文件是否已经上传（但是还没有与对应的表格建立联系）
        /// </summary>
        /// <param name="formtypeid"></param>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static int checkFile(string formtypeid,string tempVendorID)
        {
            int check = 1;
            for (int i=0;i<FileType_FormType_DAL.selectFileTypeID(formtypeid).Count;i++)
            {
                string filetypeid = FileType_FormType_DAL.selectFileTypeID(formtypeid)[i].File_Type_ID;
                int result=File_DAL.selectFileID(tempVendorID,filetypeid);//查询是否有记录
                if(result==0)
                {
                    check = 0;
                    return check;   //若没有记录 返回文件不全
                }
            }
            return check;

        }

        /// <summary>
        /// 将文件记录加入到From_File
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static int bindFormFile(string formTypeID,string tempVendorID,string formID)
        {
            int check = 1;
            IList<As_FileType_FormType> formFileList = FileType_FormType_BLL.selectFileTypeID(formTypeID);
            for (int i = 0; i < formFileList.Count; i++)
            {
                string filetypeid = formFileList[i].File_Type_ID;
                int result = File_BLL.selectFileID(tempVendorID, filetypeid);//查询是否有文件上传记录
                if (result == 0)
                {
                    check = 0;
                    return check;   //若没有记录 文件未上传，无法绑定
                }
                else
                {
                    As_Form_File Form_File = new As_Form_File();
                    string fileid = File_BLL.selectFileid(tempVendorID, filetypeid);      //查询filed
                    Form_File.File_ID = fileid;
                    Form_File.Form_ID = formID;
                    Form_File.Temp_Vendor_ID = tempVendorID;
                    check = FormFile_BLL.addFormFile(Form_File);  //若有上传文件记录，则绑定记录    
                }
            }
            return check;
        }
    }
}
