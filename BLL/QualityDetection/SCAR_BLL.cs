using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.QualityDetection;
using MODEL.QualityDetection;
using System.Data;

namespace BLL.QualityDetection
{
    public class SCAR_BLL
    {
        public static string getFormIDbyBatch_No(string Batch_No)
        {
            return SCAR_DAL.getFormIDbyBatch_No(Batch_No);
        }

        public static bool checkSCAR(string formID)
        {
            return SCAR_DAL.checkSCAR(formID);
        }

        public static int addSCAR(QT_SCAR qtSCAR)
        {
            return SCAR_DAL.addSCAR(qtSCAR);
        }

        public static string getSCARFormID(QT_SCAR SCAR)
        {
            return SCAR_DAL.getSCARFormID(SCAR);
        }

        public static void updateSCAR(QT_SCAR qtSCAR)
        {
            SCAR_DAL.updateSCAR(qtSCAR);
        }

        
    }
}
