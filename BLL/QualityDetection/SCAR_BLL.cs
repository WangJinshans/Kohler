using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.QualityDetection;
using MODEL.QualityDetection;
using System.Data;

namespace BLL.QualityDetection
{
    public class SCAR_BLL
    {
        public static string getFormIDbyBatch_No(string Batch_No)
        {
            return SCAR_DAL.getFormIDbyBatch_No(Batch_No);
        }

        public static bool checkSCAR(string formID)
        {
            return SCAR_DAL.checkSCAR(formID);
        }

        public static int addSCAR(QT_SCAR qtSCAR)
        {
            return SCAR_DAL.addSCAR(qtSCAR);
        }

        /// <summary>
        /// 更新Scar的状态 以及文件路径
        /// </summary>
        /// <param name="batch_No"></param>
        /// <returns></returns>
        public static int updateScarStatus(string batch_No,string vendor_Code,string file_Path)
        {
            return SCAR_DAL.updateScarStatus(batch_No, vendor_Code, file_Path);
        }


        public static string getSCARFormID(QT_SCAR SCAR)
        {
            return SCAR_DAL.getSCARFormID(SCAR);
        }

        public static void updateSCAR(QT_SCAR qtSCAR)
        {
            SCAR_DAL.updateSCAR(qtSCAR);
        }

        /// <summary>
        /// 返回值决定哪一个不过
        /// </summary>
        /// <param name="vendor_Code"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static int isSCARQuilifited(string vendor_Code,string factory)
        {
            return SCAR_DAL.isSCARQuilifited(vendor_Code, factory);
        }


        /// <summary>
        /// 判断是否已经存在Scar
        /// </summary>
        /// <param name="batch_No"></param>
        /// <param name="vendorCode"></param>
        /// <returns></returns>
        public static bool haveSCAR(string batch_No, string vendorCode)
        {
            return SCAR_DAL.haveSCAR(batch_No, vendorCode);
        }

    }
}
