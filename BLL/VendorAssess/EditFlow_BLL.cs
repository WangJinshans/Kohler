using DAL.VendorAssess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL.VendorAssess;

namespace BLL.VendorAssess
{
    public class EditFlow_BLL
    {
        public static int checkFormEditFlow(string formID)
        {
            return EditFlow_DAL.checkFormEditFlow(formID);
        }

        public static As_Edit_Flow getEditFlow(string FORM_TYPE_ID)
        {
            return EditFlow_DAL.getEditFlow(FORM_TYPE_ID);
        }

        public static int addFormEditFlow(As_Form_EditFlow formEditFlow)
        {
            return EditFlow_DAL.addFormEditFlow(formEditFlow);
        }

    }
}
