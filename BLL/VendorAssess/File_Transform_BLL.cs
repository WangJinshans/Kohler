﻿using DAL.VendorAssess;
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

            if (checkFileSubmit(tempVendorID, factory) && checkFormSubmit(tempVendorID, factory) && FormAccessSuccessFul(tempVendorID, factory))
            {
                string normalCode = "";
                insertNormalCode(normalCode);
            }
            copyFile(getFilesWithPath(tempVendorID, factory));
            copyFile(getFormsWithPath(tempVendorID, factory));
            return false;
        }
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
                foreach (string formid in forms)//单个文件的ID在As_File中查找
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
        /// 获取该供应商该厂的所有文件  不包括表
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
                        }
                    }
                }
            }
            return fileWithPath;
        }
        /// <summary>
        /// 获取该供应商该厂的所有的表
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

        public static void copyFile(Dictionary<string, string> fileWithPath)
        {
            if (fileWithPath.Count > 0)
            {
                foreach (string key in fileWithPath.Keys)
                {
                    string fileID = key;
                    string filePath = fileWithPath[key];
                    FileInfo fi = new FileInfo(filePath);//文件复制
                    string newNameAndPath = "";
                    string newPath = "";
                    fi.CopyTo(newPath, true);
                    fi = new FileInfo(newPath);
                    fi.MoveTo(newNameAndPath);
                }
            }
        }

    }
}