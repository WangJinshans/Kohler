using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    public class File_Transform_BLL
    {
        public static bool vendorTransForm(string tempVendorID, string factory)
        {
            /*
             * 供应商已经审批完成的表的转移
             * 
             * 1.检查所有需要提交的文件是否已经提交
             * 2.检查所有需要填写的表格是否已经提交并且完成了审批
             *      1.审批完成之后 生成正式的供应商code 添加到tempvendorType的normal code
             * 3.文件转移 表 文件    normal
             * 
             */
            //tempVendorID = "TempVendor1047";
            //copyFile(getFilesWithPath(tempVendorID, factory));
            //copyFile(getFormsWithPath(tempVendorID, factory));
            //bool s = checkFileSubmit(tempVendorID, factory);
            //bool ss = checkFormSubmit(tempVendorID, factory);
            //string results = checkKciFileSubmit(tempVendorID, factory);
            if (checkFileSubmit(tempVendorID, factory) && checkFormSubmit(tempVendorID, factory))//检查文件和表提交
            {
                string result = checkKciFileSubmit(tempVendorID, factory);
                if (result == "true") //KCI文件提交 只有满足是KCI没有提交文件才会返回false
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        //insertNormalCode(tempVendorID);
                        copyFile(getFilesWithPath(tempVendorID, factory));
                        copyFile(getFormsWithPath(tempVendorID, factory));
                        copyFile(getKciFilesWithPath(tempVendorID, factory));
                    }
                }
                else if (result == "none")//不需要进行KCI文件的转移
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        insertNormalCode(tempVendorID);
                        copyFile(getFilesWithPath(tempVendorID, factory));
                        copyFile(getFormsWithPath(tempVendorID, factory));
                    }
                }
                else if(result == "false")
                {
                    //没有提交KCI的审批结果
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 过期表重新审批后的文件转移
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>

        public static bool vendorOverDueFormTransForm(string tempVendorID, string factory)
        {
            /*获取所有的新的formID对应的path
             * 判断是否有需要KCI审批的 有 需要转移新的KCI审批文件
             * 
             */
            if (checkFormSubmit(tempVendorID, factory) == false)//是否所有表格都已经提交
            {
                return false;
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "none")//不需要KCI
            {
                if (copyFile(getOverDueFormWithPath(tempVendorID, factory)))//转移文件成功
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "true")//需要转移KCI的审批文件
            {
                if (copyFile(getOverDueFormWithPath(tempVendorID, factory))&& copyFile(getOverDueKciFormWithPath(tempVendorID, factory)))//转移文件成功
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "false")//没有提交KCI的审批文件
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 过期文件重新审批后的转移 转移新上传的文件 和新审批完成的表
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static bool vendorOverDueFileTransForm(string tempVendorID, string factory)
        {
            //获取所有的过期的文件 查出最新的File_ID
            IList<As_Form_OverDue> OverDueFileForms = new List<As_Form_OverDue>();
            OverDueFileForms = FileOverDue_BLL.getOverDueForm(tempVendorID, factory);//获取所有与File过期的Form_ID

            if (checkFileSubmit(tempVendorID, factory) && checkFormSubmit(tempVendorID, factory))//检查文件和表提交
            {
                string result = checkFileOverDueKciFileSubmit(tempVendorID, factory);//过期文件的审批过程中是否包含KCI审批

                string normalCode = "";
                if (result == "true") //过期重审的文件和表 和KCI文件
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        insertNormalCode(normalCode);
                        //新的File_ID的文件
                        copyFile(getOverDueFileWithPath(tempVendorID, factory));
                        //新的Form_ID的文件
                        copyFile(getOverDueFileFormWithPath(tempVendorID, factory));
                        //重审后KCI文件转移
                        copyFile(getOverDueKciFileWithPath(tempVendorID, factory));
                    }
                }
                else if (result == "none")//不需要进行KCI文件的转移  过期重审的文件和表
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        insertNormalCode(normalCode);
                        copyFile(getOverDueFileWithPath(tempVendorID, factory));
                        //新的Form_ID的文件
                        copyFile(getOverDueFileFormWithPath(tempVendorID, factory));
                    }
                }
                else if (result == "false")
                {
                    //没有提交KCI的审批结果
                    return false;
                }
            }
            return false;
        }

        private static Dictionary<string, string> getOverDueKciFileWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> OverDueFileWithPath = new Dictionary<string, string>();
            List<string> fileTypeIDs = new List<string>();
            //从As_VendorFile_OverDue中获取所有过期文件的fileTypeID
            fileTypeIDs = File_Transform_DAL.getFileTypeIDs(tempVendorID, factory);
            if (fileTypeIDs.Count > 0)
            {
                foreach (string fileTypeID in fileTypeIDs)
                {
                    //获取新的file_ID 
                    string fileID = File_Transform_DAL.getFileIDByType(tempVendorID, fileTypeID, factory);
                    if (fileID != "")
                    {
                        //获取新的form_ID
                        string filePath = "";
                        string formID = File_Transform_DAL.getFormIDByFileID(fileID);
                        DataTable table = File_Transform_DAL.getKciFilePath(formID);//从As_KCI_File中获取KCI文件的审批结果
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow dr in table.Rows)
                            {
                                filePath = dr["File_Path"].ToString().Trim();
                            }
                            OverDueFileWithPath.Add(fileID, filePath);
                        }
                    }
                }
            }
            return OverDueFileWithPath;
        }

        /// <summary>
        /// 获取过期的文件
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static Dictionary<string, string> getOverDueFilesWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> OverDueFileWithPath = new Dictionary<string, string>();
            List<string> fileTypeIDs = new List<string>();
            //从As_VendorFile_OverDue中获取所有过期文件的fileTypeID
            fileTypeIDs = File_Transform_DAL.getFileTypeIDs(tempVendorID, factory);
            if (fileTypeIDs.Count > 0)
            {
                foreach (string fileTypeID in fileTypeIDs)
                {
                    //获取新的file_ID 
                    string fileID = File_Transform_DAL.getFileIDByType(tempVendorID, fileTypeID, factory);
                    string filepath = "";
                    if (fileID != "")
                    {
                        //获取新的form_ID
                        DataTable table = File_Transform_DAL.getFilePath(fileID);
                        if (table.Rows.Count > 0)
                        {
                            foreach (DataRow dr in table.Rows)
                            {
                                filepath = dr["File_Path"].ToString().Trim();
                            }
                        }
                        OverDueFileWithPath.Add(fileID, filepath);
                    }
                }
            }
            return OverDueFileWithPath;
        }


        /// <summary>
        /// 过期的文件审批需要KCI的文件结果转移
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static Dictionary<string, string> getOverDueKciFormWithPath(string tempVendorID, string factory)
        {
            DataTable table = new DataTable();
            Dictionary<string, string> OverDueFormWithPath = new Dictionary<string, string>();
            List<string> forms = new List<string>();
            List<string> oldForms = File_Transform_DAL.getOverDueOldFormID(tempVendorID, factory);//返回原来需要KCI的Form_ID
            if (oldForms.Count > 0)
            {
                foreach (string formID in oldForms)
                {
                    string formTypeID = File_Transform_DAL.getFormTypeID(formID);//获取form的Type_ID
                    string newFormID = File_Transform_DAL.getOverDueNewFormID(tempVendorID, formTypeID, factory);//新的FormID
                    forms.Add(newFormID);//添加新的formID
                }
            }
            string path = "";
            if (forms != null && forms.Count > 0)
            {
                foreach (string newformID in forms)
                {
                    table = File_Transform_DAL.getFormPath(newformID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            path = dr["Form_Path"].ToString().Trim();
                        }
                    }
                    if (path != "")
                    {
                        OverDueFormWithPath.Add(newformID, path);
                    }
                }
            }
            return OverDueFormWithPath;
        }



      


        /// <summary>
        /// 获取KCI文件的路径
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>

        private static Dictionary<string, string> getKciFilesWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> kciFileWithPath = new Dictionary<string, string>();
            DataTable table = new DataTable();
            List<string> kciForms = File_Transform_DAL.getKciForms(tempVendorID, factory);//返回需要KCI的Form_ID
            if (kciFileWithPath.Count > 0)
            {
                foreach (string formID in kciForms)
                {
                    table = File_Transform_DAL.getKciFilePath(formID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            string filePath = dr["File_Path"].ToString().Trim();
                            kciFileWithPath.Add(formID, filePath);
                            //return kciFileWithPath;
                        }
                    }
                }
            }
            return kciFileWithPath;
        }



        /// <summary>
        /// 从As_Vendor_FileType中查出所有需要提交的文件的File_ID 
        /// 然后根据File_ID在As_File中查出是否有提交记录
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>

        private static bool checkFileSubmit(string tempVendorID, string factory)
        {
            /*
             * 1.从As_Vendor_FileType中获取需要提交的文件list
             * 2.单个文件在As_File中进行检查
             */
            
            List<string> files = new List<string>();
            files = File_Transform_DAL.getFileIDs(tempVendorID, factory);
            if (files != null && files.Count > 0)
            {
                foreach (string fileid in files)//单个文件的ID在As_File中查找
                {
                    if (File_Transform_DAL.checkFileSubmit(tempVendorID, factory, fileid) == false)
                    {
                        return false;//没有查到对应的ID的提交记录
                    }
                }
            }
            else
            {
                return false;//没有查到文件ID  不可能
            }
            return true;
        }


        /// <summary>
        /// 获取所有的Form_ID 根据Form_ID在As_FormAccessFlow中查找是否需要KCI审批
        /// 需要KCI审批的检查KCI的审批结果文件是否上传
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static string checkKciFileSubmit(string tempVendorID, string factory)
        {
            List<string> forms = new List<string>();
            forms = File_Transform_DAL.getFormIDs(tempVendorID, factory);
            if (forms != null && forms.Count > 0)
            {
                bool kciNeed = false;//该供应商是否存在文件需要KCI
                foreach (string formid in forms)//在As_Form_AccessFlow中查找Form_ID的kci值 
                {
                    bool isKci = false;
                    isKci = File_Transform_DAL.isFormKCI(formid);
                    if (isKci)//需要KCI审批
                    {
                        /*
                         * 检查KCI文件是否上传
                         * 
                         */
                        kciNeed = true;
                        if (File_Transform_DAL.isKciFileSubmit(formid)==false)
                        {
                            return "false";//没有上传KCI的处理结果
                        }
                    }
                }
                if (!kciNeed)//不存在任何KCI
                {
                    return "none";
                }
                return "true";
            }
            else
            {
                return "false";//没有查到文件ID  不可能
            }
        }

        private static bool checkFormSubmit(string tempVendorID, string factory)
        {
            /*
             * 1.从As_Vendor_FormType中获取需要提交的文件list
             * 2.单个文件在As_Form中进行检查
             */
            
            List<string> forms = new List<string>();
            forms = File_Transform_DAL.getFormIDs(tempVendorID, factory);
            if (forms != null && forms.Count > 0)
            {
                foreach (string formid in forms)//单个文件的ID在As_Form中查找
                {
                    if (File_Transform_DAL.checkFormSubmit(tempVendorID, factory, formid) == false)
                    {
                        return false;//没有查到对应的ID的提交记录
                    }
                }
            }
            else
            {
                return false;//没有查到文件ID  不可能
            }
            return true;
        }
        private static bool FormAccessSuccessFul(string tempVendorID, string factory)
        {
            return File_Transform_DAL.AccessSuccessFul(tempVendorID, factory);
        }

        private static bool insertNormalCode(string tempVendorID)
        {
            /*
             * 1.形成真正的供应商Code
             * 2.将其插入到As_Temp_Vendor中
             */
            string normalCode = "";
            return File_Transform_DAL.insertNormalCode(normalCode, tempVendorID);
        }

        /// <summary>
        /// 正常审批完成：获取该供应商该厂的所有文件  不包括表
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static Dictionary<string,string> getFilesWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> fileWithPath = new Dictionary<string, string>();
            DataTable table = new DataTable();
            List<string> fileIDlist = File_Transform_DAL.getFiles(tempVendorID, factory);
            if (fileIDlist.Count > 0)
            {
                foreach (string fileID in fileIDlist)
                {
                    table = File_Transform_DAL.getFilePath(fileID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            string filePath = dr["File_Path"].ToString().Trim();
                            fileWithPath.Add(fileID, filePath);
                            //return fileWithPath;
                        }
                    }
                }
            }
            return fileWithPath;
        }
        /// <summary>
        /// 正常审批完成：获取该供应商该厂的所有的表
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>

        private static Dictionary<string, string> getFormsWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> formWithPath = new Dictionary<string, string>();
            DataTable table = new DataTable();
            List<string> formIDlist = File_Transform_DAL.getForms(tempVendorID, factory);
            if (formIDlist.Count > 0)
            {
                foreach (string formID in formIDlist)
                {
                    table = File_Transform_DAL.getFormPath(formID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            string filePath = dr["Form_Path"].ToString().Trim();
                            formWithPath.Add(formID, filePath);
                        }
                    }
                }
            }
            return formWithPath;
        }

        public static bool copyFile(Dictionary<string, string> fileWithPath)
        {
            if (fileWithPath.Count > 0)
            {
                foreach (string key in fileWithPath.Keys)
                {
                    string fileID = key;
                    string filePath = "E:\\科勒\\github\\SHZSZHSUPPLY\\SHZSZHSUPPLY\\files" + "\\" + fileID + ".pdf";
                    //string filePath = fileWithPath[key] + "\\" + fileID;
                    FileInfo fi = new FileInfo(filePath);//文件复制
                    int number = 0;
                    int i = 0;
                    for (i = 0; i < fileID.Length; i++)
                    {
                        if (fileID[i] > 65 && fileID[i] < 97)
                        {
                            number++;
                            if (number == 3)
                            {
                                break;
                            }
                        }
                    }
                    string substring = fileID.Substring(0, i);
                    string normalCode = "";
                    string newfileID = fileID.Replace(substring, normalCode);
                    string newNameAndPath = "E:\\科勒\\github\\SHZSZHSUPPLY\\SHZSZHSUPPLY\\Upload\\" + fileID + ".pdf";
                    string newPath = "D:\\test\\" + newfileID + ".pdf";//临时存储文件
                    fi.CopyTo(newPath, true);
                    fi = new FileInfo(newPath);
                    fi.MoveTo(newNameAndPath);//最终存储文件
                }
                return true;
            }
            else //不需要进行文件转移 不可能
            {
                return false;
            }
        }
        private static Dictionary<string, string> getOverDueFormWithPath(string tempVendorID, string factory)
        {
            string formTypeID = "";
            string newFormID = "";
            Dictionary<string, string> OverDueFormWithPath = new Dictionary<string, string>();
            DataTable table = new DataTable();
            List<string> oldForms = File_Transform_DAL.getOverDueOldFormID(tempVendorID, factory);//返回原来需要KCI的Form_ID
            if (OverDueFormWithPath.Count > 0)
            {
                foreach (string formID in oldForms)
                {
                    formTypeID = File_Transform_DAL.getFormTypeID(formID);//获取form的Type_ID
                    newFormID = File_Transform_DAL.getOverDueNewFormID(tempVendorID, formTypeID, factory);//新的FormID
                    table = File_Transform_DAL.getFormPath(formID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            string fomrPath = dr["Form_Path"].ToString().Trim();
                            OverDueFormWithPath.Add(formID, fomrPath);
                        }
                    }
                }
            }
            return OverDueFormWithPath;
        }

        /// <summary>
        /// 先获取原来过期的Form_ID 通过它查出form_Type_ID 根据form_Type_ID,Temp_Vendor_ID，Factory查出现在的formID
        /// 再查出现在的form_ID是否需要KCI
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static string checkFormOverDueKciFileSubmit(string tempVendorID, string factory)
        {
            List<string> forms = new List<string>();//新的Form_ID的集合
            List<string> oldForms = File_Transform_DAL.getOverDueOldFormID(tempVendorID, factory);//返回原来需要KCI的Form_ID
            if (oldForms.Count > 0)
            {
                foreach (string formID in oldForms)
                {
                    string formTypeID = File_Transform_DAL.getFormTypeID(formID);//获取form的Type_ID
                    string newFormID = File_Transform_DAL.getOverDueNewFormID(tempVendorID, formTypeID, factory);//新的FormID
                    forms.Add(newFormID);//添加新的formID
                }
            }
            if (forms != null && forms.Count > 0)
            {
                bool kciNeed = false;//该供应商是否存在文件需要KCI
                foreach (string formid in forms)//在As_Form_AccessFlow中查找Form_ID的kci值 
                {
                    bool isKci = false;
                    isKci = File_Transform_DAL.isFormKCI(formid);
                    if (isKci)//需要KCI审批
                    {
                        /*
                         * 检查KCI文件是否上传
                         * 
                         */
                        kciNeed = true;
                        if (File_Transform_DAL.isKciFileSubmit(formid) == false)
                        {
                            return "false";//没有上传KCI的处理结果
                        }
                    }
                }
                if (!kciNeed)//不存在任何KCI
                {
                    return "none";
                }
                return "true";
            }
            else
            {
                return "false";//没有查到文件ID  不可能
            }
        }



        /// <summary>
        /// 返回过期文件审批后的新的文件的path 不含form
        /// 通过file_ID得到file_Path
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static Dictionary<string, string> getOverDueFileWithPath(string tempVendorID, string factory)
        {
            Dictionary<string, string> OverDueFileWithPath = new Dictionary<string, string>();
            List<string> fileTypeIDs = new List<string>();
            //从As_VendorFile_OverDue中获取所有过期文件的fileTypeID
            fileTypeIDs = File_Transform_DAL.getFileTypeIDs(tempVendorID, factory);
            if (fileTypeIDs.Count > 0)
            {
                foreach (string fileTypeID in fileTypeIDs)
                {
                    //获取新的file_ID 
                    string fileID = File_Transform_DAL.getFileIDByType(tempVendorID, fileTypeID, factory);
                    string filePath = File_BLL.getFilePathByID(fileID);
                    OverDueFileWithPath.Add(fileID, filePath);
                }
            }
            return OverDueFileWithPath;
        }


        /// <summary>
        /// 过期文件的普通Form的路径
        /// 从As_VendorFile_OverDue中获取所有过期文件的fileTypeID 
        /// 根据file_Type_ID，temp_Vendor_ID,Factory_Name查出新的file_ID
        /// 查出新的form_ID的form_Path
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static Dictionary<string, string> getOverDueFileFormWithPath(string tempVendorID, string factory) 
        {
            Dictionary<string, string> OverDueFileWithPath = new Dictionary<string, string>();
            List<string> fileTypeIDs = new List<string>();
            //从As_VendorFile_OverDue中获取所有过期文件的fileTypeID
            fileTypeIDs = File_Transform_DAL.getFileTypeIDs(tempVendorID, factory);
            if (fileTypeIDs.Count > 0)
            {
                foreach (string fileTypeID in fileTypeIDs)
                {
                    //获取新的file_ID 
                    string fileID = File_Transform_DAL.getFileIDByType(tempVendorID, fileTypeID, factory);
                    if (fileID != "")
                    {
                        //获取新的form_ID
                        string formID = File_Transform_DAL.getFormIDByFileID(fileID);
                        if (formID != "")
                        {
                            //获取新的formID的form_Path
                            string formPath = File_Transform_DAL.getFormPathByFormID(formID);
                            OverDueFileWithPath.Add(formID, formPath);//添加form和formPath
                        }
                    }
                }
            }
            return OverDueFileWithPath;
        }

        /// <summary>
        /// 在As_VendorFile_OverDue中查出该供应商那些文件过期 获取对应的file_Type_ID
        /// 根据file_Type_ID，temp_Vendor_ID,Factory_Name查出新的file_ID
        /// 通过新的file_ID查出新的form_ID 判断新的form_ID是否需要kci审批
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static string checkFileOverDueKciFileSubmit(string tempVendorID, string factory)
        {
            List<string> forms = new List<string>();
            List<string> fileTypeIDs = new List<string>();
            fileTypeIDs = File_Transform_DAL.getFileTypeIDs(tempVendorID, factory);//获取所有过期文件的fileTypeID
            if (fileTypeIDs.Count > 0)
            {
                foreach (string fileTypeID in fileTypeIDs)
                {
                    //获取新的file_ID 
                    string fileID = File_Transform_DAL.getFileIDByType(tempVendorID, fileTypeID, factory);//获取新的fileID
                    //获取新的form_ID
                    if (fileID != "")
                    {
                        string formID = File_Transform_DAL.getFormIDByFileID(fileID);
                        //获取新的formID的form_Path
                        forms.Add(formID);
                    }
                }
            }
            if (forms != null && forms.Count > 0)
            {
                bool kciNeed = false;//该供应商是否存在文件需要KCI
                foreach (string formid in forms)//在As_Form_AccessFlow中查找Form_ID的kci值 
                {
                    bool isKci = false;
                    isKci = File_Transform_DAL.isFormKCI(formid);
                    if (isKci)//需要KCI审批
                    {
                        /*
                         * 检查KCI文件是否上传
                         * 
                         */
                        kciNeed = true;
                        if (File_Transform_DAL.isKciFileSubmit(formid) == false)
                        {
                            return "false";//没有上传KCI的处理结果
                        }
                    }
                }
                if (!kciNeed)//不存在任何KCI
                {
                    return "none";
                }
                return "true";
            }
            else
            {
                return "false";//没有查到文件ID  不可能
            }
        }
    }
}
