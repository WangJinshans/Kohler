using DAL.QualityDetection;
using MODEL.QualityDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.QualityDetection
{
    public class LabInspectionList_BLL
    {
        //委托检验单逻辑
        public static List<ConsignmentInspection> getConsignmentInspectionList(int type,string factory_Name)
        {
            return LabInspectionList_DAL.getConsignmentInspectionList(type, factory_Name);
        }

        public static int addConsignmentInspection(ConsignmentInspection inspection)
        {
            return LabInspectionList_DAL.addConsignmentInspection(inspection);
        }

        public static int updateStatus(string batch_no)
        {
            return LabInspectionList_DAL.updateStatus(batch_no);
        }
    }
}
