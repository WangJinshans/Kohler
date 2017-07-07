﻿using DAL;
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
        public static string GetVendorName(string formID)
        {
            return AddForm_DAL.GetVendorName(formID);
        }
        public static string GetFormID(string name)
        {
            return AddForm_DAL.GetFormID(name);
        }
    }
}
