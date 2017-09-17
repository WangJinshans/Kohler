using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL.VendorAssess
{
    public class File_Transform_BLL
    {
        public const string CHECK_FAIL = "检查失败";
        public const string TRANSFER_FAIL = "文件复制失败";
        public const string TRANSFER_FAIL_KCI = "KCI文件复制失败";
        public const string PATH_IS_NULL = "未找到表格对应的文件，请生成文件后重试";
        public const string CODE_EXIST = "供应商正式编号已存在，不予替换";
        public const string CODE_UPDATE_FAIL = "供应商编号更新失败";
        public const string NO_KCI_EXIST = "未提交KCI的审批结果";
        public const string WAIT_FORM_SUBMIT = "请提交所有表单";
      
        public const int FILE_TYPE = 20;
        public const int FORM_TYPE = 21;
        public const int ALL_TYPE = 22;


        public static string vendorTransForm(string tempVendorID, string factory,string normalCode, string destPath,string employeeID)
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
            string resultStr = "";
            //管理那边需要供应商名称
            string vendorName = TempVendor_BLL.getTempVendorName(tempVendorID);
            if (checkFileSubmit(tempVendorID, factory) && checkFormSubmit(tempVendorID, factory))//检查文件和表提交
            {
                string result = checkKciFileSubmit(tempVendorID, factory);
                if (result == "true") //KCI文件提交 只有满足是KCI没有提交文件才会返回false
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        string rs0 = insertNormalCode(normalCode,tempVendorID);
                        if (rs0 == CODE_EXIST)
                        {
                            normalCode = TempVendor_BLL.getNormalCode(tempVendorID);
                        }

                        string rs2 = copyFile(getFormsWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs2 != "")
                        {
                            return rs2;
                        }
                        string rs1 = copyFile(getFilesWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs1 != "")
                        {
                            return rs1;
                        }
                        string rs3 = copyFile(getKciFilesWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs3 != "")
                        {
                            return rs3;
                        }
                        string type = TempVendor_BLL.getTempVendorType(tempVendorID);

                        //插入新的vendorCode
                        addNormalCode(normalCode, vendorName);
                        //添加到VendorPlantInfo中
                        if (type == "")
                        {
                            return null;
                        }
                        addVendorPlantInfo(normalCode, factory, type, "Enable");
                        return resultStr = rs0 + rs1 + rs2;
                    }
                }
                else if (result == "none")//不需要进行KCI文件的转移
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        string rs0 = insertNormalCode(normalCode,tempVendorID);
                        if (rs0 == CODE_EXIST)
                        {
                            normalCode = TempVendor_BLL.getNormalCode(tempVendorID);
                        }
                        string rs1 = copyFile(getFilesWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory, employeeID);
                        if (rs1 != "")
                        {
                            return rs1;
                        }
                        string rs2 = copyFile(getFormsWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory, employeeID);
                        if (rs2 != "")
                        {
                            return rs2;
                        }
                        return resultStr = rs0 + rs1 + rs2;
                    }
                }
                else if(result == "false")
                {
                    //没有提交KCI的审批结果
                    return CHECK_FAIL;
                }
            }
            return CHECK_FAIL;
        }
        
        /// <summary>
        /// 过期表重新审批后的文件转移
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static string vendorOverDueFormTransForm(string tempVendorID, string factory,string normalCode, string destPath,string employeeID)
        {
            /*获取所有的新的formID对应的path
             * 判断是否有需要KCI审批的 有 需要转移新的KCI审批文件
             * 
             */
            if (checkFormSubmit(tempVendorID, factory) == false)//是否所有表格都已经提交
            {
                return WAIT_FORM_SUBMIT;
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "none")//不需要KCI
            {
                if (copyFile(getOverDueFormWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory, employeeID) != "")//转移文件不成功
                {
                    return TRANSFER_FAIL;
                }
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "true")//需要转移KCI的审批文件
            {
                if (copyFile(getOverDueFormWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory, employeeID) == "" && copyFile(getOverDueKciFormWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID) == "")//转移文件成功
                {
                }
                else
                {
                    return TRANSFER_FAIL_KCI;
                }
            }
            if (checkFormOverDueKciFileSubmit(tempVendorID, factory) == "false")//没有提交KCI的审批文件
            {
                return NO_KCI_EXIST;
            }
            return "";
        }

        /// <summary>
        /// 判断转移类型
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <returns></returns>
        public static int getTransferType(string tempVendorID)
        {
            bool fileType = FileOverDue_DAL.checkVendor(tempVendorID);
            bool formType = FormOverDue_DAL.checkVendor(tempVendorID);
            if (fileType)
            {
                return FILE_TYPE;
            }
            else if (formType)
            {
                return FORM_TYPE;
            }
            else
            {
                return ALL_TYPE;
            }
        }

        /// <summary>
        /// 过期文件重新审批后的转移 转移新上传的文件 和新审批完成的表
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static string vendorOverDueFileTransForm(string tempVendorID, string factory,string normalCode, string destPath,string employeeID)
        {
            //UI信息
            string rs0 = "";
            string rs1 = "";
            string rs2 = "";
            string rs3 = "";


            //获取所有的过期的文件 查出最新的File_ID
            IList<As_Form_OverDue> OverDueFileForms = new List<As_Form_OverDue>();
            OverDueFileForms = FileOverDue_BLL.getOverDueForm(tempVendorID, factory);//获取所有与File过期的Form_ID

            if (checkFileSubmit(tempVendorID, factory) && checkFormSubmit(tempVendorID, factory))//检查文件和表提交
            {
                string result = checkFileOverDueKciFileSubmit(tempVendorID, factory);//过期文件的审批过程中是否包含KCI审批

                if (result == "true") //过期重审的文件和表 和KCI文件
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        rs0 = insertNormalCode(normalCode,tempVendorID);
                        if (rs0 == CODE_EXIST)
                        {
                            normalCode = TempVendor_BLL.getNormalCode(tempVendorID);
                        }//新的File_ID的文件
                        rs1 = copyFile(getOverDueFileWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory, employeeID);
                        if (rs1 != "")
                        {
                            return rs1;
                        }
                        //新的Form_ID的文件
                        rs2 = copyFile(getOverDueFileFormWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs2 != "")
                        {
                            return rs2;
                        }
                        //重审后KCI文件转移
                        rs3 = copyFile(getOverDueKciFileWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs3 != "")
                        {
                            return rs3;
                        }

                        return rs0 + rs1 + rs2 + rs3;
                    }
                }
                else if (result == "none")//不需要进行KCI文件的转移  过期重审的文件和表
                {
                    if (FormAccessSuccessFul(tempVendorID, factory))
                    {
                        rs0 = insertNormalCode(normalCode,tempVendorID);
                        if (rs0 == CODE_EXIST)
                        {
                            normalCode = TempVendor_BLL.getNormalCode(tempVendorID);
                        }
                        rs1 = copyFile(getOverDueFileWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode,factory,employeeID);
                        if (rs1 != "")
                        {
                            return rs1;
                        }
                        //新的Form_ID的文件
                        rs2 = copyFile(getOverDueFileFormWithPath(tempVendorID, factory),tempVendorID,destPath,normalCode, factory, employeeID);
                        if (rs2 != "")
                        {
                            return rs2;
                        }

                        return rs0 + rs1 + rs2;
                    }
                }
                else if (result == "false")
                {
                    //没有提交KCI的审批结果
                    return NO_KCI_EXIST;
                }
            }
            return CHECK_FAIL;
        }


        /// <summary>
        /// 修改版
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
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
                            string[] tempArray = new string[7];
                            foreach (DataRow dr in table.Rows)
                            {
                                tempArray[0] = dr["File_Path"].ToString().Trim();
                                tempArray[1] = "FALSE";
                                tempArray[2] = dr["File_Type_ID"].ToString();
                                tempArray[3] = "其他";
                                tempArray[4] = dr["File_Enable_Time"].ToString();
                                tempArray[5] = dr["File_Due_Time"].ToString();
                                tempArray[6] = "KCI审批结果";
                                //filePath = dr["File_Path"].ToString().Trim();
                            }
                            OverDueFileWithPath.Add(fileID, String.Join("&", tempArray));
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
            string [] tempArray = new string[7];
            if (forms != null && forms.Count > 0)
            {
                foreach (string newformID in forms)
                {
                    table = File_Transform_DAL.getFormPath(newformID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            tempArray[0] = dr["Form_Path"].ToString().Trim();
                            tempArray[1] = "FALSE";
                            tempArray[2] = dr["File_Type_ID"].ToString();
                            tempArray[3] = dr["File_Type_Range"].ToString();
                            tempArray[4] = "";//TODO::更新starttime，end time 2017年9月10日21:02:50
                            tempArray[5] = "";
                            tempArray[6] = dr["File_Type_Name"].ToString();
                            OverDueFormWithPath.Add(newformID, String.Join("&", tempArray));
                        }
                    }
                }
            }
            return OverDueFormWithPath;
        }

        private static Dictionary<string, string> getOverDueFormWithPath(string tempVendorID, string factory)
        {
            string formTypeID = "";
            string newFormID = "";
            Dictionary<string, string> OverDueFormWithPath = new Dictionary<string, string>();
            DataTable table = new DataTable();
            List<string> oldForms = File_Transform_DAL.getOverDueOldFormID(tempVendorID, factory);//返回原来需要KCI的Form_ID
            if (oldForms.Count > 0)
            {
                foreach (string formID in oldForms)
                {
                    formTypeID = File_Transform_DAL.getFormTypeID(formID);//获取form的Type_ID
                    newFormID = File_Transform_DAL.getOverDueNewFormID(tempVendorID, formTypeID, factory);//新的FormID
                    table = File_Transform_DAL.getFormPath(formID);
                    if (table.Rows.Count > 0)
                    {
                        string [] tempArray = new string[7];
                        foreach (DataRow dr in table.Rows)
                        {
                            tempArray[0] = dr["Form_Path"].ToString().Trim();
                            tempArray[1] = "FALSE";
                            tempArray[2] = dr["File_Type_ID"].ToString();
                            tempArray[3] = dr["File_Type_Range"].ToString();
                            tempArray[4] = "";//TODO::更新starttime，end time 2017年9月10日21:02:50
                            tempArray[5] = "";
                            tempArray[6] = dr["File_Type_Name"].ToString();
                            //formWithPath.Add(formID, String.Join("&", tempArray));
                            //string fomrPath = dr["Form_Path"].ToString().Trim();
                            OverDueFormWithPath.Add(formID, String.Join("&", tempArray));
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
            if (kciForms.Count > 0)
            {
                string[] tempArray = new string[7];
                foreach (string formID in kciForms)
                {
                    table = File_Transform_DAL.getKciFilePath(formID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            tempArray[0] = dr["File_Path"].ToString().Trim();
                            tempArray[1] = "FALSE";
                            tempArray[2] = dr["File_Type_ID"].ToString();
                            tempArray[3] = "其他";
                            tempArray[4] = dr["File_Enable_Time"].ToString();
                            tempArray[5] = dr["File_Due_Time"].ToString();
                            tempArray[6] = "KCI审批结果";
                            kciFileWithPath.Add(formID, String.Join("&", tempArray));
                            //return kciFileWithPath;
                        }
                    }
                }
            }
            return kciFileWithPath;
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
                string[] tempArray = new string[7];
                foreach (string fileID in fileIDlist)
                {
                    table = File_Transform_DAL.getFilePath(fileID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            //string filePath = dr["File_Path"].ToString().Trim();
                            tempArray[0] = dr["File_Path"].ToString().Trim();
                            tempArray[1] = dr["Is_Shared"].ToString();
                            tempArray[2] = dr["File_Type_ID"].ToString();
                            tempArray[3] = dr["File_Type_Range"].ToString();
                            tempArray[4] = dr["File_Enable_Time"].ToString();
                            tempArray[5] = dr["File_Due_Time"].ToString();
                            tempArray[6] = dr["File_Type_Name"].ToString();
                            fileWithPath.Add(fileID, String.Join("&",tempArray));
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
                string[] tempArray = new string[7];
                foreach (string formID in formIDlist)
                {
                    table = File_Transform_DAL.getFormPath(formID);
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            tempArray[0] = dr["Form_Path"].ToString().Trim();
                            tempArray[1] = "FALSE";
                            tempArray[2] = dr["File_Type_ID"].ToString();
                            tempArray[3] = dr["File_Type_Range"].ToString();
                            tempArray[4] = "";//TODO::更新starttime，end time 2017年9月10日21:02:50
                            tempArray[5] = "";
                            tempArray[6] = dr["File_Type_Name"].ToString();
                            formWithPath.Add(formID, String.Join("&", tempArray));
                        }
                    }
                }
            }
            return formWithPath;
        }

        /// <summary>
        /// 从As_Vendor_FileType中查出所有需要提交的文件的File_ID 
        /// 然后根据File_ID在As_File中查出是否有提交记录
        /// </summary>
        /// <param name="tempVendorID"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static bool checkFileSubmit(string tempVendorID, string factory)
        {
            /*
             * 1.从As_Vendor_FileType中获取需要提交的文件list
             * 2.单个文件在As_File中进行检查
             */
            
            List<string> files = File_Transform_DAL.getFileIDs(tempVendorID, factory);
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

        public static bool checkFormSubmit(string tempVendorID, string factory)
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

        public static bool FormAccessSuccessFul(string tempVendorID, string factory)
        {
            return File_Transform_DAL.AccessSuccessFul(tempVendorID, factory);
        }

        public static string insertNormalCode(string normalCode,string tempVendorID)
        {
            /*
             * 1.形成真正的供应商Code
             * 2.将其插入到As_Temp_Vendor中
             */
            if (TempVendor_BLL.hasNormalCode(tempVendorID))
            {
                return CODE_EXIST;
            }
            else
            {
                if (File_Transform_DAL.insertNormalCode(normalCode, tempVendorID))
                {
                    return "";
                }
                else
                {
                    return CODE_UPDATE_FAIL;
                }
            }
        }

        public static string copyFile(Dictionary<string, string> fileWithPath,string tempVendorID,string destPath,string code,string factory,string employeeID)
        {
            string type = TempVendor_BLL.getTempVendorType(tempVendorID);
            if (fileWithPath.Count > 0)
            {
                foreach (string key in fileWithPath.Keys)
                {
                    try
                    {
                        string fileID = key;

                        //0path,1shared,2typeID,3range,4start,5end,6typeName
                        string[] fileInfo = fileWithPath[key].Split('&');

                        string filePath = fileInfo[0];
                        if (filePath == "")
                        {
                            return PATH_IS_NULL;
                        }

                        FileInfo fileSource = new FileInfo(filePath);//文件复制

                        string newName = fileSource.Name.Replace(tempVendorID, code);
                        string newPath = HttpContext.Current.Server.MapPath(destPath) + newName;

                        FileInfo destFile = new FileInfo(newPath);
                        //过滤性转移，预防重复复制文件
                        if (!destFile.Exists)
                        {
                            fileSource.CopyTo(newPath, true);
                        }
                        //插入到文件上传的地方
                        if (type == "")
                        {
                            return null;
                        }
                        //预防重复插入记录
                        if (!recordExist(newName.Replace(".pdf","")))
                        {
                            string s = fileInfo[6];
                            string s1 = @"..\upload\" + newName;
                            string s2 = Convert.ToBoolean(fileInfo[1]) ? "ALL" : factory;
                            string s3 = fileInfo[3] == "全部" ? "ALL" : type;
                            string s4 = newName.Replace(".pdf", "");
                            string s5 = fileInfo[4];
                            string s6 = fileInfo[5];
                            addVendorFile(code, fileInfo[6], @"..\upload\"+newName, Convert.ToBoolean(fileInfo[1])?"ALL": factory, fileInfo[3]=="全部"?"ALL":type, "Enable", newName.Replace(".pdf", ""),fileInfo[4],fileInfo[5], DateTime.Now, employeeID);
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
                }
            }
            return "";
        }

        private static bool recordExist(string fileID)
        {
            return File_Transform_DAL.recordExist(fileID);
        }

        /// <summary>
        /// 像vendorList插入真正的供应商记录
        /// </summary>
        /// <param name="code"></param>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        public static int addNormalCode(string code,string vendorName)
        {
            string sql = "insert into venderList(Vender_Code,Vender_Name) values('" + code + "', '" + vendorName + "')";
            try
            {
                File_Transform_DAL.addNormalCode(sql);      //TODO::暂时使用try预防主键冲突，重复插入 2017年9月10日19:48:30
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }


        /// <summary>
        ///  向itemList中插入文件转移后的记录
        /// </summary>
        /// <param name="Vender_Code"></param> 供应商真正编号
        /// <param name="Item_Category"></param>供应商的具体文件
        /// <param name="Item_Path"></param>文件的路径
        /// <param name="Item_Plant"></param>工厂 或 ALL
        /// <param name="Item_VendorType"></param>供应商类型
        /// <param name="Item_State"></param>状态标志
        /// <param name="Item_Label"></param>文件名称
        /// <param name="Upload_Date"></param>
        /// <param name="Upload_Person"></param>
        /// <returns></returns>
        public static int addVendorFile(string Vender_Code, string Item_Category, string Item_Path, string Item_Plant,string Item_VendorType, string Item_State,string Item_Label,string start,string end,DateTime Upload_Date,string Upload_Person)
        {
            string sql = "insert into itemList(Vender_Code,Item_Category,Item_Path,Item_Plant,Item_VenderType,Item_State,Item_Label,Item_Startdate,Item_Enddate,Upload_Date,Upload_Person) values(@Vender_Code ,@Item_Category,@Item_Path,@Item_Plant,@Item_VenderType,@Item_State,@Item_Label,@Item_Startdate,@Item_Enddate,@Upload_Date,@Upload_Person)";
            SqlParameter[] sq = new SqlParameter[]
            {
                new SqlParameter("@Vender_Code",Vender_Code),
                new SqlParameter("@Item_Category",Item_Category),
                new SqlParameter("@Item_Path",Item_Path),
                new SqlParameter("@Item_Plant",Item_Plant),
                new SqlParameter("@Item_VenderType",Item_VendorType),
                new SqlParameter("@Item_State",Item_State),
                new SqlParameter("@Item_Label",Item_Label),
                new SqlParameter("@Item_Startdate",start),
                new SqlParameter("@Item_Enddate",end),
                new SqlParameter("@Upload_Date",DateTime.Now),
                new SqlParameter("@Upload_Person",Upload_Person)
            };
            return File_Transform_DAL.addVendorFile(sql, sq);
        }

        public static int addVendorPlantInfo(string Vender_Code, string Plant_Name, string Vendor_Type, string Vendor_State)
        {
            string sql = "insert into venderPlantInfo(Vender_Code,Plant_Name,Vender_Type,Vender_State) values(@Vender_Code ,@Plant_Name,@Vender_Type,@Vender_State)";
            SqlParameter[] sq = new SqlParameter[]
            {
                new SqlParameter("@Vender_Code",Vender_Code),
                new SqlParameter("@Plant_Name",Plant_Name),
                new SqlParameter("@Vender_Type",Vendor_Type),
                new SqlParameter("@Vender_State",Vendor_State)
            };
            try
            {
                File_Transform_DAL.addVendorPlantInfo(sql, sq);
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }
        public static List<string> getForms(string tempVendorID, string factory)
        {
            return File_Transform_DAL.getForms(tempVendorID, factory);
        }
    }
}