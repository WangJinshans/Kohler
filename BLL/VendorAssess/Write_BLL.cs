using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Web;

namespace BLL
{
    public class Write_BLL
    {
        public static int addWrite(As_Write write)
        {
            return Write_DAL.addWrite(write);
        }

        public static bool writeLog(string employeeID,string formID,string manul,string manulType,string tempVendorID)
        {
            //参数完全自定义

            return false;
        }

        public static bool writeLog(string formID, string manul, string manulType, string tempVendorID)
        {
            //自动获取employee
            As_Write aw = new As_Write();
            aw.Employee_ID = HttpContext.Current.Session["Employee_ID"].ToString();
            aw.Form_ID = formID;
            aw.Form_Fill_Time = DateTime.Now.ToString();
            aw.Manul = manul;
            aw.Manul_Type = manulType;
            aw.Temp_Vendor_ID = tempVendorID;
            if (Write_DAL.addWrite(aw)>0)
            {
                return true;
            }
            return false;
        }

        public static bool writeLog(string formID, string manul, string tempVendorID)
        {
            //自动获取employee，使用常规类型

            return false;
        }
    }
}
