using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.SystemAdmin;
using BO.SystemAdmin;


namespace BLL.SystemAdmin
{
    public class SystemAdmin_BLL
    {
        public List<SystemAdmin_BO> SystemAdmin_BLL_List(string usernum)
        {
            SystemAdmin_DAL SystemAdmin_DAL = new SystemAdmin_DAL();
            return SystemAdmin_DAL.SystemAdmin_DAL_List(usernum);
        }

        public bool SystemAdmincheck(string usernum)
        {
            bool result = false;

            SystemAdmin_BLL SystemAdmin = new SystemAdmin_BLL();

            if (SystemAdmin.SystemAdmin_BLL_List(usernum).Count > 0)
           {
              result = true;
                     
           }
             else
                   {
                       result = false;
                   }

               
            

           return result;
        }
    }
}
