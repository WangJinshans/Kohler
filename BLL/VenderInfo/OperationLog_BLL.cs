using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.VenderInfo;


namespace BLL.VenderInfo
{
    public class OperationLog_BLL
    {
        public int ItemOperationLog_BLL_Insert(string itemlabel, string itemoperation, string username)
        {
            OperationLog_DAL OperationLog_DAL = new OperationLog_DAL();
            return OperationLog_DAL.ItemOperationLog_DAL_Insert(itemlabel, itemoperation, username);
        }

        public int VenderOperationLog_BLL_Insert(string vendercode, string vendertype, string plantname, string venderoperation, string username)
        {
            OperationLog_DAL OperationLog_DAL = new OperationLog_DAL();
            return OperationLog_DAL.VenderOperationLog_DAL_Insert(vendercode, vendertype, plantname, venderoperation, username);
        }
    }
}
