using DAL.VendorAssess;
using MODEL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.VendorAssess
{
    /// <summary>
    /// 由于系统中已经不存在任何除了Log外能判断该表是否存在拒绝状态 因而添加
    /// </summary>
    public class FormReject_BLL
    {
        public static int insertFormReject(As_Form_Reject form)
        {
            return FormReject_DAL.insertFormReject(form);
        }
        public static int updateRejectFormStatus(As_Form_Reject form)
        {
            return FormReject_DAL.updateRejectFormStatus(form);
        }
        public static bool isExist(As_Form_Reject form)
        {
            return FormReject_DAL.isExist(form);
        }

    }
}
