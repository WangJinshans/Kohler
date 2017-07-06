using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SelectApproveForm_BLL
    {
        public static IList<As_Approve> selectApproveForm(string sql)
        {
            return SelectApproveForm_DAL.selectApproveForm(sql);
        }
    }
}
