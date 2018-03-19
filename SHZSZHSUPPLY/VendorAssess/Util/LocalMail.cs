using BLL;
using BLL.VendorAssess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LocalMail
    {
        /// <summary>
        /// 给目标
        /// </summary>
        /// <param name="aimEmail"></param>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="tempVendorName"></param>
        /// <param name="formTypeName"></param>
        /// <param name="status"></param>
        /// <param name="lastTime"></param>
        /// <param name="other"></param>
        public static void flowToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other,string formID)
        {
            if (LSetting.Mail_Enabled)
            {
                Mail.flowToast(aimEmail, name, factory, tempVendorID, tempVendorName, formTypeName, status, lastTime, other, formID);
            }
        }

        /// <summary>
        /// 给申请人
        /// </summary>
        /// <param name="aimEmail"></param>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <param name="tempVendorID"></param>
        /// <param name="tempVendorName"></param>
        /// <param name="formTypeName"></param>
        /// <param name="status"></param>
        /// <param name="lastTime"></param>
        /// <param name="other"></param>
        public static void backToast(string aimEmail, string name, string factory, string tempVendorID, string tempVendorName, string formTypeName, string status, string lastTime, string other,string formID)
        {
            if (LSetting.Mail_Enabled)
            {
                Mail.backToast(aimEmail, name, factory, tempVendorID, tempVendorName, formTypeName, status, lastTime, other, formID);
            }
        }
    }
}