using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHZSZHSUPPLY.VendorAssess.Util
{
    public class LSetting
    {
        public static bool Mail_Enabled {
            get
            {
                return Properties.Settings.Default.Mail_Enabled;
            }
        }

        public static string File_Path
        {
            get
            {
                return Properties.Settings.Default.File_UpLoad_Path;
            }
        }

        public static bool Log_Enabled
        {
            get
            {
                return Properties.Settings.Default.Log_Enabled;
            }
        }

        public static string File_Reltive_Path
        {
            get
            {
                return Properties.Settings.Default.File_Relative_Path;
            }
        }
    }
}