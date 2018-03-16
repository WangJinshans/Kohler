using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DAL;
using BLL.VendorAssess;
using System.Web;

namespace BLL
{
    public class CheckFile_BLL
    {
        /// <summary>
        /// 未绑定状态下检查必要的文件是否已经上传（但是还没有与对应的表格建立联系）
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
                int result=File_DAL.selectFileID(tempVendorID,filetypeid, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));//查询是否有记录
                if(result==0)
                {
                    check = 0;
                    return check;   //若没有记录 返回文件不全
                }
            }
            return check;

        }

        /// <summary>
        /// 未绑定状态下查询必要的文件是否已经上传，如果没有，返回需要上传的文件类型名称
        /// </summary>
        /// <param name="formTypeID"></param>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static string checkFileWithResult(string formTypeID,string tempVendorID)
        {
            string check = "";

            IList<As_FileType_FormType> list = FileType_FormType_DAL.selectFileTypeID(formTypeID);
            IList<string> nameList = FileType_FormType_DAL.selectFileTypeName(formTypeID);


            for (int i = 0; i < list.Count; i++)
            {
                string filetypeid = list[i].File_Type_ID;
                
                //查询是否有记录
                int result = File_DAL.selectFileID(tempVendorID, filetypeid, Employee_DAL.getEmployeeFactory(HttpContext.Current.Session["Employee_ID"].ToString()));

                if (result == 0)
                {
                    check += nameList[i];
                    check += "、";
                }

            }

            try
            {
                check = check.Remove(check.Length - 1, 1);
            }
            catch (Exception)
            {
                check = "";
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
                string fileTypeID = formFileList[i].File_Type_ID;
                int result = File_BLL.selectFileID(tempVendorID, fileTypeID);//查询是否有文件上传记录
                if (result == 0)
                {
                    check = 0;
                    return check;   //若没有记录 文件未上传，无法绑定
                }
                else
                {
                    As_Form_File Form_File = new As_Form_File();
                    string fileID = File_BLL.selectFileid(tempVendorID, fileTypeID);      //查询filed Status='new'
                    Form_File.File_ID = fileID;
                    Form_File.Form_ID = formID;
                    Form_File.Temp_Vendor_ID = tempVendorID;
                    check = FormFile_BLL.addFormFile(Form_File);  //若有上传文件记录，则绑定记录    
                }
            }
            return check;
        }

        /// <summary>
        /// 从已经绑定的表格-文件中查询
        /// </summary>
        /// <param name="formID"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        internal static bool checkExistFile(string formID, string fileType)
        {
            if (Form_File_DAL.checkFormFile(formID, fileType) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 绑定单个文件和表格
        /// </summary>
        /// <param name="fileID"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public static int bindSingleFormFile(string fileID, string tempVendorID, string formID)
        {

            //进入审批 在show页面查看这份绑定的文件
            As_Form_File Form_File = new As_Form_File();
            Form_File.File_ID = fileID;
            Form_File.Form_ID = formID;
            Form_File.Temp_Vendor_ID = tempVendorID;
            int result = FormFile_BLL.addFormFile(Form_File);

            return VendorSingleFile_BLL.updateSingleFileFlag(formID, fileID);
        }

    }
}
