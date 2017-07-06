using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SelectForm_BLL
    {
        public static IList<As_Form> selectForm(string sql2)
        {
            return SelectForm_DAL.selectForm(sql2);
        }
    }
}
