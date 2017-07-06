using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;


namespace BLL
{
    public class Write_BLL
    {
        public static int addWrite(As_Write write)
        {
            return Write_DAL.addWrite(write);
        }
    }
}
