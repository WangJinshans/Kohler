using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddForm_BLL
    {
        public static int addForm(As_Form form)
        {
            return AddForm_DAL.addForm(form);
        }
    }
}
